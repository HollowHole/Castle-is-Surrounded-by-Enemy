using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CostUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI costText;

    private const int COSTMAX = 100;
    private float cost=20;
    private float Cost
    {
        get
        {
            return cost;
        }
        set
        {
            if (value < 0)
            {
                cost = 0;
            }
            else if (value > COSTMAX)
            {
                cost = COSTMAX;
            }
            else
            {
                cost = value;
            }
            costText.text = "能量：" + ((int)Cost).ToString();
        }
    }
    public int GetCost()
    {
        return (int)Cost;
    }

    public void SetCost(int changedCost)
    {
        Cost += changedCost;
    }

    private void Update()
    {
        Cost+=1*Time.deltaTime;
    }
}
