using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FocusOnObject : MonoBehaviour
{
    //defining the camera
    public GameObject staticCamera;
    //public Vector3 initialPosition;
    //public Vector3 finalPosition;
    
    public TMP_Dropdown ChooseObjectDropdown;
 
    public GameObject ChooseAnObject;

    //defining the camera
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
    private float multiplier = 1.0f;

    public void Update()
    {
        //ChooseObjectDropdown = GetComponent<TMP_Dropdown>();
        GameObject ChooseAnObject = GameObject.Find("ChooseAnObject");

        int val = ChooseAnObject.GetComponent<TMP_Dropdown>().value;

        Vector3 topView = new Vector3(0, 0, 25);
        Vector3 zoomIn1 = new Vector3(0, 0, 3);
        Vector3 zoomIn2 = new Vector3(0, 0, 1);
        Vector3 zoomIn3 = new Vector3(0, 0, 0.5f);

        if (val == 0) //solar system
        {
            staticCamera.transform.position = topView;

        }
        else if (val == 1) //sun
        {
            // defining the scroll wheel value
            var d = Input.GetAxis("Mouse ScrollWheel");
            // As scroll wheel is varied, the multiplier value changes
            // this value affects the zoomin distance when following an object
            multiplier += d;

            //staticCamera.transform.position = new Vector3(0, 0, 3);
            GameObject Sun = GameObject.Find("Sun");
            //Vector3 sunFocus = Sun.transform.position + zoomIn1;
            // Vector3 smoothPosition = Vector3.Lerp(initialPosition, sunFocus, smoothspeed);
            //staticCamera.transform.position = smoothPosition; 
            staticCamera.transform.position = Sun.transform.position + (zoomIn1 * multiplier);

        }
        else if (val == 2) //mercury
        {
            // defining the scroll wheel value
            var d = Input.GetAxis("Mouse ScrollWheel");
            // As scroll wheel is varied, the multiplier value changes
            // this value affects the zoomin distance when following an object
            multiplier += d;

            //staticCamera.transform.position = new Vector3(6, 0, 1);
            GameObject Mercury = GameObject.Find("Mercury");
            //Vector3 mercuryFocus = Mercury.transform.position + zoomIn2;
            // Vector3 smoothPosition = Vector3.Lerp(initialPosition, mercuryFocus, smoothspeed);
            //staticCamera.transform.position = smoothPosition; 
            staticCamera.transform.position = Mercury.transform.position + (zoomIn2 * multiplier);
        }
        else if (val == 3) //venus
        {
            // defining the scroll wheel value
            var d = Input.GetAxis("Mouse ScrollWheel");
            // As scroll wheel is varied, the multiplier value changes
            // this value affects the zoomin distance when following an object
            multiplier += d;

            //staticCamera.transform.position = new Vector3(11, 0, 1);
            GameObject Venus = GameObject.Find("Venus");
            //Vector3 venusFocus = Venus.transform.position + zoomIn2;
            //Vector3 smoothPosition = Vector3.Lerp(initialPosition, venusFocus, smoothspeed);
            staticCamera.transform.position = Venus.transform.position + (zoomIn2 * multiplier);
        }
        else if (val == 4) //earth
        {
            // defining the scroll wheel value
            var d = Input.GetAxis("Mouse ScrollWheel");
            // As scroll wheel is varied, the multiplier value changes
            // this value affects the zoomin distance when following an object
            multiplier += d;

            //staticCamera.transform.position = new Vector3(15.5f, 0, 1);
            GameObject Earth = GameObject.Find("Earth");
            staticCamera.transform.position = Earth.transform.position + (zoomIn2 * multiplier);
        }
        else if (val == 5) //mars
        {
            // defining the scroll wheel value
            var d = Input.GetAxis("Mouse ScrollWheel");
            // As scroll wheel is varied, the multiplier value changes
            // this value affects the zoomin distance when following an object
            multiplier += d;

            //staticCamera.transform.position = new Vector3(22.8f, 0, 1);
            GameObject Mars = GameObject.Find("Mars");
            staticCamera.transform.position = Mars.transform.position + (zoomIn2 * multiplier);
        }
        else if (val == 6) //vesta
        {
            // defining the scroll wheel value
            var d = Input.GetAxis("Mouse ScrollWheel");
            // As scroll wheel is varied, the multiplier value changes
            // this value affects the zoomin distance when following an object
            multiplier += d;

            //staticCamera.transform.position = new Vector3(35.3f, 0, 0.5f);
            GameObject Vesta = GameObject.Find("Vesta");
            staticCamera.transform.position = Vesta.transform.position + (zoomIn3 * multiplier);
        }
        else if (val == 7) //ceres
        {
            // defining the scroll wheel value
            var d = Input.GetAxis("Mouse ScrollWheel");
            // As scroll wheel is varied, the multiplier value changes
            // this value affects the zoomin distance when following an object
            multiplier += d;

            //staticCamera.transform.position = new Vector3(42, 0, 1);
            GameObject Ceres = GameObject.Find("Ceres");
            staticCamera.transform.position = Ceres.transform.position + (zoomIn2 * multiplier);
        }
        else if (val == 8) //jupiter
        {
            // defining the scroll wheel value
            var d = Input.GetAxis("Mouse ScrollWheel");
            // As scroll wheel is varied, the multiplier value changes
            // this value affects the zoomin distance when following an object
            multiplier += d;

            //staticCamera.transform.position = new Vector3(78, 0, 1);
            GameObject Jupiter = GameObject.Find("Jupiter");
            staticCamera.transform.position = Jupiter.transform.position + (zoomIn2 * multiplier);
        }
        else if (val == 9) //saturn
        {
            // defining the scroll wheel value
            var d = Input.GetAxis("Mouse ScrollWheel");
            // As scroll wheel is varied, the multiplier value changes
            // this value affects the zoomin distance when following an object
            multiplier += d;

            //staticCamera.transform.position = new Vector3(143.5f, 0, 1);
            GameObject Saturn = GameObject.Find("Saturn");
            staticCamera.transform.position = Saturn.transform.position + (zoomIn2 * multiplier);
        }
        else if (val == 10) //uranus
        {
            // defining the scroll wheel value
            var d = Input.GetAxis("Mouse ScrollWheel");
            // As scroll wheel is varied, the multiplier value changes
            // this value affects the zoomin distance when following an object
            multiplier += d;

            //staticCamera.transform.position = new Vector3(287.2f, 0, 1);
            GameObject Uranus = GameObject.Find("Uranus");
            staticCamera.transform.position = Uranus.transform.position + (zoomIn2 * multiplier);
        }
        else if (val == 11) //neptune
        {
            // defining the scroll wheel value
            var d = Input.GetAxis("Mouse ScrollWheel");
            // As scroll wheel is varied, the multiplier value changes
            // this value affects the zoomin distance when following an object
            multiplier += d;

            //staticCamera.transform.position = new Vector3(449.5f, 0, 1);
            GameObject Neptune = GameObject.Find("Neptune");
            staticCamera.transform.position = Neptune.transform.position + (zoomIn2 * multiplier);
        }
        else if (val==12) //free view
        {
            //defining the variables needed in mouse 
            int travel = 0;
            int scrollSpeed = 3;
            var d = Input.GetAxis("Mouse ScrollWheel");

            //script that allows user to zoom in and out by scrolling the mouse

            if (d > 0f && travel > -30)
            {
                travel = travel - scrollSpeed;
                staticCamera.transform.Translate(0, 0, 1 * scrollSpeed, Space.Self);
            }
            else if (d < 0f && travel < 100)
            {
                travel = travel + scrollSpeed;
                staticCamera.transform.Translate(0, 0, -1 * scrollSpeed, Space.Self);
            }

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
                staticCamera.transform.Translate(p);
                newPosition.x = transform.position.x;
                newPosition.z = transform.position.z;
                staticCamera.transform.position = newPosition;
            }
            else
            {
                staticCamera.transform.Translate(p);
            }
        }
        else 
        {
            // defining the scroll wheel value
            var d = Input.GetAxis("Mouse ScrollWheel");
            // As scroll wheel is varied, the multiplier value changes
            // this value affects the zoomin distance when following an object
            multiplier += d;

            // General term used for following any unassigned new object
            // This will allow new generated objects to be followed
            GameObject otherObject = GameObject.Find(ChooseObjectDropdown.options[val].text);
            staticCamera.transform.position = otherObject.transform.position + (zoomIn2 * multiplier);
        }
    }

    // enables the user to move the static camera up, left, down and right using arrow keys (taken from part of the FlyCamera script)

    /// <summary>
    /// checks basic arrow key inputs and put it in a Vector. if it's 0 than it's not active.
    /// </summary>
    /// <returns>Vector of all user input from WASD</returns>
   

    private Vector3 GetBaseInput()
    {
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            p_Velocity += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            p_Velocity += new Vector3(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }

}
