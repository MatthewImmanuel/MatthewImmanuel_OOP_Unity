using UnityEngine;

public class EnemyTargeting : Enemy
{
    public float speed = 3f; // Kecepatan Enemy
    private Transform player; // Referensi ke objek Player

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player").transform; // Asumsikan Player ada dengan tag "Player"
    }

    protected override void Update()
    {
        base.Update();
        Vector2 direction = (player.position - transform.position).normalized; // Menghitung arah menuju Player
        rb.velocity = direction * speed; // Bergerak ke arah Player

        // Jika bersentuhan dengan Player, Enemy mati
        if (Vector2.Distance(transform.position, player.position) < 0.5f)
        {
            Destroy(gameObject); // Hapus Enemy
        }
    }
}
