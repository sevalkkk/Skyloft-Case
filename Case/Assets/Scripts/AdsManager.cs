using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public static AdsManager instance;
    string GameID = "5068309";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


    }
    private void Start()
    {
        Advertisement.Initialize(GameID);

        Advertisement.AddListener(this);
    }

   

    public void ShowAds()
    {
        //you can skip this ads. But if your ads are rewarded video ads, u can not skip.
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    public void ShowRewardedAds()
    {
      
      
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {

        if (showResult == ShowResult.Finished)
        {

            GameManager.instance.GameOverPanel.SetActive(false);
            //user watched ad.
            //earned coins.
            Debug.Log("player watched whole ad video.");

            
            GameManager.instance.EndGame(true);


        }

        if (showResult == ShowResult.Skipped)
        {

            //user skipped the ad.
            //lost the change of earn coin.
        }
    }
}