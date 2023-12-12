using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TimeManager : MonoBehaviour
{

    public TextMeshProUGUI timerTxt;

    public float currentTime;

    public bool flag = false;

    private void Update()
    {
        if (flag)
            return;

        currentTime += Time.deltaTime;
        timerTxt.text = currentTime.ToString("0.0");
    }
}
