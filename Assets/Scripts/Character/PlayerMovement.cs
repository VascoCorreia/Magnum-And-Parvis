using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public Transform cam;

    [SerializeField]
    private GameObject crosshair;
    [SerializeField]
    private PlayerData playerData;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    Vector3 velocity;
    public float gravity = -9.8f;

    public Vector3 characterSpeedVector;

    private void Awake()
    {

        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (controller.isGrounded && velocity.y < 0)
        {

            velocity.y = -2f;
            if (playerData.currentCharacter == "Magnum")
                animator.SetBool("IsGrounded", true);
        }



        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(ReturnCharacterJumpHeight() * -2f * gravity);
            if (playerData.currentCharacter == "Magnum")
                animator.SetBool("IsGrounded", false);

        }



        velocity.y += gravity * Time.deltaTime;

        if (direction.magnitude >= 0.1f)
        {
            if (playerData.currentCharacter == "Magnum")
                animator.SetBool("Moving", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * ReturnCharacterSpeed() * Time.deltaTime);
            characterSpeedVector = (moveDir.normalized * ReturnCharacterSpeed()); //for ranged enemy bullet prediction

            if (Input.GetKey("left shift"))
            {
                if (playerData.currentCharacter == "Magnum")
                    animator.SetBool("Aiming", true);
                EnableCrosshair();
                Strafing();
            }
            else
            {
                if (playerData.currentCharacter == "Magnum")
                    animator.SetBool("Aiming", false);
                DisableCrosshair();

            }
        }
        else
        {

            if (playerData.currentCharacter == "Magnum")
                animator.SetBool("Moving", false);

            if (Input.GetKey("left shift"))
            {
                if (playerData.currentCharacter == "Magnum")
                    animator.SetBool("Aiming", true);
                EnableCrosshair();
                Strafing();
            }
            else
            {
                if (playerData.currentCharacter == "Magnum")
                    animator.SetBool("Aiming", false);
                DisableCrosshair();

            }

        }

        controller.Move(velocity * Time.deltaTime);

        if (playerData.currentCharacter == "Magnum")
            animator.SetFloat("Speed", velocity.magnitude);
        if (playerData.currentCharacter == "Magnum")
            animator.SetFloat("Gravity", velocity.y);


    }

    private void Strafing()
    {
        Vector3 cameraDirection = transform.position - cam.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(cameraDirection.x, 0, cameraDirection.z), new Vector3(0, 1, 0));
    }

    private void EnableCrosshair()
    {
        crosshair.SetActive(true);
    }

    private void DisableCrosshair()
    {
        crosshair.SetActive(false);
    }

    private float ReturnCharacterSpeed()
    {
        if (playerData.currentCharacter == "Magnum")
            return playerData.magnumSpeed;
        else
            return playerData.parvisSpeed;
    }

    private float ReturnCharacterJumpHeight()
    {
        if (playerData.currentCharacter == "Magnum")
            return playerData.magnumJumpHeight;
        else
            return playerData.parvisJumpHeight;
    }
}
