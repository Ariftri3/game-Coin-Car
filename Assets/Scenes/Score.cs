using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score :MonoBehaviour
{
    Text text;
    public static int coinA = 0;

    void Start()
    {
        text = GetComponent<Text>();
    }
    void Update ()
    {
        text.text = "Score: " + coinA;
    }
}