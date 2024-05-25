using System.Collections;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera mainCamera;
    private Transform playerTransform;
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private float 
                speed = 5f,
                bulletForce = 10f,
                nextTimeToShoot = -1f,
                bulletFireRate = 4f;        

    [SerializeField] private Transform shootPoint;

    [SerializeField] private Projection projection;

    [SerializeField] private Bullet projectBulletPrefab;
    
    private bool isShot = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
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
                if(bullet != null)
                {
                    bullet.transform.parent = null;
                }
            }
        }
        projection.SimulateTrajectory(projectBulletPrefab, shootPoint.position, GetVelocity());
    }

    private void Update()
    {
        
        
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

    private Vector2 GetVelocity()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - playerTransform.position;
        direction.Normalize();

        return direction * bulletForce;
    }

    private IEnumerator Shoot()
    {
        bullet.SetActive(true);

        yield return new WaitForSeconds(0f);

        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - playerTransform.position;
        direction.Normalize();

        Rigidbody2D bulletRb = bullet?.GetComponent<Rigidbody2D>();

        bulletRb.velocity = direction * bulletForce;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        isShot = true;
    }

    private void ReparentToPlayer()
    {
        bullet.transform.parent = playerTransform;
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            collider.gameObject.SetActive(false);
            collider.gameObject.transform.position = shootPoint.position;
            ReparentToPlayer();
            isShot = false;
        }
    }
}