using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Energy : MonoBehaviour
{
    private static TMP_Text energyAmmount;
    public static float currentEnergy;

    private void Start()
    {
        currentEnergy = 200;
        energyAmmount = GetComponent<TMP_Text>();
        energyAmmount.text = currentEnergy.ToString();   
    }

    public static void ChangeEnergy(float energyToGain)
    {
        currentEnergy += energyToGain;
        energyAmmount.text = currentEnergy.ToString();

    }

}
