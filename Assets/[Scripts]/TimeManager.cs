using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TimeManager : MonoBehaviour
{

    public TextMeshProUGUI timerTxt;

    public float currentTime;

    private void Update()
    {
        currentTime += Time.deltaTime;
        timerTxt.text = currentTime.ToString("0.0");
    }
}
