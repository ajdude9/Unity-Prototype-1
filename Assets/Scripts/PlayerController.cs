using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{
     private float horsePower = 750;// The speed at which the car moves forward and backwards
    [SerializeField] private float turnSpeed = 100;// The speed at which the car turns left or right
    private float horizontalInput;// A numerical value between -1 and 1, which decreases or increases based on player input ('A' or 'D' for Left and Right)
    private float verticalInput;// A numerical value between -1 and 1, which decreases or increases based on player input ('W' or 'S' for Up/Forward and Down/Backward)
    private float boostInput;// A numerical value between -1 and 1, which decreases or increases based on player input ('Space' to boost)
    public Camera mainCamera;
    public Camera hoodCamera;
    private Rigidbody playerRb;
    [SerializeField] GameObject centreOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float MPH;
    [SerializeField] float RPM;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    // Start is called before the first frame update
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();  
        playerRb.centerOfMass = centreOfMass.transform.position; 
        
    }
    
    // Update is called once per frame
    void FixedUpdate() //Move the vehicle forward
    {
        if(Grounded())
        {
            PlayerMovementController();   
        }
    }
    void Update()
    {
        CameraController();
        if(Grounded())
        {
            DisplayController();
        }
    }

    void CameraController()//Controls the Camera switching
    {
        if(Input.GetKeyDown("r"))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }

    void DisplayController()
    {
        MPH = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
        speedometerText.SetText("MPH: " + MPH);
        RPM = Mathf.Round((MPH % 30)*40);
        rpmText.SetText("RPM: " + RPM);
    }

    void PlayerMovementController()//Handles player movement
    {
        horizontalInput = Input.GetAxis("Horizontal");// Bind the value of horizontalInput to the Horizontal axis, bound to A and D
        verticalInput = Input.GetAxis("Vertical");// Bind the value of verticalInput to the Vertical axis, bound to W and S
        boostInput = Input.GetAxis("Jump");//Bind the value of boostInput to the 'Jump' axis, bound to Space        

        playerRb.AddRelativeForce(Vector3.forward * verticalInput * (horsePower * 100));
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);// Turn the car on the Y axis, rotating its model, based on whether the player is holding Left (A) or Right (D)
    }

    bool Grounded()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if(wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if(wheelsOnGround >= 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
