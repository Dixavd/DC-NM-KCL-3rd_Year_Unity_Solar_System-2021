using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateDropdown : MonoBehaviour
{
    public TMP_Dropdown MassDropdown;
    public TMP_Dropdown RadiusDropdown;
    public TMP_Dropdown FocalPointDropdown;
    public TMP_Dropdown Object1Dropdown;
    public TMP_Dropdown DistanceDropdown;
    public TMP_Dropdown DistanceDirectionDropdown;
    public TMP_Dropdown Object2Dropdown;
    public TMP_Dropdown Object3Dropdown;
    public TMP_Dropdown Object4Dropdown;
    public TMP_Dropdown SpeedDropdown;
    public TMP_Dropdown Object5Dropdown;
    public TMP_Dropdown Object6Dropdown;
    public TMP_Dropdown VelocityDirectionDropdown;
    public TMP_Dropdown Object7Dropdown;

    public TMP_InputField nameInputField;
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

    // Object containing Dictionary
    public GameObject dictionaryObject;

    //Define a general list for all dropdowns in the 'Create An Object' panel
    public List<string> createObjectDropdown = new List<string>() { }; // "Sun", "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Moon", "Phobos", "Deimos", "Io", "Europa", "Callisto", "Ganymede", "Titan", "Rhea", "Iapetus", "Titania", "Oberon", "Umbriel", "Ariel", "Triton", "Vesta", "Ceres" };


    IEnumerator WaitForDictionary() 
    {
        // Wait until Dictionary is filled
        yield return new WaitUntil(() => dictionaryObject.GetComponent<Dictionary>().check >= 2);

        // Fill dropdown values
        MassDropdown.AddOptions(createObjectDropdown);
        RadiusDropdown.AddOptions(createObjectDropdown);
        Object1Dropdown.AddOptions(createObjectDropdown);
        Object2Dropdown.AddOptions(createObjectDropdown);
        Object3Dropdown.AddOptions(createObjectDropdown);
        Object4Dropdown.AddOptions(createObjectDropdown);
        Object5Dropdown.AddOptions(createObjectDropdown);
        Object6Dropdown.AddOptions(createObjectDropdown);
        Object7Dropdown.AddOptions(createObjectDropdown);

    }

    // Start is called before the first frame update
    void Start() 
    {
        // find the object with the dictionary script attached
        dictionaryObject = GameObject.Find("Dictionary");
        // Fill dropdowns with dictionary values
        StartCoroutine("WaitForDictionary");

    }

    /* Your Previous Code
    // Start is called before the first frame update
    void Start()
    {
        //Adding all the objects in the createObjectDropdown list to all dropdown manus in the Create An Object panel
        MassDropdown.AddOptions(createObjectDropdown);
        RadiusDropdown.AddOptions(createObjectDropdown);
        ObliquityDropdown.AddOptions(createObjectDropdown);
        SpinRotationPeriodDropdown.AddOptions(createObjectDropdown);
        OrbitTiltDropdown.AddOptions(createObjectDropdown);
        OrbitalSpeedDropdown.AddOptions(createObjectDropdown);
        FocusDropdown.AddOptions(createObjectDropdown);
        Distance1Dropdown.AddOptions(createObjectDropdown);
        Distance2Dropdown.AddOptions(createObjectDropdown);

    }

    public void Update() - The debug logs only show if they're under Update(). I did it for the mass and radius, just to check if the conversion was a success - it worked, we got string outputs. I've put it under comments for now
       Also, here I used intMass and intRadius instead of i cuz I didn't wanna get confused 
    {
        int intMass = MassDropdown.value;
        string stringMass = MassDropdown.options[intMass].text;
        Debug.Log("Selected mass:" + stringMass);

        int intRadius = RadiusDropdown.value;
        string stringRadius = RadiusDropdown.options[intRadius].text;
        Debug.Log("Selected radius:" + stringRadius);

    } 
  
    //FUNCTIONS TO CONVERT INT TO STRING FOR EACH DROPDOWN - I checked, converting the integers to string work, yay! (read comment above)
    public void GetStringMass(int i)
    {
        string stringMass = MassDropdown.options[i].text;
        Debug.Log("Selected mass:" + stringMass);
    }

    public void GetStringRadius(int i)
    {
        string stringRadius = RadiusDropdown.options[i].text;
        Debug.Log("Selected radius:" + stringRadius);
    }

    public void GetStringObliquity(int i)
    {
        string stringObliquity = ObliquityDropdown.options[i].text;
        Debug.Log("Selected obliquity:" + stringObliquity);
    }

    public void GetStringSpinDirection(int i)
    {
        string stringSpinDirection = SpinDirectionDropdown.options[i].text;
        Debug.Log("Selected spin direction:" + stringSpinDirection);
    }
    
    public void GetStringSpinRotationPeriod(int i)
    {
        string stringSpinRotationPeriod = SpinRotationPeriodDropdown.options[i].text;
        Debug.Log("Selected spin rotation period:" + stringSpinRotationPeriod);
    }

    public void GetStringOrbitTilt(int i)
    {
        string stringOrbitTilt = OrbitTiltDropdown.options[i].text;
        Debug.Log("Selected orbit tilt:" + stringOrbitTilt);
    }

    public void GetStringOrbitDirection(int i)
    {
        string stringOrbitDirection = OrbitDirectionDropdown.options[i].text;
        Debug.Log("Selected orbit direction:" + stringOrbitDirection);
    }
    public void GetStringOrbitalSpeed(int i)
    {
        string stringOrbitalSpeed = OrbitalSpeedDropdown.options[i].text;
        Debug.Log("Selected orbital speed:" + stringOrbitalSpeed);
    }

    public void GetStringFocus(int i)
    {
        string stringFocus = FocusDropdown.options[i].text;
        Debug.Log("Selected focus:" + stringFocus);
    }

    public void GetStringDistance1(int i)
    {
        string stringDistance1 = Distance1Dropdown.options[i].text;
        Debug.Log("Selected distance 1:" + stringDistance1);
    }

    public void GetStringDistance2(int i)
    {
        string stringDistance2 = Distance2Dropdown.options[i].text;
        Debug.Log("Selected distance 2:" + stringDistance2);
    }

    //A function to store the newly created object's name as a string variable
    //If no name is entered, ie the placeholder default text is in the input field, the object is automatically named as "New Object"
    public void NameObject(string text)
    {
        if (text == "Enter object name")
        {
            text = "New Object";
        }
        else { }
        string objectName = text;
        Debug.Log("Object name is " + objectName);
    }

    //A function to convert the text in the input field into a float variable that will multiply with the Mass, Radius etc values
    //If 0 is keyed, variable will automatically be assigned to 1 as 0 is unacceptable 
    public void GetFloatMass(string text)
    {
        if (text == "0")
        {
            text = "1";
        }
        else { }
        float floatMass = float.Parse(text);
        Debug.Log("Mass is " + floatMass + " times");
    }

    public void GetFloatRadius(string text)
    {
        if (text == "0")
        {
            text = "1";
        }
        else { }
        float floatRadius = float.Parse(text);
        Debug.Log("Radius is " + floatRadius + " times");
    }

    public void GetFloatObliquity(string text)
    {
        if (text == "0")
        {
            text = "1";
        }
        else { }
        float floatObliquity = float.Parse(text);
        Debug.Log("Obliquity is " + floatObliquity + " times");
    }

    public void GetFloatSpinRotationPeriod(string text)
    {
        if (text == "0")
        {
            text = "1";
        }
        else { }
        float floatSpinRotationPeriod = float.Parse(text);
        Debug.Log("Spin Rotation Period is " + floatSpinRotationPeriod + " times");
    }

    public void GetFloatOrbitTilt(string text)
    {
        if (text == "0")
        {
            text = "1";
        }
        else { }
        float floatOrbitTilt = float.Parse(text);
        Debug.Log("Orbit Tilt is " + floatOrbitTilt + " times");
    }

    public void GetFloatOrbitalSpeed(string text)
    {
        if (text == "0")
        {
            text = "1";
        }
        else { }
        float floatOrbitalSpeed = float.Parse(text);
        Debug.Log("Orbital Speed is " + floatOrbitalSpeed + " times");
    }

    public void GetFloatDistance1(string text)
    {
        if (text == "0")
        {
            text = "1";
        }
        else { }
        float floatDistance1 = float.Parse(text);
        Debug.Log("Distance 1 is " + floatDistance1 + " times");
    }

    public void GetFloatDistance2(string text)
    {
        if (text == "0")
        {
            text = "1";
        }
        else { }
        float floatDistance2 = float.Parse(text);
        Debug.Log("Distance2 is " + floatDistance2 + " times"); 

        //Also, I checked that it really is a float by putting "Distance2 is " + (floatDistance2 + 5) + " times" to see that it does add both numbers together :D
    }

    //A test function to see if variables are stored - THEY ARE :)
    public void Update() 
    {
        NameObject("Anya");
        GetFloatDistance2("4");
    }
    */
}
