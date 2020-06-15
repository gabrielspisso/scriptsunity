using System.Collections;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") {
            StartCoroutine("SmoothTransition", other.gameObject.transform.position);
        }
    }

    private IEnumerator SmoothTransition(Vector3 position) {
        var heading = position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        Vector3 startingPos = transform.position;
        Vector3 finalPos = position + direction;
        float elapsedTime = 0;
        float time = 0.5f;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
