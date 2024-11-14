using UnityEngine;

public class EnemyHorizontal : MonoBehaviour
{
    public float speed = 2f;
    private bool moveRight = true;

    private void Update()
    {
        if (moveRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x > 10f) moveRight = false;
        else if (transform.position.x < -10f) moveRight = true;
    }
}
