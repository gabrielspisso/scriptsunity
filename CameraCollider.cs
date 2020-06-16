using System.Collections;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{

    public float smoothTime = 0.125F;
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void LateUpdate()
    {
        SmoothFollow();
    }

    private void SmoothFollow()
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = targetPosition;
        transform.position = Vector3.SmoothDamp(startingPos, finalPos, ref velocity, smoothTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            targetPosition = other.gameObject.transform.position;
        }
    }
}
