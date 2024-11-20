using UnityEngine;

public class CollisionResponse : MonoBehaviour
{
    public float pushForce = 10f; // Çarpýþma kuvveti
    public float bounceMultiplier = 1.5f; // Zýplama kuvvet çarpaný
    public float speedIncreaseFactor = 1.2f; // Çarpýþma sonrasý hýz artýþý

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRb = collision.rigidbody;
        if (otherRb != null)
        {
            // Çarpýþma yönü
            Vector3 collisionDirection = collision.contacts[0].normal;

            // Ýtme kuvveti uygula
            otherRb.AddForce(-collisionDirection * pushForce, ForceMode.Impulse);

            // Zýplama ve hýzlanma etkisi
            Vector3 bounceVelocity = Vector3.Reflect(otherRb.velocity, collisionDirection) * bounceMultiplier;
            otherRb.velocity = bounceVelocity;

            // Hýz artýþý
            otherRb.velocity *= speedIncreaseFactor;
        }
    }
}
