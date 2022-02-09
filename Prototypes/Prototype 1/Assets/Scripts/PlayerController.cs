using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Players
{
    Player1,
    Player2
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horsePower = 10;
    [SerializeField] float turnSpeed = 75.0f;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] private List<WheelCollider> allWheels;

    private Rigidbody playerRb;
    
    private float horizontalInput;
    private float verticalInput;
    
    private string horizontalInputString;
    private string verticalInputString;
    public Players player = Players.Player1;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
        
        if (player == Players.Player1)
        {
            horizontalInputString = "Horizontal_1";
            verticalInputString = "Vertical_1";
        }
        else
        {
            horizontalInputString = "Horizontal_2";
            verticalInputString = "Vertical_2";
        }
    }
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis(horizontalInputString);
        verticalInput = Input.GetAxis(verticalInputString);
        if (isOnGround())
        {
            // Moves the car foward based on vertical input
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower, ForceMode.Force);
            // Rotates the car based on horizontal input
            transform.Rotate(Vector3.up, turnSpeed *horizontalInput * Time.deltaTime);
            
            // Calculate Speed and RPM
            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f); // 2.237 for mph || 3.6 for kph
            rpm = Mathf.Round((speed % 30) * 40);
            
            // Print Speed and RPM
            speedometerText.SetText($"Speed: {speed} kph");
            rpmText.SetText($"RPM: {rpm}");
        }
    }

    bool isOnGround()
    {
        foreach (var wheel in allWheels)
        {
            if (!wheel.isGrounded)
                return false;
        }

        return true;
    }
}
