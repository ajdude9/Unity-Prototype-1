using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TrafficController : MonoBehaviour
{
    private float speed = 20;// The speed at which the car moves forward and backwards
    private float turnSpeed = 100;// The speed at which the car turns left or right
    private float horizontalInput;// A numerical value between -1 and 1, which decreases or increases based on player input ('A' or 'D' for Left and Right)
    private float verticalInput;// A numerical value between -1 and 1, which decreases or increases based on player input ('W' or 'S' for Up/Forward and Down/Backward)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //Move the vehicle forward
    {
        

        transform.Translate(Vector3.forward * Time.deltaTime * speed);// Move the car forward linearly every second, and multiply it by the speed and vertical input to allow it to only move when W or S is pressed
        //transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);// Turn the car on the Y axis, rotating its model, based on whether the player is holding Left (A) or Right (D)

       
    }
}
