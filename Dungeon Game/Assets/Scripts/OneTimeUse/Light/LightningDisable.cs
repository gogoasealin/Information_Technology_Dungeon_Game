using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class LightningDisable : MonoBehaviour
{

    [SerializeField] private LightChanger lc;

    public void OnEnable()
    {

        lc.up = true;
        Handheld.Vibrate();
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .1f);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void OnDisable()
    {
        lc.Invoke("StopUp", 1f);
    }

}
