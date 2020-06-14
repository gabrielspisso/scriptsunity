using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowRectangle : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    public Vector3 offset;
    [SerializeField]
    private Vector3 mouseOffset;
    [SerializeField]
    [Range(0, 100)]
    public float widthPercent = 100f;
    [SerializeField]
    [Range(0, 100)]
    public float heightPercent = 100f;

    private float widthLimit;

    private float heightLimit;

    private void calculateLimits()
    {
        widthLimit = Screen.width / 2 * widthPercent / 100f;
        print(widthLimit);
        heightLimit = Screen.height / 2 * heightPercent / 100f;
        print(heightLimit);
    }

    private float GetXPositionValueLimited()
    {
        float xPosition = Input.mousePosition.x - Screen.width / 2;
        if (Mathf.Abs(xPosition) < widthLimit)
            return xPosition;
        else
            return Mathf.Sign(xPosition) * widthLimit;
    }

    private float GetYPositionValueLimited()
    {
        float yPosition = Input.mousePosition.y - Screen.height / 2;
        if (Mathf.Abs(yPosition) < heightLimit)
            return yPosition;
        else
            return Mathf.Sign(yPosition) * heightLimit;
    }

    private Vector2 GetInputValues()
    {
        calculateLimits();
        float x = GetXPositionValueLimited();
        float y = GetYPositionValueLimited();
        return new Vector2(x, y);
    }

    private void Start()
    {
        Input.mousePosition.Set(Screen.width / 2, Screen.height / 2, 0);
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector2 mousePosition = GetInputValues();
        Vector3 mouseOffset = new Vector3(mousePosition.x, 0, mousePosition.y);

        print(new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2));
        transform.position = target.position + offset + mouseOffset * 0.025f;
    }
}
