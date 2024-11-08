using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder; // Menyimpan referensi ke objek Weapon yang bisa diambil oleh player
    private static Weapon currentWeapon; // Menyimpan referensi ke weapon yang saat ini dimiliki oleh player (hanya ada satu weapon aktif)

    private void Awake()
    {
        // Mengecek apakah weaponHolder tidak null
        if (weaponHolder != null)
        {
            TurnVisual(false, weaponHolder); // Menyembunyikan visual dari weaponHolder saat permainan dimulai
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Mengecek apakah objek yang masuk ke trigger memiliki tag "Player"
        if (other.CompareTag("Player"))
        {
            // Jika player sudah memiliki weapon, sembunyikan weapon yang sedang dipegang
            if (currentWeapon != null)
            {
                TurnVisual(false, currentWeapon); // Menyembunyikan visual dari currentWeapon yang sedang dipegang
            }

            // Menetapkan weaponHolder sebagai anak dari objek player (untuk "mengambil" weapon)
            weaponHolder.transform.SetParent(other.transform);
            weaponHolder.transform.localPosition = Vector3.zero; // Mengatur posisi weapon agar berada tepat di posisi player

            // Menampilkan visual dari weaponHolder yang baru diambil
            TurnVisual(true, weaponHolder);
            currentWeapon = weaponHolder; // Mengatur currentWeapon sebagai weapon yang baru diambil
        }
    }

    // Method untuk menampilkan atau menyembunyikan visual dari weapon tertentu
    private void TurnVisual(bool on, Weapon weapon)
    {
        weapon.gameObject.SetActive(on); // Mengatur aktif atau tidaknya game object dari weapon
    }
}
