using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] float speed = 2f;          // Kecepatan Portal Asteroid Bergerak
    [SerializeField] float rotateSpeed = 50f;    // Kecepatan Portal Asteroid Berputar

    private Vector2 newPosition;
    private bool isActive; // Menandakan apakah portal aktif atau tidak

    void Start()
    {
        ChangePosition();  // Inisialisasi nilai newPosition
        isActive = false;  // Portal tidak aktif saat dimulai
    }

    void Update()
    {
        // Jika portal aktif, gerakkan dan rotasikan portal
        if (isActive)
        {
            MovePortal();
        }
    }

    void MovePortal()
    {
        // Gerakan Portal Asteroid
        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);

        // Cek jarak antara posisi asteroid saat ini dengan posisi newPosition
        if (Vector2.Distance(transform.position, newPosition) < 0.5f)
        {
            ChangePosition();  // Buat posisi baru jika sudah dekat
            Debug.Log("Portal moved to new position: " + newPosition); // Debug untuk melihat posisi baru
        }

        // Rotasi portal
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        Debug.Log("Portal is active and rotating."); // Debug untuk memastikan portal aktif
    }

    void ChangePosition()
    {
        // Menghasilkan posisi baru secara acak dalam batas tertentu
        newPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
    }

    // Metode ini bisa dipanggil dari skrip pemain untuk mengaktifkan portal
    public void ActivatePortal()
    {
        isActive = true; // Mengatur portal menjadi aktif
        Debug.Log("Portal activated."); // Debug untuk melihat ketika portal diaktifkan
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Jika asteroid mengenai Player, maka LoadScene Main
            SceneManager.LoadScene("Main");
        }
    }
}
