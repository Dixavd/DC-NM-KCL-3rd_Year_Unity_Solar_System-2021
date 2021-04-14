using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLoop : MonoBehaviour
{
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
    public decimal distanceScale = 1.0m;


    // Real value of Gravitational constant G       // [m^3 kg^-1 s^-2]
    public decimal realG = 6.6743015e-11m;
    // Gravitational Constant to be varied by Unity scale
    // Default set it to real value and units (i.1. assume unity units were 1-to-1)
    public decimal rescaledG = 6.6743015e-11m;

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

    public void Time(int val)
    {
        int i = 1;
        if(val == 0)
        {
            timeScale *= 0.5f;
            timeVariable = timeInitial * (decimal)timeScale;
            // recalculate G
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
            // Send a Debug Log to confirm the simulation has slowed down
            Debug.Log("Simulation slowed down. It is now " + timeScale + " times the Default Speed");
            Debug.Log("G in Simulated units is now" + rescaledG);
        }
        if(val == 1)
        {
            // Set variable units to initial values
            timeVariable = timeInitial;
            massVariable = massInitial;
            distanceVariable = distanceInitial;
            // Calculate Gravitational Constant G in initial Unity conditions
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
        }
        while(i < val)
        {
            timeScale *= 2;
            timeVariable = timeInitial * (decimal)timeScale;
            i++;
            
        }
        // recalculate G
        RescalingG(realG, timeVariable, massVariable, distanceVariable);
        // Send a Debug Log to confirm the simulation was sped up
        Debug.Log("Simulation speed up. It is now " + timeScale + " times the Default Speed");
        Debug.Log("G in Simulated units is now" + rescaledG);


    }
}
