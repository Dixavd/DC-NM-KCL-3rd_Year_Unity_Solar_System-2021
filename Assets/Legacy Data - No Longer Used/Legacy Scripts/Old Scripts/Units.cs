using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    // Variables used for the scale of the simulation
    // time Unit
    public decimal  timeUnit = 17529.4m;                 // [s]
    // mass Unit - shifted to keep in decimal range
    public decimal  massUnit = 1e+22m;                   // [kg * 10^-5] shifted to keep in decimal range
    // distance Unit
    public decimal  distanceUnit = 1e+7m;                // [km]

    // Previous values of Variables for manipulation with new ones
    // time Unit
    private decimal oldTimeUnit = 17529.4m;             // [s]
    // mass Unit
    private decimal oldMassUnit = 1e+22m;                // [kg * 10^-5] shifted to keep in decimal range
    // distance Unit
    private decimal oldDistanceUnit = 1e+7m;            // [km]

    // Real value of Gravitational constant G           // [m^3 kg^-1 s^-2]
    public decimal  gravitationalConstantG = 6.6743e-11m;

    // Gravitational Constant to be varied by Unity scale
    // Default set it to real value and units (i.1. assume unity units were 1-to-1)
    public decimal  rescaledG = 6.6743e-11m;

    // Determines direction of orbital rotation
    // Factor value of 1 for Anticlockwise and 2 for Clockwise
    // Factor value of 0 for no rotation
    // Default set to AntiClockwise with Solar System
    public string   orbitDirection = "AntiClockwise";
    public float    orbitDirectionFactor = 1.0f;

    // Determines direction of spin rotation
    // Factor value of 1 for Anticlockwise and 2 for Clockwise
    // Factor value of 0 for no rotation
    // Default set to AntiClockwise with Solar System
    public string   spinDirection = "AntiClockwise";
    public float    spinDirectionFactor = 1.0f;

    // Real Values
    // Sun
    private decimal massSun = 2e+25m;                           // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusSun = 696340m;                        // [km]
    private decimal distanceSunToSun = 0.0m;                    // [km]
    // private decimal periodOrbitSun = 0.0m;                      // [days] currently not used but may be used later
    private decimal orbitalSpeedSun = 19.4m;                    // [km/s]
    private decimal periodSpinRotationSun = 609.12m;            // [hr]
    private float   obliquitySun = 7.25f;                       // [deg]
    private float   orbitTiltSun = 0.0f;                        // [deg]

    // Mercury
    private decimal massMercury = 2.3e+18m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusMercury = 2439.5m;                    // [km]
    private decimal distanceSunToMercury = 5.79e+07m;           // [km]
    // private decimal periodOrbitMercury = 88m;                   // [days] currently not used but may be used later
    private decimal orbitalSpeedMercury = 47.4m;                // [km/s]
    private decimal periodSpinRotationMercury = 1407.6m;        // [hr]
    private float   obliquityMercury = 0.034f;                  // [deg]
    private float   orbitTiltMercury = 3.38f;                   // [deg]

    // Venus
    private decimal massVenus = 4.8e+19m;                       // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusVenus = 6052m;                        // [km]
    private decimal distanceSunToVenus = 1.08e+08m;             // [km]
    // private decimal periodOrbitVenus = 224.7m;                  // [days] currently not used but may be used later
    private decimal orbitalSpeedVenus = 35m;                    // [km/s]
    private decimal periodSpinRotationVenus = 5832.5m;          // [hr]
    private float   obliquityVenus = 177.4f;                    // [deg]
    private float   orbitTiltVenus = 3.86f;                     // [deg]

    // Earth
    private decimal massEarth = 5.97e+19m;                      // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusEarth = 6378m;                        // [km]
    private decimal distanceSunToEarth = 1.5e+08m;              // [km]
    // private decimal periodOrbitEarth = 365.2m;                  // [days] currently not used but may be used later
    private decimal orbitalSpeedEarth = 29.8m;                  // [km/s]
    private decimal periodSpinRotationEarth = 23.9m;            // [hr]
    private float   obliquityEarth = 23.4f;                     // [deg]
    private float   orbitTiltEarth = 7.155f;                    // [deg]

    // Mars
    private decimal massMars = 6.42e+18m;                       // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusMars = 3396m;                         // [km]
    private decimal distanceSunToMars = 2.2e+08m;               // [km]
    // private decimal periodOrbitMars = 687m;                     // [days] currently not used but may be used later
    private decimal orbitalSpeedMars = 24.1m;                   // [km/s]
    private decimal periodSpinRotationMars = 24.6m;             // [hr]
    private float   obliquityMars = 25.2f;                      // [deg]
    private float   orbitTiltMars = 5.65f;                      // [deg]

    // Jupiter
    private decimal massJupiter = 1.898e+22m;                   // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusJupiter = 71492m;                     // [km]
    private decimal distanceSunToJupiter = 7.79e+08m;           // [km]
    // private decimal periodOrbitJupiter = 4331m;                 // [days] currently not used but may be used later
    private decimal orbitalSpeedJupiter = 13.1m;                // [km/s]
    private decimal periodSpinRotationJupiter = 9.9m;           // [hr]
    private float   obliquityJupiter = 3.1f;                    // [deg]
    private float   orbitTiltJupiter = 6.09f;                   // [deg]

    // Saturn
    private decimal massSaturn = 5.68e+21m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusSaturn = 60268m;                      // [km]
    private decimal distanceSunToSaturn = 1.43e+09m;            // [km]
    // private decimal periodOrbitSaturn = 10747m;                 // [days] currently not used but may be used later
    private decimal orbitalSpeedSaturn = 9.7m;                  // [km/s]
    private decimal periodSpinRotationSaturn = 10.7m;           // [hr]
    private float   obliquitySaturn = 26.7f;                    // [deg]
    private float   orbitTiltSaturn = 5.51f;                    // [deg]

    // Uranus
    private decimal massUranus = 8.68e+20m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusUranus = 25559m;                      // [km]
    private decimal distanceSunToUranus = 2.87e+09m;            // [km]
    // private decimal periodOrbitUranus = 30589m;                 // [days] currently not used but may be used later
    private decimal orbitalSpeedUranus = 6.8m;                  // [km/s]
    private decimal periodSpinRotationUranus = 17.2m;           // [hr]
    private float   obliquityUranus = 97.8f;                    // [deg]
    private float   orbitTiltUranus = 6.48f;                    // [deg]

    // Neptune
    private decimal massNeptune = 1.02e+21m;                    // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusNeptune = 24764m;                     // [km]
    private decimal distanceSunToNeptune = 4.5e+09m;            // [km]
    // private decimal periodOrbitNeptune = 59800m;                // [days] currently not used but may be used later
    private decimal orbitalSpeedNeptune = 5.4m;                 // [km/s]
    private decimal periodSpinRotationNeptune = 16.1m;          // [hr]
    private float   obliquityNeptune = 28.3f;                   // [deg]
    private float   orbitTiltNeptune = 6.43f;                   // [deg]

    //MOONS
    
    // Earth's Moon
    private decimal massMoon = 7.30e+17m;                       // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusMoon = 1737.5m;                       // [km]
    private decimal distanceEarthToMoon = 3.84e+05m;            // [km]
    // private decimal periodOrbitMoon = 27.3m;                    // [days] currently not used but may be used later
    private decimal orbitalSpeedMoon = 1.022m;                  // [km/s]
    private decimal periodSpinRotationMoon = 655.7m;            // [hr]
    private float   obliquityMoon = 6.7f;                       // [deg]
    private float   orbitTiltMoon = 5.145f;                     // [deg]

    // Mars' Moon 1 - Phobos
    private decimal massPhobos = 1.06e+11m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusPhobos = 11.2667m;                    // [km]
    private decimal distanceMarsToPhobos = 9.378e+03m;          // [km]
    // private decimal periodOrbitPhobos = 0.31891023m;            // [days] currently not used but may be used later
    private decimal orbitalSpeedPhobos = 2.138m;                // [km/s]
    private decimal periodSpinRotationPhobos = 7.65384m;        // [hr]
    private float   obliquityPhobos = 0.0f;                     // [deg]
    private float   orbitTiltPhobos = 1.08f;                    // [deg]

    // Mars' Moon 2 - Deimos
    private decimal massDeimos = 2.4e+10m;                      // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusDeimos = 6.2m;                        // [km]
    private decimal distanceMarsToDeimos = 2.3459e+04m;         // [km]
    // private decimal periodOrbitDeimos = 1.263m;                 // [days] currently not used but may be used later
    private decimal orbitalSpeedDeimos = 1.3513m;               // [km/s]
    private decimal periodSpinRotationDeimos = 30.29856m;       // [hr]
    private float   obliquityDeimos = 0.0f;                     // [deg]
    private float   orbitTiltDeimos = 1.79f;                    // [deg]

    // Jupiter's Moon 1 - Io
    private decimal massIo = 8.932e+17m;                        // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusIo = 1821.5m;                         // [km]
    private decimal distanceJupiterToIo = 4.217e+05m;           // [km]
    // private decimal periodOrbitIo = 1.769137786m;               // [days] currently not used but may be used later
    private decimal orbitalSpeedIo = 17.334m;                   // [km/s]
    private decimal periodSpinRotationIo = 42.45930686m;        // [hr]
    private float   obliquityIo = 0.0f;                         // [deg]
    private float   orbitTiltIo = 0.04f;                        // [deg]

    // Jupiter's Moon 2 - Europa
    private decimal massEuropa = 4.8e+17m;                      // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusEuropa = 1560.8m;                     // [km]
    private decimal distanceJupiterToEuropa = 6.709e+05m;       // [km]
    // private decimal periodOrbitEuropa = 3.551181m;              // [days] currently not used but may be used later
    private decimal orbitalSpeedEuropa = 13.74m;                // [km/s]
    private decimal periodSpinRotationEuropa = 85.228344m;      // [hr]
    private float   obliquityEuropa = 0.1f;                     // [deg]
    private float   orbitTiltEuropa = 0.47f;                    // [deg]

    // Jupiter's Moon 3 - Callisto
    private decimal massCallisto = 1.0759e+18m;                 // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusCallisto = 2410.3m;                   // [km]
    private decimal distanceJupiterToCallisto = 1.883e+06m;     // [km]
    // private decimal periodOrbitCallisto = 16.6890184m;          // [days] currently not used but may be used later
    private decimal orbitalSpeedCallisto = 8.204m;              // [km/s]
    private decimal periodSpinRotationCallisto = 400.5364416m;  // [hr]
    private float   obliquityCallisto = 0.0f;                   // [deg]
    private float   orbitTiltCallisto = 2.017f;                 // [deg]

    // Jupiter's Moon 4 - Ganymede
    private decimal massGanymede = 1.4819e+18m;                 // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusGanymede = 2631.2m;                   // [km]
    private decimal distanceJupiterToGanymede = 1.0704e+06m;    // [km]
    // private decimal periodOrbitGanymede = 7.15455296m;          // [days] currently not used but may be used later
    private decimal orbitalSpeedGanymede = 10.88m;              // [km/s]
    private decimal periodSpinRotationGanymede = 171.709271m;   // [hr]
    private float   obliquityGanymede = 0.165f;                 // [deg]
    private float   orbitTiltGanymede = 2.214f;                 // [deg]

    // Saturn's Moon 2 - Titan
    private decimal massTitan = 1.3455e+18m;                    // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusTitan = 2575m;                        // [km]
    private decimal distanceSaturnToTitan = 1.2e+06m;           // [km]
    // private decimal periodOrbitTitan = 15.945m;                 // [days] currently not used but may be used later
    private decimal orbitalSpeedTitan = 5.57m;                  // [km/s]
    private decimal periodSpinRotationTitan = 382.68m;          // [hr]
    private float   obliquityTitan = 0.0f;                      // [deg]
    private float   orbitTiltTitan = 0.34854f;                  // [deg]

    // Saturn's Moon 2 - Rhea
    private decimal massRhea = 2.31e+16m;                       // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusRhea = 763.8m;                        // [km]
    private decimal distanceSaturnToRhea = 5.27108e+05m;        // [km]
    // private decimal periodOrbitRhea = 4.518212m;                // [days] currently not used but may be used later
    private decimal orbitalSpeedRhea = 8.48m;                   // [km/s]
    private decimal periodSpinRotationRhea = 108.437088m;       // [hr]
    private float   obliquityRhea = 0.0f;                       // [deg]
    private float   orbitTiltRhea = 0.345f;                     // [deg]

    // Saturn's Moon 3 - Iapetus
    private decimal massIapetus = 1.81e+16m;                    // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusIapetus = 734.5m;                     // [km]
    private decimal distanceSaturnToIapetus = 3.56082e+06m;     // [km]
    // private decimal periodOrbitIapetus = 79.3215m;              // [days] currently not used but may be used later
    private decimal orbitalSpeedIapetus = 3.26m;                // [km/s]
    private decimal periodSpinRotationIapetus = 1903.716m;      // [hr]
    private float   obliquityIapetus = 0.0f;                    // [deg]
    private float   orbitTiltIapetus = 15.47f;                  // [deg]

    // Uranus' Moon 1 - Titania
    private decimal massTitania = 3.42e+16m;                    // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusTitania = 788.9m;                     // [km]
    private decimal distanceUranusToTitania = 4.36e+05m;        // [km]
    // private decimal periodOrbitTitania = 8.706234m;             // [days] currently not used but may be used later
    private decimal orbitalSpeedTitania = 3.64m;                // [km/s]
    private decimal periodSpinRotationTitania = 208.949616m;    // [hr]
    private float   obliquityTitania = 0.0f;                    // [deg]
    private float   orbitTiltTitania = 0.340f;                  // [deg]

    // Uranus' Moon 2 - Oberon
    private decimal massOberon = 2.88e+16m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusOberon = 761.4m;                      // [km]
    private decimal distanceUranusToOberon = 5.84e+05m;         // [km]
    // private decimal periodOrbitOberon = 13.463234m;             // [days] currently not used but may be used later
    private decimal orbitalSpeedOberon = 3.15m;                 // [km/s]
    private decimal periodSpinRotationOberon = 323.117616m;     // [hr]
    private float   obliquityOberon = 0.0f;                     // [deg]
    private float   orbitTiltOberon = 0.058f;                   // [deg]

    // Uranus' Moon 3 - Umbriel
    private decimal massUmbriel = 1.22e+16m;                    // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusUmbriel = 584.7m;                     // [km]
    private decimal distanceUranusToUmbriel = 2.66e+05m;        // [km]
    // private decimal periodOrbitUmbriel = 4.144m;                // [days] currently not used but may be used later
    private decimal orbitalSpeedUmbriel = 4.67m;                // [km/s]
    private decimal periodSpinRotationUmbriel = 99.456m;        // [hr]
    private float   obliquityUmbriel = 0.0f;                    // [deg]
    private float   orbitTiltUmbriel = 0.128f;                  // [deg]

    // Uranus' Moon 4 - Ariel
    private decimal massAriel = 1.29e+16m;                      // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusAriel = 578.9m;                       // [km]
    private decimal distanceUranusToAriel = 1.9e+05m;           // [km]
    // private decimal periodOrbitAriel = 2.52m;                   // [days] currently not used but may be used later
    private decimal orbitalSpeedAriel = 5.51m;                  // [km/s]
    private decimal periodSpinRotationAriel = 60.48m;           // [hr]
    private float   obliquityAriel = 0.0f;                      // [deg]
    private float   orbitTiltAriel = 0.26f;                     // [deg]

    // Neptune's Moon - Triton
    private decimal massTriton = 2.14e+17m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusTriton = 1353.4m;                     // [km]
    private decimal distanceNeptuneToTriton = 3.54759e+05m;     // [km]
    // private decimal periodOrbitTriton = 5.876854m;              // [days] currently not used but may be used later
    private decimal orbitalSpeedTriton = 4.39m;                 // [km/s]
    private decimal periodSpinRotationTriton = 141.044496m;     // [hr]
    private float   obliquityTriton = 0.0f;                     // [deg]
    private float   orbitTiltTriton = 156.885f;                 // [deg]

    //ASTEROIDS

    // Ceres

    private decimal massCeres = 9.393e+15m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusCeres = 469.73m;                      // [km]
    private decimal distanceSunToCeres = 4.19e+08m;             // [km]
    // private decimal periodOrbitCeres = 1683.14570801m;          // [days] currently not used but may be used later
    private decimal orbitalSpeedCeres = 17.905m;                // [km/s]
    private decimal periodSpinRotationCeres = 9.074170m;        // [hr]
    private float   obliquityCeres = 4.0f;                      // [deg]
    private float   orbitTiltCeres = 0.0f;                      // [deg]

    // Vesta

    private decimal massVesta = 2.59e+15m;                      // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusVesta = 262.7m;                       // [km]
    private decimal distanceSunToVesta = 3.53e+08m;             // [km]
    // private decimal periodOrbitVesta = 1325.75m;                // [days] currently not used but may be used later
    private decimal orbitalSpeedVesta = 19.34m;                 // [km/s]
    private decimal periodSpinRotationVesta = 5.34m;            // [hr]
    private float   obliquityVesta = 0.0f;                      // [deg]
    private float   orbitTiltVesta = 0.0f;                      // [deg]


    // Public string to categorise objects
    // Default set to "None"
    public string bodyCategory = "None";
    // Rigidbody Component relating to self
    public Rigidbody rb;
    // Rigidbody Component of the Focal Objects this body orbits around
    public Rigidbody rbFocus;
    // Collider Component relating to self
    public SphereCollider sc;

    // Variable for Spin Rotation, default of no spin
    // Will be replaced by Categorised value for calculations
    private decimal periodSpinRotation = 0.0m;
    // Frequency of Spin roation, default of no spin
    // Floats used for rotations
    private float frequencySpinRotation = 0.0f;

    // Variable for describing the angle-offset of the plane-of-orbit from the z-direction.
    private float orbitTilt = 0.0f;     // [rad]

    // Value to scale mass before converting to float for Rigidbody
    private decimal scaledMass = 0.0m;
    // Value to scale radius before converting to float for collider
    private decimal scaledRadius = 1.0m;
    // Speed of orbit used for OrbitalVelocity function
    private decimal orbitalSpeed = 0.0m;

    // Conversion ratio of old time unit to new time unit
    // Used in order to reduce repeated calculation of the same division
    private decimal conversionTime = 1.0m;
    // Conversion ratio of old distance unit to new distance unit
    // Used in order to reduce repeated calculation of the same division
    private decimal conversionDistance = 1.0m;

    // Awake is the earliest possible event
    // Awake occurs before OnEnable
    void Awake() 
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

        // If Statements to check category of object
        // Once Categorized, sets initial conditions dependent on Unity scaling units
        
        // Calculate Stars first in Awake
        // Initial conditions of Stars are independent of a parent
        if (bodyCategory == "Sun")
        {
            // calculates what scaled mass will be
            scaledMass = massSun / massUnit;
            // sets the mass used by Rigidbody
            rb.mass = (float)scaledMass;
            // calculates what scaled radius will be
            scaledRadius = radiusSun / distanceUnit;
            // sets the radius used for the Collider
            sc.radius = (float)scaledRadius;
            // Define rotation directions for orbit and spin
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            // sets starting rotation to be obliquity angle
            rb.rotation = Quaternion.Euler(0.0f, obliquitySun, 0.0f);
            // convert Spin Period into Unity Scale
            // 3600 comes from hours to seconds - 3600 seconds per hour
            periodSpinRotation = periodSpinRotationSun * 3600.0m / timeUnit;
            // convert Orbital Speed into Unity Scale
            orbitalSpeed = orbitalSpeedSun * (timeUnit / distanceUnit);
            // Set general orbitTilt Variable to this object's value in radians
            orbitTilt = (Mathf.PI / 180) * orbitTiltSun;
            // calls function to set initial position
            RelativePosition(rbFocus, distanceSunToSun, distanceUnit);
            // calls function to set initial velocity
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);


        }
        else if (bodyCategory == "Mercury")
        {;
        }
        else if (bodyCategory == "Venus")
        {
        }
        else if (bodyCategory == "Earth")
        {
        }
        else if (bodyCategory == "Mars")
        {
        }
        else if (bodyCategory == "Jupiter")
        {
        }
        else if (bodyCategory == "Saturn")
        {
        }
        else if (bodyCategory == "Uranus")
        {
        }
        else if (bodyCategory == "Neptune")
        {
        }
        else if (bodyCategory == "Moon")
        {
        }
        else if (bodyCategory == "Phobos")
        {
        }
        else if (bodyCategory == "Deimos")
        {
        }
        else if (bodyCategory == "Io")
        {
        }
        else if (bodyCategory == "Europa")
        {
        }
        else if (bodyCategory == "Callisto")
        {
        }
        else if (bodyCategory == "Ganymede")
        {
        }
        else if (bodyCategory == "Titan")
        {
        }
        else if (bodyCategory == "Rhea")
        {
        }
        else if (bodyCategory == "Iapetus")
        {
        }
        else if (bodyCategory == "Titania")
        {
        }
        else if (bodyCategory == "Oberon")
        {
        }
        else if (bodyCategory == "Umbriel")
        {
        }
        else if (bodyCategory == "Ariel")
        {
        }
        else if (bodyCategory == "Triton")
        {
        }
        else if (bodyCategory == "Ceres")
        {
        }
        else if (bodyCategory == "Vesta")
        {
        }
        else
        {
        }
    }

    // OnEnable is called when the assigned object is first initialised
    // OnEnable occurs after Awake but before Start
    void OnEnable()
    {
        // If Statements to check category of object
        // Once Categorized, sets initial conditions dependent on Unity scaling units

        // Calculate Planets second in OnEnable
        // Initial conditions of Planets are dependent on Stars
        if (bodyCategory == "Sun")
        {
        }
        else if (bodyCategory == "Mercury")
        {
            scaledMass = massMercury / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusMercury / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityMercury, 0.0f);
            periodSpinRotation = periodSpinRotationMercury * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedMercury * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltMercury;
            RelativePosition(rbFocus, distanceSunToMercury, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Venus")
        {
            scaledMass = massVenus / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusVenus / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityVenus, 0.0f);
            periodSpinRotation = periodSpinRotationVenus * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedVenus * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltVenus;
            RelativePosition(rbFocus, distanceSunToVenus, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Earth")
        {
            scaledMass = massEarth / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusEarth / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityEarth, 0.0f);
            periodSpinRotation = periodSpinRotationEarth * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedEarth * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltEarth;
            RelativePosition(rbFocus, distanceSunToEarth, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Mars")
        {
            scaledMass = massMars / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusMars / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityMars, 0.0f);
            periodSpinRotation = periodSpinRotationMars * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedMars * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltMars;
            RelativePosition(rbFocus, distanceSunToMars, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Jupiter")
        {
            scaledMass = massJupiter / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusJupiter / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityJupiter, 0.0f);
            periodSpinRotation = periodSpinRotationJupiter * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedJupiter * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltJupiter;
            RelativePosition(rbFocus, distanceSunToJupiter, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Saturn")
        {
            scaledMass = massSaturn / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusSaturn / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquitySaturn, 0.0f);
            periodSpinRotation = periodSpinRotationSaturn * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedSaturn * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltSaturn;
            RelativePosition(rbFocus, distanceSunToSaturn, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Uranus")
        {
            scaledMass = massUranus / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusUranus / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "Clockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityUranus, 0.0f);
            periodSpinRotation = periodSpinRotationUranus * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedUranus * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltUranus;
            RelativePosition(rbFocus, distanceSunToUranus, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Neptune")
        {
            scaledMass = massNeptune / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusNeptune / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityNeptune, 0.0f);
            periodSpinRotation = periodSpinRotationNeptune * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedNeptune * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltNeptune;
            RelativePosition(rbFocus, distanceSunToNeptune, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Moon")
        {
        }
        else if (bodyCategory == "Phobos")
        {
        }
        else if (bodyCategory == "Deimos")
        {
        }
        else if (bodyCategory == "Io")
        {
        }
        else if (bodyCategory == "Europa")
        {
        }
        else if (bodyCategory == "Callisto")
        {
        }
        else if (bodyCategory == "Ganymede")
        {
        }
        else if (bodyCategory == "Titan")
        {
        }
        else if (bodyCategory == "Rhea")
        {
        }
        else if (bodyCategory == "Iapetus")
        {
        }
        else if (bodyCategory == "Titania")
        {
        }
        else if (bodyCategory == "Oberon")
        {
        }
        else if (bodyCategory == "Umbriel")
        {
        }
        else if (bodyCategory == "Ariel")
        {
        }
        else if (bodyCategory == "Triton")
        {
        }
        else if (bodyCategory == "Ceres")
        {
        }
        else if (bodyCategory == "Vesta")
        {
        }
        else
        {
        }
    }

    // Start occurs immediately before the first frame
    // Start occurs after OnEnable
    void Start()
    {
        // If Statements to check category of object
        // Once Categorized, sets initial conditions dependent on Unity scaling units

        // Calculate Satelites third in Start
        // Initial conditions of Satelites are dependent on Planets (which are already dependent on Stars)
        if (bodyCategory == "Sun")
        {
        }
        else if (bodyCategory == "Mercury")
        {
        }
        else if (bodyCategory == "Venus")
        {
        }
        else if (bodyCategory == "Earth")
        {
        }
        else if (bodyCategory == "Mars")
        {
        }
        else if (bodyCategory == "Jupiter")
        {
        }
        else if (bodyCategory == "Saturn")
        {
        }
        else if (bodyCategory == "Uranus")
        {
        }
        else if (bodyCategory == "Neptune")
        {
        }
        else if (bodyCategory == "Moon")
        {
            scaledMass = massMoon / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusMoon / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityMoon, 0.0f);
            periodSpinRotation = periodSpinRotationMoon * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedMoon * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltMoon;
            RelativePosition(rbFocus, distanceEarthToMoon, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Phobos")
        {
            scaledMass = massPhobos / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusPhobos / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityPhobos, 0.0f);
            periodSpinRotation = periodSpinRotationPhobos * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedPhobos * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltPhobos;
            RelativePosition(rbFocus, distanceMarsToPhobos, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Deimos")
        {
            scaledMass = massDeimos / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusDeimos / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityDeimos, 0.0f);
            periodSpinRotation = periodSpinRotationDeimos * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedDeimos * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltDeimos;
            RelativePosition(rbFocus, distanceMarsToDeimos, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Io")
        {
            scaledMass = massIo / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusIo / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityIo, 0.0f);
            periodSpinRotation = periodSpinRotationIo * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedIo * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltIo;
            RelativePosition(rbFocus, distanceJupiterToIo, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Europa")
        {
            scaledMass = massEuropa / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusEuropa / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityEuropa, 0.0f);
            periodSpinRotation = periodSpinRotationEuropa * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedEuropa * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltEuropa;
            RelativePosition(rbFocus, distanceJupiterToEuropa, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Callisto")
        {
            scaledMass = massCallisto / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusCallisto / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityCallisto, 0.0f);
            periodSpinRotation = periodSpinRotationCallisto * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedCallisto * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltCallisto;
            RelativePosition(rbFocus, distanceJupiterToCallisto, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Ganymede")
        {
            scaledMass = massGanymede / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusGanymede / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityGanymede, 0.0f);
            periodSpinRotation = periodSpinRotationGanymede * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedGanymede * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltGanymede;
            RelativePosition(rbFocus, distanceJupiterToGanymede, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Titan")
        {
            scaledMass = massTitan / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusTitan / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityTitan, 0.0f);
            periodSpinRotation = periodSpinRotationTitan * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedTitan * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltTitan;
            RelativePosition(rbFocus, distanceSaturnToTitan, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Rhea")
        {
            scaledMass = massRhea / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusRhea / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityRhea, 0.0f);
            periodSpinRotation = periodSpinRotationRhea * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedRhea * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltRhea;
            RelativePosition(rbFocus, distanceSaturnToRhea, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Iapetus")
        {
            scaledMass = massIapetus / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusIapetus / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityIapetus, 0.0f);
            periodSpinRotation = periodSpinRotationIapetus * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedIapetus * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltIapetus;
            RelativePosition(rbFocus, distanceSaturnToIapetus, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Titania")
        {
            scaledMass = massTitania / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusTitania / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityTitania, 0.0f);
            periodSpinRotation = periodSpinRotationTitania * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedTitania * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltTitania;
            RelativePosition(rbFocus, distanceUranusToTitania, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Oberon")
        {
            scaledMass = massOberon / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusOberon / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityOberon, 0.0f);
            periodSpinRotation = periodSpinRotationOberon * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedOberon * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltOberon;
            RelativePosition(rbFocus, distanceUranusToOberon, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Umbriel")
        {
            scaledMass = massUmbriel / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusUmbriel / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityUmbriel, 0.0f);
            periodSpinRotation = periodSpinRotationUmbriel * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedUmbriel * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltUmbriel;
            RelativePosition(rbFocus, distanceUranusToUmbriel, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Ariel")
        {
            scaledMass = massAriel / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusAriel / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityAriel, 0.0f);
            periodSpinRotation = periodSpinRotationAriel * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedAriel * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltAriel;
            RelativePosition(rbFocus, distanceUranusToAriel, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Triton")
        {
            scaledMass = massTriton / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusTriton / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityTriton, 0.0f);
            periodSpinRotation = periodSpinRotationTriton * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedTriton * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltTriton;
            RelativePosition(rbFocus, distanceNeptuneToTriton, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Ceres")
        {
            scaledMass = massCeres / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusCeres / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityCeres, 0.0f);
            periodSpinRotation = periodSpinRotationCeres * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedCeres * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltCeres;
            RelativePosition(rbFocus, distanceSunToCeres, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        else if (bodyCategory == "Vesta")
        {
            scaledMass = massVesta / massUnit;
            rb.mass = (float)scaledMass;
            scaledRadius = radiusVesta / distanceUnit;
            sc.radius = (float)scaledRadius;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityVesta, 0.0f);
            periodSpinRotation = periodSpinRotationVesta * 3600m / timeUnit;
            orbitalSpeed = orbitalSpeedVesta * (timeUnit / distanceUnit);
            orbitTilt = (Mathf.PI / 180) * orbitTiltVesta;
            RelativePosition(rbFocus, distanceSunToVesta, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitTilt, orbitDirection);
        }
        // If Object body name hasn't been found after going through all the Satelites
        // Set object to values that null values that should avoid breaking the simulation
        else
        {
            scaledMass = 0.0m;
            rb.mass = (float)scaledMass;
            scaledRadius = 0.0m;
            sc.radius = (float)scaledRadius;
            orbitDirection = "None";
            spinDirection = "None";
            periodSpinRotation = 0.0m;
            orbitTilt = 0.0f;

            Debug.Log(this + " cannot be set because it's bodyCategory, " + bodyCategory + ", has no values");
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
    public void RelativePosition(Rigidbody rb2, decimal distance1to2 , decimal distanceScaleFactor)
    {   // do not change position if object's focal point is itself - i.e. largest object doesn't orbit self
        if (rb.position == rb2.position)
        { }
        else
        {
            // Calculate the vector between the current positions of This Object, 1, and Another Object, 2
            Vector3 radius = rb.position - rb2.position;
            // set position of 1 a predetermined distance away from 2
            rb.position = rb2.position + (radius.normalized * (float)(distance1to2 / distanceScaleFactor));

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
        {}
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
        /*
        // Set the factor of proportionality
        // Proportionality of 1 would 1:1 representation of scale in Unity units
        decimal proportionality = 25.0m;
        // Sets the Render Scaling to a sphere with radius equal to object radius (scaled to simulation units) * proportionality
        rb.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f) * (float)(scaledRadius * proportionality);
        */
    }
}