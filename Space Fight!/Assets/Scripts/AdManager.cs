using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
 
public class AdManager : MonoBehaviour
{
    //Game ID number in place of "33675"
    [SerializeField]
    string gameID = "33675";
 

    /// <summary>
    /// iniitializes the advertisements
    /// </summary>
    void Awake()
    {
        Advertisement.Initialize(gameID, true);
 
    }
 
    /// <summary>
    /// shows an ad if the advertisement is ready.
    /// </summary>
    public void ShowAd(string zone = "")
    {
#if UNITY_EDITOR
        StartCoroutine(WaitForAd());
#endif

        //this allows you to specify ads that are rewarded, or the default if nothing specified, for example.
        if (string.Equals(zone, ""))
            zone = null;

        //this allows the adcallbackhandler
        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackhandler;



        if (Advertisement.isReady(zone))
            Advertisement.Show(zone, options);
 
    }


    /// <summary>
    /// example of checking ads, should change the debugs for any production builds.
    /// This is a callback handler for whether the ad was watched, skipped, or an issue arose. 
    /// </summary>
    /// <param name="result">the result of the ad showing</param>
    void AdCallbackhandler(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Ad finished. Rewarding player...");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad skipped. Disappointment!");
                break;
            case ShowResult.Failed:
                Debug.Log("Ad failed. I swear this has never happened before");
                break;
        }
    }

    /// <summary>
    /// pauses the game and all calculations while the ad is played.
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForAd()
    {
        float currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
            yield return null;

        Time.timeScale = currentTimeScale;


    }
}


