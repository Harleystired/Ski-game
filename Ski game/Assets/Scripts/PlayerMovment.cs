using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    private InputAction move;
    [SerializeField] private float rotateSpeed = -30;
    [SerializeField] private float moveSpeed = -30;
    private Rigidbody rb;

    private void Awake()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    { 
        Vector2 moveVector = move.ReadValue<Vector2>();
        float slopeAngle = Mathf.Abs(transform.rotation.eulerAngles.y - 180);
        float speedMultiplier = Mathf.Cos(Mathf.Deg2Rad * slopeAngle);
        
        rb.AddForce(transform.forward * moveSpeed * speedMultiplier * Time.fixedDeltaTime);
        transform.Rotate(0, moveVector.x * rotateSpeed * Time.fixedDeltaTime, 0);
        
        
        Debug.Log("move x: " + moveVector.x + " y: " + moveVector.y);
        
       
        
    }
}
