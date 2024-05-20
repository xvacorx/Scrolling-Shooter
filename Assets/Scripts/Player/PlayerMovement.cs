using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float xLeftLimit;
    [SerializeField] private float xRightLimit;

    [SerializeField] private float downForce;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float groundCheckRadius = 0.25f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody rb;
    private Transform foot;
    public bool grounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        foot = transform.Find("Foot");
    }

    private void Update()
    {
        GroundCheck();
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (!grounded)
        {
            rb.AddForce(0f, -downForce, 0f);
        }

        rb.position = new(Mathf.Clamp(rb.position.x, xLeftLimit, xRightLimit), rb.position.y, 0);
    }

    private void GroundCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(foot.position, groundCheckRadius, groundLayer);
        grounded = colliders.Length > 0;
    }
}