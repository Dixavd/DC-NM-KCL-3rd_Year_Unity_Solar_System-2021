using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    /*a script that governs the introduction panel
      it disappears when you press esc and spacebar
    */

    public Canvas cv;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cv = GetComponent<Canvas>();

        if (Input.GetKey(KeyCode.Escape))

        {
            DestroyComponent();
        }
        
    }

    void DestroyComponent()
    {
        // Removes the component from the game object
        // Removing Canvas component in order for Introduction Panel to disappear
        // Need to remove components CanvasScaler and GraphicRaycaster as well since they are dependent on Canvas component
        Destroy(GetComponent<CanvasScaler>());
        Destroy(GetComponent<GraphicRaycaster>());
        Destroy(cv);
    }

}

    
   
    
