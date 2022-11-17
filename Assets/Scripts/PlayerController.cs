
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //private Rigidbody rb;
    //public float constantSpeed;
    //[SerializeField]
    //private float speed = .05f;
    [SerializeField]
    private float jumpHeight = 10;
    [SerializeField]
    private float gravity = 9.81f;
    [SerializeField]
    private Vector2 moveVector;

    private CharacterController characterController;
    private Animator animator;
    private float verticalVelocity;
    [SerializeField]
    public float speed = 5.0F;

    // Start is called before the first frame update
    void Start()
    {

        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        characterController.SimpleMove(forward * speed);
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        
    }

    private void Move()
    {
        verticalVelocity += -gravity*Time.deltaTime;

        if(characterController.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -0.1f * gravity * Time.deltaTime;
        }
        Vector3 move = transform.right*moveVector.x + transform.forward*moveVector.y + transform.up*verticalVelocity;
        characterController.Move(move*speed*Time.deltaTime);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(characterController.isGrounded && context.performed)
        {
            jump();
            animator.Play("Jump");
            
        }
        //if (moveVector.magnitude > 0)
        //{
        //    animator.SetBool("IsJumping", true);
        //}
        //else
        //{
        //    animator.SetBool("IsJumping", false);
        //}
    }

    private void jump()
    {
        verticalVelocity = Mathf.Sqrt(jumpHeight * gravity);
    }
}
