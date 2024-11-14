using UnityEngine;

public class EnemyBoss : Enemy
{
    public float speed = 2f;
    // public GameObject projectilePrefab; // Prefab peluru (tidak digunakan sementara)
    // public Transform firePoint; // Titik untuk menembak (tidak digunakan sementara)

    protected override void Start()
    {
        base.Start();
        transform.position = new Vector2(0, 5f); // Spawn di atas tengah layar
    }

    protected override void Update()
    {
        base.Update();
        // Bergerak ke arah Player
        Vector2 direction = (GameObject.FindWithTag("Player").transform.position - transform.position).normalized;
        rb.velocity = direction * speed;

        // Nonaktifkan penembakan
        // shootTimer += Time.deltaTime;
        // if (shootTimer >= shootInterval)
        // {
        //     Shoot();
        //     shootTimer = 0f;
        // }
    }

    // void Shoot()
    // {
    //     if (firePoint == null)
    //     {
    //         Debug.LogError("FirePoint is not assigned on EnemyBoss.");
    //         return;
    //     }
    //     GameObject projectile = projectilePool.Get();
    //     projectile.transform.position = firePoint.position;
    //     projectile.transform.rotation = firePoint.rotation;
    // }
}
