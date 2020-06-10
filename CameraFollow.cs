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

    private void Start()
    {
        Vector3 mouseOffsetInicial = new Vector3(Input.mousePosition.x,0,Input.mousePosition.y)* 0.025f;
        mouseOffset = mouseOffsetInicial;
        offset =  transform.position - target.position - mouseOffsetInicial;
        print(offset);
    }

    private float normaTurbia()
    {
        return (Input.mousePosition.x*Input.mousePosition.x + Input.mousePosition.y*Input.mousePosition.y) * 0.025f* 0.025f;
    }

    private void LateUpdate()
    {
        if(normaTurbia() < radio*radio)
            mouseOffset = new Vector3(Input.mousePosition.x,0,Input.mousePosition.y)* 0.025f;
        transform.position = target.position + offset + mouseOffset;
    }

    private void Update()
    {

    }
}
