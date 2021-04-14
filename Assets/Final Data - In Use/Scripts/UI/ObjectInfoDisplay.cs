using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInfoDisplay : MonoBehaviour
{
    public TMP_Dropdown ChooseAnObject;
    public TextMeshProUGUI objectInformation;

    public List<string> mainDropdownObjects = new List<string>() { "Sun", "Mercury", "Venus", "Earth", "Mars", "Vesta", "Ceres", "Jupiter", "Saturn", "Uranus", "Neptune", "Free View Mode" };
    public List<string> secondaryObjects = new List<string>() { "Moon", "Phobos", "Deimos", "Io", "Europa", "Callisto", "Ganymede", "Titan", "Rhea", "Iapetus", "Titania", "Oberon", "Umbriel", "Ariel", "Triton" };

    void Start()
    {
        ChooseAnObject.AddOptions(mainDropdownObjects);
        ChooseAnObject.AddOptions(secondaryObjects);
    }

    public void DisplayInfo(int val)
    {
        if (val == 0)
        {
            objectInformation.text = "Information Display\n\nChoose a planet to display its information here!";
        }
        if (val == 1)
        {
            objectInformation.text = "Sun\n\nThe Sun is a main sequence star at the centre of the Solar System. It has a surface temperature of about 5800K and a core temperature of about 15.7 million K. It is the main source of life on Earth.";
        }
        if (val == 2)
        {
            objectInformation.text = "Mercury\n\nMercury is the smallest planet in the Solar System. It is also closest to, and orbits fastest around the Sun. However, it has very long days - one day on Mercury is equaivalent to 59 days on Earth!";
        }
        if (val == 3)
        {
            objectInformation.text = "Venus\n\nNamed after the goddess of love and beauty, Venus is the hottest planet in the Solar System. Contrary to popular belief, Venus only looks like it's spinning in the opposite direction to the other planets, as it is actually upside down (probably due to collisions from its early life).";
        }
        if (val == 4)
        {
            objectInformation.text = "Earth\n\nThird from the Sun and fifth largest in the Solar System is our planet home Earth. It is the only planet known to have oxygen and liquid water on its surface, providing the best conditions to host life.";
        }
        if (val == 5)
        {
            objectInformation.text = "Mars\n\nNamed after the Roman god of war, Mars is home to the tallest mountain in the Solar System. Despite often dubbed the Red Planet, Mars have blue sunsets and is predicted to have a ring one day.";
        }
        if (val == 6)
        {
            objectInformation.text = "Vesta\n\nVesta is the fourth asteroid ever discovered and holds 9% of the total mass of the Asteroid Belt, making it the second most massive. It is also one of the brightest rocky bodies observed in the Solar System.";
        }
        if (val == 7)
        {
            objectInformation.text = "Ceres\n\nNot only is Ceres the first ever asteroid discovered and the largest in the Asteroid Belt, but it is also the smallest and closest dwarf planet to the Sun. It was named after the Roman goddess of agriculture.";
        }
        if (val == 8)
        {
            objectInformation.text = "Jupiter\n\nJupiter is the fastest-spinning and most massive planet in the Solar System. Besides its red, brown, yellow and white clouds, Jupiter is characterised by the Great Red Spot, a giant spinning storm visible on its surface. In total, it has 67 moons.";
        }
        if (val == 9)
        {
            objectInformation.text = "Saturn\n\nSaturn is the flattest planet and most distant planet to be seen with the naked eye. It has the most extensive rings in the Solar System and the most number of moons - 82! It is mostly made up of hydrogen.";
        }
        if (val == 10)
        {
            objectInformation.text = "Uranus\n\nThe ice giant, Uranus is the seventh planet from the Sun. Contrary to Mercury, it has short days and long years. It is the only planet to spin in the opposite direction and on its side.";
        }
        if (val == 11)
        {
            objectInformation.text = "Neptune\n\nNeptune is the furthest planet from the Sun and the coldest planet in the Solar System. It also has the strongest winds. Its largest moon, Titan will likely be torn apart by the planet's gravitational forces, forming a spectacular ring, billions of years from now.";
        }
        if (val == 12)
        {
            objectInformation.text = "You are now in free view mode. Scroll your mouse to zoom in and out, and click on your arrow keys to move the camera.";
        }
        else if (val==13 | val==14 | val==15| val==16 | val==17 | val==18 | val==19 | val==20 | val==21 | val==22 | val==23 | val==24 | val==25 | val==26 | val==27 )
        {
            objectInformation.text = ChooseAnObject.options[val].text + "\n\nMeet " + ChooseAnObject.options[val].text + ", one of the many moons in the Solar System!";
        }
        else if (val > 27)
        {
            objectInformation.text = ChooseAnObject.options[val].text + "\n\nMeet " + ChooseAnObject.options[val].text + ", a new object generated in the Solar System!";
        }
        else { }

    }
}

