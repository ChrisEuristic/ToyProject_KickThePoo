using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider energybar;
    void Update()
    {
        energybar.value = PlayerMove.energy;
        if(energybar.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);
    }
}
