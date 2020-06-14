using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;

    public Vector3 mouseOffset;
    [Range(0,100)]
    public float radio = 100f;

    private Vector3 mousePosition()
    {
        return new Vector3(Input.mousePosition.x,0,Input.mousePosition.y)* 0.025f;
    }

    private void Start()
    {
        Vector3 mouseOffsetInicial = mousePosition();
        mouseOffset = mouseOffsetInicial;
        offset =  transform.position - target.position - mouseOffsetInicial;
        print(offset);
    }

    
    private void LateUpdate()
    {
        if(mousePosition().magnitude < radio*radio)
            mouseOffset = mousePosition();
        else
            mouseOffset = mousePosition().normalized * radio;
        transform.position = target.position + offset + mouseOffset;
    }

    private void Update()
    {

    }
}
