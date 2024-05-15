using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float timer = 0f;
    private bool moveRight = true;

    [SerializeField] private float velocity = 2.8f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            moveRight = !moveRight;

            timer = 0f;
        }

        if (moveRight)
        {
            rb.velocity = new Vector2(velocity, 0);
        }
        else
        {
            rb.velocity = new Vector2(-velocity, 0);
        }
    }
}
