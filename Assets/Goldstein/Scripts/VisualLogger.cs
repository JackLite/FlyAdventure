using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class VisualLogger : MonoBehaviour
{
    private static VisualLogger instance;
    private Text textUI;
    private void Awake()
    {
        instance = this;
        textUI = GetComponent<Text>();
    }

    public static void Log(string text)
    {
        instance.textUI.text = text;
    }
}
