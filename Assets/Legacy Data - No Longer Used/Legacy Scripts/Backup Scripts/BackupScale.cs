// This is a Backup copy of the original Scale script
// This is prior to changing the numbers from floats to doubles and decimals


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Scale : MonoBehaviour
{
    // Variables used for the scale of the simulation


    // Initial values of Scale which can be used to reset values
    // Initial Time Variable
    public float timeInitial = 17529.4f;       // [s]
    // Initial mass Variable
    public float massInitial = 1e+27f;         // [kg]
    // Initial distance Variable
    public float distanceInitial = 1e+7f;      // [km]

    // Current Variables for Scaling which will be changed to alter Simulation
    // time Unit
    public float timeVariable = 17529.4f;       // [s]
    // mass Unit
    public float massVariable = 1e+27f;         // [kg]
    // distance Unit
    public float distanceVariable = 1e+7f;      // [km]

    // Variable to keep track of the relative speed of the simulation 
    public float timeScale = 1.0f;

    // Variable to keep track of the relative distance multiplier of the simulation 
    public float distanceScale = 1.0f;


    // Real value of Gravitational constant G   // [m^3 kg^-1 s^-2]
    public float realG = 6.6743e-11f;
    // Gravitational Constant to be varied by Unity scale
    // Default set it to real value and units (i.1. assume unity units were 1-to-1)
    public float rescaledG = 6.6743e-11f;



    // OnEnable is called when the assigned object is first initialised
    void OnEnable()
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
        // If the , key is pressed during a frame, halve the speed of the simulation. I.e. < key
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            timeScale *= 0.5f;
            timeVariable = timeInitial * timeScale;
            // recalculate G
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
            // Send a Debug Log to confirm the simulation has slowed down
            Debug.Log("Simulation slowed down. It is now " + timeScale + " times the Default Speed");
        }
        // If the . key is pressed during a frame, double the speed of the simulation. I.e. > key
        else if (Input.GetKeyDown(KeyCode.Period))
        {
            timeScale *= 2.0f;
            timeVariable = timeInitial * timeScale;
            // recalculate G
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
            // Send a Debug Log to confirm the simulation was sped up
            Debug.Log("Simulation speed up. It is now " + timeScale + " times the Default Speed");
        }
        // If the Space key is pressed during a frame, reset the speed of the simulation
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            timeScale = 1.0f;
            timeVariable = timeInitial;
            // recalculate G
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
            // Send a Debug Log to confirm the simulation was sped up
            Debug.Log("Simulation speed up. It is now " + timeScale + " times the Default Speed");
        }

        // If the V key is pressed during a frame, halve the distance of the simulation.
        else if (Input.GetKeyDown(KeyCode.V))
        {
            distanceScale *= 0.5f;
            distanceVariable = distanceInitial * distanceScale;
            // recalculate G
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
            // Send a Debug Log to confirm the simulation has shrunk
            Debug.Log("Simulation shrunk. It is now " + distanceScale + " times the Default Distance");
        }
        // If the B key is pressed during a frame, double the distance of the simulation.
        else if (Input.GetKeyDown(KeyCode.B))
        {
            distanceScale *= 2.0f;
            distanceVariable = distanceInitial * distanceScale;
            // recalculate G
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
            // Send a Debug Log to confirm the simulation was sped up
            Debug.Log("Simulation expanded. It is now " + distanceScale + " times the Default Distance");
        }
        // If the G key is pressed during a frame, reset the distances of the simulation
        else if (Input.GetKeyDown(KeyCode.G))
        {
            distanceScale = 1.0f;
            distanceVariable = distanceInitial;
            // recalculate G
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
            // Send a Debug Log to confirm the simulation distances were reset
            Debug.Log("Simulation distances were reset. It is now " + distanceScale + " times the Default distance");
        }

        // If any other input is pressed, do nothing
        else
        {

        }
    }

    // Functions to call

    // Function for calculated Gravitational Constant G in Unity simulation units
    public void RescalingG(float realG, float timeVariable, float massVariable, float distanceVariable)
    {
        // Calculate value of G in Unity scaling units
        rescaledG = realG * (Mathf.Pow(timeVariable, 2.0f) * (massVariable) / Mathf.Pow(distanceVariable * 1000.0f, 3.0f));
    }
}
*/

/*
public class Scale : MonoBehaviour
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
    public decimal timeScale = 1.0m;

    // Variable to keep track of the relative distance multiplier of the simulation 
    public decimal distanceScale = 1.0m;


    // Real value of Gravitational constant G       // [m^3 kg^-1 s^-2]
    public decimal realG = 6.6743015e-11m;
    // Gravitational Constant to be varied by Unity scale
    // Default set it to real value and units (i.1. assume unity units were 1-to-1)
    public decimal rescaledG = 6.6743015e-11m;



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
        // If the , key is pressed during a frame, halve the speed of the simulation. I.e. < key
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            timeScale *= 0.5m;
            timeVariable = timeInitial * timeScale;
            // recalculate G
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
            // Send a Debug Log to confirm the simulation has slowed down
            Debug.Log("Simulation slowed down. It is now " + timeScale + " times the Default Speed");
            Debug.Log("G in Simulated units is now" + rescaledG);
        }
        // If the . key is pressed during a frame, double the speed of the simulation. I.e. > key
        else if (Input.GetKeyDown(KeyCode.Period))
        {
            timeScale *= 2.0m;
            timeVariable = timeInitial * timeScale;
            // recalculate G
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
            // Send a Debug Log to confirm the simulation was sped up
            Debug.Log("Simulation speed up. It is now " + timeScale + " times the Default Speed");
            Debug.Log("G in Simulated units is now" + rescaledG);
        }
        // If the Space key is pressed during a frame, reset the speed of the simulation
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            timeScale = 1.0m;
            timeVariable = timeInitial;
            // recalculate G
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
            // Send a Debug Log to confirm the simulation was sped up
            Debug.Log("Simulation speed up. It is now " + timeScale + " times the Default Speed");
            Debug.Log("G in Simulated units is now" + rescaledG);
        }

        // If the V key is pressed during a frame, halve the distance of the simulation.
        else if (Input.GetKeyDown(KeyCode.V))
        {
            distanceScale *= 2.0m;
            distanceVariable = distanceInitial * distanceScale;
            // recalculate G
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
            // Send a Debug Log to confirm the simulation has shrunk
            Debug.Log("Simulation shrunk. It is now " + (1.0m / distanceScale) + " times the Default Distance");
            Debug.Log("G in Simulated units is now" + rescaledG);
        }
        // If the B key is pressed during a frame, double the distance of the simulation.
        else if (Input.GetKeyDown(KeyCode.B))
        {
            distanceScale *= 0.5m;
            distanceVariable = distanceInitial * distanceScale;
            // recalculate G
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
            // Send a Debug Log to confirm the simulation was sped up
            Debug.Log("Simulation expanded. It is now " + (1.0m / distanceScale) + " times the Default Distance");
            Debug.Log("G in Simulated units is now" + rescaledG);
        }
        // If the G key is pressed during a frame, reset the distances of the simulation
        else if (Input.GetKeyDown(KeyCode.G))
        {
            distanceScale = 1.0m;
            distanceVariable = distanceInitial;
            // recalculate G
            RescalingG(realG, timeVariable, massVariable, distanceVariable);
            // Send a Debug Log to confirm the simulation distances were reset
            Debug.Log("Simulation distances were reset. It is now " + (1.0m / distanceScale) + " times the Default distance");
            Debug.Log("G in Simulated units is now" + rescaledG);
        }

        // If any other input is pressed, do nothing
        else
        {

        }
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
*/