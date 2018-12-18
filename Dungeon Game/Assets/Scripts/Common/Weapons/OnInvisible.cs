using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInvisible : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
