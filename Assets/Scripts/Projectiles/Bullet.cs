using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyGameObject;
    //private Rigidbody2D rb;

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Boundary"))
        {
            Destroy(gameObject);
            PlayerMotion.hintTaken = false;
            GameStatusManager.BulletDestroyed();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(collider.gameObject);
            enemyGameObject.Remove(collider.gameObject);
            PlayerMotion.hintTaken = false;
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

    public void Launch(Vector2 velocity)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = velocity;  
    }
}
