# DC-NM-KCL-3rd_Year_Unity_Solar_System-2021

**-- BELOW IS A GUIDE FOR THE SOFTWARE --**

_Feel Free to skim it or only refer back when you need to. A Script called README.sc exists in the Unity Project as well.
The README.sc script doe nothing; it just contains a copy of the below information._

---------------------------------------------------------------------------------------------------------------------

This Repository contains all documents required to recreate the Unity Project created by David Childs and Nur Imanina Binti Mohd Faidzal for our 3rd Year Physics Undergaduate Project at King's College London

---------------------------------------------------------------------------------------------------------------------

-- HOW TO RECREATE THE UNITY PROJECT --

    Create a New Unity Project
    Open The File Explorer showing the files for this New Unity project
        Close Unity
    Delete the "Scenes" Folder of the New Unity Project

    Download the data from this repository
    Copy the downloaded data into the New Unity Project files folder
        Into the same Project folder that already contains a folder called "Assets"
        Choose to Replace all Duplicate files

    Open the New Unity Project in Unity
        In the Project Files panel, Go to:
            "Assets" > "Final Data - In Use" > "Scenes"
        Open the Scene:
            "3rd Year Project David Nur Solar System Final"

            NOTE: The Scene Titled:
                "Solar System"
            Is almost-identical to "Solar System", 
                except that the objects were in different places initially for debugging
                    "Solar System" may also not have the most recent UI edits

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
        The result of both is all objects start in a line,
            However, you can vary their position in the Scene view to see they will be initially placed a different points in their orbits
                This is because for all objects dependent on another object:
                    The position of the object they are dependent on is found and set as a focal point
                    Then the new object is set them at a predefined distance away from the focal point
                    Along the direction vector between the focal point and the object's current position (i.e. scene-view position)

    You can move around the positions of the objects in the scene before running the software 
        You will see the objects begin at different points around their orbits

    New objects can be created in the Scene View although their name must be associated with predefined values in the Dictionary Script
        Using the Dictionary Script:
            "Final Data - In Use" > "Scripts" > "Other" > "Dictionary.sc"
                Go to the "CreateDictionary()" method at line 40
                    Inside this method, new predefined values can be added by following the format of previous additions
                    So long as all the required values have been defined in the dictionary, a new object of that name can be added into the scene

---------------------------------------------------------------------------------------------------------------------

-- VARYING THE SCALES: --

    As written in the Scale script:
        "Final Data - In Use" > "Scripts" > "Physics" > "Scale.sc"

    The Simulation is coded to allow 4 Variables to be changed:
        3 That affect the Physics
            timeVariable : which is augmented by: timeScale
            distanceVariable : which is augmented by distanceScale
            massVariable : Code for the simulation to work if the massVariable changes works, however was not used

        1 That only affects the rendering:
            renderScale
                renderCheck - switches between Render Types

    Initial Conditions of Objects in Scene set by script:
        "Final Data - In Use" > "Scripts" > "Physics" > "SetInitialConditions.sc"

    Gravity is Calculated by script:
        "Final Data - In Use" > "Scripts" > "Physics" > "GravitationalAttraction.sc"

    Objects created mid-simulation by the Generation Panel are set by the Script:
            "Final Data - In Use" > "Scripts" > "Physics" > "CreateMass.sc"

---------------------------------------------------------------------------------------------------------------------

-- GAME VIEW (once the simulation is running): --

    2 Camera Views
        Flying Camera
            This is the initial view
        Static Camera

        SPACE key: Switches between Cameras
                FOREWARNING: BUG - apologies if you experience this
                    Sometimes an issue occurs when the SPACE key is pressed 
                    Both Cameras appear to be inactive so no switching occurs
                    We could not find the source
                    It seems to only occur on initialisation
                    To fix it, you must STOP the game and RESTART it

    When the game is initially run, the Flying Camera is active, and a explanation appears on screen

---------------------------------------------------------------------------------------------------------------------

