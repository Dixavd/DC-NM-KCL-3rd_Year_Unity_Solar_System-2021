using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateMass : MonoBehaviour
{
    // This Script allows the creation of a whole new object to be created using TMPro UI elements

    // The following dropdowns need to be created and assigned in the Unity Scene View
    // Their initial options should be as shown to the right

    // Dropdowns for user to select from lists
    public TMP_Dropdown MassDropdown;               // "* Mass Unit" , "100,000 kg"
    public TMP_Dropdown RadiusDropdown;             // "* Radius Unit" , "km"
    public TMP_Dropdown FocalPointDropdown;         // "* Focal Point, FP" , "Position of 1" , "(x1,y1,z1)"
    public TMP_Dropdown Object1Dropdown;            // "Object 1"
    public TMP_Dropdown DistanceDropdown;           // "* Distance Unit" , "Distance 2 to 3" , "Radius of 2" , "km" , "Light-Second" , "Light-Year"
    public TMP_Dropdown Object2Dropdown;            // "Object 2" 
    public TMP_Dropdown Object3Dropdown;            // "Object 3" 
    public TMP_Dropdown DistanceDirectionDropdown;  // "* Distance Direction" , "Towards 4" , "Towards (x2,y2,z2)" , "(x2,y2,z2) Normalized", "Spherical: theta1 & phi1 [deg]"
    public TMP_Dropdown Object4Dropdown;            // "Object 4" 
    public TMP_Dropdown SpeedDropdown;              // "* Soeed Unit" , "km/s" , "Speed of Sounds" , "Speed of Light"
    public TMP_Dropdown Object5Dropdown;            // "Object 5" 
    public TMP_Dropdown Object6Dropdown;            // "Object 6" 
    public TMP_Dropdown VelocityDirectionDropdown;  // "* Velocity Direction" , "Towards 7" , "Towards (x3,y3,z3)" , "(x3,y3,z3) Normalized", "Spherical: theta2 & phi2 [deg]"
    public TMP_Dropdown Object7Dropdown;            // "Object 7" 

    // The following input fields need to be created

    // Input field for user to name object using text string
    public TMP_InputField nameInputField;

    // Input fields for user to type in number values using text string (to be converted to floats)
    public TMP_InputField massInputField;
    public TMP_InputField radiusInputField;
    public TMP_InputField vectorX1InputField;
    public TMP_InputField vectorY1InputField;
    public TMP_InputField vectorZ1InputField;
    public TMP_InputField distanceInputField;
    public TMP_InputField vectorX2InputField;
    public TMP_InputField vectorY2InputField;
    public TMP_InputField vectorZ2InputField;
    public TMP_InputField speedInputField;
    public TMP_InputField vectorX3InputField;
    public TMP_InputField vectorY3InputField;
    public TMP_InputField vectorZ3InputField;
    public TMP_InputField theta1InputField;
    public TMP_InputField phi1InputField;
    public TMP_InputField theta2InputField;
    public TMP_InputField phi2InputField;

    // The premade object to be cloned for each new generated object
        // The Prefab object needs to be assigned and have the following Components and Scripts attached:
            // Rigidbody
            // Sphere Collider
            // Trail Render
            // SetInitialConditions.cs
            // GravitationalAttraction.cs
    public GameObject prefabObject;

    // Values to be found from Dropdown
    public string dropdownMassUnit = "None";                // Unit Type for Mass
    public string dropdownRadiusUnit = "None";              // Unit Type for Radius
    public string dropdownFocalPoint = "None";              // How the User wants define where to place the object
    public string dropdownDistanceUnit = "None";            // Unit Type for Distance object is placed away from the focal point
    public string dropdownDistanceDirection = "None";       // How the User wants to define the direction from the focal point
    public string dropdownSpeedUnit = "None";               // Unit Type for Speed
    public string dropdownVelocityDirection = "None";       // How the User wants to define the direction of velocity
    public string dropdownObject1 = "None";                 // Name of object which may be used as the Focal Point
    public string dropdownObject2 = "None";                 // Name of object which may be used to define Distance Unit
    public string dropdownObject3 = "None";                 // Name of object which may be used to define Distance Unit
    public string dropdownObject4 = "None";                 // Name of object which may be used to define Direction of Distance
    public string dropdownObject5 = "None";                 // Name of object which may be used to define Speed Unit
    public string dropdownObject6 = "None";                 // Name of object which may be used to define Speed Unit
    public string dropdownObject7 = "None";                 // Name of object which may be used to define Direction of Velocity

    // Values to be found from input fields
    public string newObjectName = "None";                   // Name the user has chosen to call the object
    public float multipleMass = 1.0f;                       // Number of Mass Unit
    public float multipleRadius = 1.0f;                     // Number of Radius Unit
    public float multipleDistance = 1.0f;                   // Number of Distance Unit
    public float multipleSpeed = 0.0f;                      // Number of Speed Unit
    public float theta1 = 0.0f;                             // Angle which may be used to define Direction of Distance [degrees]
    public float phi1 = 0.0f;                               // Angle which may be used to define Direction of Distance [degrees]
    public float theta2 = 0.0f;                             // Angle which may be used to define Direction of Velocity [degrees]
    public float phi2 = 0.0f;                               // Angle which may be used to define Direction of Velocity [degrees]

    // Vectors which the user may choose to use

    public Vector3 Vector1 = new Vector3(0.0f, 0.0f, 0.0f); // Vector which may be used to define Focal Point
    // Components of Vector 1 to be found from input fields
    public float x1 = 0.0f;
    public float y1 = 0.0f;
    public float z1 = 0.0f;

    public Vector3 Vector2 = new Vector3(0.0f, 0.0f, 0.0f); // Vector which may be used to define Direction of Distance
    // Components of Vector 2 to be found from input fields
    public float x2 = 0.0f;
    public float y2 = 0.0f;
    public float z2 = 0.0f;

    public Vector3 Vector3 = new Vector3(0.0f, 0.0f, 0.0f); // Vector which may be used to define Direction of Velocity
    // Components of Vector 3 to be found from input fields
    public float x3 = 0.0f;
    public float y3 = 0.0f;
    public float z3 = 0.0f;

    // Object with Dictionaries attached
    public GameObject DictionaryObject;
    // Dictionaries for looking up pre-set values
    public Dictionary<string, decimal> data;
    public Dictionary<string, string> labels;

    // Value to be set to true when Generate button is pressed
    public bool startCreation = false;
    
    // Check to make sure new objects are only made after the current one has finished
    public bool runCreation = false;

    // Object with dropdowns
    public GameObject EmptyInformationPanel;
    // List used for objects to follow
    public List<string> mainDropdownList;
    // Dropdown used for following objects
    public TMP_Dropdown ChooseAnObject;

    // Variables used for the scale of the simulation
    // time Unit
    private decimal timeUnit = 17529.4m;                        // [s]
    // mass Unit - shifted to keep in decimal range
    private decimal massUnit = 1e+22m;                          // [kg * 10^-5] shifted to keep in decimal range
    // distance Unit
    private decimal distanceUnit = 1e+7m;                       // [km]

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

    // Object which determines scale of simulation
    private GameObject scalingObject;

    // Rigidbodies of Objects used in object Generation
    public Rigidbody rbObject1;
    public Rigidbody rbObject2;
    public Rigidbody rbObject3;
    public Rigidbody rbObject4;
    public Rigidbody rbObject5;
    public Rigidbody rbObject6;
    public Rigidbody rbObject7;

    // Variables used in object Generation
    public decimal finalMass;
    public decimal finalRadius;
    public decimal finalDistance;
    public decimal finalSpeed;

    // Vectors used in Object Generation
    public Vector3 FPPosition;
    public Vector3 FinalPosition;
    public Vector3 FinalVelocity;
    public Vector3 SphericalOutput;


    IEnumerator WaitDictionary()
    {
        // Set StartCreation to false so an infinite loop is not created
        // i.e. it only briefly becomes true when the generate button is pressed
        startCreation = false;

        // Wait until Dictionary is filled
        yield return new WaitUntil(() => DictionaryObject.GetComponent<Dictionary>().check >= 2);

        // Wait until all default objects are in the scene
        yield return new WaitUntil(() => DictionaryObject.GetComponent<Dictionary>().check >= (2 + (2 * DictionaryObject.GetComponent<Dictionary>().stars) + (2 * DictionaryObject.GetComponent<Dictionary>().planets) + (2 * DictionaryObject.GetComponent<Dictionary>().asteroids) + (2 * DictionaryObject.GetComponent<Dictionary>().moons)));

        data = DictionaryObject.GetComponent<Dictionary>().data;
        labels = DictionaryObject.GetComponent<Dictionary>().labels;

        // Start CoRoutine to create an object
        StartCoroutine("WaitCurrentCreation");

    }
    IEnumerator WaitCurrentCreation()
    {
        // Wait to create a new object while one is already being generated
        yield return new WaitWhile(() => runCreation == true);

        // Set check that creation is running
        runCreation = true;


        // Series of If Statements to end creation if invalid options are chosen
        if (dropdownMassUnit == "None" | dropdownMassUnit == "* Mass Unit")
        {
            Debug.Log("Mass Unit not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        else if (dropdownRadiusUnit == "None" | dropdownRadiusUnit == "* Radius Unit")
        {
            Debug.Log("Radius Unit not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        else if (dropdownFocalPoint == "None" | dropdownFocalPoint == "* Focal Point, FP")
        {
            Debug.Log("Focal Point, FP, not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        else if (dropdownFocalPoint == "Position of 1" & dropdownObject1 == "None" | dropdownFocalPoint == "Position of 1" & dropdownObject1 == "Object 1")
        {
            Debug.Log("Focal Point, FP, dependent on Object 1 but Object 1 is not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        else if (dropdownDistanceUnit == "None" | dropdownDistanceUnit == "* Distance Unit")
        {
            Debug.Log("Distance Unit not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        else if (dropdownDistanceUnit == "Distance 2 to 3" & dropdownObject2 == "None" | dropdownDistanceUnit == "Distance 2 to 3" & dropdownObject2 == "Object 2" | dropdownDistanceUnit == "Radius of 2" & dropdownObject2 == "Object 2")
        {
            Debug.Log("Distance Unit dependent on Object 2 but Object 2 is not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        else if (dropdownDistanceUnit == "Distance 2 to 3" & dropdownObject3 == "None" | dropdownDistanceUnit == "Distance 2 to 3" & dropdownObject3 == "Object 3")
        {
            Debug.Log("Distance Unit dependent on Object 3 but Object 3 is not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        else if (dropdownDistanceDirection == "None" | dropdownDistanceDirection == "* Distance Direction")
        {
            Debug.Log("Distance Direction not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        else if (dropdownDistanceDirection == "Towards 4" & dropdownObject4 == "None" | dropdownDistanceUnit == "Towards 4" & dropdownObject3 == "Object 4")
        {
            Debug.Log("Distance Direction dependent on Object 4 but Object 4 is not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        else if (dropdownSpeedUnit == "None" | dropdownSpeedUnit == "* Speed Unit")
        {
            Debug.Log("Speed Unit not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        else if (dropdownSpeedUnit == "Speed of 5 from 6" & dropdownObject6 == "None" | dropdownSpeedUnit == "Speed of 5 from 6" & dropdownObject6 == "Object 5")
        {
            Debug.Log("Speed Unit dependent on Object 5 but Object 5 is not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        else if (dropdownSpeedUnit == "Speed of 5 from 6" & dropdownObject6 == "None" | dropdownSpeedUnit == "Speed of 5 from 6" & dropdownObject6 == "Object 6")
        {
            Debug.Log("Speed Unit dependent on Object 6 but Object 6 is not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        else if (dropdownVelocityDirection == "None" | dropdownVelocityDirection == "* Velocity Direction")
        {
            Debug.Log("Velocity Direction not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        else if (dropdownVelocityDirection == "Towards 7" & dropdownObject7 == "None" | dropdownDistanceUnit == "Towards 7" & dropdownObject3 == "Object 7")
        {
            Debug.Log("Velocity Direction dependent on Object 7 but Object 7 is not set. An Object CANNOT be created");
            runCreation = false;
            startCreation = false;
        }
        // Continue if valid options given
        // Input values have been forced to default values if none entered
        else
        {
            // Set Vectors (whether to be used or not)
            Vector1 = new Vector3(x1, y1, z1);
            Vector2 = new Vector3(x2, y2, z2);
            Vector3 = new Vector3(x3, y3, z3);

            // Set Mass for object to be created
            if (dropdownMassUnit == "100,000 kg") 
            {
                finalMass = ((decimal)multipleMass * data[dropdownMassUnit]) / massUnit;
                Debug.Log("finalMass set at: " + finalMass);
            }
            else 
            {
                finalMass = ((decimal)multipleMass * data["mass" + dropdownMassUnit]) / massUnit;
                Debug.Log("finalMass set at: " + finalMass);

            }

            // Set Radius for object to be created
            if (dropdownRadiusUnit == "km") 
            {
                finalRadius = ((decimal)multipleRadius * data[dropdownRadiusUnit]) / distanceUnit;
                Debug.Log("finalRadius set at: " + finalRadius);

            }
            else 
            {
                finalRadius = ((decimal)multipleRadius * data["radius" + dropdownRadiusUnit]) / distanceUnit;
                Debug.Log("finalRadius set at: " + finalRadius);
            }


            // Set position of Focal Point, FP.
            if (dropdownFocalPoint == "Position of 1") 
            {
                rbObject1 = GameObject.Find(dropdownObject1).GetComponent<Rigidbody>();
                FPPosition = rbObject1.position;

                Debug.Log("Focal Position set for: " + FPPosition);
            }
            else if (dropdownFocalPoint == "(x1,y1,z1)")
            {
                FPPosition = Vector1;
                Debug.Log("Focal Position set for: " + FPPosition);

            }

            // Set distance from FP the created object will be placed
            // Then will activate function to use distance direction options to set position
            // Then will activate function to use speed inputs to calculate speed
            // Then will activate function to use velocity direction options to set velocity
            if (dropdownDistanceUnit == "Distance 2 to 3") 
            {
                rbObject2 = GameObject.Find(dropdownObject2).GetComponent<Rigidbody>();
                rbObject3 = GameObject.Find(dropdownObject3).GetComponent<Rigidbody>();
                finalDistance = (decimal)(multipleDistance) * (decimal)(rbObject2.position - rbObject3.position).magnitude;

                Debug.Log("finalDistance set at: " + finalDistance);


                // After setting the distance
                // Find the direction and set the final position with this function
                FindFinalPosition();
            }
            else if (dropdownDistanceUnit == "Radius of 2") 
            {
                finalDistance = (decimal)(multipleDistance) * data["radius" + dropdownObject2] / distanceUnit;

                Debug.Log("finalDistance set at: " + finalDistance);

                // After setting the distance
                // Find the direction and set the final position with this function
                FindFinalPosition();
            }
            else if (dropdownDistanceUnit == "km" | dropdownDistanceUnit == "Light-Second" | dropdownDistanceUnit == "Light-Year")
            {
                finalDistance = (decimal)(multipleDistance) * data[dropdownDistanceUnit] / distanceUnit;

                Debug.Log("finalDistance set at: " + finalDistance);

                // After setting the distance
                // Find the direction and set the final position with this function
                FindFinalPosition();
            }
        }
    }

    // Awake is called first
    void Awake()
    {
        // Make sure checking values are correctly at default state
        startCreation = false;
        runCreation = false;

        // Find Dictionaries
        DictionaryObject = GameObject.Find("Dictionary");
        data = DictionaryObject.GetComponent<Dictionary>().data;
        labels = DictionaryObject.GetComponent<Dictionary>().labels;

        // Find Dropdown List
        EmptyInformationPanel = GameObject.Find("EmptyInformationPanel");
        mainDropdownList = EmptyInformationPanel.GetComponent<ObjectInfoDisplay>().mainDropdownObjects;
        ChooseAnObject = EmptyInformationPanel.GetComponent<ObjectInfoDisplay>().ChooseAnObject;

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
        }

    }

    // Update is called once per frame
    void Update()
    {

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
            FinalVelocity *= (float)(1.0m / conversionTime);
            finalSpeed *= (decimal)(1.0m / conversionTime);

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
            finalMass *= oldMassUnit / massUnit;

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
            Vector1 *= (float)conversionDistance;
            x1 *= (float)conversionDistance;
            y1 *= (float)conversionDistance;
            z1 *= (float)conversionDistance;

            Vector2 *= (float)conversionDistance;
            x2 *= (float)conversionDistance;
            y2 *= (float)conversionDistance;
            z2 *= (float)conversionDistance;

            Vector3 *= (float)conversionDistance;
            x3 *= (float)conversionDistance;
            y3 *= (float)conversionDistance;
            z3 *= (float)conversionDistance;

            finalDistance *= (decimal)conversionDistance;
            finalRadius *= (decimal)conversionDistance;
            finalSpeed *= (decimal)conversionDistance;

            FPPosition *= (float)conversionDistance;
            FinalPosition *= (float)conversionDistance;
            FinalVelocity *= (float)conversionDistance;
            SphericalOutput *= (float)conversionDistance;


            finalRadius *= conversionDistance;

            // Update previous Distrance Unit for use at next change of Distance Variable
            oldDistanceUnit = distanceUnit;
        }

        // Begin process to create an object
        if (startCreation == true)
        {
            StartCoroutine("WaitDictionary");
        }
    }



    // Functions to Call


    // Function to get Users choice of how to define Mass Unit
    public void SetMass(int i) 
    {
        dropdownMassUnit = MassDropdown.options[i].text;
        Debug.Log("Mass Unit selected is: " + dropdownMassUnit);

    }

    // Function to get Users choice of how to define Radius Unit
    public void SetRadius(int i)
    {
        dropdownRadiusUnit = RadiusDropdown.options[i].text;
        Debug.Log("Radius Unit selected is: " + dropdownRadiusUnit);

    }

    // Function to get Users choice of how to define Focal Point
    public void SetFocalPoint(int i)
    {
        dropdownFocalPoint = FocalPointDropdown.options[i].text;
        Debug.Log("Focal Point selected: " + dropdownFocalPoint);

    }

    // Function to get Users choice of how to define Distance Unit
    public void SetDistance(int i)
    {
        dropdownDistanceUnit = DistanceDropdown.options[i].text;
        Debug.Log("Distance Unit selected: " + dropdownDistanceUnit);

    }

    // Function to get Users choice of how to define Direction of Distance
    public void SetDistanceDirection(int i)
    {
        dropdownDistanceDirection = DistanceDirectionDropdown.options[i].text;
        Debug.Log("Distance Direction selected: " + dropdownDistanceDirection);

    }

    // Function to get Users choice of how to define Speed Unit
    public void SetSpeed(int i)
    {
        dropdownSpeedUnit = SpeedDropdown.options[i].text;
        Debug.Log("Speed Unit selected: " + dropdownSpeedUnit);

    }

    // Function to get Users choice of how to define Direction of Velocity
    public void SetVelocityDirection(int i)
    {
        dropdownVelocityDirection = VelocityDirectionDropdown.options[i].text;
        Debug.Log("Velocity Direction selected: " + dropdownVelocityDirection);

    }

    // Function to get name of Object 1
    // Only Used if Focal Point Option chosen involves Object 1
    public void SetObject1(int i)
    {
        dropdownObject1 = Object1Dropdown.options[i].text;
        Debug.Log("Object 1 selected: " + dropdownObject1);

    }

    // Function to get name of Object 2
    // Only Used if Distance Unit Option chosen involves Object 2
    public void SetObject2(int i)
    {
        dropdownObject2 = Object2Dropdown.options[i].text;
        Debug.Log("Object 2 selected: " + dropdownObject2);

    }

    // Function to get name of Object 3
    // Only Used if Distance Unit Option chosen involves Object 3
    public void SetObject3(int i)
    {
        dropdownObject3 = Object3Dropdown.options[i].text;
        Debug.Log("Object 3 selected: " + dropdownObject3);

    }

    // Function to get name of Object 4
    // Only Used if Distance Direction Option chosen involves Object 4
    public void SetObject4(int i)
    {
        dropdownObject4 = Object4Dropdown.options[i].text;
        Debug.Log("Object 4 selected: " + dropdownObject4);

    }

    // Function to get name of Object 5
    // Only Used if Speed Unit Option chosen involves Object 5
    public void SetObject5(int i)
    {
        dropdownObject5 = Object5Dropdown.options[i].text;
        Debug.Log("Object 5 selected: " + dropdownObject5);

    }

    // Function to get name of Object 6
    // Only Used if Speed Unit Option chosen involves Object 6
    public void SetObject6(int i)
    {
        dropdownObject6 = Object6Dropdown.options[i].text;
        Debug.Log("Object 6 selected: " + dropdownObject6);

    }

    // Function to get name of Object 7
    // Only Used if Velocity Direction Option chosen involves Object 7
    public void SetObject7(int i)
    {
        dropdownObject7 = Object7Dropdown.options[i].text;
        Debug.Log("Object 7 selected: " + dropdownObject7);

    }

    // Function to get the Name the User has chosen for the object
    // Sends to the nameCheck function to find out if the name is taken
    public void GetNewObjectName(string text)
    {
        int n = 1;
        newObjectName = text;
        nameCheck(text, n);
    }

    // Function to determine if an object of the chosen name already exists
    // If it does exist, iterates the name by the digit 1 and repeats
    public void nameCheck(string text, int n) 
    {
        if (mainDropdownList.Contains(newObjectName) == true)
        {
            Debug.Log(newObjectName + " was found in the list of objects in the scene. The name will be iterated");
            newObjectName = text + n;
            n += 1;
            nameCheck(text, n);
        }
        else
        {
            Debug.Log("Created Object will be named " + newObjectName);
        }
    }


    // Function to obtain multiple of Mass Unit input
    public void GetMultipleMass(string text)
    {
        // Sets multiple to positive if a negative value is entered
        if (float.Parse(text) < 0)
        {
            multipleMass = (-1.0f) * float.Parse(text);
            Debug.Log("Mass is " + multipleMass + " times chosen Mass Unit");
        }
        // Sets multiple exactly if a viable (positive) value is entered
        else if (float.Parse(text) > 0)
        {
            multipleMass = float.Parse(text);
            Debug.Log("Mass is " + multipleMass + " times chosen Mass Unit");
        }
        // Otherwise, sets the unit to 1
        // For instance, Mass cannot be 0 or a non-number
        else
        {
            multipleMass = 1.0f;
            Debug.Log("Mass is " + multipleMass + " times chosen Mass Unit");
        }
    }

    public void GetMultipleRadius(string text)
    {
        // Sets multiple to positive if a negative value is entered
        if (float.Parse(text) < 0)
        {
            multipleRadius = (-1.0f) * float.Parse(text);
            Debug.Log("Radius is " + multipleRadius + " times chosen Radius Unit");
        }
        // Sets multiple exactly if a viable (positive) value is entered
        else if (float.Parse(text) > 0)
        {
            multipleRadius = float.Parse(text);
            Debug.Log("Radius is " + multipleRadius + " times chosen Radius Unit");
        }
        // Otherwise, sets the unit to 1
        // For instance, Radius cannot be 0 or a non-number
        else
        {
            multipleRadius = 1.0f;
            Debug.Log("Radius is " + multipleRadius + " times chosen Radius Unit");
        }
    }

    public void GetMultipleDistance(string text)
    {
        // Sets multiple exactly if a negative value is entered
        // I'm allowing this because the user may mean they want the object set in the opposite direction to to the one they describe
        if (float.Parse(text) < 0)
        {
            multipleDistance = float.Parse(text);
            Debug.Log("Distance is " + multipleDistance + " times chosen Distance Unit");
        }
        // Sets multiple exactly if a viable (positive) value is entered
        else if (float.Parse(text) > 0)
        {
            multipleDistance = float.Parse(text);
            Debug.Log("Distance is " + multipleDistance + " times chosen Distance Unit");
        }
        // Otherwise, sets the unit to 1
        // For instance, Distance cannot be 0 or a non-number
        else
        {
            multipleDistance = 1.0f;
            Debug.Log("Distance is " + multipleDistance + " times chosen Distance Unit");
        }
    }


    public void GetMultipleSpeed(string text)
    {
        // Sets multiple exactly if a negative value is entered
        // I'm allowing this because the user may mean they want the object moving in the opposite direction to to the one they describe
        if (float.Parse(text) < 0)
        {
            multipleSpeed = float.Parse(text);
            Debug.Log("Speed is " + multipleSpeed + " times chosen Speed Unit");
        }
        // Sets multiple exactly if a viable (positive) value is entered
        else if (float.Parse(text) > 0)
        {
            multipleSpeed = float.Parse(text);
            Debug.Log("Speed is " + multipleSpeed + " times chosen Speed Unit");
        }
        // Otherwise, sets the unit to 0
        // For instance, Speed must be a number (but it can be 0)
        else
        {
            multipleSpeed = 0.0f;
            Debug.Log("Speed is " + multipleSpeed + " times chosen Speed Unit");
        }

    }

    // Function to get the value of Theta1
    // Only Used if Distance Direction Option chosen is Spherical Units
    public void GetTheta1(string text)
    {
        // if Angle is smaller than -360 degrees, removes the superfluous full rotations
        if (float.Parse(text) <= -360.0f) 
        {
            theta1 = float.Parse(text) + (360.0f * Mathf.Floor(float.Parse(text) / -360.0f));
            Debug.Log("Angle Theta1 is: " + theta1 + " degrees");
        }
        // if Angle is greater than +360 degrees, removes the superfluous full rotations
        else if (float.Parse(text) >= 360.0f) 
        {
            theta1 = float.Parse(text) - (360.0f * Mathf.Floor(float.Parse(text) / 360.0f));
            Debug.Log("Angle Theta1 is: " + theta1 + " degrees");
        }
        // Sets Angle exactly if it's within 1 rotation (positively or negatively)
        else if (float.Parse(text) > -360.0f & float.Parse(text) < 360.0f)
        {
            theta1 = float.Parse(text);
        }
        // Otherwise, sets the angle to 0
        // For instance, Angle must be a number (but it can be 0 degrees)
        else
        {
            theta1 = 0.0f;
            Debug.Log("Angle Theta1 is: " + theta1 + " degrees");
        }
    }

    // Function to get the value of Phi1
    // Only Used if Distance Direction Option chosen is Spherical Units
    public void GetPhi1(string text)
    {
        // if Angle is smaller than -360 degrees, removes the superfluous full rotations
        if (float.Parse(text) <= -360.0f)
        {
            phi1 = float.Parse(text) + (360.0f * Mathf.Floor(float.Parse(text) / -360.0f));
            Debug.Log("Angle Phi1 is: " + phi1 + " degrees");
        }
        // if Angle is greater than +360 degrees, removes the superfluous full rotations
        else if (float.Parse(text) >= 360.0f)
        {
            phi1 = float.Parse(text) - (360.0f * Mathf.Floor(float.Parse(text) / 360.0f));
            Debug.Log("Angle Phi1 is: " + phi1 + " degrees");
        }
        // Sets Angle exactly if it's within 1 rotation (positively or negatively)
        else if (float.Parse(text) > -360.0f & float.Parse(text) < 360.0f)
        {
            phi1 = float.Parse(text);
        }
        // Otherwise, sets the angle to 0
        // For instance, Angle must be a number (but it can be 0 degrees)
        else
        {
            phi1 = 0.0f;
            Debug.Log("Angle Phi1 is: " + phi1 + " degrees");
        }
    }

    // Function to get the value of Theta2
    // Only Used if Distance Velocity Option chosen is Spherical Units
    public void GetTheta2(string text)
    {
        // if Angle is smaller than -360 degrees, removes the superfluous full rotations
        if (float.Parse(text) <= -360.0f)
        {
            theta2 = float.Parse(text) + (360.0f * Mathf.Floor(float.Parse(text) / -360.0f));
            Debug.Log("Angle Theta2 is: " + theta2 + " degrees");
        }
        // if Angle is greater than +360 degrees, removes the superfluous full rotations
        else if (float.Parse(text) >= 360.0f)
        {
            theta2 = float.Parse(text) - (360.0f * Mathf.Floor(float.Parse(text) / 360.0f));
            Debug.Log("Angle Theta2 is: " + theta2 + " degrees");
        }
        // Sets Angle exactly if it's within 1 rotation (positively or negatively)
        else if (float.Parse(text) > -360.0f & float.Parse(text) < 360.0f)
        {
            theta2 = float.Parse(text);
        }
        // Otherwise, sets the angle to 0
        // For instance, Angle must be a number (but it can be 0 degrees)
        else
        {
            theta2 = 0.0f;
            Debug.Log("Angle Theta2 is: " + theta2 + " degrees");
        }
    }

    // Function to get the value of Phi2
    // Only Used if Distance Velocity Option chosen is Spherical Units
    public void GetPhi2(string text)
    {
        // if Angle is smaller than -360 degrees, removes the superfluous full rotations
        if (float.Parse(text) <= -360.0f)
        {
            phi2 = float.Parse(text) + (360.0f * Mathf.Floor(float.Parse(text) / -360.0f));
            Debug.Log("Angle Phi2 is: " + phi2 + " degrees");
        }
        // if Angle is greater than +360 degrees, removes the superfluous full rotations
        else if (float.Parse(text) >= 360.0f)
        {
            phi2 = float.Parse(text) - (360.0f * Mathf.Floor(float.Parse(text) / 360.0f));
            Debug.Log("Angle Phi2 is: " + phi2 + " degrees");
        }
        // Sets Angle exactly if it's within 1 rotation (positively or negatively)
        else if (float.Parse(text) > -360.0f & float.Parse(text) < 360.0f)
        {
            phi2 = float.Parse(text);
        }
        // Otherwise, sets the angle to 0
        // For instance, Angle must be a number (but it can be 0 degrees)
        else
        {
            phi2 = 0.0f;
            Debug.Log("Angle Phi2 is: " + phi2 + " degrees");
        }
    }

    // Functions to determine components of Vector 1
    // Only Used if Focal Point Option chosen involves a vector
    // Function to get x-component of Vector 1
    public void Getvectorx1(string text)
    {
        // If statement to make sure x1 has a value
        // I.E. Sets x1 to 0 if no number is entered
        if (float.Parse(text) < 0 | float.Parse(text) > 0) 
        {
            x1 = float.Parse(text);
            Debug.Log("x1 is " + x1);
        }
        else 
        {
            x1 = 0.0f;
            Debug.Log("x1 is " + x1);
        }
    }
    // Function to get y-component of Vector 1
    public void Getvectory1(string text)
    {
        // If statement to make sure y1 has a value
        // I.E. Sets y1 to 0 if no number is entered
        if (float.Parse(text) < 0 | float.Parse(text) > 0)
        {
            y1 = float.Parse(text);
            Debug.Log("y1 is " + y1);
        }
        else
        {
            y1 = 0.0f;
            Debug.Log("y1 is " + y1);
        }
    }
    // Function to get z-component of Vector 1
    public void Getvectorz1(string text)
    {
        // If statement to make sure z1 has a value
        // I.E. Sets z1 to 0 if no number is entered
        if (float.Parse(text) < 0 | float.Parse(text) > 0)
        {
            z1 = float.Parse(text);
            Debug.Log("z1 is " + z1);
        }
        else
        {
            z1 = 0.0f;
            Debug.Log("z1 is " + z1);
        }
    }

    // Functions to determine components of Vector 2
    // Only Used if Distance Direction Option chosen involves a vector
    // Function to get x-component of Vector 2
    public void Getvectorx2(string text)
    {
        // If statement to make sure x2 has a value
        // I.E. Sets x2 to 0 if no number is entered
        if (float.Parse(text) < 0 | float.Parse(text) > 0)
        {
            x2 = float.Parse(text);
            Debug.Log("x2 is " + x2);
        }
        else
        {
            x2 = 0.0f;
            Debug.Log("x2 is " + x2);
        }
    }
    // Function to get y-component of Vector 2
    public void Getvectory2(string text)
    {
        // If statement to make sure y2 has a value
        // I.E. Sets y2 to 0 if no number is entered
        if (float.Parse(text) < 0 | float.Parse(text) > 0)
        {
            y2 = float.Parse(text);
            Debug.Log("y2 is " + y2);
        }
        else
        {
            y2 = 0.0f;
            Debug.Log("y2 is " + y2);
        }
    }
    // Function to get z-component of Vector 2
    public void Getvectorz2(string text)
    {
        // If statement to make sure z2 has a value
        // I.E. Sets z2 to 0 if no number is entered
        if (float.Parse(text) < 0 | float.Parse(text) > 0)
        {
            z2 = float.Parse(text);
            Debug.Log("z2 is " + z2);
        }
        else
        {
            z2 = 0.0f;
            Debug.Log("z2 is " + z2);
        }
    }

    // Functions to determine components of Vector 3
    // Only Used if Velocity Direction Option chosen involves a vector
    // Function to get x-component of Vector 3
    public void Getvectorx3(string text)
    {
        // If statement to make sure x3 has a value
        // I.E. Sets x3 to 0 if no number is entered
        if (float.Parse(text) < 0 | float.Parse(text) > 0)
        {
            x3 = float.Parse(text);
            Debug.Log("x3 is " + x3);
        }
        else
        {
            x3 = 0.0f;
            Debug.Log("x3 is " + x3);
        }
    }
    // Function to get y-component of Vector 3

    public void Getvectory3(string text)
    {
        // If statement to make sure y3 has a value
        // I.E. Sets y3 to 0 if no number is entered
        if (float.Parse(text) < 0 | float.Parse(text) > 0)
        {
            y3 = float.Parse(text);
            Debug.Log("y3 is " + y3);
        }
        else
        {
            y3 = 0.0f;
            Debug.Log("y3 is " + y3);
        }
    }
    // Function to get z-component of Vector 3
    public void Getvectorz3(string text)
    {
        // If statement to make sure z3 has a value
        // I.E. Sets z3 to 0 if no number is entered
        if (float.Parse(text) < 0 | float.Parse(text) > 0)
        {
            z3 = float.Parse(text);
            Debug.Log("z3 is " + z3);
        }
        else
        {
            z3 = 0.0f;
            Debug.Log("z3 is " + z3);
        }
    }

    // Function which sets the bool used to determine if an object should be created to true
    // This will be used when the user clicks the generate key
    public void StartCreation() 
    {
        startCreation = true;
        Debug.Log("Generate Button input registered, now startCreation is: " + startCreation);
    }

    // Function to set the Initial Position a created object will be set
    public void FindFinalPosition() 
    {
        if (dropdownDistanceDirection == "Towards 4")
        {
            rbObject4 = GameObject.Find(dropdownObject4).GetComponent<Rigidbody>();
            FinalPosition = FPPosition + ((float)finalDistance * (rbObject4.position - FPPosition).normalized);

            Debug.Log("FinalPosition set for: " + FinalPosition);

            // Set initial speed of the created object
            FindFinalSpeed();
        }
        else if (dropdownDistanceDirection == "Towards (x2,y2,z2)")
        {
            FinalPosition = FPPosition + ((float)finalDistance * (Vector2 - FPPosition).normalized);

            Debug.Log("FinalPosition set for: " + FinalPosition);

            // Set initial speed of the created object
            FindFinalSpeed();
        }
        else if (dropdownDistanceDirection == "(x2,y2,z2) Normalized")
        {
            FinalPosition = FPPosition + ((float)finalDistance * (Vector2.normalized));

            Debug.Log("FinalPosition set for: " + FinalPosition);

            // Set initial speed of the created object
            FindFinalSpeed();
        }
        else if (dropdownDistanceDirection == "Spherical: theta1 & phi1 [deg]")
        {
            Spherical((float)finalDistance, theta1, phi1);
            FinalPosition = FPPosition + SphericalOutput;

            Debug.Log("FinalPosition set for: " + FinalPosition);

            // Set initial speed of the created object
            FindFinalSpeed();
        }
    }

    // Function to set the initial Speed of a created object
    public void FindFinalSpeed() 
    {
        if (dropdownSpeedUnit == "Speed of 5 from 6")
        {
            rbObject5 = GameObject.Find(dropdownObject5).GetComponent<Rigidbody>();
            rbObject6 = GameObject.Find(dropdownObject6).GetComponent<Rigidbody>();
            finalSpeed = (decimal)(multipleSpeed) * (decimal)(rbObject5.velocity - rbObject6.velocity).magnitude;

            Debug.Log("finalSpeed set for: " + finalSpeed);

            // After setting the speed
            // Find the direction and set the final velocity with this function
            FindFinalVelocity();
        }
        else if (dropdownSpeedUnit == "km/s" | dropdownSpeedUnit == "Speed of Sound" | dropdownSpeedUnit == "Speed of Light")
        {
            finalSpeed = (decimal)(multipleSpeed) * data[dropdownSpeedUnit] * (timeUnit / distanceUnit);

            Debug.Log("finalSpeed set for: " + finalSpeed);

            // After setting the speed
            // Find the direction and set the final velocity with this function
            FindFinalVelocity();
        }
    }

    // Function to set the velocity a created object will be set
    public void FindFinalVelocity()
    {
        if (dropdownVelocityDirection == "Towards 7")
        {
            rbObject7 = GameObject.Find(dropdownObject7).GetComponent<Rigidbody>();
            FinalVelocity = ((float)finalSpeed * (rbObject7.position - FinalPosition).normalized);

            Debug.Log("FinalVelocity set for: " + FinalVelocity);

            // Finally, begin object creation
            ObjectCreation();
        }
        else if (dropdownVelocityDirection == "Towards (x3,y3,z3)")
        {
            FinalVelocity = ((float)finalSpeed * (Vector3 - FinalPosition).normalized);
            Debug.Log("FinalVelocity set for: " + FinalVelocity);

            // Finally, begin object creation
            ObjectCreation();
        }
        else if (dropdownVelocityDirection == "(x3,y3,z3) Normalized")
        {
            FinalVelocity = ((float)finalSpeed * Vector3.normalized);
            Debug.Log("FinalVelocity set for: " + FinalVelocity);

            // Finally, begin object creation
            ObjectCreation();
        }
        else if (dropdownVelocityDirection == "Spherical: theta2 & phi2 [deg]")
        {
            Spherical((float)finalSpeed, theta2, phi2);
            FinalVelocity = SphericalOutput;
            Debug.Log("FinalVelocity set for: " + FinalVelocity);

            // Finally, begin object creation
            ObjectCreation();
        }
    }


    // Function to create a Cartesian Vector out of Spherical Co-Ordinates
    public void Spherical(float r, float theta, float phi) 
    {
        float x = r * Mathf.Sin(theta * (Mathf.PI/180)) * Mathf.Cos(phi * (Mathf.PI / 180));
        float y = r * Mathf.Cos(theta * (Mathf.PI / 180));
        float z = -r * Mathf.Sin(theta * (Mathf.PI / 180)) * Mathf.Sin(phi * (Mathf.PI / 180));

        SphericalOutput = new Vector3(x, y, z);
        Debug.Log("SphericalOutput calculated " + SphericalOutput);

    }

    // Function to create an object using the input values obtained from the UI
    public void ObjectCreation()
    {
        // Create a copy of the prefab object at the calculated position
        GameObject createdObject = (GameObject)Instantiate(prefabObject, FinalPosition, Quaternion.identity);
        Debug.Log(createdObject + " was created");

        // Set object's name to chosen name
        createdObject.name = newObjectName;
        Debug.Log("The new object's name is now: " + createdObject.name);

        // Obtain Rigidbody and SphereCollider components of created object
        Rigidbody rbCreated = createdObject.GetComponent<Rigidbody>();
        SphereCollider scCreated = createdObject.GetComponent<SphereCollider>();

        // Didn't get around to adding into the UI the ability to choose a custom spin
        // Therefore, this object will not spin
        createdObject.GetComponent<SetInitialConditions>().runSpin = false;

        // Set created object's mass
        createdObject.GetComponent<SetInitialConditions>().scaledMass = finalMass;
        rbCreated.mass = (float)finalMass;

        // Set created object's radius
        createdObject.GetComponent<SetInitialConditions>().scaledRadius = finalRadius;
        scCreated.radius = (float)finalRadius;

        // set created object's velocity
        rbCreated.velocity = FinalVelocity;

        // Add object to the list of objects that the UI can follow
        mainDropdownList.Add(createdObject.name);
        // Create a new list containing only this new object's name
        List<string> objectAdd = new List<string>() { createdObject.name };
        // Add list to options of objects to follow
        ChooseAnObject.AddOptions(objectAdd);

        // Set render size multiplier used when determined via camera rather than actual radius
        createdObject.GetComponent<SetInitialConditions>().defaultRenderSize = new Vector3(0.5f, 0.5f, 0.5f);

        // Confirm in the GravitationalAttraction script that this new created object is ready to affect the gravity of others
        createdObject.GetComponent<GravitationalAttraction>().runGravity = true;

        // Reset trail (in case it had jumped positions when initially created)
        createdObject.GetComponent<TrailRenderer>().Clear();

        // Confirm objected has been fully created and this cycle of object creation can end
        runCreation = false;
        Debug.Log(createdObject + " was fully setup");
    }


    /* Variables to obtain from the UI:
     
     * Name of Object
     
     * Dropdown "* Mass Unit" + "100,000 kg" + objects in dictionary: "Sun", "Earth", "Moon", etc...
     * Input float multipleMass
      
     * Dropdown "* Radius Unit" + "km" + Objects in dictionary: "Sun", "Earth", "Moon", etc...
     * Input float multipleRadius
      
     * Dropdown "* Focal Point, FP" + "Position of 1" + "(x1,y1,z1)"
     * Dropdown "Object 1" + Objects in dictionary: "Sun", "Earth", "Moon", etc...
     * Input float x1
     * Input float y1
     * Input float z1
    
     * Distance Unit - "Distance 2 to 3" , "Radius of 2", "km", "light-second", "light-year"
     * Object 2 - list of all objects in scene
     * Object 3 - list of all objects in scene
     * float multipleDistance
    
     * Distance Direction - "FP to 4", "FP to (x2,y2,z2)", "(x2,y2,z2) Normalized" "Sphereical: Theta1 & Phi1 (degrees)",
     * Object 4 - list of all objects in scene
     * float x2
     * float y2
     * float z2
     * Theta1
     * Phi1
 
     //* Speed Unit - "Speed of 5 from 6", "km/s", "speed of sound", "speed of light"
     //* Object 5 - list of all objects in scene
     //* Object 6 - list of all objects in scene
     //* float multipleSpeed

     * Velocity Direction - "Towards 7", "Towards (x3, y3, z3)", "(x3,y3,z3) Normalized",  "Perpendicular to 7 and (x3,y3,z3)", "Sphereical: Theta2 & Phi2 (degrees)",
     //* float x3
     //* float y3
     //* float z3
     //* Object 7 - list of all objects in scene
     * Theta2
     * Phi2
     
     */
}