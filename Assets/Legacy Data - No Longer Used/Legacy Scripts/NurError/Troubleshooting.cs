using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troubleshooting : MonoBehaviour
{
    
    // EXAMPLE CODE BELOW

    // try specifing all of the variables
    /*
    public void RescaleTime(float val,
        float timeScale, decimal timeVariable,
        decimal timeInitial, decimal massVariable, decimal distanceVariable, decimal realG, decimal rescaledG)
    {
        timeScale = val;
        timeVariable = timeInitial * (decimal)timeScale;
        // recalculate G
        RescalingG(realG, timeVariable, massVariable, distanceVariable);
        // Send a Debug Log to confirm the simulation was sped up
        Debug.Log("Simulation speed up. It is now " + timeScale + " times the Default Speed");
        Debug.Log("G in Simulated units is now" + rescaledG);
    }


    // EXAMPLE OF CALLING CODE BELOW

    // How code in another Script would be written

        // replace with however you find val
        float val = 1.0f;

        // finding Scale object for sake of this example
        GameObject ScaleObject = GameObject.Find("ScaleScriptObject");

        // Specify that all of these values are the ones in the Scale script
        float timeScale = ScaleObject.GetComponent<Scale>().timeScale;
        decimal timeVariable = ScaleObject.GetComponent<Scale>().timeVariable;
        decimal timeInitial = ScaleObject.GetComponent<Scale>().timeInitial;
        decimal massVariable = ScaleObject.GetComponent<Scale>().massVariable;
        decimal distanceVariable = ScaleObject.GetComponent<Scale>().distanceVariable;
        decimal realG = ScaleObject.GetComponent<Scale>().realG;
        decimal rescaledG = ScaleObject.GetComponent<Scale>().rescaledG;

        // Run the method RescaleTime from the ScaleObject
        ScaleObject.GetComponent<Scale>().RescaleTime(val, timeScale, timeVariable, timeInitial, massVariable, distanceVariable, realG, rescaledG);

    */

}
