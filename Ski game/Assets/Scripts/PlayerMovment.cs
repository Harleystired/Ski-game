using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    private InputAction move;
    [SerializeField] private float rotateSpeed = -30;
    [SerializeField] private float moveSpeed = -30;
    [SerializeField] private bool isGround = true;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Vector3 pushbackForce;
    [SerializeField] private bool disabled;
    [SerializeField] private float disableTime = 0.7f;
    private float LastDisableTime;
    private Rigidbody rb;

    private void Awake()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Obstickl.OnPlayerHit += TakeDamage;
    }

    void TakeDamage()
    {
        disabled = true;
        LastDisableTime= Time.timeSinceLevelLoad;
        rb.AddForce(pushbackForce);
        Debug.Log("OW :[");
    }
    
    void FixedUpdate()
    { 
        isGround= Physics.Linecast(transform.position, transform.position- transform.up * 2, groundLayers);
        Debug.DrawRay(transform.position, transform.up * 2, Color.red);
        if(Time.timeSinceLevelLoad > LastDisableTime + disableTime)
            disabled = false;
        if (isGround && !disabled)
        {
            Vector2 moveVector = move.ReadValue<Vector2>();
            float slopeAngle = Mathf.Abs(transform.rotation.eulerAngles.y - 180);
            float speedMultiplier = Mathf.Cos(Mathf.Deg2Rad * slopeAngle);
                    
            rb.AddForce(transform.forward * moveSpeed * speedMultiplier * Time.fixedDeltaTime);
            transform.Rotate(0, moveVector.x * rotateSpeed * Time.fixedDeltaTime, 0);
                    
                    
            //Debug.Log("move x: " + moveVector.x + " y: " + moveVector.y);
        }
        
    }
}
