using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Dictionary : MonoBehaviour
{
    // Dictionary containing real value data as decimals
    public Dictionary<string, decimal> data;
    // Dictionary containing lavels as strings
    public Dictionary<string, string> labels;
    // Bool to confirm when Dictionaries have started being filled
    public bool start = false;
    // Bool to confirm when Dictionaries have finished being filled
    public bool finish = false;

    // Start is called before the first frame update
    void Awake()
    {


        // Check if thw dictionary has already been filled
        // If the dictionary does not have the "complete" confirmation key, then fill it
        if (start == false)
        {
            // Run function to add all the predefined values
            CreateDictionary(data, labels, start, finish);
        }
    }


    // This function will fill a dictionary with all of the input data for this program
    public void CreateDictionary(Dictionary<string, decimal> data, Dictionary<string, string> labels, bool start, bool finish)
    {
        if (data == null)
        {
            data = new Dictionary<string, decimal>();
        }
        if (labels == null)
        {
            labels = new Dictionary<string, string>();
        }

        // Set start to true for confirmation that Dictionaries are being built
        start = true;
        Debug.Log("Dictionaries: " + labels + " and " + data + "has started to be filled. i.e. start = " + start);

        // Real Values - added to dictionary

        // Stars

        // Sun
        labels.Add("objectSun", "Sun");                             // Name of object
        labels.Add("typeSun", "Star");                              // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massSun", 2e+25m);                                // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusSun", 696340m);                             // [km]
        data.Add("distanceSunToSun", 0.0m);                         // [km]
        data.Add("periodOrbitSun", 0.0m);                           // [days] currently not used but may be used later
        data.Add("orbitalSpeedSun", 19.4m);                         // [km/s]
        data.Add("periodSpinRotationSun", 609.12m);                 // [hr]
        data.Add("obliquitySun", 7.25m);                            // [deg]
        data.Add("orbitTiltSun", 0.0m);                             // [deg]
        labels.Add("focusSun", "Sun");                              // The object that this object orbit arounds
        labels.Add("orbitDirectionSun", "AntiClockwise");           // Direction of Rotation defined from above
        labels.Add("spintDirectionSun", "AntiClockwise");           // Direction of Rotation defined from above

        // Planets

        // Mercury
        labels.Add("objectMercury", "Mercury");                     // Name of object
        labels.Add("typeMercury", "Planet");                        // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massMercury", 2.3e+18m);                          // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusMercury", 2439.5m);                         // [km]
        data.Add("distanceSunToMercury", 5.79e+07m);                // [km]
        data.Add("periodOrbitMercury", 88m);                        // [days] currently not used but may be used later
        data.Add("orbitalSpeedMercury", 47.4m);                     // [km/s]
        data.Add("periodSpinRotationMercury", 1407.6m);             // [hr]
        data.Add("obliquityMercury", 0.034m);                       // [deg]
        data.Add("orbitTiltMercury", 3.38m);                        // [deg]
        labels.Add("focusMercury", "Sun");                          // The object that this object orbit arounds
        labels.Add("orbitDirectionMercury", "AntiClockwise");       // Direction of Rotation defined from above
        labels.Add("spintDirectionMercury", "AntiClockwise");       // Direction of Rotation defined from above

        // Venus
        labels.Add("objectVenus", "Venus");                         // Name of object
        labels.Add("typeVenus", "Planet");                          // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massVenus", 4.8e+19m);                            // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusVenus", 6052m);                             // [km]
        data.Add("distanceSunToVenus", 1.08e+08m);                  // [km]
        data.Add("periodOrbitVenus", 224.7m);                       // [days] currently not used but may be used later
        data.Add("orbitalSpeedVenus", 35m);                         // [km/s]
        data.Add("periodSpinRotationVenus", 5832.5m);               // [hr]
        data.Add("obliquityVenus", 177.4m);                         // [deg]
        data.Add("orbitTiltVenus", 3.86m);                          // [deg]
        labels.Add("focusVenus", "Sun");                            // The object that this object orbit arounds
        labels.Add("orbitDirectionVenus", "AntiClockwise");         // Direction of Rotation defined from above
        labels.Add("spintDirectionVenus", "AntiClockwise");         // Direction of Rotation defined from above

        // Earth
        labels.Add("objectEarth", "Earth");                         // Name of object
        labels.Add("typeEarth", "Planet");                          // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massEarth", 5.97e+19m);                           // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusEarth", 6378m);                             // [km]
        data.Add("distanceSunToEarth", 1.5e+08m);                   // [km]
        data.Add("periodOrbitEarth", 365.2m);                       // [days] currently not used but may be used later
        data.Add("orbitalSpeedEarth", 29.8m);                       // [km/s]
        data.Add("periodSpinRotationEarth", 23.9m);                 // [hr]
        data.Add("obliquityEarth", 23.4m);                          // [deg]
        data.Add("orbitTiltEarth", 7.155m);                         // [deg]
        labels.Add("focusEarth", "Sun");                            // The object that this object orbit arounds
        labels.Add("orbitDirectionEarth", "AntiClockwise");         // Direction of Rotation defined from above
        labels.Add("spintDirectionEarth", "AntiClockwise");         // Direction of Rotation defined from above

        // Mars
        labels.Add("objectMars", "Mars");                           // Name of object
        labels.Add("typeMars", "Planet");                           // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massMars", 6.42e+18m);                            // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusMars", 3396m);                              // [km]
        data.Add("distanceSunToMars", 2.2e+08m);                    // [km]
        data.Add("periodOrbitMars", 687m);                          // [days] currently not used but may be used later
        data.Add("orbitalSpeedMars", 24.1m);                        // [km/s]
        data.Add("periodSpinRotationMars", 24.6m);                  // [hr]
        data.Add("obliquityMars", 25.2m);                           // [deg]
        data.Add("orbitTiltMars", 5.65m);                           // [deg]
        labels.Add("focusMars", "Sun");                             // The object that this object orbit arounds
        labels.Add("orbitDirectionMars", "AntiClockwise");          // Direction of Rotation defined from above
        labels.Add("spintDirectionMars", "AntiClockwise");          // Direction of Rotation defined from above

        // Jupiter
        labels.Add("objectJupiter", "Jupiter");                     // Name of object
        labels.Add("typeJupiter", "Planet");                        // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massJupiter", 1.898e+22m);                        // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusJupiter", 71492m);                          // [km]
        data.Add("distanceSunToJupiter", 7.79e+08m);                // [km]
        data.Add("periodOrbitJupiter", 4331m);                      // [days] currently not used but may be used later
        data.Add("orbitalSpeedJupiter", 13.1m);                     // [km/s]
        data.Add("periodSpinRotationJupiter", 9.9m);                // [hr]
        data.Add("obliquityJupiter", 3.1m);                         // [deg]
        data.Add("orbitTiltJupiter", 6.09m);                        // [deg]
        labels.Add("focusJupiter", "Sun");                          // The object that this object orbit arounds
        labels.Add("orbitDirectionJupiter", "AntiClockwise");       // Direction of Rotation defined from above
        labels.Add("spintDirectionJupiter", "AntiClockwise");       // Direction of Rotation defined from above

        // Saturn
        labels.Add("objectSaturn", "Saturn");                       // Name of object
        labels.Add("typeSaturn", "Planet");                         // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massSaturn", 5.68e+21m);                          // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusSaturn", 60268m);                           // [km]
        data.Add("distanceSunToSaturn", 1.43e+09m);                 // [km]
        data.Add("periodOrbitSaturn", 10747m);                      // [days] currently not used but may be used later
        data.Add("orbitalSpeedSaturn", 9.7m);                       // [km/s]
        data.Add("periodSpinRotationSaturn", 10.7m);                // [hr]
        data.Add("obliquitySaturn", 26.7m);                         // [deg]
        data.Add("orbitTiltSaturn", 5.51m);                         // [deg]
        labels.Add("focusSaturn", "Sun");                           // The object that this object orbit arounds
        labels.Add("orbitDirectionSaturn", "AntiClockwise");        // Direction of Rotation defined from above
        labels.Add("spintDirectionSaturn", "AntiClockwise");        // Direction of Rotation defined from above

        // Uranus
        labels.Add("objectUranus", "Uranus");                       // Name of object
        labels.Add("typeUranus", "Planet");                         // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massUranus", 8.68e+20m);                          // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusUranus", 25559m);                           // [km]
        data.Add("distanceSunToUranus", 2.87e+09m);                 // [km]
        data.Add("periodOrbitUranus", 30589m);                      // [days] currently not used but may be used later
        data.Add("orbitalSpeedUranus", 6.8m);                       // [km/s]
        data.Add("periodSpinRotationUranus", 17.2m);                // [hr]
        data.Add("obliquityUranus", 97.8m);                         // [deg]
        data.Add("orbitTiltUranus", 6.48m);                         // [deg]
        labels.Add("focusUranus", "Sun");                           // The object that this object orbit arounds
        labels.Add("orbitDirectionUranus", "AntiClockwise");        // Direction of Rotation defined from above
        labels.Add("spintDirectionUranus", "AntiClockwise");        // Direction of Rotation defined from above

        // Neptune
        labels.Add("objectNeptune", "Neptune");                     // Name of object
        labels.Add("typeNeptune", "Planet");                        // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massNeptune", 1.02e+21m);                         // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusNeptune", 24764m);                          // [km]
        data.Add("distanceSunToNeptune", 4.5e+09m);                 // [km]
        data.Add("periodOrbitNeptune", 59800m);                     // [days] currently not used but may be used later
        data.Add("orbitalSpeedNeptune", 5.4m);                      // [km/s]
        data.Add("periodSpinRotationNeptune", 16.1m);               // [hr]
        data.Add("obliquityNeptune", 28.3m);                        // [deg]
        data.Add("orbitTiltNeptune", 6.43m);                        // [deg]
        labels.Add("focusNeptune", "Sun");                          // The object that this object orbit arounds
        labels.Add("orbitDirectionNeptune", "AntiClockwise");       // Direction of Rotation defined from above
        labels.Add("spintDirectionNeptune", "AntiClockwise");       // Direction of Rotation defined from above

        //MOONS

        // Earth's Moon
        labels.Add("objectMoon", "Moon");                           // Name of object
        labels.Add("typeMoon", "Moon");                             // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massMoon", 7.30e+17m);                            // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusMoon", 1737.5m);                            // [km]
        data.Add("distanceEarthToMoon", 3.84e+05m);                 // [km]
        data.Add("periodOrbitMoon", 27.3m);                         // [days] currently not used but may be used later
        data.Add("orbitalSpeedMoon", 1.022m);                       // [km/s]
        data.Add("periodSpinRotationMoon", 655.7m);                 // [hr]
        data.Add("obliquityMoon", 6.7m);                            // [deg]
        data.Add("orbitTiltMoon", 5.145m);                          // [deg]
        labels.Add("focusMoon", "Earth");                           // The object that this object orbit arounds
        labels.Add("orbitDirectionMoon", "AntiClockwise");          // Direction of Rotation defined from above
        labels.Add("spintDirectionMoon", "AntiClockwise");          // Direction of Rotation defined from above

        // Mars' Moon 1 - Phobos
        labels.Add("objectPhobos", "Phobos");                       // Name of object
        labels.Add("typePhobos", "Moon");                           // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massPhobos", 1.06e+11m);                          // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusPhobos", 11.2667m);                         // [km]
        data.Add("distanceMarsToPhobos", 9.378e+03m);               // [km]
        data.Add("periodOrbitPhobos", 0.31891023m);                 // [days] currently not used but may be used later
        data.Add("orbitalSpeedPhobos", 2.138m);                     // [km/s]
        data.Add("periodSpinRotationPhobos", 7.65384m);             // [hr]
        data.Add("obliquityPhobos", 0.0m);                          // [deg]
        data.Add("orbitTiltPhobos", 1.08m);                         // [deg]
        labels.Add("focusPhobos", "Mars");                          // The object that this object orbit arounds
        labels.Add("orbitDirectionPhobos", "AntiClockwise");        // Direction of Rotation defined from above
        labels.Add("spintDirectionPhobos", "AntiClockwise");        // Direction of Rotation defined from above

        // Mars' Moon 2 - Deimos
        labels.Add("objectDeimos", "Deimos");                       // Name of object
        labels.Add("typeDeimos", "Moon");                           // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massDeimos", 2.4e+10m);                           // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusDeimos", 6.2m);                             // [km]
        data.Add("distanceMarsToDeimos", 2.3459e+04m);              // [km]
        data.Add("periodOrbitDeimos", 1.263m);                      // [days] currently not used but may be used later
        data.Add("orbitalSpeedDeimos", 1.3513m);                    // [km/s]
        data.Add("periodSpinRotationDeimos", 30.29856m);            // [hr]
        data.Add("obliquityDeimos", 0.0m);                          // [deg]
        data.Add("orbitTiltDeimos", 1.79m);                         // [deg]
        labels.Add("focusDeimos", "Mars");                          // The object that this object orbit arounds
        labels.Add("orbitDirectionDeimos", "AntiClockwise");        // Direction of Rotation defined from above
        labels.Add("spintDirectionDeimos", "AntiClockwise");        // Direction of Rotation defined from above

        // Jupiter's Moon 1 - Io
        labels.Add("objectIo", "Io");                               // Name of object
        labels.Add("typeIo", "Moon");                               // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massIo", 8.932e+17m);                             // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusIo", 1821.5m);                              // [km]
        data.Add("distanceJupiterToIo", 4.217e+05m);                // [km]
        data.Add("periodOrbitIo", 1.769137786m);                    // [days] currently not used but may be used later
        data.Add("orbitalSpeedIo", 17.334m);                        // [km/s]
        data.Add("periodSpinRotationIo", 42.45930686m);             // [hr]
        data.Add("obliquityIo", 0.0m);                              // [deg]
        data.Add("orbitTiltIo", 0.04m);                             // [deg]
        labels.Add("focusIo", "Jupiter");                           // The object that this object orbit arounds
        labels.Add("orbitDirectionIo", "AntiClockwise");            // Direction of Rotation defined from above
        labels.Add("spintDirectionIo", "AntiClockwise");            // Direction of Rotation defined from above

        // Jupiter's Moon 2 - Europa
        labels.Add("objectEuropa", "Europa");                       // Name of object
        labels.Add("typeEuropa", "Moon");                           // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massEuropa", 4.8e+17m);                           // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusEuropa", 1560.8m);                          // [km]
        data.Add("distanceJupiterToEuropa", 6.709e+05m);            // [km]
        data.Add("periodOrbitEuropa", 3.551181m);                   // [days] currently not used but may be used later
        data.Add("orbitalSpeedEuropa", 13.74m);                     // [km/s]
        data.Add("periodSpinRotationEuropa", 85.228344m);           // [hr]
        data.Add("obliquityEuropa", 0.1m);                          // [deg]
        data.Add("orbitTiltEuropa", 0.47m);                         // [deg]
        labels.Add("focusEuropa", "Jupiter");                       // The object that this object orbit arounds
        labels.Add("orbitDirectionEuropa", "AntiClockwise");        // Direction of Rotation defined from above
        labels.Add("spintDirectionEuropa", "AntiClockwise");        // Direction of Rotation defined from above

        // Jupiter's Moon 3 - Callisto
        labels.Add("objectCallisto", "Callisto");                   // Name of object
        labels.Add("typeCallisto", "Moon");                         // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massCallisto", 1.0759e+18m);                      // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusCallisto", 2410.3m);                        // [km]
        data.Add("distanceJupiterToCallisto", 1.883e+06m);          // [km]
        data.Add("periodOrbitCallisto", 16.6890184m);               // [days] currently not used but may be used later
        data.Add("orbitalSpeedCallisto", 8.204m);                   // [km/s]
        data.Add("periodSpinRotationCallisto", 400.5364416m);       // [hr]
        data.Add("obliquityCallisto", 0.0m);                        // [deg]
        data.Add("orbitTiltCallisto", 2.017m);                      // [deg]
        labels.Add("focusCallisto", "Jupiter");                     // The object that this object orbit arounds
        labels.Add("orbitDirectionCallisto", "AntiClockwise");      // Direction of Rotation defined from above
        labels.Add("spintDirectionCallisto", "AntiClockwise");      // Direction of Rotation defined from above

        // Jupiter's Moon 4 - Ganymede
        labels.Add("objectGanymede", "Ganymede");                   // Name of object
        labels.Add("typeGanymede", "Moon");                         // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massGanymede", 1.4819e+18m);                      // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusGanymede", 2631.2m);                        // [km]
        data.Add("distanceJupiterToGanymede", 1.0704e+06m);         // [km]
        data.Add("periodOrbitGanymede", 7.15455296m);               // [days] currently not used but may be used later
        data.Add("orbitalSpeedGanymede", 10.88m);                   // [km/s]
        data.Add("periodSpinRotationGanymede", 171.709271m);        // [hr]
        data.Add("obliquityGanymede", 0.165m);                      // [deg]
        data.Add("orbitTiltGanymede", 2.214m);                      // [deg]
        labels.Add("focusGanymede", "Jupiter");                     // The object that this object orbit arounds
        labels.Add("orbitDirectionGanymede", "AntiClockwise");      // Direction of Rotation defined from above
        labels.Add("spintDirectionGanymede", "AntiClockwise");      // Direction of Rotation defined from above

        // Saturn's Moon 2 - Titan
        labels.Add("objectTitan", "Titan");                         // Name of object
        labels.Add("typeTitan", "Moon");                            // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massTitan", 1.3455e+18m);                         // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusTitan", 2575m);                             // [km]
        data.Add("distanceSaturnToTitan", 1.2e+06m);                // [km]
        data.Add("periodOrbitTitan", 15.945m);                      // [days] currently not used but may be used later
        data.Add("orbitalSpeedTitan", 5.57m);                       // [km/s]
        data.Add("periodSpinRotationTitan", 382.68m);               // [hr]
        data.Add("obliquityTitan", 0.0m);                           // [deg]
        data.Add("orbitTiltTitan", 0.34854m);                       // [deg]
        labels.Add("focusTitan", "Saturn");                         // The object that this object orbit arounds
        labels.Add("orbitDirectionTitan", "AntiClockwise");         // Direction of Rotation defined from above
        labels.Add("spintDirectionTitan", "AntiClockwise");         // Direction of Rotation defined from above

        // Saturn's Moon 2 - Rhea
        labels.Add("objectRhea", "Rhea");                           // Name of object
        labels.Add("typeRhea", "Moon");                             // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massRhea", 2.31e+16m);                            // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusRhea", 763.8m);                             // [km]
        data.Add("distanceSaturnToRhea", 5.27108e+05m);             // [km]
        data.Add("periodOrbitRhea", 4.518212m);                     // [days] currently not used but may be used later
        data.Add("orbitalSpeedRhea", 8.48m);                        // [km/s]
        data.Add("periodSpinRotationRhea", 108.437088m);            // [hr]
        data.Add("obliquityRhea", 0.0m);                            // [deg]
        data.Add("orbitTiltRhea", 0.345m);                          // [deg]
        labels.Add("focusRhea", "Saturn");                          // The object that this object orbit arounds
        labels.Add("orbitDirectionRhea", "AntiClockwise");          // Direction of Rotation defined from above
        labels.Add("spintDirectionRhea", "AntiClockwise");          // Direction of Rotation defined from above

        // Saturn's Moon 3 - Iapetus
        labels.Add("objectIapetus", "Iapetus");                     // Name of object
        labels.Add("typeIapetus", "Moon");                          // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massIapetus", 1.81e+16m);                         // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusIapetus", 734.5m);                          // [km]
        data.Add("distanceSaturnToIapetus", 3.56082e+06m);          // [km]
        data.Add("periodOrbitIapetus", 79.3215m);                   // [days] currently not used but may be used later
        data.Add("orbitalSpeedIapetus", 3.26m);                     // [km/s]
        data.Add("periodSpinRotationIapetus", 1903.716m);           // [hr]
        data.Add("obliquityIapetus", 0.0m);                         // [deg]
        data.Add("orbitTiltIapetus", 15.47m);                       // [deg]
        labels.Add("focusIapetus", "Saturn");                       // The object that this object orbit arounds
        labels.Add("orbitDirectionIapetus", "AntiClockwise");       // Direction of Rotation defined from above
        labels.Add("spintDirectionIapetus", "AntiClockwise");       // Direction of Rotation defined from above

        // Uranus' Moon 1 - Titania
        labels.Add("objectTitania", "Titania");                     // Name of object
        labels.Add("typeTitania", "Moon");                          // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massTitania", 3.42e+16m);                         // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusTitania", 788.9m);                          // [km]
        data.Add("distanceUranusToTitania", 4.36e+05m);             // [km]
        data.Add("periodOrbitTitania", 8.706234m);                  // [days] currently not used but may be used later
        data.Add("orbitalSpeedTitania", 3.64m);                     // [km/s]
        data.Add("periodSpinRotationTitania", 208.949616m);         // [hr]
        data.Add("obliquityTitania", 0.0m);                         // [deg]
        data.Add("orbitTiltTitania", 0.340m);                       // [deg]
        labels.Add("focusTitania", "Uranus");                       // The object that this object orbit arounds
        labels.Add("orbitDirectionTitania", "AntiClockwise");       // Direction of Rotation defined from above
        labels.Add("spintDirectionTitania", "AntiClockwise");       // Direction of Rotation defined from above

        // Uranus' Moon 2 - Oberon
        labels.Add("objectOberon", "Oberon");                       // Name of object
        labels.Add("typeOberon", "Moon");                           // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massOberon", 2.88e+16m);                          // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusOberon", 761.4m);                           // [km]
        data.Add("distanceUranusToOberon", 5.84e+05m);              // [km]
        data.Add("periodOrbitOberon", 13.463234m);                  // [days] currently not used but may be used later
        data.Add("orbitalSpeedOberon", 3.15m);                      // [km/s]
        data.Add("periodSpinRotationOberon", 323.117616m);          // [hr]
        data.Add("obliquityOberon", 0.0m);                          // [deg]
        data.Add("orbitTiltOberon", 0.058m);                        // [deg]
        labels.Add("focusOberon", "Uranus");                        // The object that this object orbit arounds
        labels.Add("orbitDirectionOberon", "AntiClockwise");        // Direction of Rotation defined from above
        labels.Add("spintDirectionOberon", "AntiClockwise");        // Direction of Rotation defined from above

        // Uranus' Moon 3 - Umbriel
        labels.Add("objectUmbriel", "Umbriel");                     // Name of object
        labels.Add("typeUmbriel", "Moon");                          // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massUmbriel", 1.22e+16m);                         // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusUmbriel", 584.7m);                          // [km]
        data.Add("distanceUranusToUmbriel", 2.66e+05m);             // [km]
        data.Add("periodOrbitUmbriel", 4.144m);                     // [days] currently not used but may be used later
        data.Add("orbitalSpeedUmbriel", 4.67m);                     // [km/s]
        data.Add("periodSpinRotationUmbriel", 99.456m);             // [hr]
        data.Add("obliquityUmbriel", 0.0m);                         // [deg]
        data.Add("orbitTiltUmbriel", 0.128m);                       // [deg]
        labels.Add("focusUmbriel", "Uranus");                       // The object that this object orbit arounds
        labels.Add("orbitDirectionUmbriel", "AntiClockwise");       // Direction of Rotation defined from above
        labels.Add("spintDirectionUmbriel", "AntiClockwise");       // Direction of Rotation defined from above

        // Uranus' Moon 4 - Ariel
        labels.Add("objectAriel", "Ariel");                         // Name of object
        labels.Add("typeAriel", "Moon");                            // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massAriel", 1.29e+16m);                           // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusAriel", 578.9m);                            // [km]
        data.Add("distanceUranusToAriel", 1.9e+05m);                // [km]
        data.Add("periodOrbitAriel", 2.52m);                        // [days] currently not used but may be used later
        data.Add("orbitalSpeedAriel", 5.51m);                       // [km/s]
        data.Add("periodSpinRotationAriel", 60.48m);                // [hr]
        data.Add("obliquityAriel", 0.0m);                           // [deg]
        data.Add("orbitTiltAriel", 0.26m);                          // [deg]
        labels.Add("focusAriel", "Uranus");                         // The object that this object orbit arounds
        labels.Add("orbitDirectionAriel", "AntiClockwise");         // Direction of Rotation defined from above
        labels.Add("spintDirectionAriel", "AntiClockwise");         // Direction of Rotation defined from above

        // Neptune's Moon - Triton
        labels.Add("objectTriton", "Triton");                       // Name of object
        labels.Add("typeTriton", "Moon");                           // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massTriton", 2.14e+17m);                          // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusTriton", 1353.4m);                          // [km]
        data.Add("distanceNeptuneToTriton", 3.54759e+05m);          // [km]
        data.Add("periodOrbitTriton", 5.876854m);                   // [days] currently not used but may be used later
        data.Add("orbitalSpeedTriton", 4.39m);                      // [km/s]
        data.Add("periodSpinRotationTriton", 141.044496m);          // [hr]
        data.Add("obliquityTriton", 0.0m);                          // [deg]
        data.Add("orbitTiltTriton", 156.885m);                      // [deg]
        labels.Add("focusTriton", "Neptune");                       // The object that this object orbit arounds
        labels.Add("orbitDirectionTriton", "AntiClockwise");        // Direction of Rotation defined from above
        labels.Add("spintDirectionTriton", "AntiClockwise");        // Direction of Rotation defined from above

        //ASTEROIDS

        // Ceres

        labels.Add("objectCeres", "Ceres");                         // Name of object
        labels.Add("typeCeres", "Asteroid");                        // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massCeres", 9.393e+15m);                          // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusCeres", 469.73m);                           // [km]
        data.Add("distanceSunToCeres", 4.19e+08m);                  // [km]
        data.Add("periodOrbitCeres", 1683.14570801m);               // [days] currently not used but may be used later
        data.Add("orbitalSpeedCeres", 17.905m);                     // [km/s]
        data.Add("periodSpinRotationCeres", 9.074170m);             // [hr]
        data.Add("obliquityCeres", 4.0m);                           // [deg]
        data.Add("orbitTiltCeres", 0.0m);                           // [deg]
        labels.Add("focusCeres", "Sun");                            // The object that this object orbit arounds
        labels.Add("orbitDirectionCeres", "AntiClockwise");         // Direction of Rotation defined from above
        labels.Add("spintDirectionCeres", "AntiClockwise");         // Direction of Rotation defined from above

        // Vesta

        labels.Add("objectVesta", "Vesta");                         // Name of object
        labels.Add("typeVesta", "Asteroid");                        // Categorising objects into Star, Planet, Asteroid, Moon 
        data.Add("massVesta", 2.59e+15m);                           // [kg * 10^-5] shifted to keep in decimal range
        data.Add("radiusVesta", 262.7m);                            // [km]
        data.Add("distanceSunToVesta", 3.53e+08m);                  // [km]
        data.Add("periodOrbitVesta", 1325.75m);                     // [days] currently not used but may be used later
        data.Add("orbitalSpeedVesta", 19.34m);                      // [km/s]
        data.Add("periodSpinRotationVesta", 5.34m);                 // [hr]
        data.Add("obliquityVesta", 0.0m);                           // [deg]
        data.Add("orbitTiltVesta", 0.0m);                           // [deg]
        labels.Add("focusVesta", "Sun");                            // The object that this object orbit arounds
        labels.Add("orbitDirectionVesta", "AntiClockwise");         // Direction of Rotation defined from above
        labels.Add("spintDirectionVesta", "AntiClockwise");         // Direction of Rotation defined from above

        // Set start to true for confirmation that Dictionaries are being built
        finish = true;
        Debug.Log("Dictionaries: " + labels + " and " + data + "have finished being filled. i.e. finish = " + finish);

    }


}
*/