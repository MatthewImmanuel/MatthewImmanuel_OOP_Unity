using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20;
    public int damage = 10;
    private Rigidbody2D rb;
    private IObjectPool<Bullet> objectPool;
    public void SetPool(IObjectPool<Bullet> pool)
    {
        objectPool = pool;
    }

    public void Initialize()
    {
        // Set velocity of bullet to move upwards
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
    // Check if the collided object has a different tag
        if (collision.gameObject.tag != gameObject.tag)
        {
            HitboxComponent hitbox = collision.GetComponent<HitboxComponent>();
            if (hitbox != null)
            {
                hitbox.Damage(damage);
                objectPool.Release(this); // Return the bullet to the pool after causing damage
            }
        }
        else
        {
            objectPool.Release(this); // Optionally return to pool if no relevant collision
        }
    }


    private void OnBecameInvisible()
    {
        // Return bullet to pool when it leaves the screen
        objectPool.Release(this);
    }
}