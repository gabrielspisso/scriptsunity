using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowRectangle : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 offset;
    [SerializeField, Range(0, 100)]
    public float widthPercent = 100f;
    [Range(0, 100)]
    public float heightPercent = 100f;

    private float widthLimit;

    private float heightLimit;

    //Calcula el largo y ancho del rectangulo segun los porcentajes de pantalla ingresados por el usuario
    private void SizeRectangleArea()
    {
        widthLimit = Screen.width / 2 * widthPercent / 100f;
        heightLimit = Screen.height / 2 * heightPercent / 100f;
    }

    private float GetMouseX()
    {
        float xPosition = Input.mousePosition.x - Screen.width / 2;
        if (Mathf.Abs(xPosition) < widthLimit)
            return xPosition;
        else
            return Mathf.Sign(xPosition) * widthLimit;
    }

    private float GetMouseY()
    {
        float yPosition = Input.mousePosition.y - Screen.height / 2;
        if (Mathf.Abs(yPosition) < heightLimit)
            return yPosition;
        else
            return Mathf.Sign(yPosition) * heightLimit;
    }

    private Vector2 GetMousePosition()
    {
        SizeRectangleArea();//Se pone aca para poder actualizar los valores si se cambian los limites en el editor
        float x = GetMouseX();
        float y = GetMouseX();
        return new Vector2(x, y);
    }

    private Vector3 Get3DMousePosition(float scaleFactor)
    {
        Vector2 mousePosition = GetMousePosition();
        return new Vector3(mousePosition.x, 0, mousePosition.y) * scaleFactor;
    }

    private void Start()
    {
        SizeRectangleArea();
        Input.mousePosition.Set(Screen.width / 2, Screen.height / 2, 0);//Mueve el puntero al medio de la pantalla
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 mouseOffset = Get3DMousePosition(0.025f);
        transform.position = target.position + offset + mouseOffset;
    }
}
