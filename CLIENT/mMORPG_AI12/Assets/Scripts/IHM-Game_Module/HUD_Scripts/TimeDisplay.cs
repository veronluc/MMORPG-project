using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeDisplay : MonoBehaviour
{
    public Text timeText;

    private void Update()
    {
        DateTime currentTime = DateTime.Now;
        String hour = currentTime.Hour.ToString();
        String minute = currentTime.Minute.ToString();
        String second = currentTime.Second.ToString();

        timeText.text = hour + ":" + minute + ":" + second;
    }
}
