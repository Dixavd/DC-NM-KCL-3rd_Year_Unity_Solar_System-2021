
// This is a Backup copy of the original Units script
// This is prior to changing the numbers from floats to doubles and decimals

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
public class Units : MonoBehaviour
{
    // Variables used for the scale of the simulation
    // time Unit
    public float timeUnit = 17529.4f;       // [s]
    // mass Unit
    public float massUnit = 1e+27f;         // [kg]
    // distance Unit
    public float distanceUnit = 1e+7f;      // [km]

    // Previous values of Variables for manipulation with new ones
    // time Unit
    private float oldTimeUnit = 17529.4f;       // [s]
    // mass Unit
    private float oldMassUnit = 1e+27f;         // [kg]
    // distance Unit
    private float oldDistanceUnit = 1e+7f;      // [km]

    // Real value of Gravitational constant G   // [m^3 kg^-1 s^-2]
    public float gravitationalConstantG = 6.6743e-11f;

    // Gravitational Constant to be varied by Unity scale
    // Default set it to real value and units (i.1. assume unity units were 1-to-1)
    public float rescaledG = 6.6743e-11f;

    // Determines direction of orbital rotation
    // Factor value of 1 for Anticlockwise and 2 for Clockwise
    // Factor value of 0 for no rotation
    // Default set to AntiClockwise with Solar System
    public string orbitDirection = "AntiClockwise";
    public float orbitDirectionFactor = 1.0f;

    // Determines direction of spin rotation
    // Factor value of 1 for Anticlockwise and 2 for Clockwise
    // Factor value of 0 for no rotation
    // Default set to AntiClockwise with Solar System
    public string spinDirection = "AntiClockwise";
    public float spinDirectionFactor = 1.0f;

    // Real Values
    // Sun
    private float massSun = 2e+30f;                      // [kg]
    private float radiusSun = 696340f;                   // [km]
    private float distanceSunToSun = 0.0f;               // [km]
    private float periodOrbitSun = 0.0f;                 // [days] currently not used but may be used later
    private float orbitalSpeedSun = 19.4f;               // [km/s]
    private float periodSpinRotationSun = 609.12f;          // [hr]
    private float obliquitySun = 7.25f;                  // [deg]
    private float orbitTiltSun = 0.0f;                   // [deg] currently not used but may be used later

    // Mercury
    private float massMercury = 2.3e+23f;                // [kg]
    private float radiusMercury = 2439.5f;               // [km]
    private float distanceSunToMercury = 5.79e+07f;      // [km]
    private float periodOrbitMercury = 88f;              // [days] currently not used but may be used later
    private float orbitalSpeedMercury = 47.4f;           // [km/s]
    private float periodSpinRotationMercury = 1407.6f;   // [hr]
    private float obliquityMercury = 0.034f;             // [deg]
    private float orbitTiltMercury = 3.38f;              // [deg] currently not used but may be used later

    // Venus
    private float massVenus = 4.8e+24f;                  // [kg]
    private float radiusVenus = 6052f;                   // [km]
    private float distanceSunToVenus = 1.08e+08f;        // [km]
    private float periodOrbitVenus = 224.7f;             // [days] currently not used but may be used later
    private float orbitalSpeedVenus = 35f;               // [km/s]
    private float periodSpinRotationVenus = 5832.5f;     // [hr]
    private float obliquityVenus = 177.4f;               // [deg]
    private float orbitTiltVenus = 3.86f;                // [deg] currently not used but may be used later

    // Earth
    private float massEarth = 5.97e+24f;                 // [kg]
    private float radiusEarth = 6378f;                   // [km]
    private float distanceSunToEarth = 1.5e+08f;         // [km]
    private float periodOrbitEarth = 365.2f;             // [days] currently not used but may be used later
    private float orbitalSpeedEarth = 29.8f;             // [km/s]
    private float periodSpinRotationEarth = 23.9f;       // [hr]
    private float obliquityEarth = 23.4f;                // [deg]
    private float orbitTiltEarth = 7.155f;               // [deg] currently not used but may be used later

    // Mars
    private float massMars = 6.42e+23f;                  // [kg]
    private float radiusMars = 3396f;                    // [km]
    private float distanceSunToMars = 2.2e+08f;          // [km]
    private float periodOrbitMars = 687f;                // [days] currently not used but may be used later
    private float orbitalSpeedMars = 24.1f;              // [km/s]
    private float periodSpinRotationMars = 24.6f;        // [hr]
    private float obliquityMars = 25.2f;                 // [deg]
    private float orbitTiltMars = 5.65f;                 // [deg] currently not used but may be used later

    // Jupiter
    private float massJupiter = 1.898e+27f;              // [kg]
    private float radiusJupiter = 71492f;                // [km]
    private float distanceSunToJupiter = 7.79e+08f;      // [km]
    private float periodOrbitJupiter = 4331f;            // [days] currently not used but may be used later
    private float orbitalSpeedJupiter = 13.1f;           // [km/s]
    private float periodSpinRotationJupiter = 9.9f;      // [hr]
    private float obliquityJupiter = 3.1f;               // [deg]
    private float orbitTiltJupiter = 6.09f;              // [deg] currently not used but may be used later

    // Saturn
    private float massSaturn = 5.68e+26f;                // [kg]
    private float radiusSaturn = 60268f;                 // [km]
    private float distanceSunToSaturn = 1.43e+09f;       // [km]
    private float periodOrbitSaturn = 10747f;            // [days] currently not used but may be used later
    private float orbitalSpeedSaturn = 9.7f;             // [km/s]
    private float periodSpinRotationSaturn = 10.7f;      // [hr]
    private float obliquitySaturn = 26.7f;               // [deg]
    private float orbitTiltSaturn = 5.51f;               // [deg] currently not used but may be used later

