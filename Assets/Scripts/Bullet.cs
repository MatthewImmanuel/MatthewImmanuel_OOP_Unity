using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20f;
    public int damage = 10;
    private Rigidbody2D rb;
    private float lifetime = 5f; // Waktu hidup maksimum peluru dalam detik
    private float lifeTimer; // Timer untuk melacak waktu hidup

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing on Bullet prefab.");
        }
    }

    private void OnEnable()
    {
        if (rb != null)
        {
            rb.velocity = transform.up * bulletSpeed;
        }
        lifeTimer = 0f; // Reset timer setiap kali Bullet diaktifkan
    }

    private void Update()
    {
        // Perbarui timer hidup
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifetime)
        {
            ReturnToPool();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Jika bertabrakan dengan objek lain, kembalikan ke pool
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
        gameObject.SetActive(false); // Nonaktifkan Bullet
    }
}
