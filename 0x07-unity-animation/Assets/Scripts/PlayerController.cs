using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Transform cam;
    CharacterController characterController;
    public float speed = 8.0f;
    public float turnTime = 0.1f;
    public float turnSpeed;
    bool canMove = true;
    bool isFalling = false;

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

    void Start()
    {
        Time.timeScale = 1;
        CameraController.turnSpeed = 1;
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
    }

    // FixedUpdate is called before any physics are applied
    void Update()
    {
        // Checks for 
        if (characterController.isGrounded && currentMovement.y < 0)
        {
            currentMovement.y = groundedGravity;
            anim.SetBool("isFalling", false);
        }
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hor, 0f, ver).normalized;

        if (canMove)
        {
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeed, turnTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                characterController.Move(moveDir.normalized * speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            } else
            {
                anim.SetBool("isRunning", false);
            }
            if (Input.GetButton("Jump") && !isJumping && characterController.isGrounded)
            {
                isJumping = true;
                anim.SetTrigger("isJumping");
                currentMovement.y = jumpVelocity * 0.5f;
            } else if (isJumping && characterController.isGrounded)
            {
                isJumping = false;
                anim.SetTrigger("backToIdle");
            }
        }

        currentMovement.y += gravity * Time.deltaTime;
        characterController.Move(currentMovement * Time.deltaTime);

        // move the character back to the start if they fall
        if (characterController.transform.position.y <= -9f)
        {
            anim.SetBool("isFalling", true);
            if (characterController.transform.position.y <= -20f)
            {
                characterController.transform.position = new Vector3(0, 30, 0);
                canMove = false;
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Happy Idle") && !isFalling && !canMove)
            canMove = true;
    }
}
