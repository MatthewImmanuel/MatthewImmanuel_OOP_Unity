using UnityEngine;

public class EnemyForward : MonoBehaviour
{
    public float speed = 2f;

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -6f)
            transform.position = new Vector2(transform.position.x, 6f);
    }
}
