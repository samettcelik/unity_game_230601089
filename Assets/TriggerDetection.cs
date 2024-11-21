using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public float pullForce = 10f; // Çekim kuvveti
    private bool isOccupied = false; // Trigger alanýnýn dolu olup olmadýðýný kontrol eder

    void OnTriggerEnter(Collider other)
    {
        if (!isOccupied) // Eðer Trigger alaný boþsa
        {
            isOccupied = true; // Trigger alanýný kilitle
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Nesneyi merkeze çek
                Vector3 directionToCenter = (transform.position - other.transform.position).normalized;
                rb.AddForce(directionToCenter * pullForce, ForceMode.Impulse);
            }

            // Nesneyi hemen yok et
            Destroy(other.gameObject);

            // Trigger alanýný yeniden aç
            isOccupied = false;
        }
    }
}
