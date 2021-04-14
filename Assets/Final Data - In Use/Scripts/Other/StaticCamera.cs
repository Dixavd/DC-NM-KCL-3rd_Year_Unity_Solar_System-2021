using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticCamera : MonoBehaviour //A script that encompasses all the functions of the static camera
{
    
    //defining the camera
    public GameObject staticCamera;
    public Vector3 initialPosition;
    public Vector3 finalPosition;

    /// regular speed
    [Tooltip("Normal movement speed")]
    public float mainSpeed = 100.0f;

    /// <summary>
    /// Running speed. Multiplied by how long (left) shift is held. 
    /// if you dont want the extra speed, put here the same number as normal speed.
    /// </summary>
    [Tooltip("Acceleration when holding left shift")]
    public float shiftAdd = 250.0f;

    /// <summary>
    /// Maximum speed when holding left shift
    /// </summary>
    [Tooltip("Maximum speed when holding left shift")]
    public float maxShift = 1000.0f;

    private float totalRun = 1.0f;

    //defining the variables needed in mouse 

    int travel;
    int scrollSpeed = 3;

    // Update is called once per frame
    void Update()
    {
        //Keyboard commands
        Vector3 p = GetBaseInput(); //take WASD input from user

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //if LeftShift -> Running mode
            totalRun += Time.deltaTime;
            p = p * totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else
        {
            //No Shift -> normal speed
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
        }

        p = p * Time.deltaTime;
        Vector3 newPosition = transform.position;
        if (Input.GetKey(KeyCode.Space))
        {
            //If player wants to move on X and Z axis only
            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
        else
        {
            transform.Translate(p);
        }

        //script that allows user to zoom in and out by scrolling the mouse
      
        var d = Input.GetAxis("Mouse ScrollWheel");

        if (d > 0f && travel > -30)
        {
            travel = travel - scrollSpeed;
            transform.Translate(0, 0, 1 * scrollSpeed, Space.Self);
        }
        else if (d < 0f && travel < 100)
        {
            travel = travel + scrollSpeed;
            transform.Translate(0, 0, -1 * scrollSpeed, Space.Self);
        }
        

    }

    // enables the user to move the static camera up, left, down and right using W, A, S, D (taken from part of the FlyCamera script)

    /// <summary>
    /// checks basic WASD input and put it in a Vector. if it's 0 than it's not active.
    /// </summary>
    /// <returns>Vector of all user input from WASD</returns>
    private Vector3 GetBaseInput()
    {
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }

}








