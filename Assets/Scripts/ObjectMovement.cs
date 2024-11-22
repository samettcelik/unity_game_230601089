using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float maxSpeed = 20f; // Maksimum hýz sýnýrý
    public float gravityMultiplier = 2f; // Yerçekimi çarpaný (2 kat artýrýlmýþ yerçekimi)

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Varsayýlan yerçekimini devre dýþý býrak
    }

    void Update()
    {
        // Klavye girdisi al
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Hareket yönü
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Kuvvet uygula
        rb.AddForce(movement * moveSpeed);

        // Maksimum hýzý kontrol et
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void FixedUpdate()
    {
        // Manuel yerçekimi uygula
        Vector3 gravity = Physics.gravity * gravityMultiplier;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
}
