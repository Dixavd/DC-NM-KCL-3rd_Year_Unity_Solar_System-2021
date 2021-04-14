using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Unity Script will give keyboard controls to speeding up and slowing down the simulation

public class TimeManipulator : MonoBehaviour
{

    // Update is called once per frame
    // If the , key is pressed during a frame, halve the speed of the simulation. I.e. <
    void Update()
    { if (Input.GetKeyDown(KeyCode.Comma))
        {
            Time.timeScale = 0.5f*Time.timeScale;
            // Send a Debug Log to confirm the simulation has slowed down
            Debug.Log("Simulation slowed down. It is now " + Time.timeScale + " times the Default Speed");
        }
    // If the . key is pressed during a frame, double the speed of the simulation. I.e. >
      if (Input.GetKeyDown(KeyCode.Period))
        {
            Time.timeScale = 2.0f * Time.timeScale;
            // Send a Debug Log to confirm the simulation was sped up
            Debug.Log("Simulation speed up. It is now " + Time.timeScale + " times the Default Speed");
        }
    // If any other input is pressed, do nothing
      else
        {

        }
    }
}
