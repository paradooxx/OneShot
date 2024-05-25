using System.Collections;
using UnityEngine;

public class DummyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            yield return null;
        }
    }

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
    }
}
