using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test5 : MonoBehaviour
{
     void Update()
     {
         


     } 
    /*
    public GameObject ScaleScriptObject;
    public Scale scale;
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
    */

    void Awake()
    {
        // finding Scale object for sake of this example
        GameObject ScaleObject = GameObject.Find("ScaleScriptObject");

        // Specify that all of these values are the ones in the Scale script
        float timeScale = ScaleObject.GetComponent<Scale>().timeScale;
        decimal timeVariable = ScaleObject.GetComponent<Scale>().timeVariable;
        decimal timeInitial = ScaleObject.GetComponent<Scale>().timeInitial;
        decimal massInitial = ScaleObject.GetComponent<Scale>().massInitial;
        decimal massVariable = ScaleObject.GetComponent<Scale>().massVariable;
        decimal distanceInitial = ScaleObject.GetComponent<Scale>().distanceInitial;
        decimal distanceVariable = ScaleObject.GetComponent<Scale>().distanceVariable;
        decimal realG = ScaleObject.GetComponent<Scale>().realG;
        decimal rescaledG = ScaleObject.GetComponent<Scale>().rescaledG;
        // Set variable units to initial values
        timeVariable = timeInitial;
        massVariable = massInitial;
        distanceVariable = distanceInitial;
        // Calculate Gravitational Constant G in initial Unity conditions
        RescalingG(realG, timeVariable, massVariable, distanceVariable);
    }

    public void RescaleTime(float val, float timeScale, decimal timeVariable,
        decimal timeInitial, decimal massVariable, decimal distanceVariable, decimal realG, decimal rescaledG)
    {
        timeScale = val;
        timeVariable = timeInitial * (decimal)timeScale;
        // recalculate G
        RescalingG(realG, timeVariable, massVariable, distanceVariable);
        // Send a Debug Log to confirm the simulation was sped 
        Debug.Log("Simulation speed up. It is now " + timeScale + " times the Default Speed");
        Debug.Log("G in Simulated units is now" + rescaledG);
    }

    /* public void RescaleDistance(float val, float timeScale, decimal distanceScale,
        decimal distanceInitial, decimal massVariable, decimal distanceVariable, decimal realG, decimal rescaledG)
    {
        distanceScale = val;
        distanceVariable = distanceInitial * (decimal)distanceScale;
        // recalculate G
        RescalingG(realG, timeVariable, massVariable, distanceVariable);
        // Send a Debug Log to confirm the simulation has shrunk
        Debug.Log("Simulation shrunk. It is now " + (1.0f / distanceScale) + " times the Default Distance");
        Debug.Log("G in Simulated units is now" + rescaledG);
    } */
    
         

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
        decimal rescaledG = realG * (timeVariable / distanceVariable) * (timeVariable / distanceVariable) * (massVariable / distanceVariable) * (1.0e+05m / 1.0e+09m);
    }
}