-- FLYING CAMERA VIEW --

    Initial Explanation Panel:
        ESC key: To remove the explanation
    Flying Camera Movement:
        Mouse : moves the direction the Camera is Looking
        W, A, S, D Keys: moves position of the camera
            W : Forward - towards direction Camera is looking
            S : Backward - away from the direction the Camera is looking
            A : Left - From Camera Perspective, Parallel to the direction the Camera is looking
            D : Right - From Camera Perspective, Parallel to the direction the Camera is looking

    Varying Scale in Flying Camera View: 
        Keys can be pressed to either double or halve the Time and Distance scales of the Unity simulation
            , Key increases speed of simulation          > for Greater Speed - Speed Doubled
            . Key decreases speed of the simulation      < for Less Speed - Speed Halved
            F Key increases distances of simulation      F for Further away - Distances Doubled
            C Key decreases distances of simulation      C for Closer together - Distances Halved
            R Key resets scaling of simulation           R for Reset manipualtion

---------------------------------------------------------------------------------------------------------------------

-- STATIC VIEW --

    View from a camera directly above the simulation (placed in positive z-direction looking towards negative z-direction)

    UI Split into 4 sections:
        1) Render of the Scene:
            Central Area - Initially covered by an information panel
                Information Can be turned off with the Yellow Checkbox in the 3) Scaling Area

        2) Static Camera Focus Panel:
            Top Right Area with the Dropdown "The Solar System" and an information panel underneath
                Clicking on the Dropdown allows the choice of which object to follow
                "The Solar System"
                    Initial Dropdown Option
                    Camera is static
                "[ANY OBJECT NAME]"
                    Camera follows the named object
                    Mouse Scroll Wheel: Zooms In or Out (z-axis direction)
                "Free Camera View"
                    Camera stops moving (if it was following an object) and responds to Arrow keys:
                        Up Arrow - Moves Camera Up (positive y-axis)
                        Down Arrow - Moves Camera Down (negative y-axis)
                        Left Arrow - Moves Camera Left (negative x-axis)
                        Right Arrow - Moves Camera Right (positive x-axis)
                        Mouse Scroll Wheel: Zooms In or Out (z-axis direction)

        3) Scaling Area
            Lower Right Area with 3 Sliders: 
                GREEN Slider: Initially Center
                    Varies TIME of Unity Scale
                            Centre of Slider is initial speed of simulation
                            Slider less than centre slows down speed (down to 0.0001x)
                            Slider above centre speeds up time (up to 32x)
                RED Slider: Initially Center
                    Varies DISTANCE of Unity Scale
                            Centre of Slider is initial distances of simulation
                            Slider less than centre reduces distances (down to 0.0001x)
                            Slider above centre increases distances (up to 32x)
                BLUE Slider: Initially 1/8th across from the left (value of 25/200)
                    Varies RENDERING SIZE of Objects in Scene
                            NO EFFECT ON PHYSICS
                            Slider varies from 1 to 200
            A RESET button: 
                    Resets sliders to initial values
            Bottom-most area with 3 Checkboxes: Initially Ticked
                ORANGE Checkbox: Debug Lights
                    Orange Ticked: Debug lights are ON
                        All objects are lit from 8 directions
                            Useful initially and when looking for objects
                    Orange Empty: Debug lights are OFF
                        Objects only lit by the Sun
                            Visually interesting to approximate shadows
                PURPLE Checkbox: Render Type
                    Purple Ticked: Renders Using Camera Distance
                        Sets render size relative to distance from the camera
                            Therefore all objects of the same type (i.e. Stars, Planets, Asteroids or Moons) will appear the same size on the scene
                        This means the BLUE slider varies the percentage of the scene each object takes up
                        Useful when looking for objects
                    Purple Empty: Renders relative to actual radius of the objects
                        When BLUE Slider is all the way to the left, value of 1:
                            Objects rendered at actual size in Unity Scale
                        As BLUE Slider is increased to the right (up to 200):
                            Rendering Sizes are multiplied.
                            Therefore render sizes no longer true to Unity Scale / distances between objects
                            However Relative render sizes between objects is still accurate
                        Useful to get a sense of the actual scale of the system
                YELLOW Checkbox: Central Information Panel
                    Yellow Ticked: Central Information Panel is VISIBLE
                    Yellow Empty: Central Information Panel is INVISIBLE
                        Recommended turning Yellow checkbox to Empty when information panel is not required

                PLEASE CLICK SOMETHING NON-INTERACTABLE BEFORE CLICKING SPACE-BAR TO SWITCH VIEWS
                    For instance, Unity sometimes registers the space-bar as clicking a checkbox otherwise
                    
        4) Generation Panel:
            Left Panel of inputs and Dropdowns with button at the top called "GENERATE NEW OBJECT"
            This Panel allows a new object to be created

