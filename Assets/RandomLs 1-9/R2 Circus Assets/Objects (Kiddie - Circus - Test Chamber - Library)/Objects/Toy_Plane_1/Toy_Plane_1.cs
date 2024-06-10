using UnityEngine;

public class Toy_Plane_1 : MonoBehaviour
{
    public float turnSpeed = 60.0f; // Turning speed in degrees per second

    void Update()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}
