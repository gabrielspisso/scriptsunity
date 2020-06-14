using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public Vector3 mouseOffset;
    [Range(0,100)]
    public float radio = 100f;

    private Vector3 calculateMousePosition()
    {
        return new Vector3(Input.mousePosition.x - Screen.width/2,0,Input.mousePosition.y - Screen.height/2)* 0.025f;
    }

    private void Start()
    {
        Input.mousePosition.Set(Screen.width/2,Screen.height/2,0);
        Vector3 mouseOffsetInicial = calculateMousePosition();
        mouseOffset = mouseOffsetInicial;
        offset =  transform.position - target.position;
        print(offset);
    }

    
    private void LateUpdate()
    {
        Vector3 mousePosition = calculateMousePosition();
        if(mousePosition.magnitude < radio*radio)
            mouseOffset = mousePosition;
        else
            mouseOffset = mousePosition.normalized * radio * radio;
        transform.position = target.position + offset + mouseOffset;
        print(mousePosition);
    }

    private void Update()
    {

    }
}
