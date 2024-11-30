using System.Security.Cryptography.X509Certificates;
using Unity.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] points;
    public float speed = 5f;   // Speed of movement
    private int currentIndex = 0; // Index of the current target point

    void Update()
    {
        // Check if there are points defined
        if (points.Length == 0) return;

        // Move towards the current target point
        Transform targetPoint = points[currentIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // Check if we reached the target point
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            // Update to the next point
            currentIndex = (currentIndex + 1) % points.Length; // Loop back to the start
        }
    }
}