    // Uranus
    private float massUranus = 8.68e+25f;                // [kg]
    private float radiusUranus = 25559f;                 // [km]
    private float distanceSunToUranus = 2.87e+09f;       // [km]
    private float periodOrbitUranus = 30589f;            // [days] currently not used but may be used later
    private float orbitalSpeedUranus = 6.8f;             // [km/s]
    private float periodSpinRotationUranus = 17.2f;      // [hr]
    private float obliquityUranus = 97.8f;               // [deg]
    private float orbitTiltUranus = 6.48f;               // [deg] currently not used but may be used later

    // Neptune
    private float massNeptune = 1.02e+26f;               // [kg]
    private float radiusNeptune = 24764f;                // [km]
    private float distanceSunToNeptune = 4.5e+09f;       // [km]
    private float periodOrbitNeptune = 59800f;           // [days] currently not used but may be used later
    private float orbitalSpeedNeptune = 5.4f;            // [km/s]
    private float periodSpinRotationNeptune = 16.1f;     // [hr]
    private float obliquityNeptune = 28.3f;              // [deg]
    private float orbitTiltNeptune = 6.43f;              // [deg] currently not used but may be used later

    //MOONS

    // Earth's Moon
    private float massMoon = 7.30e+22f;               // [kg]
    private float radiusMoon = 1737.5f;                // [km]
    private float distanceEarthToMoon = 3.84e+05f;       // [km]
    private float periodOrbitMoon = 27.3f;           // [days] currently not used but may be used later
    private float orbitalSpeedMoon = 1.0f;            // [km/s]
    private float periodSpinRotationMoon = 655.7f;     // [hr]
    private float obliquityMoon = 6.7f;              // [deg]
    private float orbitTiltMoon = 5.145f;              // [deg] currently not used but may be used later

    // Mars' Moon 1 - Phobos
    private float massPhobos = 1.06e+16f;               // [kg]
    private float radiusPhobos = 11.2667f;                // [km]
    private float distanceMarsToPhobos = 9.378e+03f;       // [km]
    private float periodOrbitPhobos = 0.31891023f;           // [days] currently not used but may be used later
    private float orbitalSpeedPhobos = 2.138f;            // [km/s]
    private float periodSpinRotationPhobos = 7.65384f;     // [hr]
    private float obliquityPhobos = 0.0f;              // [deg]
    private float orbitTiltPhobos = 1.08f;              // [deg] currently not used but may be used later

    // Mars' Moon 2 - Deimos
    private float massDeimos = 2.4e+15f;               // [kg]
    private float radiusDeimos = 6.2f;                // [km]
    private float distanceMarsToDeimos = 2.3459e+04f;       // [km]
    private float periodOrbitDeimos = 1.263f;           // [days] currently not used but may be used later
    private float orbitalSpeedDeimos = 1.3513f;            // [km/s]
    private float periodSpinRotationDeimos = 30.29856f;     // [hr]
    private float obliquityDeimos = 0.0f;              // [deg]
    private float orbitTiltDeimos = 1.79f;              // [deg] currently not used but may be used later

    // Jupiter's Moon 1 - Io
    private float massIo = 8.932e+22f;               // [kg]
    private float radiusIo = 1821.5f;                // [km]
    private float distanceJupiterToIo = 4.217e+05f;       // [km]
    private float periodOrbitIo = 1.769137786f;           // [days] currently not used but may be used later
    private float orbitalSpeedIo = 17.334f;            // [km/s]
    private float periodSpinRotationIo = 42.45930686f;     // [hr]
    private float obliquityIo = 0.0f;              // [deg]
    private float orbitTiltIo = 0.04f;              // [deg] currently not used but may be used later

    // Jupiter's Moon 2 - Europa
    private float massEuropa = 4.8e+22f;               // [kg]
    private float radiusEuropa = 1560.8f;                // [km]
    private float distanceJupiterToEuropa = 6.709e+05f;       // [km]
    private float periodOrbitEuropa = 3.551181f;           // [days] currently not used but may be used later
    private float orbitalSpeedEuropa = 13.74f;            // [km/s]
    private float periodSpinRotationEuropa = 85.228344f;     // [hr]
    private float obliquityEuropa = 0.1f;              // [deg]
    private float orbitTiltEuropa = 0.47f;              // [deg] currently not used but may be used later

    // Jupiter's Moon 3 - Callisto
    private float massCallisto = 1.0759e+23f;               // [kg]
    private float radiusCallisto = 2410.3f;                // [km]
    private float distanceJupiterToCallisto = 1.883e+06f;       // [km]
    private float periodOrbitCallisto = 16.6890184f;           // [days] currently not used but may be used later
    private float orbitalSpeedCallisto = 8.204f;            // [km/s]
    private float periodSpinRotationCallisto = 400.5364416f;     // [hr]
    private float obliquityCallisto = 0.0f;              // [deg]
    private float orbitTiltCallisto = 2.017f;              // [deg] currently not used but may be used later

    // Jupiter's Moon 4 - Ganymede
    private float massGanymede = 1.4819e+23f;               // [kg]
    private float radiusGanymede = 2631.2f;                // [km]
    private float distanceJupiterToGanymede = 1.0704e+06f;       // [km]
    private float periodOrbitGanymede = 7.15455296f;           // [days] currently not used but may be used later
    private float orbitalSpeedGanymede = 10.88f;            // [km/s]
    private float periodSpinRotationGanymede = 171.709271f;     // [hr]
    private float obliquityGanymede = 0.165f;              // [deg]
    private float orbitTiltGanymede = 2.214f;              // [deg] currently not used but may be used later

    // Saturn's Moon 2 - Titan
    private float massTitan = 1.3455e+23f;               // [kg]
    private float radiusTitan = 2575f;                // [km]
    private float distanceSaturnToTitan = 1.2e+06f;       // [km]
    private float periodOrbitTitan = 15.945f;           // [days] currently not used but may be used later
    private float orbitalSpeedTitan = 5.57f;            // [km/s]
    private float periodSpinRotationTitan = 382.68f;     // [hr]
    private float obliquityTitan = 0.0f;              // [deg]
    private float orbitTiltTitan = 0.34854f;              // [deg] currently not used but may be used later

