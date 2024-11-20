using UnityEngine;

public class BoundaryControl : MonoBehaviour
{
    public float minX = -4.54f; // X ekseni minimum s�n�r
    public float maxX = 4.54f;  // X ekseni maksimum s�n�r
    public float minY = -3.34f; // Y ekseni minimum s�n�r
    public float minZ = 0.55f;
    public float maxZ = 20.39f;
    private void Update()
    {
        // Mevcut pozisyonu al
        Vector3 position = transform.position;

        // X ekseninde s�n�rland�r
        position.x = Mathf.Clamp(position.x, minX, maxX);

        // Y ekseninde s�n�rland�r
        position.y = Mathf.Max(position.y, minY);

        // Z ekseninde s�n�rland�r
        position.z = Mathf.Clamp(position.z, minZ, maxZ);

        // Pozisyonu g�ncelle
        transform.position = position;
    }
}
