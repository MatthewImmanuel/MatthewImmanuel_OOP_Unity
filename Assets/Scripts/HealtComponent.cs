using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int health;

    private void Start()
    {
        health = maxHealth; // Inisialisasi health
    }

    public int Health => health; // Getter untuk health

    public void Subtract(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject); // Hapus Entity jika health di bawah 0
        }
    }
}