    // Saturn's Moon 2 - Rhea
    private float massRhea = 2.31e+21f;               // [kg]
    private float radiusRhea = 763.8f;                // [km]
    private float distanceSaturnToRhea = 5.27108e+05f;       // [km]
    private float periodOrbitRhea = 4.518212f;           // [days] currently not used but may be used later
    private float orbitalSpeedRhea = 8.48f;            // [km/s]
    private float periodSpinRotationRhea = 108.437088f;     // [hr]
    private float obliquityRhea = 0.0f;              // [deg]
    private float orbitTiltRhea = 0.345f;              // [deg] currently not used but may be used later

    // Saturn's Moon 3 - Iapetus
    private float massIapetus = 1.81e+21f;               // [kg]
    private float radiusIapetus = 734.5f;                // [km]
    private float distanceSaturnToIapetus = 3.56082e+06f;       // [km]
    private float periodOrbitIapetus = 79.3215f;           // [days] currently not used but may be used later
    private float orbitalSpeedIapetus = 3.26f;            // [km/s]
    private float periodSpinRotationIapetus = 1903.716f;     // [hr]
    private float obliquityIapetus = 0.0f;              // [deg]
    private float orbitTiltIapetus = 15.47f;              // [deg] currently not used but may be used later

    // Uranus' Moon 1 - Titania
    private float massTitania = 3.42e+21f;               // [kg]
    private float radiusTitania = 788.9f;                // [km]
    private float distanceUranusToTitania = 4.36e+05f;       // [km]
    private float periodOrbitTitania = 8.706234f;           // [days] currently not used but may be used later
    private float orbitalSpeedTitania = 3.64f;            // [km/s]
    private float periodSpinRotationTitania = 208.949616f;     // [hr]
    private float obliquityTitania = 0.0f;              // [deg]
    private float orbitTiltTitania = 0.340f;              // [deg] currently not used but may be used later

    // Uranus' Moon 2 - Oberon
    private float massOberon = 2.88e+21f;               // [kg]
    private float radiusOberon = 761.4f;                // [km]
    private float distanceUranusToOberon = 5.84e+05f;       // [km]
    private float periodOrbitOberon = 13.463234f;           // [days] currently not used but may be used later
    private float orbitalSpeedOberon = 3.15f;            // [km/s]
    private float periodSpinRotationOberon = 323.117616f;     // [hr]
    private float obliquityOberon = 0.0f;              // [deg]
    private float orbitTiltOberon = 0.058f;              // [deg] currently not used but may be used later

    // Uranus' Moon 3 - Umbriel
    private float massUmbriel = 1.22e+21f;               // [kg]
    private float radiusUmbriel = 584.7f;                // [km]
    private float distanceUranusToUmbriel = 2.66e+05f;       // [km]
    private float periodOrbitUmbriel = 4.144f;           // [days] currently not used but may be used later
    private float orbitalSpeedUmbriel = 4.67f;            // [km/s]
    private float periodSpinRotationUmbriel = 99.456f;     // [hr]
    private float obliquityUmbriel = 0.0f;              // [deg]
    private float orbitTiltUmbriel = 0.128f;              // [deg] currently not used but may be used later

    // Uranus' Moon 4 - Ariel
    private float massAriel = 1.29e+21f;               // [kg]
    private float radiusAriel = 578.9f;                // [km]
    private float distanceUranusToAriel = 1.9e+05f;       // [km]
    private float periodOrbitAriel = 2.52f;           // [days] currently not used but may be used later
    private float orbitalSpeedAriel = 5.51f;            // [km/s]
    private float periodSpinRotationAriel = 60.48f;     // [hr]
    private float obliquityAriel = 0.0f;              // [deg]
    private float orbitTiltAriel = 0.26f;              // [deg] currently not used but may be used later

    // Neptune's Moon - Triton
    private float massTriton = 2.14e+22f;               // [kg]
    private float radiusTriton = 1353.4f;                // [km]
    private float distanceNeptuneToTriton = 3.54759e+05f;       // [km]
    private float periodOrbitTriton = 5.876854f;           // [days] currently not used but may be used later
    private float orbitalSpeedTriton = 4.39f;            // [km/s]
    private float periodSpinRotationTriton = 141.044496f;     // [hr]
    private float obliquityTriton = 0.0f;              // [deg]
    private float orbitTiltTriton = 156.885f;              // [deg] currently not used but may be used later

    //ASTEROIDS

    // Ceres

    private float massCeres = 9.393e+20f;               // [kg]
    private float radiusCeres = 469.73f;                // [km]
    private float distanceSunToCeres = 4.19e+08f;       // [km]
    private float periodOrbitCeres = 1683.14570801f;           // [days] currently not used but may be used later
    private float orbitalSpeedCeres = 17.905f;            // [km/s]
    private float periodSpinRotationCeres = 9.074170f;     // [hr]
    private float obliquityCeres = 4.0f;              // [deg]
    private float orbitTiltCeres = 0.0f;              // [deg] currently not used but may be used later

    // Vesta

    private float massVesta = 2.59e+20f;               // [kg]
    private float radiusVesta = 262.7f;                // [km]
    private float distanceSunToVesta = 3.53e+08f;       // [km]
    private float periodOrbitVesta = 1325.75f;           // [days] currently not used but may be used later
    private float orbitalSpeedVesta = 19.34f;            // [km/s]
    private float periodSpinRotationVesta = 5.342f;     // [hr]
    private float obliquityVesta = 0.0f;              // [deg]
    private float orbitTiltVesta = 0.0f;              // [deg] currently not used but may be used later


    // Public string to categorise objects
    // Default set to "None"
    public string bodyCategory = "None";
    // Rigidbody Component relating to self
    public Rigidbody rb;
    // Rigidbody Component of the Focal Objects this body orbits around
    public Rigidbody rbFocus;
    // Collider Component relating to self
    public SphereCollider sc;
    // Vecter of Euler Angles to be used for spin rotation
    // Default set for no spin
    private Vector3 eulerAngleVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    // Variable for Spin Rotation, default of no spin
    // Will be replaced by Categorised value for calculations
    private float periodSpinRotation = 0.0f;

