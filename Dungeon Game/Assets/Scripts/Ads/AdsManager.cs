using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdsManager : MonoBehaviour
{
#if UNITY_ANDROID
    private string gameId = "2091336";
#elif UNITY_IOS
    private string gameId = "2091337";
#endif

    private GameController gameControllerScript;


    public void InitializeAdd()
    {
        Advertisement.Initialize(gameId);
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdResult });
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                gameControllerScript.AddShowSuccesfully();
                break;
            case ShowResult.Skipped:
                gameControllerScript.AddShowSuccesfully();
                break;
            case ShowResult.Failed:
                gameControllerScript.AddFailed();
                break;
            default:
                Debug.Log("something when wrong");
                return;
        }

    }
}
