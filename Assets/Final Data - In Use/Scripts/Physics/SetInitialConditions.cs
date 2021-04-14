using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitialConditions : MonoBehaviour
{
    // Variables used for the scale of the simulation
    // time Unit
    private decimal timeUnit = 17529.4m;                         // [s]
    // mass Unit - shifted to keep in decimal range
    private decimal massUnit = 1e+22m;                           // [kg * 10^-5] shifted to keep in decimal range
    // distance Unit
    private decimal distanceUnit = 1e+7m;                        // [km]

    // Previous values of Variables for manipulation with new ones
    // time Unit
    private decimal oldTimeUnit = 17529.4m;                     // [s]
    // mass Unit
    private decimal oldMassUnit = 1e+22m;                       // [kg * 10^-5] shifted to keep in decimal range
    // distance Unit
    private decimal oldDistanceUnit = 1e+7m;                    // [km]

    // Conversion ratio of old time unit to new time unit
    // Used in order to reduce repeated calculation of the same division
    private decimal conversionTime = 1.0m;
    // Conversion ratio of old distance unit to new distance unit
    // Used in order to reduce repeated calculation of the same division
    private decimal conversionDistance = 1.0m;

    // Unique Variables used in script

    // Determines direction of orbital rotation
    // Factor value of 1 for Anticlockwise and 2 for Clockwise
    // Factor value of 0 for no rotation
    // Default set to AntiClockwise with Solar System
    public string orbitDirection = "AntiClockwise";             // Direction of Rotation defined from above
    private float orbitDirectionFactor = 1.0f;                   // [None]
    // Determines direction of spin rotation
    // Factor value of 1 for Anticlockwise and 2 for Clockwise
    // Factor value of 0 for no rotation
    // Default set to AntiClockwise with Solar System
    public string spinDirection = "AntiClockwise";              // Direction of Rotation defined from above
    private float spinDirectionFactor = 1.0f;                    // [None]
    // Variable for Spin Rotation, default of no spin
    // Will be replaced by Categorised value for calculations
    public decimal periodSpinRotation = 0.0m;                  // [days]
    // Frequency of Spin roation, default of no spin
    // Floats used for rotations
    private float frequencySpinRotation = 0.0f;                 // [deg/s]
    // Variable for describing the angle-offset of the plane-of-orbit from the z-direction.
    public float orbitTilt = 0.0f;                             // [rad]
    // Value to scale mass before converting to float for Rigidbody
    public decimal scaledMass = 0.0m;                          // [Unity Scaled Units - variable]
    // Value to scale radius before converting to float for collider
    public decimal scaledRadius = 1.0m;                        // [Unity Scaled Units - variable]
    // Speed of orbit used for OrbitalVelocity function
    public decimal orbitalSpeed = 0.0m;                        // [km/s]
    // Distance this object, 1, should be initially set from another object 2, that it orbits around
    public decimal distance2to1 = 0.0m;                        // [km]

    // These are the string variables that will be used to look up the initial values in the Dictionary
    // Set to "None" initially
    public string objectName = "None";
    public string typeName = "None";
    public string massName = "None";
    public string radiusName = "None";
    public string orbitDirectionName = "None";
    public string spinDirectionName = "None";
    public string obliquityName = "None";
    public string periodSpinRotationName = "None";
    public string orbitalSpeedName = "None";
    public string orbitTiltName = "None";
    public string focusName = "None";

    // This object's Rigidbody
    public Rigidbody rb;
    // This object's SphereCollider
    public SphereCollider sc;

    // Object with Dictionary attached
    private GameObject dictionaryObject;
    // Dictionary with decimal output
    private Dictionary<string, decimal> data;
    // Dictionary with string output
    private Dictionary<string, string> labels;

    // Object which determines scale of simulation
    private GameObject scalingObject;

    private GameObject activeCamera;
    public Vector3 defaultRenderSize;

    // The initial position and velocity will be set relative to this object
    private GameObject focusObject;
    // The Rigidbody component of this other object
    private Rigidbody rbFocus;

    // Vector calculated from values in Dictionary
    // Will be the Velocity vector when all objects begin moving
    public Vector3 initialVelocity = new Vector3(0, 0, 0);

    // variable to be true when spin should be calculated
    public bool runSpin = false;


    // Coroutines implement code after waiting for a condition
    // These are used to make sure processes occur only when all prerequisites have occured

    // Coroutine that waits until the Dictionaries have finished being filled
    // Then uses Dictionary to determine this object's type
    // Uses object type to determine which coroutine to start for setting position and velocity
    IEnumerator DictionaryNeedsToFinish()
    {
        yield return new WaitUntil(() => dictionaryObject.GetComponent<Dictionary>().check >= 2);

        // Check if the Dictionary has values assigned for this object's exact name
        // If so, set all of them to this found name
        if (labels.ContainsKey("object" + objectName) == true)
        {
            Debug.Log("Successfully found the key object" + objectName + " in " + labels);
            typeName = this.name;
            massName = this.name;
            radiusName = this.name;
            orbitDirectionName = this.name;
            spinDirectionName = this.name;
            obliquityName = this.name;
            periodSpinRotationName = this.name;
            orbitalSpeedName = this.name;
            orbitTiltName = this.name;
            focusName = this.name;
        }


        // Do nothing if the values have not been set
        if (typeName == "None")
        {
            // Set Vector used for camera rendering at a sphere of size 0.5 for Miscellaneous
            defaultRenderSize = new Vector3(0.5f, 0.5f, 0.5f);

            Debug.Log("typeName not set. It's still: " + typeName + " for " + this + ", after searching for key " + "object" + objectName);
        }

        // Check if this object is a Star
        else if (labels["type" + typeName] == "Star")
        {
            Debug.Log(this + " is a " + "Star");
            // Stars are not dependent on any other object being placed

            // Set Vector used for camera rendering at a sphere of size 1 for Suns
            defaultRenderSize = new Vector3(1.0f, 1.0f, 1.0f);

            // Call Function to Set Position and Velocity
            SetFromDictionary(massName, radiusName, orbitDirectionName, spinDirectionName, obliquityName, periodSpinRotationName, orbitalSpeedName, orbitTiltName, focusName);
        }

        // Check if this object is a Planet
        else if (labels["type" + typeName] == "Planet")
        {
            Debug.Log(this + " is a " + "Planet");

            // Set Vector used for camera rendering at a sphere of size 0.5 for Planets
            defaultRenderSize = new Vector3(0.5f, 0.5f, 0.5f);

            // Planets are dependent on the position of Stars
            // Therefore, need to wait until all Stars have been placed before placing any Planets
            StartCoroutine("WaitForStars");
        }

        // Check if this object is an Asteroid
        else if (labels["type" + typeName] == "Asteroid")
        {
            Debug.Log(this + " is an " + "Asteroid");

            // Set Vector used for camera rendering at a sphere of size 0.5 for Asteroids
            defaultRenderSize = new Vector3(0.5f, 0.5f, 0.5f);

            // Asteroids are dependent on the position of Stars
            // Therefore, need to wait until all Stars have been placed before placing any Asteroids
            // Start Coroutine to wait until all Stars have positions before continuing
            StartCoroutine("WaitForStars");
        }

        // Check if this object is a Moon
        else if (labels["type" + typeName] == "Moon")
        {
            Debug.Log(this + " is a " + "Moon");

            // Set Vector used for camera rendering at a sphere of size 0.1 for Moons
            defaultRenderSize = new Vector3(0.1f, 0.1f, 0.1f);


            // Moons are dependent on the position of Planets and Asteroids
            // Therefore, need to wait until all Planets and Asteroids have been placed before placing any Moons
            // Start Coroutine to wait until all Planets and Asteroids have positions before continuing
            StartCoroutine("WaitForPlanetsAndAsteroids");
        }

        // Finally if the TypeName has not been identified
        // send a Debug report to state as such
        else
        {
            // Set Vector used for camera rendering at a sphere of size 0.5 for Miscellaneous
            defaultRenderSize = new Vector3(0.5f, 0.5f, 0.5f);

            Debug.Log(this + " could not be placed due to an incompatable typeName, " + typeName + ", which isn't assigned in the " + labels + " Dictionary");
        }
    }

    // Coroutine that waits until all of the Stars have a set position
    // Then implements method for setting object
    IEnumerator WaitForStars()
    {
        Debug.Log(this + " is waiting for Stars since check = " + dictionaryObject.GetComponent<Dictionary>().check);

        yield return new WaitUntil(() => dictionaryObject.GetComponent<Dictionary>().check >= (2 + dictionaryObject.GetComponent<Dictionary>().stars));

        // Call Function to Set Position and Velocity
        SetFromDictionary(massName, radiusName, orbitDirectionName, spinDirectionName, obliquityName, periodSpinRotationName, orbitalSpeedName, orbitTiltName, focusName);
    }

    // Coroutine that waits until all of the Planets and Asteroids have a set position
    // This occurs after all of the Stars
    // Then implements method for setting object
    IEnumerator WaitForPlanetsAndAsteroids()
    {
        Debug.Log(this + " is waiting for Planets and Asteroids since check = " + dictionaryObject.GetComponent<Dictionary>().check);

        yield return new WaitUntil(() => dictionaryObject.GetComponent<Dictionary>().check >= (2 + dictionaryObject.GetComponent<Dictionary>().stars + dictionaryObject.GetComponent<Dictionary>().planets + dictionaryObject.GetComponent<Dictionary>().asteroids));

        // Call Function to Set Position and Velocity
        SetFromDictionary(massName, radiusName, orbitDirectionName, spinDirectionName, obliquityName, periodSpinRotationName, orbitalSpeedName, orbitTiltName, focusName);
    }

    // Coroutine that waits until all Moons have a set position
    // This occurs after all of the Stars, Planets, and Asteroids
    // Then implements method for calculating velocity
    IEnumerator WaitForMoons()
    {
        Debug.Log(this + " is waiting for Moons since check = " + dictionaryObject.GetComponent<Dictionary>().check);

        yield return new WaitUntil(() => dictionaryObject.GetComponent<Dictionary>().check >= (2 + dictionaryObject.GetComponent<Dictionary>().stars + dictionaryObject.GetComponent<Dictionary>().planets + dictionaryObject.GetComponent<Dictionary>().asteroids + dictionaryObject.GetComponent<Dictionary>().moons));

        // calls function to calculate initial velocity
        OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        Debug.Log(this + "velocity calculated");

        // update check value for second pass through objects
        dictionaryObject.GetComponent<Dictionary>().check += 1;

        // Start Coroutine to wait until all velocities are calculated before continuing
        StartCoroutine("WaitForVelocityCalculations");

    }
    // Currently, the Dictionary only has values of Stars, Planets, Asteroids, and Moons
    // Therefore waiting until all of these have been placed,
    // is the same as waiting until all the objects defined in the Dictionaries have been placed

    // Coroutine that waits until all of the Velocities have been calculated
    // This involves a second pass through the objects after the positions were set
    IEnumerator WaitForVelocityCalculations()
    {
        Debug.Log(this + " is waiting for all Velocities to be calculated since check = " + dictionaryObject.GetComponent<Dictionary>().check);

        yield return new WaitUntil(() => dictionaryObject.GetComponent<Dictionary>().check >= (2 + (2 * dictionaryObject.GetComponent<Dictionary>().stars) + (2 * dictionaryObject.GetComponent<Dictionary>().planets) + (2 * dictionaryObject.GetComponent<Dictionary>().asteroids) + (2 * dictionaryObject.GetComponent<Dictionary>().moons)));

        // Add calculated velocity of focal point to put both in the same refernce frame
        initialVelocity += focusObject.GetComponent<SetInitialConditions>().initialVelocity;
        // Set velocity to caclulated initial velocity to start movement
        rb.velocity = initialVelocity;

        // Activate Spin calculations
        runSpin = true;
        // Notify Gravity script to start caclulations
        this.GetComponent<GravitationalAttraction>().runGravity = true;

        Debug.Log(this + " will start moving with the velocity: " + initialVelocity + " and gravity will be calculated");
    }


    // Awake is the earliest possible event
    // Awake occurs before OnEnable
    void Awake()
    {
        // Notify that spin should be in inactive at start
        runSpin = false;

        // Label this object's Rigidbody Component
        rb = this.GetComponent<Rigidbody>();

        // Label this object's Sphere Collider Component
        sc = this.GetComponent<SphereCollider>();

        // find the object with the dictionary script attached
        dictionaryObject = GameObject.Find("Dictionary");

        // label values fom dictionary Script
        data = dictionaryObject.GetComponent<Dictionary>().data;
        labels = dictionaryObject.GetComponent<Dictionary>().labels;

        // find the object with the scaling script attached
        scalingObject = GameObject.Find("ScaleScriptObject");

        // Check if the Time scaling Unit has changed, and update it if so
        if (timeUnit == scalingObject.GetComponent<Scale>().timeVariable)
        { }
        else
        {
            timeUnit = scalingObject.GetComponent<Scale>().timeVariable;
            oldTimeUnit = timeUnit;
        }

        // Check if the Mass scaling Unit has changed, and update it if so
        if (massUnit == scalingObject.GetComponent<Scale>().massVariable)
        { }
        else
        {
            massUnit = scalingObject.GetComponent<Scale>().massVariable;
            oldMassUnit = massUnit;
        }

        // Check if the Distance scaling Unit has changed, and update it if so
        if (distanceUnit == scalingObject.GetComponent<Scale>().distanceVariable)
        { }
        else
        {
            distanceUnit = scalingObject.GetComponent<Scale>().distanceVariable;
            oldDistanceUnit = distanceUnit;

            // Reset trail
            this.GetComponent<TrailRenderer>().Clear();
        }

        // Set the objectName variable to it's own name
        objectName = this.name;


    }

    // OnEnable is called when the assigned object is first initialised
    // OnEnable occurs after Awake but before Start
    void OnEnable()
    {

    }

    // Start occurs immediately before the first frame
    // Start occurs after OnEnable
    void Start()
    {
        // If Dictionaries have not been made yet, create them
        if (data == null)
        {
            data = new Dictionary<string, decimal>();
        }
        if (labels == null)
        {
            labels = new Dictionary<string, string>();
        }

        // Start Coroutine to wait until Dictionary is filled before continuing
        StartCoroutine("DictionaryNeedsToFinish");
    }

    // FixedUpdate is called at a constant time interval independent of Frame-Rate
    void FixedUpdate()
    {
        // Check if the Time scaling Unit has changed, and update it if so
        if (timeUnit == scalingObject.GetComponent<Scale>().timeVariable)
        { }
        else
        {
            // set Time Unit to new value of variable
            timeUnit = scalingObject.GetComponent<Scale>().timeVariable;

            // Convert time-dependent properties to new Time Unit
            conversionTime = oldTimeUnit / timeUnit;
            rb.velocity *= (float)(1.0m / conversionTime);
            rb.angularVelocity *= (float)(1.0m / conversionTime);
            periodSpinRotation *= conversionTime;

            // Update previous Time Unit for use at next change of Time Variable
            oldTimeUnit = timeUnit;

        }

        // Check if the Mass scaling Unit has changed, and update it if so
        if (massUnit == scalingObject.GetComponent<Scale>().massVariable)
        { }
        else
        {
            // set Mass Unit to new value of variable
            massUnit = scalingObject.GetComponent<Scale>().massVariable;

            // Convert mass-dependent properties to new Mass Unit
            scaledMass *= oldMassUnit / massUnit;
            rb.mass = (float)scaledMass;

            // Update previous Mass Unit for use at next change of Mass Variable
            oldMassUnit = massUnit;
        }

        // Check if the Distance scaling Unit has changed, and update it if so
        if (distanceUnit == scalingObject.GetComponent<Scale>().distanceVariable)
        { }
        else
        {
            // set Mass Unit to new value of variable
            distanceUnit = scalingObject.GetComponent<Scale>().distanceVariable;

            // Convert Distance-dependent properties to new Distance Unit
            conversionDistance = (oldDistanceUnit / distanceUnit);
            rb.position *= (float)conversionDistance;
            rb.velocity *= (float)conversionDistance;
            scaledRadius *= conversionDistance;
            sc.radius = (float)scaledRadius;

            // Reset trail
            this.GetComponent<TrailRenderer>().Clear();

            // Update previous Distrance Unit for use at next change of Distance Variable
            oldDistanceUnit = distanceUnit;
        }

        // Only calculate Spin if it should be running

        if (runSpin == true)
        {
            // determine value of spinDirectionFactor
            // spinDirectionFactor used to discern direction of rotation by using it as the power of -1
            // Result will be Positive if Clockwise
            // Result will be Negative if AntiClockwise
            // Result will be Zero otherwise
            if (spinDirection == "Clockwise")
            {
                spinDirectionFactor = 2.0f;
            }
            else if (spinDirection == "AntiClockwise")
            {
                spinDirectionFactor = 1.0f;
            }
            else
            {
                spinDirectionFactor = 0.0f;
            }

            // Do not calculate an additional spin if spin is zero
            if (periodSpinRotation == 0.0m)
            { }
            else
            {
                // Function to implement spin
                // Convert Period of Spin to Frequency as a float for use in rotations
                // 360 degrees in a circle
                frequencySpinRotation = (float)(360.0m / periodSpinRotation);
                // Calculate vector of Euler Angles for Spin Rotation
                Vector3 eulerAngleVelocity = new Vector3(0.0f, 0.0f, frequencySpinRotation);
                // Calculate whether rotation will be positive or negative
                eulerAngleVelocity *= Mathf.Pow(-1, spinDirectionFactor);
                // Turn Euler Angle Vector into rotation at each time step
                rb.MoveRotation(rb.rotation * Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime));
            }
        }

        // Function which changes the scale an object is rendered by either using the slider or the distance from the camera
        // Has no effect on physics
        RenderScaling();
    }



    // Functions to call

    // Function to set position and velocity based on values found in two Dictionaries
    public void SetFromDictionary(
        // keys used to search dictionaries
        string massName, string radiusName, string orbitDirectionName, string spinDirectionName, string obliquityName, string periodSpinRotationName, string orbitalSpeedName, string orbitTiltName, string focusName)
    {
        // calculates what scaled mass will be
        scaledMass = data["mass" + massName] / massUnit;

        // sets the mass used by Rigidbody
        rb.mass = (float)scaledMass;

        // calculates what scaled radius will be
        scaledRadius = data["radius" + radiusName] / distanceUnit;

        // sets the radius used for the Collider
        sc.radius = (float)scaledRadius;

        // Define rotation directions for orbit and spin
        orbitDirection = labels["orbitDirection" + orbitDirectionName];
        spinDirection = labels["spinDirection" + spinDirectionName];

        // sets starting rotation to be obliquity angle
        rb.rotation = Quaternion.Euler(0f, (float)data["obliquity" + obliquityName], 0f);

        // convert Spin Period into Unity Scale
        // 3600 comes from hours to seconds - 3600 seconds per hour
        periodSpinRotation = data["periodSpinRotation" + periodSpinRotationName] * 3600.0m / timeUnit;

        // convert Orbital Speed into Unity Scale
        orbitalSpeed = data["orbitalSpeed" + orbitalSpeedName] * (timeUnit / distanceUnit);

        // Set general orbitTilt Variable to this object's value in radians
        orbitTilt = (Mathf.PI / 180) * (float)data["orbitTilt" + orbitTiltName];

        // Finds the name of the object to orbit around in the Dictionary
        focusObject = GameObject.Find(labels["focus" + focusName]);

        // Finds the object with the name identical to the string found in the Dictionary
        // Sets a Rigidbody variable rbFocus to refer to the Rigidbody component of the found object
        rbFocus = focusObject.GetComponent<Rigidbody>();

        // Set distance this object should be placed from the focus object
        distance2to1 = data["distance" + rbFocus.name + "To" + focusName];

        // calls function to set initial position
        RelativePosition(rbFocus, distance2to1, distanceUnit);

        Debug.Log(this + " position set");

        // once object has been placed in position, increase the check counter
        dictionaryObject.GetComponent<Dictionary>().check += 1;

        // wait until all objects are in place before implimenting velocities
        StartCoroutine("WaitForMoons");

    }


    // Function to set position of oject to a defined distance away from another object it will orbit around
    public void RelativePosition(Rigidbody rb2, decimal distance2to1, decimal distanceScaleFactor)
    {   // do not change position if object's focal point is itself - i.e. largest object doesn't orbit self
        if (rb.position == rb2.position)
        { }
        else
        {
            // Calculate the vector between the current positions of This Object, 1, and Another Object, 2
            Vector3 radius = rb.position - rb2.position;
            // set position of 1 a predetermined distance away from 2
            rb.position = rb2.position + (radius.normalized * (float)(distance2to1 / distanceScaleFactor));

            // Reset Trail
            this.GetComponent<TrailRenderer>().Clear();
        }
    }

    // Function to set the velocity of an object to rotate around another body
    public void OrbitalVelocity(Rigidbody rb2, decimal orbitalSpeed, float orbitTilt, string orbitDirection)
    {
        // determine value of OrbitDirectionFactor
        // orbitDirectionFactor used to discern direction of rotation by using it as the power of -1
        // Result will be Positive if Clockwise
        // Result will be Negative if AntiClockwise
        // Result will be Zero otherwise
        if (orbitDirection == "Clockwise")
        {
            orbitDirectionFactor = 2.0f;
        }
        else if (orbitDirection == "AntiClockwise")
        {
            orbitDirectionFactor = 1.0f;
        }
        else
        {
            orbitDirectionFactor = 0.0f;
        }

        // do not change orbital velocity if object's focal point is itself - i.e. largest object doesn't orbit self
        if (rb.position == rb2.position)
        { }
        // if no Orbital Tilt then plane of orbit in x-y plane with z-direction as the normal to the orbit;
        else
        {
            // Set Normal Vector relative to angle of orbit Tilt
            float sin = Mathf.Sin(orbitTilt);
            float cos = Mathf.Cos(orbitTilt);
            Vector3 orbitalNormal = new Vector3(sin, 0.0f, cos);
            // Calculate the vector between the current positions of This Object, 1, and Another Object, 2
            Vector3 radius = rb.position - rb2.position;
            // Calculate cross product between the Radius of Orbit the Normal to Orbit
            Vector3 crossProduct = Vector3.Cross(orbitalNormal, radius);
            // Create orbital velocity by taking direction of cross product multiplied by predefined speed
            initialVelocity = Mathf.Pow(-1, orbitDirectionFactor) * crossProduct.normalized * (float)orbitalSpeed;

        }
    }


    // Function to alter the render scaling
    // Has no effect on gravity
    public void RenderScaling() 
    { 
        // If renderCheck is disabled, scale render relative to actual radius
        if (scalingObject.GetComponent<Scale>().renderCheck == false) 
        {
            // renderScale in Scale script used as proportionality
            // Proportionality of 1 would 1:1 representation of scale in Unity units
            // Sets the Render Scaling to a sphere with radius equal to object radius (scaled to simulation units) * proportionality
            rb.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f) * (float)(scaledRadius) * scalingObject.GetComponent<Scale>().renderScale;

        }
        // If renderCheck is enabled, scale render relative to distance from camera
        else if (scalingObject.GetComponent<Scale>().renderCheck == true) 
        {
            // Check which camera as active to use
            if (GameObject.Find("FlyingCamera") == enabled) 
            {
                activeCamera = GameObject.Find("FlyingCamera");
                rb.transform.localScale = defaultRenderSize * (scalingObject.GetComponent<Scale>().renderScale / 200) * ((activeCamera.GetComponent<Camera>().transform.position - rb.position).magnitude);
            }
            else if (GameObject.Find("StaticCamera") == enabled) 
            {
                activeCamera = GameObject.Find("StaticCamera");
                rb.transform.localScale = defaultRenderSize * (scalingObject.GetComponent<Scale>().renderScale / 200) * ((activeCamera.GetComponent<Camera>().transform.position - rb.position).magnitude);

            }
        }
    }
    
}