    private float scaledMass = 0.0f;
    private float orbitalSpeed = 0.0f;
    private float conversionTime = 1.0f;
    private float conversionDistance = 1.0f;

    public Vector3 orbitalNormal = new Vector3(0.0f, 0.0f, 1.0f);


    // OnEnable is called when the assigned object is first initialised
    void OnEnable()
    {
        // find the object with the scaling script attached
        // by default have set it to be on the camera
        // alternative to having scaling script repeated on every object which would waste resources repeating the same calculations
        GameObject scalingObject = GameObject.Find("Main Camera");

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
        if (bodyCategory == "Sun")
        {
            // calculates what scaled mass will be
            scaledMass = massSun / massUnit;
            // sets the mass used by Rigidbody
            rb.mass = scaledMass;
            // sets radius used for collider (independent of rendering)
            sc.radius = radiusSun / distanceUnit;
            // Define rotation directions for orbit and spin
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            // sets starting rotation to be obliquity angle
            rb.rotation = Quaternion.Euler(0.0f, obliquitySun, 0.0f);
            // convert Spin Period into Unity Scale
            // 3600 comes from hours to seconds - 3600 seconds per hour
            periodSpinRotation = periodSpinRotationSun * 3600f * timeUnit;
            // convert Orbital Speed into Unity Scale
            orbitalSpeed = orbitalSpeedSun * (timeUnit / distanceUnit);
            // calls function to set initial position
            RelativePosition(rbFocus, distanceSunToSun, distanceUnit);
            // calls function to set initial velocity
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);


        }
        else if (bodyCategory == "Mercury")
        {
            scaledMass = massMercury / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusMercury / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityMercury, 0.0f);
            periodSpinRotation = periodSpinRotationMercury * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedMercury * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceSunToMercury, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Venus")
        {
            scaledMass = massVenus / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusVenus / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityVenus, 0.0f);
            periodSpinRotation = periodSpinRotationVenus * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedVenus * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceSunToVenus, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Earth")
        {
            scaledMass = massEarth / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusEarth / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityEarth, 0.0f);
            periodSpinRotation = periodSpinRotationEarth * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedEarth * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceSunToEarth, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Mars")
        {
            scaledMass = massMars / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusMars / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityMars, 0.0f);
            periodSpinRotation = periodSpinRotationMars * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedMars * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceSunToMars, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Jupiter")
        {
            scaledMass = massJupiter / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusJupiter / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityJupiter, 0.0f);
            periodSpinRotation = periodSpinRotationJupiter * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedJupiter * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceSunToJupiter, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Saturn")
        {
            scaledMass = massSaturn / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusSaturn / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquitySaturn, 0.0f);
            periodSpinRotation = periodSpinRotationSaturn * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedSaturn * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceSunToSaturn, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Uranus")
        {
            scaledMass = massUranus / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusUranus / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "Clockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityUranus, 0.0f);
            periodSpinRotation = periodSpinRotationUranus * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedUranus * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceSunToUranus, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Neptune")
        {
            scaledMass = massNeptune / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusNeptune / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityNeptune, 0.0f);
            periodSpinRotation = periodSpinRotationNeptune * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedNeptune * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceSunToNeptune, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Moon")
        {
            scaledMass = massMoon / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusMoon / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityMoon, 0.0f);
            periodSpinRotation = periodSpinRotationMoon * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedMoon * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceEarthToMoon, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Phobos")
        {
            scaledMass = massPhobos / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusPhobos / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityPhobos, 0.0f);
            periodSpinRotation = periodSpinRotationPhobos * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedPhobos * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceMarsToPhobos, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Deimos")
        {
            scaledMass = massDeimos / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusDeimos / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityDeimos, 0.0f);
            periodSpinRotation = periodSpinRotationDeimos * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedDeimos * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceMarsToDeimos, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Io")
        {
            scaledMass = massIo / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusIo / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityIo, 0.0f);
            periodSpinRotation = periodSpinRotationIo * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedIo * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceJupiterToIo, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Europa")
        {
            scaledMass = massEuropa / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusEuropa / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityEuropa, 0.0f);
            periodSpinRotation = periodSpinRotationEuropa * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedEuropa * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceJupiterToEuropa, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Callisto")
        {
            scaledMass = massCallisto / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusCallisto / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityCallisto, 0.0f);
            periodSpinRotation = periodSpinRotationCallisto * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedCallisto * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceJupiterToCallisto, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Ganymede")
        {
            scaledMass = massGanymede / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusGanymede / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityGanymede, 0.0f);
            periodSpinRotation = periodSpinRotationGanymede * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedGanymede * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceJupiterToGanymede, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Titan")
        {
            scaledMass = massTitan / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusTitan / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityTitan, 0.0f);
            periodSpinRotation = periodSpinRotationTitan * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedTitan * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceSaturnToTitan, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Rhea")
        {
            scaledMass = massRhea / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusRhea / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityRhea, 0.0f);
            periodSpinRotation = periodSpinRotationRhea * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedRhea * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceSaturnToRhea, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Iapetus")
        {
            scaledMass = massIapetus / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusIapetus / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityIapetus, 0.0f);
            periodSpinRotation = periodSpinRotationIapetus * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedIapetus * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceSaturnToIapetus, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Titania")
        {
            scaledMass = massTitania / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusTitania / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityTitania, 0.0f);
            periodSpinRotation = periodSpinRotationTitania * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedTitania * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceUranusToTitania, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Oberon")
        {
            scaledMass = massOberon / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusOberon / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityOberon, 0.0f);
            periodSpinRotation = periodSpinRotationOberon * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedOberon * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceUranusToOberon, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Umbriel")
        {
            scaledMass = massUmbriel / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusUmbriel / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityUmbriel, 0.0f);
            periodSpinRotation = periodSpinRotationUmbriel * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedUmbriel * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceUranusToUmbriel, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Ariel")
        {
            scaledMass = massAriel / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusAriel / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityAriel, 0.0f);
            periodSpinRotation = periodSpinRotationAriel * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedAriel * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceUranusToAriel, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Triton")
        {
            scaledMass = massTriton / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusTriton / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityTriton, 0.0f);
            periodSpinRotation = periodSpinRotationTriton * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedTriton * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceNeptuneToTriton, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Ceres")
        {
            scaledMass = massCeres / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusCeres / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityCeres, 0.0f);
            periodSpinRotation = periodSpinRotationCeres * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedCeres * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceSunToCeres, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else if (bodyCategory == "Vesta")
        {
            scaledMass = massVesta / massUnit;
            rb.mass = scaledMass;
            sc.radius = radiusVesta / distanceUnit;
            orbitDirection = "AntiClockwise";
            spinDirection = "AntiClockwise";
            rb.rotation = Quaternion.Euler(0.0f, obliquityVesta, 0.0f);
            periodSpinRotation = periodSpinRotationVesta * 3600f * timeUnit;
            orbitalSpeed = orbitalSpeedVesta * (timeUnit / distanceUnit);
            RelativePosition(rbFocus, distanceSunToVesta, distanceUnit);
            OrbitalVelocity(rbFocus, orbitalSpeed, orbitalNormal, orbitDirection);
        }
        else
        {
            scaledMass = 0.0f;
            rb.mass = scaledMass;
            sc.radius = 0.0f;
            orbitDirection = "None";
            spinDirection = "None";
            periodSpinRotation = 0.0f;
        }
    }

