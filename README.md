# DC-NM-KCL-3rd_Year_Unity_Solar_System-2021
This repository contains all documents required for the Unity Project David and Nur created

Please Copy All Data into a new Unity Project folder

Into your folder with Unity projects.

A Script called README.sc exists inside the Unity project. This script is copied in sections below:

---------------------------------------------------------------------------------------------------------------------

-- THIS SCRIPT EXISTS SOLELY AS AN EXPLANATION FOR THE USER OF THIS APPLICATION --

    This was created as part of a King's College London 3rd Year Physics Project by:

        David Childs
        Nur Imanina Binti Mohd Faidzal

---------------------------------------------------------------------------------------------------------------------

-- WELCOME TO OUR SOLAR SYSTEM SIMULATION SOFTWARE --

    Data has been split into two folders:
        "Final Data - In Use"
            Contains all the data currently used for our simulation
        "Legacy Data - No Longer Used"
            Contains all the data previously created but not longer currently used for our simulation

    This Application requires use of:
        Unity API
        TextMesh Pro (TMPro) API

---------------------------------------------------------------------------------------------------------------------

-- SCENE VIEW (prior to running the simulation): --

    Since, an object must be at a different position of the previous one it depends on when it's position is set
        In the "Solar System" Scene:
            the "Sun" (whose initial position currently is independent of all other objects) is set to (0,0,0)
            Planets and Asteroids (whose initial position depends on the Sun) are set to points other than (0,0,0) 
            These non-origin points are approximately where they will be calulated to start in the scene
        In the "3rd Year Project David Nur Solar System Final" Scene:
            the "Sun" (whose initial position currently is independent of all other objects) 
            is set a unique starting position with all others at (0,0,0)
