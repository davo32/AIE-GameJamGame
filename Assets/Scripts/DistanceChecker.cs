using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DistanceText;
    private int DistanceGained = 0;

    private void Start()
    {
        DistanceText.text = "0m";
    }

    public void AddDistance()
    {
        DistanceGained++;
        DistanceText.text = DistanceGained.ToString() + "m";

    }
}
