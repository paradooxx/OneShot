using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float velocity = 2.8f;

    [SerializeField] private List<Vector2> movePoints;

    private Vector2 
        targetPosition,
        currentPosition,
        direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            return;
        }

        // Set Rigidbody2D to kinematic
        rb.isKinematic = true;

        if (movePoints.Count > 0)
        {
            ChooseNewTargetPosition();
        }
        else
        {
            Debug.LogWarning("No move points set!");
        }
    }

    private void ChooseNewTargetPosition()
    {
        if (movePoints.Count > 0)
        {
            targetPosition = movePoints[Random.Range(0, movePoints.Count)];
        }
    }

    void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if (movePoints.Count == 0) return;

        currentPosition = rb.position;

        if (Vector2.Distance(currentPosition, targetPosition) < 0.1f)
        {
            ChooseNewTargetPosition();
        }
        else
        {
            direction = (targetPosition - currentPosition).normalized;
            rb.velocity = direction * velocity;
        }
    }
}
