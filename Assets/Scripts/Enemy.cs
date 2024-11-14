using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int level; // Level dari Enemy
    protected Rigidbody2D rb; // Rigidbody untuk pengaturan fisika

    // Ini adalah method untuk menginisialisasi komponen
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Agar tidak terpengaruh gravitasi
    }

    // Update bisa diimplementasikan jika diperlukan
    protected virtual void Update()
    {
        // Umum untuk semua Enemy
    }
}