    void FixedUpdate()
    {
        // find the object with the scaling script attached
        // by default have set it to be on the camera
        // alternative to having scaling script repeated on every object which would waste resources repeating the same calculations
        GameObject scalingObject = GameObject.Find("Main Camera");

        // Check if the Time scaling Unit has changed, and update it if so
        if (timeUnit == scalingObject.GetComponent<Scale>().timeVariable)
        { }
        else
        {
            // set Time Unit to new value of variable
            timeUnit = scalingObject.GetComponent<Scale>().timeVariable;

            // Convert time-dependent properties to new Time Unit
            conversionTime = timeUnit / oldTimeUnit;
            rb.velocity *= conversionTime;
            rb.angularVelocity *= conversionTime;
            periodSpinRotation *= 1f / conversionTime;

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
            scaledMass *= massUnit / oldMassUnit;
            rb.mass = scaledMass;

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

            // Convert mass-dependent properties to new Mass Unit
            conversionDistance = (distanceUnit / oldDistanceUnit);
            rb.position *= 1f / conversionDistance;
            rb.velocity *= 1f / conversionDistance;

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
        if (periodSpinRotation == 0.0f)
        { }
        else
        {
            // Function to implement spin
            // Calculate vector of Euler Angles for Spin Rotation
            Vector3 eulerAngleVelocity = new Vector3(0.0f, 0.0f, (1.0f / periodSpinRotation));
            // Calculate whether rotation will be positive or negative
            eulerAngleVelocity *= Mathf.Pow(-1, spinDirectionFactor);
            // Turn Euler Angle Vector into rotation at each time step
            rb.MoveRotation(rb.rotation * Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime));
        }

    }



    // Functions to call

    // Function to set position of oject to a defined distance away from another object it will orbit around
    public void RelativePosition(Rigidbody rb2, float distance1to2, float distanceScaleFactor)
    {   // do not change position if object's focal point is itself - i.e. largest object doesn't orbit self
        if (rb.position == rb2.position)
        { }
        else
        {
            // Calculate the vector between the current positions of This Object, 1, and Another Object, 2
            Vector3 radius = rb.position - rb2.position;
            // set position of 1 a predetermined distance away from 2
            rb.position = radius.normalized * (distance1to2 / distanceScaleFactor);
        }
    }

    // Function to set the velocity of an object to rotate around another body
    public void OrbitalVelocity(Rigidbody rb2, float orbitalSpeed, Vector3 orbitalNormal, string orbitDirection)
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
            // Set Normal normalized vector in z-Direction
            //Vector3 orbitalNormal = new Vector3(0.0f, 0.0f, 1.0f);
            // Calculate the vector between the current positions of This Object, 1, and Another Object, 2
            Vector3 radius = rb.position - rb2.position;
            // Calculate cross product between the Radius of Orbit the Normal to Orbit
            Vector3 crossProduct = Vector3.Cross(orbitalNormal, radius);
            // Create orbital velocity by taking direction of cross product multiplied by predefined speed
            rb.velocity = Mathf.Pow(-1, orbitDirectionFactor) * crossProduct.normalized * orbitalSpeed;
        }
    }
}
*/

