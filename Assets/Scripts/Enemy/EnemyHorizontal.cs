using UnityEngine;

public class EnemyHorizontal : Enemy
{
    public float speed = 5f;
    private Vector2 direction;
    private Camera mainCamera;
    private float xMax;

    private void Start()
    {
        mainCamera = Camera.main;
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        xMax = screenBounds.x + 1;  // Menambahkan buffer agar musuh benar-benar hilang dari pandangan

        InitializeDirection();
        Respawn();
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // Periksa jika musuh melewati batas layar
        if (Mathf.Abs(transform.position.x) > xMax)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        float yPos = Random.Range(-mainCamera.orthographicSize, mainCamera.orthographicSize);

        // Tentukan sisi yang berlawanan dari arah saat ini
        if (direction == Vector2.right)
        {
            transform.position = new Vector2(-xMax, yPos);
        }
        else
        {
            transform.position = new Vector2(xMax, yPos);
        }

        direction = -direction; // Balik arah
    }

    private void InitializeDirection()
    {
        direction = Random.value > 0.5f ? Vector2.right : Vector2.left;
    }
}