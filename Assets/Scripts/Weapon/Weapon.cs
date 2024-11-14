using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds = 1f; // Interval waktu antar tembakan diubah menjadi 1 detik

    [Header("Bullets")]
    public Bullet bulletPrefab; // Prefab Bullet yang akan ditembakkan
    [SerializeField] private Transform bulletSpawnPoint; // Titik spawn Bullet

    [Header("Bullet Pool")]
    private ObjectPool<Bullet> bulletPool; // Object Pool untuk Bullet
    private float timer; // Timer untuk interval penembakan

    private void Start()
    {
        // Setup Object Pool
        bulletPool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, false, 30, 100);
    }

    private void Update()
    {
        HandleAutomaticShooting();
    }

    // Penembakan otomatis dengan interval 1 detik
    private void HandleAutomaticShooting()
    {
        timer += Time.deltaTime;

        if (timer >= shootIntervalInSeconds)
        {
            Fire();
            timer = 0f;
        }
    }

    private void Fire()
    {
        if (bulletPrefab == null || bulletSpawnPoint == null) return;
        Bullet bullet = bulletPool.Get(); // Ambil Bullet dari Pool
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.transform.rotation = bulletSpawnPoint.rotation;
        bullet.gameObject.SetActive(true);
    }

    private Bullet CreateBullet()
    {
        Bullet newBullet = Instantiate(bulletPrefab);
        newBullet.gameObject.SetActive(false);
        return newBullet;
    }

    private void OnGetBullet(Bullet bullet)
    {
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.transform.rotation = bulletSpawnPoint.rotation;
    }

    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}
