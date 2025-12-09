
using UnityEngine;

public class GuardRandomRotation : MonoBehaviour
{
    public float rotationInterval = 3f; // Time interval between rotations
    public float rotationSpeed = 5f; // Speed of rotation

    private float timer;

    void Start()
    {
        timer = rotationInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            RotateToRandomDirection();
            timer = rotationInterval;
        }
    }

    void RotateToRandomDirection()
    {
        // Generate a random rotation angle
        float randomYRotation = Random.Range(0f, 360f);

        // Set the new rotation
        Quaternion targetRotation = Quaternion.Euler(0, randomYRotation, 0);
        StartCoroutine(RotateOverTime(targetRotation));
    }

    System.Collections.IEnumerator RotateOverTime(Quaternion targetRotation)
    {
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            yield return null;
        }
    }
}