using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    Image energyBar;
    public static float MaxEnergy = 10f;
    public static float Energy;

    void Start()
    {
        energyBar = GetComponent<Image>();
        Energy = MaxEnergy;
    }

    void Update()
    {
        energyBar.fillAmount = Energy / MaxEnergy;
    }
}
