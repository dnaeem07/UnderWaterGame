﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    [SerializeField] bool lockCursor = true;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller = null;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    public Rigidbody rb;
    public float jumpSpeed = 2.0f;
    public int health = 10;
    private Vector3 movingDirection = Vector3.zero;

    public Vector3 StartPosition;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        StartPosition = this.transform.position;
    }

    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();

        //if (Input.GetButton("Jump"))
        //{
        //    movingDirection.y = jumpSpeed;
        //    //movingDirection.y -= 10 * Time.deltaTime;
        //    controller.Move(movingDirection * Time.deltaTime);
        //}

        //&& transform.position.y < -0.51f
        if (Input.GetButtonDown("Jump") )
        // (-0.5) change this value according to your character y position + 1
        {
            movingDirection.y = jumpSpeed;
        }
        else
        {
            movingDirection.y += gravity * Time.deltaTime;
        }
        controller.Move(movingDirection* Time.deltaTime);

        if (Input.GetKeyDown("c"))
        {

            controller.height = 0.5f;
            walkSpeed /= 2;
        }
        else if (Input.GetKeyUp("c"))
        {

            walkSpeed *= 2;
            controller.height = 2f;
        }
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if(controller.isGrounded)
            velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;

        float speed = walkSpeed;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed += 3;
        }
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * speed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);

    }
    public void ResetPosition()
    {
        controller.enabled = false;
        this.transform.position = StartPosition;
        controller.enabled = true;
        Manager.instance.TurnDropPlatformsOn();
    }
    private void OnTriggerEnter(Collider collision)
    {
        //if (collision.gameObject.tag == "Death")
        //{
        //    Debug.Log(collision.gameObject.name);
        //  this.transform.position = StartPosition;
        //}

        if (collision.gameObject.tag == "Trap")
        {
            Manager.instance.DecrementHealth();
        }

    }
   

}