---------------------------------------------------------------------------------------------------------------------

-- WHEN GENERATING AN OBJECT USING THE GENERATION PANEL: --

    Carried out by the Create Mass script:
        "Final Data - In Use" > "Scripts" > "Physics" > "CreateMass.sc"

-- STEPS TO GENERATE AN OBJECT: --

    1) Select Items with the * Dropdowns
    2) If another Dropdown is referenced by an option selected, make sure those are set too
    3) Fill in Input fields
    4) Click "GENERATE NEW OBJECT" Button
    5) Check Dropdown in the Static Camera Focus Panel at the top right of the UI to see if an Object was Created
    6) If no Object was created, check the debug console for an explanation of why

---------------------------------------------------------------------------------------------------------------------

-- FOR AN EXPLANATION OF EACH PANEL ITEM, SEE BELOW: --

    "GENERATE NEW OBJECT" Button
        Button which attempts to generate an object
            If an invalid set-up is entered, the generation is terminated
        * Dropdown options are required
            Default options for these will not create an object
        If a Dropdown references another dropdown, then that other dropdown is required
        Input fields will be set to default values if nothing is entered, or an invalid text is entered

    "ENTER OBJECT NAME"
        Text input - allows the user to type text which will be used to name an object
            If left blank, the object will be called "None"
            If an object with the name already exists in the scene, the name will be iterated by an integer, n (starting with 1) until a unique name is found

    "* Mass Unit" Dropdown
        Determines what type of unit will be used when setting the new object's Mass
        Comverted into current Unity Scale
            "100,000 kg"
                Looks up in Dictionary 100,000 kg to be used as Mass Unit
            "[ANY OBJECT NAME]"
                Filled by Dictionary Script on start of progam
                Uses the mass of that object as defined by the Dictionary

    "1" text input next to "* Mass Unit"
        Multiple to be applied to the chosen Mass Unit
            If 0, Blank or non-number entered: set to 1
            If negative value entered: set to positive

    "* Radius Unit" Dropdown
        Determines what type of unit will be used when setting the new object's Radius
        Determines Rendering Size of object once created
        Comverted into current Unity Scale
            "km"
                Looks up in Dictionary km to be used as Radius Unit
            "[ANY OBJECT NAME]"
                Filled by Dictionary Script on start of progam
                Uses the Radius of that object as defined by the Dictionary

    "1" text input field next to "* Radius Unit"
        Multiple to be applied to the chosen Radius Unit
            If 0, Blank or non-number entered: set to 1
            If negative value entered: set to positive

    "* Focal Point, FP" Dropdown
        Determines how to define where the initial point the new object's position will be placed relative to
            "Position of 1"
                Finds the position of the object of with the Name chosen in Dropdown "Object 1"
                    Dropdown "Object 1" will be required to be changed
            "(x1,y1,z1)"
                Finds the position of the vector (x1,y1,z1) using the input fields x1, y1 and z1
                if any of the input fields is left Blank or a non-number value is entered, they will be set to 0

    "Object 1" Dropdown
        Only used if option "Position of 1" is chosen in "* Focal Point, FP" Dropdown
            Initially no other options
            "[ANY OBJECT NAME]"
                Filled by Dictionary Script on start of progam

    "x1" text input field next to "Object 1" Dropdown
        Only used if option "(x1,y1,z1)" is chosen in "* Focal Point, FP" Dropdown
            if any of the input fields is left Blank or a non-number value is entered, they will be set to 0

    "y1" text input field next to "Object 1" Dropdown
        Only used if option "(x1,y1,z1)" is chosen in "* Focal Point, FP" Dropdown
            if any of the input fields is left Blank or a non-number value is entered, they will be set to 0

    "z1" text input field next to "Object 1" Dropdown
        Only used if option "(x1,y1,z1)" is chosen in "* Focal Point, FP" Dropdown
            if any of the input fields is left Blank or a non-number value is entered, they will be set to 0

    "* Distance Unit" Dropdown
        Determines how far away to place the new object from the focal point
            "Distance 2 to 3"
                Finds the distance between the positions of the objects with the Names chosen in Dropdowns "Object 2" and "Object 3"
                    Dropdowns "Object 2" and "Object 3" will be required to be changed
            "Radius of 2"
                Looks up in the Dictionary the radius of the object with the Name chosen in Dropdown "Object 2"
                    Dropdown "Object 2" will be required to be changed
            "km"
                Looks up in Dictionary km to be used as Distance Unit
            "Light-Second"
                Looks up in Dictionary Light-Second to be used as Distance Unit
            "Light-Year"
                Looks up in Dictionary Light-Year to be used as Distance Unit

    "1" text input field next to "* Distance Unit"
        Multiple to be applied to the chosen Distance Unit
            If 0, Blank or non-number entered: set to 1
            Negative value can be used 
                Will place object opposite direction the chosen distance direction

    "Object 2" Dropdown
        Only used if option "Distance 2 to 3" or "Radius of 2" is chosen in "* Distance Unit" Dropdown
            Initially no other options
            "[ANY OBJECT NAME]"
                Filled by Dictionary Script on start of progam

    "Object 3" Dropdown
        Only used if option "Distance 2 to 3" is chosen in "* Distance Unit" Dropdown
            Initially no other options
            "[ANY OBJECT NAME]"
                Filled by Dictionary Script on start of progam

    "* Distance Direction" Dropdown
        Determines the direction from focal point to place the new object
            "Towards 4"
                Finds the Position of the Object with the Name chosen in the "Object 4" Dropdown
                Finds the direction from the Focal Point and Object 4
            "Towards (x2,y2,z2)"
                Finds the Position of the vector (x2,y2,z2) using the associated input fields
                    if any of the input fields is left Blank or a non-number value is entered, they will be set to 0
                Finds the direction from the Focal Point and (x2,y2,z2)
            "(x2,y2,z2) Normalized"
                Finds the Direction of the vector (x2,y2,z2) using the associated input fields
                    if any of the input fields is left Blank or a non-number value is entered, they will be set to 0
            "Spherical: theta1 & phi1 [deg]"
                Calculates the Cartesian Vector using the input fields, theta1 and phi1, as spherical units in degrees
                    if any of the input fields is left Blank or a non-number value is entered, they will be set to 0
                    if any of the input fields is less than -360 or more than 360, the multiples of 360 will be removed
                Uses the Direction of this Cartesian Vector to place the new object.

    "Object 4" Dropdown
        Only used if option "Towards 4" is chosen in "* Distance Direction" Dropdown
            Initially no other options
            "[ANY OBJECT NAME]"
                Filled by Dictionary Script on start of progam

    "x2" text input field next to "Object 4" Dropdown
        Only used if option "Towards (x2,y2,z2)" or "(x2,y2,z2) Normalized" is chosen in "* Distance Direction" Dropdown
            if any of the input fields is left Blank or a non-number value is entered, they will be set to 0

    "y2" text input field next to "Object 4" Dropdown
        Only used if option "Towards (x2,y2,z2)" or "(x2,y2,z2) Normalized" is chosen in "* Distance Direction" Dropdown
            if any of the input fields is left Blank or a non-number value is entered, they will be set to 0

    "z2" text input field next to "Object 4" Dropdown
        Only used if option "Towards (x2,y2,z2)" or "(x2,y2,z2) Normalized" is chosen in "* Distance Direction" Dropdown
            if any of the input fields is left Blank or a non-number value is entered, they will be set to 0

    "theta1 [deg]" input field below "Object 4" Dropdown
        Only used if option "Spherical: theta1 & phi1 [deg]" is chosen in "* Distance Direction" Dropdown
            if any of the input fields is left Blank or a non-number value is entered, they will be set to 0
            if any of the input fields is less than -360 or more than 360, the multiples of 360 will be removed

    "phi1 [deg]" input field next to "theta1" input field
        Only used if option "Spherical: theta1 & phi1 [deg]" is chosen in "* Distance Direction" Dropdown
            if any of the input fields is left Blank or a non-number value is entered, they will be set to 0
            if any of the input fields is less than -360 or more than 360, the multiples of 360 will be removed

    "* Soeed Unit" Dropdown
        Determines Initial Speed the new object will be moving
            "Speed of 5 from 6"
                Finds the difference in velocities between the objects with the Names chosen in Dropdowns "Object 5" and "Object 6"
                    Dropdowns "Object 5" and "Object 6" will be required to be changed
            "km/s"
                Looks up in Dictionary km/s to be used as Speed Unit
            "Speed of Sounds"
                Looks up in Dictionary Speed of Sound to be used as Speed Unit
            "Speed of Light"
                Looks up in Dictionary Speed of Light to be used as Speed Unit

    "0" text input field next to "* Speed Unit"
        Multiple to be applied to the chosen Distance Unit
            If Blank or non-number entered: set to 0
            Negative value can be used 
                Will set initial speed in opposite direction the chosen velocity direction

    "Object 5" Dropdown
        Only used if option "Speed of 5 from 6" is chosen in "* Speed Unit" Dropdown
            Initially no other options
            "[ANY OBJECT NAME]"
                Filled by Dictionary Script on start of progam

    "Object 6" Dropdown
        Only used if option "Speed of 5 from 6" is chosen in "* Speed Unit" Dropdown
            Initially no other options
            "[ANY OBJECT NAME]"
                Filled by Dictionary Script on start of progam

    "* DVelocity Direction" Dropdown
        Determines the direction of initial velocity to give the new object
            "Towards 7"
                Finds the Position of the Object with the Name chosen in the "Object 7" Dropdown
                Finds the direction from the new object's created position and the position of Object 7
            "Towards (x3,y3,z3)"
                Finds the Position of the vector (x2,y2,z2) using the associated input fields
                    if any of the input fields is left Blank or a non-number value is entered, they will be set to 0
                Finds the direction from the new object's created position and (x2,y2,z2)
            "(x3,y3,z3) Normalized"
                Finds the Direction of the vector (x3,y3,z3) using the associated input fields
                    if any of the input fields is left Blank or a non-number value is entered, they will be set to 0
            "Spherical: theta2 & phi2 [deg]"
                Calculates the Cartesian Vector using the input fields, theta2 and phi2, as spherical units in degrees
                    if any of the input fields is left Blank or a non-number value is entered, they will be set to 0
                    if any of the input fields is less than -360 or more than 360, the multiples of 360 will be removed
                Uses the Direction of this Cartesian Vector to set the initial velocity direction

    "Object 7" Dropdown
        Only used if option "Towards 7" is chosen in "* Velocity Direction" Dropdown
            Initially no other options
            "[ANY OBJECT NAME]"
                Filled by Dictionary Script on start of progam

    "x3" text input field next to "Object 7" Dropdown
        Only used if option "Towards (x3,y3,z3)" or "(x3,y3,z3) Normalized" is chosen in "* Velocity Direction" Dropdown
            if any of the input fields is left Blank or a non-number value is entered, they will be set to 0

    "y3" text input field next to "Object 7" Dropdown
        Only used if option "Towards (x3,y3,z3)" or "(x3,y3,z3) Normalized" is chosen in "* Velocity Direction" Dropdown
            if any of the input fields is left Blank or a non-number value is entered, they will be set to 0

    "z3" text input field next to "Object 7" Dropdown
        Only used if option "Towards (x3,y3,z3)" or "(x3,y3,z3) Normalized" is chosen in "* Velocity Direction" Dropdown
            if any of the input fields is left Blank or a non-number value is entered, they will be set to 0

    "theta2 [deg]" input field below "Object 7" Dropdown
        Only used if option "Spherical: theta2 & phi2 [deg]" is chosen in "* Velocity Direction" Dropdown
            if any of the input fields is left Blank or a non-number value is entered, they will be set to 0
            if any of the input fields is less than -360 or more than 360, the multiples of 360 will be removed

    "phi2 [deg]" input field next to "theta2" input field
        Only used if option "Spherical: theta2 & phi2 [deg]" is chosen in "* Velocity Direction" Dropdown
            if any of the input fields is left Blank or a non-number value is entered, they will be set to 0
            if any of the input fields is less than -360 or more than 360, the multiples of 360 will be removed

---------------------------------------------------------------------------------------------------------------------

    -- THANK YOU FOR LOOKING AT OUR SOFTWARE -- 
    -- PLAY AROUND AND HAVE FUN --
