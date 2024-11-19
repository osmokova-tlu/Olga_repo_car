using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class SpeedRacer : MonoBehaviour
{
    public string carModel = "GTR R35";
    public string engineType = "V6, Twin Turbo";
    public int carWeight = 1609;
    public int yearMade = 2009;
    public float maxAcceleration = 0.98f;
    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = true;
    public string carMaker;

    public class Fuel
    {
        public int fuelLevel;

        public Fuel(int amount)
        {
            fuelLevel = amount;
        }
    }

    public Fuel carFuel = new Fuel(100);

    void Start()
    {
        Debug.Log($"Car Maker: {carMaker}, Model: {carModel}, Engine Type: {engineType}");

        CheckWeight();

        if (yearMade > 2009)
        {
            Debug.Log("The car was introduced in the 2010’s.");
            Debug.Log($"Maximum acceleration: {maxAcceleration}");
        }
        else
        {
            Debug.Log($"The car was introduced in {yearMade}.");
            int carAge = CalculateAge(yearMade);
            Debug.Log($"The car is {carAge} years old.");
        }

        Debug.Log(CheckCharacteristics());
    }

    private void CheckWeight()
    {
        if (carWeight < 1500)
        {
            Debug.Log($"{carModel} weighs less than 1500 kg.");
        }
        else
        {
            Debug.Log($"{carModel} weighs over 1500 kg.");
        }
    }

    private int CalculateAge(int year)
    {
        return 2023 - year;
    }

    private string CheckCharacteristics()
    {
        if (isCarTypeSedan)
        {
            return "The car type is a sedan.";
        }
        else if (hasFrontEngine)
        {
            return "The car isn't a sedan, but it has a front engine.";
        }
        else
        {
            return "The car is neither a sedan nor does it have a front engine.";
        }
    }

    private void ConsumeFuel()
    {
        carFuel.fuelLevel -= 10;
    }

    private void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                Debug.Log("Fuel level is nearing two-thirds.");
                break;
            case 50:
                Debug.Log("Fuel level is at half amount.");
                break;
            case 10:
                Debug.Log("Warning! Fuel level is critically low.");
                break;
            default:
                Debug.Log("Fuel level is fine, nothing to report.");
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConsumeFuel();
            CheckFuelLevel();
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}