using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    public Vector3 gridSize = new Vector3(5f, 0f, 5f); // Size of each grid cell
    public bool allowDiagonalPush = false; // Whether diagonal pushes are allowed

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calculate the direction of the push based on the player's movement
            Vector3 playerMovementDirection = collision.gameObject.transform.forward;

            // Round the direction to the nearest grid direction
            Vector3 pushDirection = RoundToGridDirection(playerMovementDirection);

            // Apply the push
            MoveToNextGridCell(pushDirection);
        }
    }

    Vector3 RoundToGridDirection(Vector3 direction)
    {
        Vector3 roundedDirection = Vector3.zero;

        // Round the direction to the nearest grid direction
        roundedDirection.x = Mathf.Round(direction.x);
        roundedDirection.y = Mathf.Round(direction.y);
        roundedDirection.z = Mathf.Round(direction.z);

        // Ensure only one axis is non-zero if diagonal pushes are not allowed
        if (!allowDiagonalPush)
        {
            if (Mathf.Abs(roundedDirection.x) > 0 && Mathf.Abs(roundedDirection.z) > 0)
            {
                roundedDirection.x = 0;
                roundedDirection.z = 0;
            }
        }

        return roundedDirection.normalized;
    }

    void MoveToNextGridCell(Vector3 direction)
    {
        Vector3 nextPosition = transform.position + Vector3.Scale(gridSize, direction);

        // Move the box to the next grid cell
        rb.MovePosition(nextPosition);
    }
}
