using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PushBox : MonoBehaviour
{
    public Vector3 gridSize = new Vector3(5f, 0f, 5f); // Size of each grid cell
    public bool allowDiagonalPush = false; // Whether diagonal pushes are allowed
    public LayerMask obstacleLayer; // Layer mask to specify which layers are considered obstacles
    public float moveSpeed = 5f; // Speed of the movement

    private Rigidbody rb;
    private Vector3 targetPosition;
    private bool isMoving = false;

    [SerializeField] private Collider col;
    [SerializeField] private Collider colChild;

    void Start()
    {
        //gameObject.tag = "BOX"; 
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        //colChild = GetComponentInChildren<Collider>();
        targetPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            AudioManager.Instance.SFXplay("HeavySlide");

            // Move towards the target position
            colChild.enabled = false;
            Vector3 newPosition = Vector3.MoveTowards(rb.position, targetPosition, moveSpeed * Time.deltaTime);
            rb.MovePosition(newPosition);

            // Check if reached the target position
            if (Vector3.Distance(rb.position, targetPosition) < 0.01f)
            {
                colChild.enabled = true;
                rb.MovePosition(targetPosition);
                isMoving = false;
            }

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calculate the direction of the push based on the relative position of the player to the box
            Vector3 playerRelativePosition = transform.InverseTransformPoint(collision.transform.position);

            Vector3 pushDirection = Vector3.zero;

            // Determine the direction based on the player's position relative to the box
            if (Mathf.Abs(playerRelativePosition.x) > Mathf.Abs(playerRelativePosition.z))
            {
                pushDirection = new Vector3(Mathf.Sign(playerRelativePosition.x), 0f, 0f);
            }
            else
            {
                pushDirection = new Vector3(0f, 0f, Mathf.Sign(playerRelativePosition.z));
            }

            // Invert the direction to move opposite to the player's side
            pushDirection *= -1f;

            // Round the direction to the nearest grid direction
            Vector3 roundedDirection = RoundToGridDirection(pushDirection);

            // Apply the push
            MoveToNextGridCell(roundedDirection);
        }
    }

    Vector3 RoundToGridDirection(Vector3 direction)
    {
        Vector3 roundedDirection = Vector3.zero;

        // Round the direction to the nearest grid direction
        roundedDirection.x = Mathf.Round(direction.x);
        roundedDirection.y = Mathf.Round(direction.y);
        roundedDirection.z = Mathf.Round(direction.z);

        // Ensure only one axis is non-zero
        if (!allowDiagonalPush)
        {
            if (Mathf.Abs(roundedDirection.x) > 0 && Mathf.Abs(roundedDirection.z) > 0)
            {
                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
                {
                    roundedDirection.z = 0;
                }
                else
                {
                    roundedDirection.x = 0;
                }
            }
        }

        return roundedDirection.normalized;
    }

    void MoveToNextGridCell(Vector3 direction)
    {
        if (!isMoving)
        {
            Vector3 nextPosition = transform.position + Vector3.Scale(gridSize, direction);

            // Perform a raycast to check for obstacles in the next position
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, gridSize.magnitude/2, obstacleLayer))
            {
                // If the raycast hits an obstacle, stop moving
                return;
            }

            // Move towards the next position
            targetPosition = nextPosition;
            isMoving = true;
            //gameObject.tag = "Move";
        }
    }
}
