using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Test4 : MonoBehaviour
{
    // This is the Scaling Script for determining the Time, Distance and Mass Variables

    // Currently the following Keys are assigned

    // . Key increases speed of simulation          > for Greater Than
    // , Key decreases speed of the simulation      < for Less Than
    // F Key increases distances of simulation      F for Further Apart
    // C Key decreases distances of simulation      C for Closer Together
    // R Key resets scaling of simulation           R for Reset Simulation

    // Variables used for the scale of the simulation


    // Initial values of Scale which can be used to reset values
    // Initial Time Variable
    public decimal timeInitial = 17529.4m;          // [s]
    // Initial mass Variable
    // masses are in doubles due to the range extending further than decimal range (i.e. 1.0e+27)
    public decimal massInitial = 1.0e+22m;          // [kg * 10^-5] shifted to keep in decimal range
    // Initial distance Variable
    public decimal distanceInitial = 1.0e+7m;         // [km]

    // Current Variables for Scaling which will be changed to alter Simulation
    // time Unit
    public decimal timeVariable = 17529.4m;         // [s]
    // mass Unit
    public decimal massVariable = 1.0e+22m;         // [kg * 10^-5] shifted to keep in decimal range
    // distance Unit
    public decimal distanceVariable = 1.0e+7m;        // [km]

    // Variable to keep track of the relative speed of the simulation 
    public float timeScale = 1.0f;

    // Variable to keep track of the relative distance multiplier of the simulation 
    public float distanceScale = 1.0f;


    // Real value of Gravitational constant G       // [m^3 kg^-1 s^-2]
    public decimal realG = 6.6743015e-11m;
    // Gravitational Constant to be varied by Unity scale
    // Default set it to real value and units (i.1. assume unity units were 1-to-1)
    public decimal rescaledG = 6.6743015e-11m;

    public CameraSwitch cameraSwitch;

    // Awake is called first
    void Awake()
    {
        // Set variable units to initial values
        timeVariable = timeInitial;
        massVariable = massInitial;
        distanceVariable = distanceInitial;
        // Calculate Gravitational Constant G in initial Unity conditions
        RescalingG(realG, timeVariable, massVariable, distanceVariable);
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject flyingCamera = GameObject.Find("flyingCamera");
        CameraSwitch CameraSwitchScript = flyingCamera.GetComponent<CameraSwitch>();
        
        
       /* if (CameraSwitchScript.cameraPositionChange)
        {
            
        } */

        //Add new variable
        float oldTimeScale = 1;

        if (timeScale != oldTimeScale)
        {
            TimeFunction();
            oldTimeScale = timeScale;
        }

        //Add new variable
        float oldDistanceScale = 1;

        if (distanceScale != oldDistanceScale)
        {
            DistanceFunction();
            oldDistanceScale = distanceScale;
        }




        //DistanceFunction();
        /*
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
        // If the V key is pressed during a frame, halve the distance of the simulation. I.e. C for Closer
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
        // If the F key is pressed during a frame, double the distance of the simulation. I.e. F for Further
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

        } */
    }

    public void TimeRatio(float val)
    {
        if (val == 34)
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

    public void DistanceRatio(float val)
    {
        if(val == 34)
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

    public void TimeFunction()
    {
        timeVariable = timeInitial * (decimal)timeScale;
        // recalculate G
        RescalingG(realG, timeVariable, massVariable, distanceVariable);
        // Send a Debug Log to confirm the simulation was sped up
        Debug.Log("Simulation speed up. It is now " + timeScale + " times the Default Speed");
        Debug.Log("G in Simulated units is now" + rescaledG);
    }

    public void DistanceFunction()
    {
        distanceVariable = distanceInitial * (decimal)distanceScale;
        // recalculate G
        RescalingG(realG, timeVariable, massVariable, distanceVariable);
        // Send a Debug Log to confirm the simulation has shrunk
        Debug.Log("Simulation shrunk. It is now " + (1.0f / distanceScale) + " times the Default Distance");
        Debug.Log("G in Simulated units is now" + rescaledG);
    }

    // Functions to call

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
