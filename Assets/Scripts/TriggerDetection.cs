using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public float pullForce = 2f; // Çekim kuvveti
    private bool isOccupied = false; // Trigger alanýnýn dolu olup olmadýðýný kontrol eder
    private GameObject currentObject; // Ýçerideki nesneyi saklar

    void OnTriggerEnter(Collider other)
    {
        if (!isOccupied) // Eðer Trigger alaný boþsa
        {
            isOccupied = true; // Trigger alanýný kilitle
            currentObject = other.gameObject; // Ýçeri giren nesneyi sakla

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Mevcut hýzýný sýfýrla
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // Nesneyi merkeze çek
                Vector3 directionToCenter = (transform.position - other.transform.position).normalized;
                rb.AddForce(directionToCenter * pullForce, ForceMode.VelocityChange); // Daha yumuþak bir çekim
            }
        }
        else if (other.gameObject != currentObject) // Eðer Trigger alaný doluysa ve farklý bir nesne girmeye çalýþýyorsa
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Mevcut hýzýný sýfýrla
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // Nesneyi geri it
                Vector3 directionAway = (other.transform.position - transform.position).normalized;
                rb.AddForce(directionAway * (pullForce * 0.5f), ForceMode.VelocityChange); // Daha yumuþak bir itme
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == currentObject)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Platform üzerindeki nesnenin hareketini kontrol et
                rb.velocity *= 0.9f; // Yavaþ yavaþ hareketi durdur
                rb.angularVelocity *= 0.9f; // Dönüþ hýzýný azalt
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentObject) // Eðer mevcut nesne Trigger alanýndan çýkarsa
        {
            isOccupied = false; // Trigger alanýný serbest býrak
            currentObject = null; // Mevcut nesneyi temizle
        }
    }

    void Update()
    {
        // Manuel olarak nesneyi geri almak için
        if (currentObject != null)
        {
            Rigidbody rb = currentObject.GetComponent<Rigidbody>();
            if (Input.GetKeyDown(KeyCode.R)) // "R" tuþuna basýlarak geri alma iþlemi
            {
                Vector3 directionAway = (currentObject.transform.position - transform.position).normalized;
                rb.AddForce(directionAway * (pullForce * 3f), ForceMode.Impulse); // Geriye güçlü bir itme
                isOccupied = false; // Trigger alanýný serbest býrak
                currentObject = null; // Mevcut nesneyi temizle
            }
        }
    }

    // YENÝ EKLENEN KODLAR
    void OnMouseOver()
    {
        // Eðer fare platform üzerindeki nesneye odaklanýrsa ve týklanýrsa
        if (Input.GetMouseButtonDown(0) && currentObject != null) // Sol fare týklamasý
        {
            Rigidbody rb = currentObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Nesneyi geri it
                Vector3 directionAway = (currentObject.transform.position - transform.position).normalized;
                rb.AddForce(directionAway * (pullForce * 2f), ForceMode.Impulse); // Daha yumuþak bir geri itme
                isOccupied = false; // Platform tekrar kullanýlabilir hale gelir
                currentObject = null; // Mevcut nesneyi temizle
            }
        }
    }
    // YENÝ EKLENEN KODLAR SONU
}
