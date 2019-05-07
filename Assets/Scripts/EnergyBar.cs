using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    Image energyBar;
    float maxEnergy = 10f;
    public static float energy;

    void Start()
    {
        energyBar = GetComponent<Image>();
        energy = maxEnergy;
    }

    void Update()
    {
        energyBar.fillAmount = energy / maxEnergy;
    }
}
