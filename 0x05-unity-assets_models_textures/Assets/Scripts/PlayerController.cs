using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public Transform cam;
    CharacterController characterController;
    public float speed = 8.0f;
    public float turnTime = 0.1f;
    public float turnSpeed;

    // variables for jumping math
    bool isJumping = false;
    float jumpVelocity;
    Vector3 currentMovement;
    public float jumpHeight = 2.0f;
    public float jumpTime = 0.5f;
    // gravity variables
    float gravity = -9.8f;
    float groundedGravity = -.05f;

    // Awake is called before Start
    void Awake()
    {
        characterController = GetComponent<CharacterController>();

        float timeToApex = jumpTime / 2;
        gravity = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
        jumpVelocity = (2 * jumpHeight) / timeToApex;
    }

    // FixedUpdate is called before any physics are applied
    void Update()
    {
        if (characterController.isGrounded && currentMovement.y < 0)
        {
            currentMovement.y = groundedGravity;
        }
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hor, 0f, ver).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeed, turnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        if (Input.GetButton("Jump") && !isJumping && characterController.isGrounded)
        {
            isJumping = true;
            currentMovement.y = jumpVelocity * 0.5f;
        } else if (!Input.GetButton("Jump") && isJumping && characterController.isGrounded)
        {
            isJumping = false;
        }

        currentMovement.y += gravity * Time.deltaTime;
        characterController.Move(currentMovement * Time.deltaTime);

        // move the character with the calculated movement * time
        if (characterController.transform.position.y <= -10f)
        {
            characterController.transform.position = new Vector3(0, 10, 0);
        }
    }
}
