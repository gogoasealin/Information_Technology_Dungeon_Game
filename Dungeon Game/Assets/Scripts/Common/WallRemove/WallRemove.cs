using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRemove : MonoBehaviour {

    [SerializeField] private GameObject wallToRemove;
    public int count;
    private int removedCount;

    private void Start()
    {
        removedCount = 0;
    }
    public void RemoveWall()
    {
        removedCount++;
        if(removedCount == count)
        {
            wallToRemove.SetActive(false);
        }

    }
}
