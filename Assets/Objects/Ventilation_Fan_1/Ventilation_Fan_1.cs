using UnityEngine;

public class Ventilation_Fan_1 : MonoBehaviour
{
    public float turnSpeed = 60.0f; // Turning speed in degrees per second

    void Update()
    {
        // Rotate the object around its own Z-axis with constant speed
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
    }
}
