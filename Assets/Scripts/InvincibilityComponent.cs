using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer), typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkingCount = 7; // Jumlah blinking
    [SerializeField] private float blinkInterval = 0.1f; // Interval tiap blinking
    [SerializeField] private Material blinkMaterial; // Material untuk efek blinking
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    public bool isInvincible = false; // Status invincibility

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    // Method untuk memulai invincibility jika belum aktif
    public void TriggerInvincibility()
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    // Enumerator untuk efek blinking saat invincible
    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        for (int i = 0; i < blinkingCount; i++)
        {
            spriteRenderer.material = blinkMaterial;
            yield return new WaitForSeconds(blinkInterval);
            spriteRenderer.material = originalMaterial;
            yield return new WaitForSeconds(blinkInterval);
        }

        isInvincible = false;
    }
}
