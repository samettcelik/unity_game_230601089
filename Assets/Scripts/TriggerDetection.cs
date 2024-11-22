using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public float pullForce = 2f; // �ekim kuvveti
    private bool isOccupied = false; // Trigger alan�n�n dolu olup olmad���n� kontrol eder
    private GameObject currentObject; // ��erideki nesneyi saklar

    void OnTriggerEnter(Collider other)
    {
        if (!isOccupied) // E�er Trigger alan� bo�sa
        {
            isOccupied = true; // Trigger alan�n� kilitle
            currentObject = other.gameObject; // ��eri giren nesneyi sakla

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Mevcut h�z�n� s�f�rla
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // Nesneyi merkeze �ek
                Vector3 directionToCenter = (transform.position - other.transform.position).normalized;
                rb.AddForce(directionToCenter * pullForce, ForceMode.VelocityChange); // Daha yumu�ak bir �ekim
            }
        }
        else if (other.gameObject != currentObject) // E�er Trigger alan� doluysa ve farkl� bir nesne girmeye �al���yorsa
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Mevcut h�z�n� s�f�rla
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // Nesneyi geri it
                Vector3 directionAway = (other.transform.position - transform.position).normalized;
                rb.AddForce(directionAway * (pullForce * 0.5f), ForceMode.VelocityChange); // Daha yumu�ak bir itme
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
                // Platform �zerindeki nesnenin hareketini kontrol et
                rb.velocity *= 0.9f; // Yava� yava� hareketi durdur
                rb.angularVelocity *= 0.9f; // D�n�� h�z�n� azalt
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentObject) // E�er mevcut nesne Trigger alan�ndan ��karsa
        {
            isOccupied = false; // Trigger alan�n� serbest b�rak
            currentObject = null; // Mevcut nesneyi temizle
        }
    }

    void Update()
    {
        // Manuel olarak nesneyi geri almak i�in
        if (currentObject != null)
        {
            Rigidbody rb = currentObject.GetComponent<Rigidbody>();
            if (Input.GetKeyDown(KeyCode.R)) // "R" tu�una bas�larak geri alma i�lemi
            {
                Vector3 directionAway = (currentObject.transform.position - transform.position).normalized;
                rb.AddForce(directionAway * (pullForce * 3f), ForceMode.Impulse); // Geriye g��l� bir itme
                isOccupied = false; // Trigger alan�n� serbest b�rak
                currentObject = null; // Mevcut nesneyi temizle
            }
        }
    }

    // YEN� EKLENEN KODLAR
    void OnMouseOver()
    {
        // E�er fare platform �zerindeki nesneye odaklan�rsa ve t�klan�rsa
        if (Input.GetMouseButtonDown(0) && currentObject != null) // Sol fare t�klamas�
        {
            Rigidbody rb = currentObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Nesneyi geri it
                Vector3 directionAway = (currentObject.transform.position - transform.position).normalized;
                rb.AddForce(directionAway * (pullForce * 2f), ForceMode.Impulse); // Daha yumu�ak bir geri itme
                isOccupied = false; // Platform tekrar kullan�labilir hale gelir
                currentObject = null; // Mevcut nesneyi temizle
            }
        }
    }
    // YEN� EKLENEN KODLAR SONU
}