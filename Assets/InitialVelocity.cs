using UnityEngine;

public class InitialVelocity : MonoBehaviour
{
    public float forceMagnitude = 10f; // At�� kuvveti
    public float throwAngle = 15f; // At�� a��s� (derece)

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // A�� ve y�n
            float angleInRadians = throwAngle * Mathf.Deg2Rad;
            Vector3 forceDirection = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0);

            // Kuvvet uygula
            rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        }
    }
}
