using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is attached to playerName gameobject
public class Player_Controller : MonoBehaviour
{
    //Variables for check grounded
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask grounded;
    [SerializeField] private float groundCheckRadius;
    private bool _isGrounded;

    //Variables for setting speed
    [SerializeField] private float speed = 1000f;
    [SerializeField] private float jumpspeed;
    private float _spritSpeed;
    private float _crouchSpeed;
    private float _activeSpeed;
    private float _jump;

    //Variables to get Input
    private float _lrMov;
    private float _fbMov;

    //Variables for References
    private GameControlles _controlles;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _controlles = FindObjectOfType<GameControlles>();

        _activeSpeed = speed;
        _spritSpeed = speed * 2f;
        _crouchSpeed = speed / 2f;
    }

    private void Update()
    {
        //Check weither the player is grounded or not
        GroundCheck();

        //For activating and deactivating sprint its an hold machanisam
        if (Input.GetKeyDown(_controlles.sprint)) _activeSpeed = _spritSpeed;
        if (Input.GetKeyUp(_controlles.sprint)) _activeSpeed = speed;

        //For activating and deactivating crouch its an hold machanisam 
        if (_isGrounded)
        {
            if (Input.GetKeyDown(_controlles.crouch)) Crouch();
            if (Input.GetKeyUp(_controlles.crouch)) UnCrouch();
        }

    }

    private void FixedUpdate()
    {
        //forward backward left and right movement of player
        Movement();
        //jump machanisam of the player
        if (_isGrounded) if (Input.GetKey(_controlles.jump)) Jump();
    }

    private void Movement()
    {
        _lrMov = Input.GetAxis("Horizontal") * _activeSpeed * Time.deltaTime;
        _fbMov = Input.GetAxis("Vertical") * _activeSpeed * Time.deltaTime;

        _rb.velocity = (transform.right * _lrMov) + (transform.forward * _fbMov) + (transform.up * _rb.velocity.y);
    }

    private void Jump()
    {
        _jump = jumpspeed * Time.deltaTime;
        _rb.AddForce(transform.up * _jump, ForceMode.VelocityChange);
        _isGrounded = false;
    }

    private void Crouch()
    {
        _activeSpeed = _crouchSpeed;
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void UnCrouch()
    {
        _activeSpeed = speed;
        transform.localScale = Vector3.one;
    }

    private void GroundCheck()
    {
        if (Physics.CheckSphere(groundCheckPos.position, groundCheckRadius, grounded))
        {
            _isGrounded = true;
        }
    }

    //Function for visualizing the gizmo for ground check
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheckPos.position, groundCheckRadius);
    }
}
