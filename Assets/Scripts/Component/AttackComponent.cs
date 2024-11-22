using UnityEngine;

[RequireComponent(typeof(Collider2D))] // Memastikan bahwa GameObject dengan komponen ini harus memiliki Collider2D
public class AttackComponent : MonoBehaviour
{
    public Bullet bullet; // Referensi prefab Bullet untuk menembak
    public int damage; // Jumlah damage yang diberikan

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != gameObject.tag)
        {
            HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
            InvincibilityComponent invincibility = other.GetComponent<InvincibilityComponent>();

            if (invincibility != null)
            {
                invincibility.TriggerInvincibility();
            }

            if (hitbox != null)
            {
                hitbox.Damage(damage);
            }
        }
    }

}