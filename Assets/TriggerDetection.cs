using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public float destroyDelay = 1f; // Yok olmadan �nce bekleme s�resi

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " hedefe ula�t�!");

        // Cismi yok etmeden �nce bir z�plama etkisi uygula
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse); // Yukar� do�ru kuvvet uygula
        }

        // Belirli bir s�re sonra yok et
        Destroy(other.gameObject, destroyDelay);
    }
}
