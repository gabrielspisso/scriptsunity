using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        // Cursor.SetCursor(cursorTexture, Input.mousePosition, cursorMode);
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.lockState = CursorLockMode.None;
        // Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        //print(Input.mousePosition);
    }
    void OnGUI()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
    }
}