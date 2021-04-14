using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scale : MonoBehaviour
{

    // This is the Scaling Script for determining the Time, Distance and Rendering-Size Variables (Mass Variables were created but never varied)

    // Currently the following Keys are assigned when the Flying Camera is active

    // , Key increases speed of simulation          > for Greater Speed
    // . Key decreases speed of the simulation      < for Less Speed
    // F Key increases distances of simulation      F for Further away
    // C Key decreases distances of simulation      C for Closer together
    // R Key resets scaling of simulation           R for Reset manipualtion


    // Variables used for the scale of the simulation

    // Initial values of Scale which can be used to reset values
    // Initial Time Variable
    public decimal timeInitial = 17529.4m;          // [s]
    // Initial mass Variable
    public decimal massInitial = 1.0e+22m;          // [kg * 10^-5] shifted to keep in decimal range
    // Initial distance Variable
    public decimal distanceInitial = 1.0e+7m;       // [km]

    // Current Variables for Scaling which will be changed to alter Simulation
    // time Unit
    public decimal timeVariable = 17529.4m;         // [s]
    // mass Unit
    public decimal massVariable = 1.0e+22m;         // [kg * 10^-5] shifted to keep in decimal range
    // distance Unit
    public decimal distanceVariable = 1.0e+7m;      // [km]

    // Variable to keep track of the relative speed of the simulation 
    public float timeScale = 1.0f;
    // Variable to keep track of the relative distance multiplier of the simulation 
    public float distanceScale = 1.0f;
    // Variable to determine Render Scaling of objects (no effect on Physics)
    public float renderScale = 1.0f;

    // Variables to check for value changes
    public float currentTimeScale = 1.0f;
    public float currentDistanceScale = 1.0f;
    public float currentrenderScale = 1.0f;


    // Real value of Gravitational constant G       // [m^3 kg^-1 s^-2]
    public decimal realG = 6.6743015e-11m;
    // Gravitational Constant to be varied by Unity scale
    // Default set it to real value and units (i.1. assume unity units were 1-to-1)
    public decimal rescaledG = 6.6743015e-11m;

    // True/False value dependent on whether the Size/Render Checkbox is ticked
    public bool renderCheck = true;
    // Associated Toggle
    public Toggle proportionToggle; //called it just in case

    // Camera used when flying around without the generation UI
    public GameObject flyingCamera;

    // Awake is called first
    void Awake()
    {
        // Set variable units to initial values
        timeVariable = timeInitial;
        massVariable = massInitial;
        distanceVariable = distanceInitial;
        // Calculate Gravitational Constant G in initial Unity conditions
        RescalingG(realG, timeVariable, massVariable, distanceVariable);

        // Set initial rendering scale until the slider is moved
        renderScale = 25;

        // Find the Static Camera
        flyingCamera = GameObject.Find("FlyingCamera");
    }

    // Update is called once per frame
    void Update() 
        //Runs the calculation of g with the adjusted timeScale and distanceScale
    {
        if (timeScale != currentTimeScale) 
        {
            TimeFunction();
        }

        if (distanceScale != currentDistanceScale) 
        {
            DistanceFunction();
        }

        // Allow key-commands only if the flying camera is being used
        // Otherwise, the keys interfere with users filling in the Generation UI
        if (flyingCamera == enabled)
        {
            // If the , key is pressed during a frame, halve the speed of the simulation. I.e. < key
            if (Input.GetKeyDown(KeyCode.Comma))
            {
                timeScale *= 0.5f;
                timeVariable = timeInitial * (decimal)timeScale;
                // recalculate G
                RescalingG(realG, timeVariable, massVariable, distanceVariable);
                // Send a Debug Log to confirm the simulation has slowed down
                Debug.Log("Simulation slowed down. It is now " + timeScale + " times the Default Speed");
                Debug.Log("G in Simulated units is now" + rescaledG);
            }
            // If the . key is pressed during a frame, double the speed of the simulation. I.e. > key
            else if (Input.GetKeyDown(KeyCode.Period))
            {
                timeScale *= 2.0f;
                timeVariable = timeInitial * (decimal)timeScale;
                // recalculate G
                RescalingG(realG, timeVariable, massVariable, distanceVariable);
                // Send a Debug Log to confirm the simulation was sped up
                Debug.Log("Simulation speed up. It is now " + timeScale + " times the Default Speed");
                Debug.Log("G in Simulated units is now" + rescaledG);
            }
            // If the C key is pressed during a frame, halve the distance of the simulation. I.e. C for Closer together
            else if (Input.GetKeyDown(KeyCode.C))
            {
                distanceScale *= 2.0f;
                distanceVariable = distanceInitial * (decimal)distanceScale;
                // recalculate G
                RescalingG(realG, timeVariable, massVariable, distanceVariable);
                // Send a Debug Log to confirm the simulation has shrunk
                Debug.Log("Simulation shrunk. It is now " + (1.0f / distanceScale) + " times the Default Distance");
                Debug.Log("G in Simulated units is now" + rescaledG);
            }
            // If the F key is pressed during a frame, double the distance of the simulation. I.e. F for Further apart
            else if (Input.GetKeyDown(KeyCode.F))
            {
                distanceScale *= 0.5f;
                distanceVariable = distanceInitial * (decimal)distanceScale;
                // recalculate G
                RescalingG(realG, timeVariable, massVariable, distanceVariable);
                // Send a Debug Log to confirm the simulation was sped up
                Debug.Log("Simulation expanded. It is now " + (1.0f / distanceScale) + " times the Default Distance");
                Debug.Log("G in Simulated units is now" + rescaledG);
            }
            // If the R key is pressed during a frame, reset the distances and time of the simulation. I.e. R for Reset
            else if (Input.GetKeyDown(KeyCode.R))
            {
                distanceScale = 1.0f;
                distanceVariable = distanceInitial;
                timeScale = 1.0f;
                timeVariable = timeInitial;
                // recalculate G
                RescalingG(realG, timeVariable, massVariable, distanceVariable);
                // Send a Debug Log to confirm the simulation distances were reset
                Debug.Log("Simulation distances were reset. It is now " + (1.0f / distanceScale) + " times the Default distance");
                // Send a Debug Log to confirm the simulation was sped up
                Debug.Log("Simulation speed was reset. It is now " + timeScale + " times the Default Speed");
                Debug.Log("G in Simulated units is now" + rescaledG);
            }

            // If any other input is pressed, do nothing
            else
            {

            }

        }
    }

    // Functions to call

    //Function that takes in the value of the time slider and turns it into the timeScale for g calculation
    public void TimeRatio(float val)
    {
        if (val <= 0) 
        {
            timeScale = 0.0001f;
        }
        else if (val == 34)
        {
            timeScale = val - 33;
        }
        else if (val < 34)
        {
            timeScale = (val / 34);
        }
        else if (val > 34)
        {
            timeScale = val - 33;
        }
    }

    //Function that takes in the value of the distance slider and turns it into the distanceScale for g calculation
    public void DistanceRatio(float val)
    {
        if (val <= 0)
        {
            distanceScale = 0.0001f;
        }
        else if (val == 34)
        {
            distanceScale = val - 33;
        }
        else if (val < 34)
        {
            distanceScale = (val / 34);
        }
        else if (val > 34)
        {
            distanceScale = val - 33;
        }
    }

    //Function that takes in the value of the size slider and turns it into a value for the scaling calculation

    public void SizeRatio(float val) 
    {
        if (val <= 0)
        {
            renderScale = 1f;
        }
        else
        {
            renderScale = val;
        }
    }

    //Function that is assigned to the proportion toggle and takes in a boolean. It switches values of renderCheck between true (on) and false (off)

   public void ProportionState(bool proportionIndex)
    {
        if (proportionIndex == enabled)
        {
            renderCheck = true;
            Debug.Log("The proportion state is now in state" + renderCheck);
        }
        else if (proportionIndex != enabled)
        {
            renderCheck = false;
            Debug.Log("The proportion state is now in state" + renderCheck);
        }
    } 

    //Function that takes in adjusted timeScale to calculate the new g
    public void TimeFunction()
    {
        timeVariable = timeInitial * (decimal)timeScale;
        // recalculate G
        RescalingG(realG, timeVariable, massVariable, distanceVariable);
        // Send a Debug Log to confirm the simulation was sped up
        Debug.Log("Simulation speed up. It is now " + timeScale + " times the Default Speed");
        Debug.Log("G in Simulated units is now" + rescaledG);
        // Update variable to compare changes
        currentTimeScale = timeScale;
        
    }

    //Function that takes in adjusted distanceScale to calculate the new g
    public void DistanceFunction()
    {
        distanceVariable = distanceInitial * (decimal)distanceScale;
        // recalculate G
        RescalingG(realG, timeVariable, massVariable, distanceVariable);
        // Send a Debug Log to confirm the simulation has shrunk
        Debug.Log("Simulation shrunk. It is now " + (1.0f / distanceScale) + " times the Default Distance");
        Debug.Log("G in Simulated units is now" + rescaledG);
        // Update variable to compare changes
        currentDistanceScale = distanceScale;
    }

    // Function for calculated Gravitational Constant G in Unity simulation units
    public void RescalingG(decimal realG, decimal timeVariable, decimal massVariable, decimal distanceVariable)
    {
        // Calculate value of G in Unity scaling units
        // Not using Math Power function due to requirement of converting to floats
        // spread out calculation into multiple divisions in order to stop overflow
        // All values used are within decimal range
        // The result will also be within decimal range
        // However doing numerator and denominator calculated separately would cause an overflow during the overall calculation
        // Final fraction Numerator represents shifting of [kg * 10^-05) to [kg]
        // Final fraction Denominator represents shifting of [km] to [m] three times  
        rescaledG = realG * (timeVariable / distanceVariable) * (timeVariable / distanceVariable) * (massVariable / distanceVariable) * (1.0e+05m / 1.0e+09m);
    }

}
