using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah objek yang bertabrakan memiliki tag yang sama
        if (other.CompareTag(gameObject.tag)) return;

        // Cek apakah objek yang bertabrakan memiliki HitboxComponent
        HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
        if (hitbox != null)
        {
            // Cek apakah objek memiliki InvincibilityComponent
            InvincibilityComponent invincibility = other.GetComponent<InvincibilityComponent>();
            if (invincibility != null)
            {
                invincibility.TriggerInvincibility(); // Aktifkan efek invincibility
            }

            // Berikan damage sesuai dengan damage yang ditetapkan
            hitbox.Damage(damage);
        }
    }
}
