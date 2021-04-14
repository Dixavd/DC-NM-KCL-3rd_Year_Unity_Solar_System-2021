using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
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

    // Real value of Gravitational constant G           
    private decimal gravitationalConstantG = 6.6743e-11m;        // [m^3 kg^-1 s^-2]

    // Gravitational Constant to be varied by Unity scale
    // Default set it to real value and units (i.e. assume unity units were 1-to-1)
    private decimal rescaledG = 6.6743e-11m;                     // [Unity Scaled Units - variable]

    // Determines direction of orbital rotation
    // Factor value of 1 for Anticlockwise and 2 for Clockwise
    // Factor value of 0 for no rotation
    // Default set to AntiClockwise with Solar System
    private string orbitDirection = "AntiClockwise";             // Direction of Rotation defined from above
    private float orbitDirectionFactor = 1.0f;                   // [None]

    // Determines direction of spin rotation
    // Factor value of 1 for Anticlockwise and 2 for Clockwise
    // Factor value of 0 for no rotation
    // Default set to AntiClockwise with Solar System
    private string spinDirection = "AntiClockwise";              // Direction of Rotation defined from above
    private float spinDirectionFactor = 1.0f;                    // [None]

    // Variable for Spin Rotation, default of no spin
    // Will be replaced by Categorised value for calculations
    private decimal periodSpinRotation = 0.0m;                  // [days]
    // Frequency of Spin roation, default of no spin
    // Floats used for rotations
    private float frequencySpinRotation = 0.0f;                 // [deg/s]

    // Variable for describing the angle-offset of the plane-of-orbit from the z-direction.
    private float orbitTilt = 0.0f;                             // [rad]

    // Value to scale mass before converting to float for Rigidbody
    private decimal scaledMass = 0.0m;                          // [Unity Scaled Units - variable]
    // Value to scale radius before converting to float for collider
    private decimal scaledRadius = 1.0m;                        // [Unity Scaled Units - variable]
    // Speed of orbit used for OrbitalVelocity function
    private decimal orbitalSpeed = 0.0m;                        // [km/s]
    // Distance this object, 1, should be initially set from another object 2, that it orbits around
    private decimal distance2to1 = 0.0m;                        // [km]


    // Conversion ratio of old time unit to new time unit
    // Used in order to reduce repeated calculation of the same division
    private decimal conversionTime = 1.0m;
    // Conversion ratio of old distance unit to new distance unit
    // Used in order to reduce repeated calculation of the same division
    private decimal conversionDistance = 1.0m;




    // These are the string variables that will be used to look up the initial values in the Dictionary
    // Set to "None" initially
    private string objectName = "None";
    private string typeName = "None";
    private string massName = "None";
    private string radiusName = "None";
    private string orbitDirectionName = "None";
    private string spinDirectionName = "None";
    private string obliquityName = "None";
    private string periodSpinRotationName = "None";
    private string orbitalSpeedName = "None";
    private string orbitTiltName = "None";
    private string focusName = "None";

    // Rigidbody Component relating to self
    private Rigidbody rb;
    // Rigidbody Component of the Focal Objects this body orbits around
    private Rigidbody rbFocus;
    // Collider Component relating to self
    private SphereCollider sc;
    // GameObject with Dictionary Dictionary attached 
    private GameObject dictionaryObject;
    // Dictionary containing real value data as decimals
    private Dictionary<string, decimal> data;
    // Dictionary containing lavels as strings
    private Dictionary<string, string> labels;
    // Bool to confirm when Dictionaries have started being filled
    public bool start = false;
    // Bool to confirm when Dictionaries have finished being filled
    public bool finish = false;

    // Awake is the earliest possible event
    // Awake occurs before OnEnable
    void Awake()
    {
        // Label this object's Rigidbody Component
        Rigidbody rb = this.GetComponent<Rigidbody>();
        // Label this object's Sphere Collider Component
        SphereCollider sc = this.GetComponent<SphereCollider>();

        // find the object with the scaling script attached
        // by default have set it to be on the ScaleScriptObject
        // alternative to having scaling script repeated on every object which would waste resources repeating the same calculations
        GameObject scalingObject = GameObject.Find("ScaleScriptObject");

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
        }

        // Set the objectName variable to it's own name
        objectName = this.name;

        GameObject dictionaryObject = GameObject.Find("Dictionary");

        Dictionary<string, decimal> data = dictionaryObject.GetComponent<Dictionary>().data;
        Dictionary<string, string> labels = dictionaryObject.GetComponent<Dictionary>().labels;

    dictionarywait:
        start = dictionaryObject.GetComponent<Dictionary>().start;
        finish = dictionaryObject.GetComponent<Dictionary>().finish;



        // There is a chance this script is called before the Dictionary Script has filled the Dictionary
        // Therefore, must make sure Dictionary has been filled before using it
        // Check if the Dictionary has already started being filled
        // If the Dictionary does not have the "complete" confirmation key, then return to start of loop

        if (start == false)
        {
            goto dictionarywait;
        }
        else if (finish == false)
        {
            goto dictionarywait;
        }

        // Check if the Dictionary has values assigned for that name
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
        else
        {

        }


        // Do nothing if the values have not been set
        if (typeName == "None")
        {

        }
        // Stars are not dependent on the position of other objects
        // Therefore, set their position and velocity first in Awake()
        else if (labels["type" + typeName] == "Star")
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
            rb.rotation = Quaternion.Euler(0.0f, (float)data["obliquity" + obliquityName], 0.0f);

            // convert Spin Period into Unity Scale
            // 3600 comes from hours to seconds - 3600 seconds per hour
            periodSpinRotation = data["periodSpinRotation" + periodSpinRotationName] * 3600.0m / timeUnit;

            // convert Orbital Speed into Unity Scale
            orbitalSpeed = data["orbitalSpeed" + orbitalSpeedName] * (timeUnit / distanceUnit);

            // Set general orbitTilt Variable to this object's value in radians
            orbitTilt = (Mathf.PI / 180) * (float)data["orbitTilt" + orbitTiltName];

            // Finds the name of the object to orbit around in the Dictionary
            // Finds the object with the name identical to the string found in the Dictionary
            // Sets a Rigidbody variable rbFocus to refer to the Rigidbody component of the found object
            Rigidbody rbFocus = GameObject.Find(labels["focus" + focusName]).GetComponent<Rigidbody>();

            // Set distance this object should be placed from the focus object
            distance2to1 = data["distance" + focusName + "to" + objectName];

            // calls function to set initial position
            RelativePosition(rbFocus, distance2to1, distanceUnit);
            // calls function to set initial velocity
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else
        {

        }
    }

    // OnEnable is called when the assigned object is first initialised
    // OnEnable occurs after Awake but before Start
    void OnEnable()
    {
        // Do nothing if the values have not been set
        if (typeName == "None")
        {

        }
        // Planets are only dependent on the position of other Stars
        // Therefore, set their position and velocity second in OnEnable()
        else if (labels["type" + typeName] == "Planet")
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
            rb.rotation = Quaternion.Euler(0.0f, (float)data["obliquity" + obliquityName], 0.0f);

            // convert Spin Period into Unity Scale
            // 3600 comes from hours to seconds - 3600 seconds per hour
            periodSpinRotation = data["periodSpinRotation" + periodSpinRotationName] * 3600.0m / timeUnit;

            // convert Orbital Speed into Unity Scale
            orbitalSpeed = data["orbitalSpeed" + orbitalSpeedName] * (timeUnit / distanceUnit);

            // Set general orbitTilt Variable to this object's value in radians
            orbitTilt = (Mathf.PI / 180) * (float)data["orbitTilt" + orbitTiltName];

            // Finds the name of the object to orbit around in the Dictionary
            // Finds the object with the name identical to the string found in the Dictionary
            // Sets a Rigidbody variable rbFocus to refer to the Rigidbody component of the found object
            Rigidbody rbFocus = GameObject.Find(labels["focus" + focusName]).GetComponent<Rigidbody>();

            // Set distance this object should be placed from the focus object
            distance2to1 = data["distance" + focusName + "to" + objectName];

            // calls function to set initial position
            RelativePosition(rbFocus, distance2to1, distanceUnit);
            // calls function to set initial velocity
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }

        // Asteroids are only dependent on the position of other Stars
        // Therefore, set their position and velocity second in OnEnable()
        else if (labels["type" + typeName] == "Asteroid")
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
            rb.rotation = Quaternion.Euler(0.0f, (float)data["obliquity" + obliquityName], 0.0f);

            // convert Spin Period into Unity Scale
            // 3600 comes from hours to seconds - 3600 seconds per hour
            periodSpinRotation = data["periodSpinRotation" + periodSpinRotationName] * 3600.0m / timeUnit;

            // convert Orbital Speed into Unity Scale
            orbitalSpeed = data["orbitalSpeed" + orbitalSpeedName] * (timeUnit / distanceUnit);

            // Set general orbitTilt Variable to this object's value in radians
            orbitTilt = (Mathf.PI / 180) * (float)data["orbitTilt" + orbitTiltName];

            // Finds the name of the object to orbit around in the Dictionary
            // Finds the object with the name identical to the string found in the Dictionary
            // Sets a Rigidbody variable rbFocus to refer to the Rigidbody component of the found object
            Rigidbody rbFocus = GameObject.Find(labels["focus" + focusName]).GetComponent<Rigidbody>();

            // Set distance this object should be placed from the focus object
            distance2to1 = data["distance" + focusName + "to" + objectName];

            // calls function to set initial position
            RelativePosition(rbFocus, distance2to1, distanceUnit);
            // calls function to set initial velocity
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }

        else
        {
        }
    }

    // Start occurs immediately before the first frame
    // Start occurs after OnEnable
    void Start()
    {
        // Do nothing if the values have not been set
        if (typeName == "None")
        {

        }
        // Moons are dependent on the position of other Planets (which were dependent on Stars)
        // Therefore, set their position and velocity last in Start()
        else if (labels["type" + typeName] == "Moon")
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
            rb.rotation = Quaternion.Euler(0.0f, (float)data["obliquity" + obliquityName], 0.0f);

            // convert Spin Period into Unity Scale
            // 3600 comes from hours to seconds - 3600 seconds per hour
            periodSpinRotation = data["periodSpinRotation" + periodSpinRotationName] * 3600.0m / timeUnit;

            // convert Orbital Speed into Unity Scale
            orbitalSpeed = data["orbitalSpeed" + orbitalSpeedName] * (timeUnit / distanceUnit);

            // Set general orbitTilt Variable to this object's value in radians
            orbitTilt = (Mathf.PI / 180) * (float)data["orbitTilt" + orbitTiltName];

            // Finds the name of the object to orbit around in the Dictionary
            // Finds the object with the name identical to the string found in the Dictionary
            // Sets a Rigidbody variable rbFocus to refer to the Rigidbody component of the found object
            Rigidbody rbFocus = GameObject.Find(labels["focus" + focusName]).GetComponent<Rigidbody>();

            // Set distance this object should be placed from the focus object
            distance2to1 = data["distance" + focusName + "to" + objectName];

            // calls function to set initial position
            RelativePosition(rbFocus, distance2to1, distanceUnit);
            // calls function to set initial velocity
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }

        // Finally if the TypeName has not been identified
        // send a Debug report to state as such
        else
        {
            Debug.Log(this + " could not be placed due to an incompatable typeName, " + typeName + ", which isn't assigned in the " + labels + " Dictionary");
        }
        // Sets the Render Scale to be proportional to radius
        BasicRenderScaling(scaledRadius);

    }
    void FixedUpdate()
    {
        // find the object with the scaling script attached
        // by default have set it to be on the ScaleScriptObject
        // alternative to having scaling script repeated on every object which would waste resources repeating the same calculations
        GameObject scalingObject = GameObject.Find("ScaleScriptObject");

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

            // Resets the Render Scale to be proportional to radius
            BasicRenderScaling(scaledRadius);


            // Update previous Distrance Unit for use at next change of Distance Variable
            oldDistanceUnit = distanceUnit;
        }

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



    // Functions to call

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
            rb.velocity = Mathf.Pow(-1, orbitDirectionFactor) * crossProduct.normalized * (float)orbitalSpeed;
            // Add the velocity of the focal object to this object to set both into the same reference frame
            rb.velocity += rb2.velocity;
        }
    }

    // Function the Render Scale to be proportional to radius
    public void BasicRenderScaling(decimal scaledRadius)
    {

        // Set the factor of proportionality
        // Proportionality of 1 would 1:1 representation of scale in Unity units
        //decimal proportionality = 25.0m;
        // Sets the Render Scaling to a sphere with radius equal to object radius (scaled to simulation units) * proportionality
        //rb.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f) * (float)(scaledRadius * proportionality);

    }

}
*/