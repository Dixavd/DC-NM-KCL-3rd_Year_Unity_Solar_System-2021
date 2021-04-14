using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    /*a script that enables switching between the Flying Camera (flying view) and the Controls Camera (top view) by the press of the spacebar.
      with each switch, the camera picks up where it left off
    */

    //defining the cameras and their audio listener components which will be called in the script

    public GameObject flyingCamera;
    public GameObject staticCamera;

    AudioListener flyingCameraAudioLis;
    AudioListener staticCameraAudioLis;

    // Use this for initialization
    void Awake()
    {

        //Get Camera Listeners
        flyingCameraAudioLis = flyingCamera.GetComponent<AudioListener>();
        staticCameraAudioLis = staticCamera.GetComponent<AudioListener>();

        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));

        /*Activating the Flying Camera and Disabling the Static Camera upon start of game
          so that Static Camera is only activated after the first spacebar press
        */

        flyingCamera.SetActive(true);
        flyingCameraAudioLis.enabled = true;

        staticCameraAudioLis.enabled = false;
        staticCamera.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Change Camera Keyboard
        switchCamera();
    }

    //UI JoyStick Method
    public void cameraPositonM()
    {
        cameraChangeCounter();
    }

    //Change Camera Keyboard
    public void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraChangeCounter();
        }
    }

    //Camera Counter
    public void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    //Camera change Logic
    public void cameraPositionChange(int camPosition)
    {

        if (camPosition > 1)
        {
            camPosition = 0;
        }

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set Flying Camera position
        if (camPosition == 0)
        {
            flyingCamera.SetActive(true);
            flyingCameraAudioLis.enabled = true;

            staticCameraAudioLis.enabled = false;
            staticCamera.SetActive(false);

            //return 0;
        }

        //Set Controls Camera position
        if (camPosition == 1)
        {
            staticCamera.SetActive(true);
            staticCameraAudioLis.enabled = true;

            flyingCameraAudioLis.enabled = false;
            flyingCamera.SetActive(false);

            //return 1;
        }

    }
}
