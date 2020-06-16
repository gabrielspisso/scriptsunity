using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public Vector3 mouseOffset;
    [Range(0, 3)]
    public float radio = 3f;

    private Vector3 calculateMousePosition()
    {
        return new Vector3(Input.mousePosition.x - Screen.width / 2, 0, Input.mousePosition.y - Screen.height / 2) * 0.050f;
    }

    private void Start()
    {
        Input.mousePosition.Set(Screen.width / 2, Screen.height / 2, 0);
        Vector3 mouseOffsetInicial = calculateMousePosition();
        mouseOffset = mouseOffsetInicial;
        offset = transform.position - target.position;
        print(offset);
    }

    [Range(0, 60)]
    public int mouseMovement = 5;
    private int framesCounter = 0;

    private void LateUpdate()
    {
        Vector3 mousePosition = calculateMousePosition();

        if (mousePosition.magnitude < radio * radio)
            mouseOffset = mousePosition;
        else
            mouseOffset = mousePosition.normalized * radio * radio;
        framesCounter = 0;

        transform.position = target.position + offset + mouseOffset;
        print(transform.position);
    }

    private void Update()
    {

    }
}
