using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    private Rigidbody rb;

    public float speed = 12f;

    public Vector3 moveInput;

    public Vector3 moveVelocity;

    private Camera mainCamera;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) * speed * Time.deltaTime;

        controller.Move(move);

        print(Globales.move);
        Globales.move = move;
        print(Globales.move);

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayHitOnPlane;

        if (groundPlane.Raycast(cameraRay, out rayHitOnPlane))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayHitOnPlane);

            Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }
}
