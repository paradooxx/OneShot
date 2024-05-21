using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyGameObject;

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

        if(collision.gameObject.layer == LayerMask.NameToLayer("Boundary"))
        {
            Destroy(gameObject);
            GameStatusManager.BulletDestroyed();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(collider.gameObject);
            enemyGameObject.Remove(collider.gameObject);
            GameWin();
        }
    }

    private void GameWin()
    {
        if(enemyGameObject.Count == 0)
        {
            GameStatusManager.EnemyDestroyed();
            gameObject.SetActive(false);
        }
    }
}
