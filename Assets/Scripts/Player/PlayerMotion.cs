using System.Collections;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera mainCamera;
    private Transform playerTransform;
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float bulletForce = 10f;

    private float nextTimeToShoot = -1f;
    private float bulletFireRate = 4f;  

    private Vector2 bulletStartPosition;

    private bool isShot = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        bulletStartPosition = bullet.transform.position;
        playerTransform = transform;
    }

    private void FixedUpdate() 
    {
        HorizontalMovement();
        RotateOnMouseDirection();

        if (Time.time > nextTimeToShoot)
        {
            nextTimeToShoot = Time.time + 1 / bulletFireRate;
            if(Input.GetKey(KeyCode.Mouse0) && !isShot)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    private void HorizontalMovement()
    {
        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y);
        }
    }

    private void RotateOnMouseDirection()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = playerTransform.position.z;

        Vector3 direction = mousePosition - playerTransform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        playerTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    private IEnumerator Shoot()
    {
        bullet.SetActive(true);

        yield return new WaitForSeconds(0f);

        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - playerTransform.position;
        direction.Normalize();

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        bulletRb.velocity = direction * bulletForce;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        Debug.Log("Shootot");
        isShot = true;
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            collider.gameObject.SetActive(false);
            collider.gameObject.transform.position = bulletStartPosition;
            isShot = false;
        }
    }
}
