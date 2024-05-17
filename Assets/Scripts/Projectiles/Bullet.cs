using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Repeller"))
        {
            Vector2 repelDirection = ((Vector2)transform.position - (Vector2)collision.contacts[0].point).normalized;

            GetComponent<Rigidbody2D>().velocity = repelDirection * 10f;

            float angle = Mathf.Atan2(repelDirection.y, repelDirection.x) * Mathf.Rad2Deg;
            Debug.Log("Angle " + repelDirection);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
            GameStatusManager.EnemyDestroyed();
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Boundary"))
        {
            Destroy(gameObject);
            GameStatusManager.BulletDestroyed();
        }
    }
}