/*
public class Units : MonoBehaviour
{
    // Variables used for the scale of the simulation
    // time Unit
    public decimal timeUnit = 17529.4m;                 // [s]
    // mass Unit - shifted to keep in decimal range
    public decimal massUnit = 1e+22m;                   // [kg * 10^-5] shifted to keep in decimal range
    // distance Unit
    public decimal distanceUnit = 1e+7m;                // [km]

    // Previous values of Variables for manipulation with new ones
    // time Unit
    private decimal oldTimeUnit = 17529.4m;             // [s]
    // mass Unit
    private decimal oldMassUnit = 1e+22m;                // [kg * 10^-5] shifted to keep in decimal range
    // distance Unit
    private decimal oldDistanceUnit = 1e+7m;            // [km]

    // Real value of Gravitational constant G           // [m^3 kg^-1 s^-2]
    public decimal gravitationalConstantG = 6.6743e-11m;

    // Gravitational Constant to be varied by Unity scale
    // Default set it to real value and units (i.1. assume unity units were 1-to-1)
    public decimal rescaledG = 6.6743e-11m;

    // Determines direction of orbital rotation
    // Factor value of 1 for Anticlockwise and 2 for Clockwise
    // Factor value of 0 for no rotation
    // Default set to AntiClockwise with Solar System
    public string orbitDirection = "AntiClockwise";
    public float orbitDirectionFactor = 1.0f;

    // Determines direction of spin rotation
    // Factor value of 1 for Anticlockwise and 2 for Clockwise
    // Factor value of 0 for no rotation
    // Default set to AntiClockwise with Solar System
    public string spinDirection = "AntiClockwise";
    public float spinDirectionFactor = 1.0f;

    // Real Values
    // Sun
    private decimal massSun = 2e+25m;                           // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusSun = 696340m;                        // [km]
    private decimal distanceSunToSun = 0.0m;                    // [km]
    private decimal periodOrbitSun = 0.0m;                      // [days] currently not used but may be used later
    private decimal orbitalSpeedSun = 19.4m;                    // [km/s]
    private decimal periodSpinRotationSun = 609.12m;            // [hr]
    private float obliquitySun = 7.25f;                       // [deg]
    private float orbitTiltSun = 0.0f;                        // [deg]

    // Mercury
    private decimal massMercury = 2.3e+18m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusMercury = 2439.5m;                    // [km]
    private decimal distanceSunToMercury = 5.79e+07m;           // [km]
    private decimal periodOrbitMercury = 88m;                   // [days] currently not used but may be used later
    private decimal orbitalSpeedMercury = 47.4m;                // [km/s]
    private decimal periodSpinRotationMercury = 1407.6m;        // [hr]
    private float obliquityMercury = 0.034f;                  // [deg]
    private float orbitTiltMercury = 3.38f;                   // [deg]

    // Venus
    private decimal massVenus = 4.8e+19m;                       // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusVenus = 6052m;                        // [km]
    private decimal distanceSunToVenus = 1.08e+08m;             // [km]
    private decimal periodOrbitVenus = 224.7m;                  // [days] currently not used but may be used later
    private decimal orbitalSpeedVenus = 35m;                    // [km/s]
    private decimal periodSpinRotationVenus = 5832.5m;          // [hr]
    private float obliquityVenus = 177.4f;                    // [deg]
    private float orbitTiltVenus = 3.86f;                     // [deg]

    // Earth
    private decimal massEarth = 5.97e+19m;                      // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusEarth = 6378m;                        // [km]
    private decimal distanceSunToEarth = 1.5e+08m;              // [km]
    private decimal periodOrbitEarth = 365.2m;                  // [days] currently not used but may be used later
    private decimal orbitalSpeedEarth = 29.8m;                  // [km/s]
    private decimal periodSpinRotationEarth = 23.9m;            // [hr]
    private float obliquityEarth = 23.4f;                     // [deg]
    private float orbitTiltEarth = 7.155f;                    // [deg]

    // Mars
    private decimal massMars = 6.42e+18m;                       // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusMars = 3396m;                         // [km]
    private decimal distanceSunToMars = 2.2e+08m;               // [km]
    private decimal periodOrbitMars = 687m;                     // [days] currently not used but may be used later
    private decimal orbitalSpeedMars = 24.1m;                   // [km/s]
    private decimal periodSpinRotationMars = 24.6m;             // [hr]
    private float obliquityMars = 25.2f;                      // [deg]
    private float orbitTiltMars = 5.65f;                      // [deg]

    // Jupiter
    private decimal massJupiter = 1.898e+22m;                   // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusJupiter = 71492m;                     // [km]
    private decimal distanceSunToJupiter = 7.79e+08m;           // [km]
    private decimal periodOrbitJupiter = 4331m;                 // [days] currently not used but may be used later
    private decimal orbitalSpeedJupiter = 13.1m;                // [km/s]
    private decimal periodSpinRotationJupiter = 9.9m;           // [hr]
    private float obliquityJupiter = 3.1f;                    // [deg]
    private float orbitTiltJupiter = 6.09f;                   // [deg]

    // Saturn
    private decimal massSaturn = 5.68e+21m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusSaturn = 60268m;                      // [km]
    private decimal distanceSunToSaturn = 1.43e+09m;            // [km]
    private decimal periodOrbitSaturn = 10747m;                 // [days] currently not used but may be used later
    private decimal orbitalSpeedSaturn = 9.7m;                  // [km/s]
    private decimal periodSpinRotationSaturn = 10.7m;           // [hr]
    private float obliquitySaturn = 26.7f;                    // [deg]
    private float orbitTiltSaturn = 5.51f;                    // [deg]

    // Uranus
    private decimal massUranus = 8.68e+20m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusUranus = 25559m;                      // [km]
    private decimal distanceSunToUranus = 2.87e+09m;            // [km]
    private decimal periodOrbitUranus = 30589m;                 // [days] currently not used but may be used later
    private decimal orbitalSpeedUranus = 6.8m;                  // [km/s]
    private decimal periodSpinRotationUranus = 17.2m;           // [hr]
    private float obliquityUranus = 97.8f;                    // [deg]
    private float orbitTiltUranus = 6.48f;                    // [deg]

    // Neptune
    private decimal massNeptune = 1.02e+21m;                    // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusNeptune = 24764m;                     // [km]
    private decimal distanceSunToNeptune = 4.5e+09m;            // [km]
    private decimal periodOrbitNeptune = 59800m;                // [days] currently not used but may be used later
    private decimal orbitalSpeedNeptune = 5.4m;                 // [km/s]
    private decimal periodSpinRotationNeptune = 16.1m;          // [hr]
    private float obliquityNeptune = 28.3f;                   // [deg]
    private float orbitTiltNeptune = 6.43f;                   // [deg]

    //MOONS

    // Earth's Moon
    private decimal massMoon = 7.30e+17m;                       // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusMoon = 1737.5m;                       // [km]
    private decimal distanceEarthToMoon = 3.84e+05m;            // [km]
    private decimal periodOrbitMoon = 27.3m;                    // [days] currently not used but may be used later
    private decimal orbitalSpeedMoon = 1.022m;                  // [km/s]
    private decimal periodSpinRotationMoon = 655.7m;            // [hr]
    private float obliquityMoon = 6.7f;                       // [deg]
    private float orbitTiltMoon = 5.145f;                     // [deg]

    // Mars' Moon 1 - Phobos
    private decimal massPhobos = 1.06e+11m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusPhobos = 11.2667m;                    // [km]
    private decimal distanceMarsToPhobos = 9.378e+03m;          // [km]
    private decimal periodOrbitPhobos = 0.31891023m;            // [days] currently not used but may be used later
    private decimal orbitalSpeedPhobos = 2.138m;                // [km/s]
    private decimal periodSpinRotationPhobos = 7.65384m;        // [hr]
    private float obliquityPhobos = 0.0f;                     // [deg]
    private float orbitTiltPhobos = 1.08f;                    // [deg]

    // Mars' Moon 2 - Deimos
    private decimal massDeimos = 2.4e+10m;                      // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusDeimos = 6.2m;                        // [km]
    private decimal distanceMarsToDeimos = 2.3459e+04m;         // [km]
    private decimal periodOrbitDeimos = 1.263m;                 // [days] currently not used but may be used later
    private decimal orbitalSpeedDeimos = 1.3513m;               // [km/s]
    private decimal periodSpinRotationDeimos = 30.29856m;       // [hr]
    private float obliquityDeimos = 0.0f;                     // [deg]
    private float orbitTiltDeimos = 1.79f;                    // [deg]

    // Jupiter's Moon 1 - Io
    private decimal massIo = 8.932e+17m;                        // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusIo = 1821.5m;                         // [km]
    private decimal distanceJupiterToIo = 4.217e+05m;           // [km]
    private decimal periodOrbitIo = 1.769137786m;               // [days] currently not used but may be used later
    private decimal orbitalSpeedIo = 17.334m;                   // [km/s]
    private decimal periodSpinRotationIo = 42.45930686m;        // [hr]
    private float obliquityIo = 0.0f;                         // [deg]
    private float orbitTiltIo = 0.04f;                        // [deg]

    // Jupiter's Moon 2 - Europa
    private decimal massEuropa = 4.8e+17m;                      // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusEuropa = 1560.8m;                     // [km]
    private decimal distanceJupiterToEuropa = 6.709e+05m;       // [km]
    private decimal periodOrbitEuropa = 3.551181m;              // [days] currently not used but may be used later
    private decimal orbitalSpeedEuropa = 13.74m;                // [km/s]
    private decimal periodSpinRotationEuropa = 85.228344m;      // [hr]
    private float obliquityEuropa = 0.1f;                     // [deg]
    private float orbitTiltEuropa = 0.47f;                    // [deg]

    // Jupiter's Moon 3 - Callisto
    private decimal massCallisto = 1.0759e+18m;                 // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusCallisto = 2410.3m;                   // [km]
    private decimal distanceJupiterToCallisto = 1.883e+06m;     // [km]
    private decimal periodOrbitCallisto = 16.6890184m;          // [days] currently not used but may be used later
    private decimal orbitalSpeedCallisto = 8.204m;              // [km/s]
    private decimal periodSpinRotationCallisto = 400.5364416m;  // [hr]
    private float obliquityCallisto = 0.0f;                   // [deg]
    private float orbitTiltCallisto = 2.017f;                 // [deg]

    // Jupiter's Moon 4 - Ganymede
    private decimal massGanymede = 1.4819e+18m;                 // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusGanymede = 2631.2m;                   // [km]
    private decimal distanceJupiterToGanymede = 1.0704e+06m;    // [km]
    private decimal periodOrbitGanymede = 7.15455296m;          // [days] currently not used but may be used later
    private decimal orbitalSpeedGanymede = 10.88m;              // [km/s]
    private decimal periodSpinRotationGanymede = 171.709271m;   // [hr]
    private float obliquityGanymede = 0.165f;                 // [deg]
    private float orbitTiltGanymede = 2.214f;                 // [deg]

    // Saturn's Moon 2 - Titan
    private decimal massTitan = 1.3455e+18m;                    // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusTitan = 2575m;                        // [km]
    private decimal distanceSaturnToTitan = 1.2e+06m;           // [km]
    private decimal periodOrbitTitan = 15.945m;                 // [days] currently not used but may be used later
    private decimal orbitalSpeedTitan = 5.57m;                  // [km/s]
    private decimal periodSpinRotationTitan = 382.68m;          // [hr]
    private float obliquityTitan = 0.0f;                      // [deg]
    private float orbitTiltTitan = 0.34854f;                  // [deg]

    // Saturn's Moon 2 - Rhea
    private decimal massRhea = 2.31e+16m;                       // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusRhea = 763.8m;                        // [km]
    private decimal distanceSaturnToRhea = 5.27108e+05m;        // [km]
    private decimal periodOrbitRhea = 4.518212m;                // [days] currently not used but may be used later
    private decimal orbitalSpeedRhea = 8.48m;                   // [km/s]
    private decimal periodSpinRotationRhea = 108.437088m;       // [hr]
    private float obliquityRhea = 0.0f;                       // [deg]
    private float orbitTiltRhea = 0.345f;                     // [deg]

    // Saturn's Moon 3 - Iapetus
    private decimal massIapetus = 1.81e+16m;                    // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusIapetus = 734.5m;                     // [km]
    private decimal distanceSaturnToIapetus = 3.56082e+06m;     // [km]
    private decimal periodOrbitIapetus = 79.3215m;              // [days] currently not used but may be used later
    private decimal orbitalSpeedIapetus = 3.26m;                // [km/s]
    private decimal periodSpinRotationIapetus = 1903.716m;      // [hr]
    private float obliquityIapetus = 0.0f;                    // [deg]
    private float orbitTiltIapetus = 15.47f;                  // [deg]

    // Uranus' Moon 1 - Titania
    private decimal massTitania = 3.42e+16m;                    // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusTitania = 788.9m;                     // [km]
    private decimal distanceUranusToTitania = 4.36e+05m;        // [km]
    private decimal periodOrbitTitania = 8.706234m;             // [days] currently not used but may be used later
    private decimal orbitalSpeedTitania = 3.64m;                // [km/s]
    private decimal periodSpinRotationTitania = 208.949616m;    // [hr]
    private float obliquityTitania = 0.0f;                    // [deg]
    private float orbitTiltTitania = 0.340f;                  // [deg]

    // Uranus' Moon 2 - Oberon
    private decimal massOberon = 2.88e+16m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusOberon = 761.4m;                      // [km]
    private decimal distanceUranusToOberon = 5.84e+05m;         // [km]
    private decimal periodOrbitOberon = 13.463234m;             // [days] currently not used but may be used later
    private decimal orbitalSpeedOberon = 3.15m;                 // [km/s]
    private decimal periodSpinRotationOberon = 323.117616m;     // [hr]
    private float obliquityOberon = 0.0f;                     // [deg]
    private float orbitTiltOberon = 0.058f;                   // [deg]

    // Uranus' Moon 3 - Umbriel
    private decimal massUmbriel = 1.22e+16m;                    // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusUmbriel = 584.7m;                     // [km]
    private decimal distanceUranusToUmbriel = 2.66e+05m;        // [km]
    private decimal periodOrbitUmbriel = 4.144m;                // [days] currently not used but may be used later
    private decimal orbitalSpeedUmbriel = 4.67m;                // [km/s]
    private decimal periodSpinRotationUmbriel = 99.456m;        // [hr]
    private float obliquityUmbriel = 0.0f;                    // [deg]
    private float orbitTiltUmbriel = 0.128f;                  // [deg]

    // Uranus' Moon 4 - Ariel
    private decimal massAriel = 1.29e+16m;                      // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusAriel = 578.9m;                       // [km]
    private decimal distanceUranusToAriel = 1.9e+05m;           // [km]
    private decimal periodOrbitAriel = 2.52m;                   // [days] currently not used but may be used later
    private decimal orbitalSpeedAriel = 5.51m;                  // [km/s]
    private decimal periodSpinRotationAriel = 60.48m;           // [hr]
    private float obliquityAriel = 0.0f;                      // [deg]
    private float orbitTiltAriel = 0.26f;                     // [deg]

    // Neptune's Moon - Triton
    private decimal massTriton = 2.14e+17m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusTriton = 1353.4m;                     // [km]
    private decimal distanceNeptuneToTriton = 3.54759e+05m;     // [km]
    private decimal periodOrbitTriton = 5.876854m;              // [days] currently not used but may be used later
    private decimal orbitalSpeedTriton = 4.39m;                 // [km/s]
    private decimal periodSpinRotationTriton = 141.044496m;     // [hr]
    private float obliquityTriton = 0.0f;                     // [deg]
    private float orbitTiltTriton = 156.885f;                 // [deg]

    //ASTEROIDS

    // Ceres

    private decimal massCeres = 9.393e+15m;                     // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusCeres = 469.73m;                      // [km]
    private decimal distanceSunToCeres = 4.19e+08m;             // [km]
    private decimal periodOrbitCeres = 1683.14570801m;          // [days] currently not used but may be used later
    private decimal orbitalSpeedCeres = 17.905m;                // [km/s]
    private decimal periodSpinRotationCeres = 9.074170m;        // [hr]
    private float obliquityCeres = 4.0f;                      // [deg]
    private float orbitTiltCeres = 0.0f;                      // [deg]

    // Vesta

    private decimal massVesta = 2.59e+15m;                      // [kg * 10^-5] shifted to keep in decimal range
    private decimal radiusVesta = 262.7m;                       // [km]
    private decimal distanceSunToVesta = 3.53e+08m;             // [km]
    private decimal periodOrbitVesta = 1325.75m;                // [days] currently not used but may be used later
    private decimal orbitalSpeedVesta = 19.34m;                 // [km/s]
    private decimal periodSpinRotationVesta = 5.34m;            // [hr]
    private float obliquityVesta = 0.0f;                      // [deg]
    private float orbitTiltVesta = 0.0f;                      // [deg]


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
        // by default have set it to be on the camera
        // alternative to having scaling script repeated on every object which would waste resources repeating the same calculations
        GameObject scalingObject = GameObject.Find("Main Camera");

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
            periodSpinRotation = periodSpinRotationSun * 3600.0m * timeUnit;
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
        {
            ;
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
            periodSpinRotation = periodSpinRotationMercury * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationVenus * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationEarth * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationMars * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationJupiter * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationSaturn * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationUranus * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationNeptune * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationMoon * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationPhobos * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationDeimos * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationIo * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationEuropa * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationCallisto * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationGanymede * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationTitan * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationRhea * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationIapetus * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationTitania * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationOberon * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationUmbriel * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationAriel * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationTriton * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationCeres * 3600m * timeUnit;
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
            periodSpinRotation = periodSpinRotationVesta * 3600m * timeUnit;
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
        // by default have set it to be on the camera
        // alternative to having scaling script repeated on every object which would waste resources repeating the same calculations
        GameObject scalingObject = GameObject.Find("Main Camera");

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
            frequencySpinRotation = (float)(1.0m / periodSpinRotation);
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
    public void RelativePosition(Rigidbody rb2, decimal distance1to2, decimal distanceScaleFactor)
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
        /*
        // Set the factor of proportionality
        // Proportionality of 1 would 1:1 representation of scale in Unity units
        decimal proportionality = 100.0m;
        // Sets the Render Scaling to a sphere with radius equal to object radius (scaled to simulation units) * proportionality
        rb.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f) * (float)(scaledRadius * proportionality);
        
    }
}
*/