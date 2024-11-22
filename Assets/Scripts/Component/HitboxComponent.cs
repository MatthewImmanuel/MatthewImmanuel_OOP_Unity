using UnityEngine;

[RequireComponent(typeof(Collider2D))] // Memastikan bahwa GameObject dengan komponen ini harus memiliki Collider2D
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent healthComponent;
    private InvincibilityComponent invincibilityComponent;
    

    void Awake()
    {
        invincibilityComponent = GetComponent<InvincibilityComponent>();
        healthComponent = GetComponent<HealthComponent>();
        // Cek apakah healthComponent sudah diatur di inspector, jika tidak, coba temukan komponen pada objek yang sama
        if (healthComponent == null)
        {
            Debug.LogError("HealthComponent is required but not found on the GameObject", this);
        }
        
        // Jika InvincibilityComponent tidak ditemukan, log kesalahan
        if (invincibilityComponent == null)
        {
            Debug.LogError("InvincibilityComponent is required but not found on the GameObject", this);
        }
    }

    // Method Damage yang menerima integer
    public void Damage(int damageAmount)
    {
        if (healthComponent != null)
        {
            healthComponent.Subtract(damageAmount); // Mengurangi healthpoint dengan nilai integer yang diberikan
            invincibilityComponent.TriggerInvincibility();

        }
        else
        {
            Debug.LogError("HealthComponent is not assigned", this);
        }
    }
}