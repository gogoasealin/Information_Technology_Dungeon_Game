using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    public float colorNumber;
    private bool changeColor;
    public bool up;

    void Start()
    {
        StopUp();
    }


    public void StopUp()
    {
        up = false;
    }


    private void Update()
    {
        ChangeLight();
        if (up)
        {
            if (colorNumber < 200)
                colorNumber += 0.1f;
        }
        else
        {
            if (colorNumber > 0)
                colorNumber -= 0.1f;
        }
    }

    void ChangeLight()
    {
        RenderSettings.ambientLight = new Color(colorNumber, colorNumber, colorNumber, colorNumber);
    }
}
