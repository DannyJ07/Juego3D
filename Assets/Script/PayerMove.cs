using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PayerMove : MonoBehaviour
{
    public float runnSpeed = 7;
    public float rotationSpeed = 250;
    public Animator animator;

    public Rigidbody rb;
    public float jumpHeight = 3;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    bool isGrounded;
    bool isFalling;

    private float x, y;

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runnSpeed);

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded)
        {
            if (Input.GetKey("space"))
            {
                animator.Play("Jump");
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }

            isFalling = false;
        }
        else
        {
            if (!isFalling)
            {
                animator.Play("Falling Down");
                isFalling = true;
            }
        }
    }
}

