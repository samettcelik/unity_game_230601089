using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public float destroyDelay = 1f; // Yok olmadan önce bekleme süresi

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " hedefe ulaþtý!");

        // Cismi yok etmeden önce bir zýplama etkisi uygula
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse); // Yukarý doðru kuvvet uygula
        }

        // Belirli bir süre sonra yok et
        Destroy(other.gameObject, destroyDelay);
    }
}
