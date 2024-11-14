using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent healthComponent;

    public void Damage(int amount)
    {
        InvincibilityComponent invincibility = GetComponent<InvincibilityComponent>();

        // Jika Entity tidak dalam keadaan invincible, kurangi health
        if (invincibility == null || !invincibility.isInvincible)
        {
            healthComponent.Subtract(amount);
        }
    }
}
