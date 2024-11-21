using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public float pullForce = 10f; // �ekim kuvveti
    private bool isOccupied = false; // Trigger alan�n�n dolu olup olmad���n� kontrol eder

    void OnTriggerEnter(Collider other)
    {
        if (!isOccupied) // E�er Trigger alan� bo�sa
        {
            isOccupied = true; // Trigger alan�n� kilitle
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Nesneyi merkeze �ek
                Vector3 directionToCenter = (transform.position - other.transform.position).normalized;
                rb.AddForce(directionToCenter * pullForce, ForceMode.Impulse);
            }

            // Nesneyi hemen yok et
            Destroy(other.gameObject);

            // Trigger alan�n� yeniden a�
            isOccupied = false;
        }
    }
}
