using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class Replay : MonoBehaviour
{
    private InterstitialAd interstitial;
    public Canvas myCanvas;
    static bool isPlayed = false;

    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/1033173712";     // Test Ad
            //string adUnitId = "ca-app-pub-9944606947231409/1503147188";       // Real Ad
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";     // Test Ad
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
    public void ReplayGame()
    {/*
        if(isPlayed){
            RequestInterstitial();

            //When you want call Interstitial show
            StartCoroutine(showInterstitial());
            
            IEnumerator showInterstitial()
            {
                while(!this.interstitial.IsLoaded())
                {
                    yield return new WaitForSeconds(0.2f);
                }
                this.interstitial.Show();
                myCanvas.sortingOrder = -1;
            }
        }
        else{*/
            Score.score = 0;
            Score.organic = 0;
            Score.carrot = 0;
            Score.kickthepoo = 0;
            Stage.stagelevel = 0;
            Stage.nextStageScore = 10;
            PlayerMove.energy = 0.1f;
            MakeCarrot.isBeingCarrot = false;
            SceneManager.LoadScene("PlayScene");
            isPlayed = true;
        /*}*/
    }

    public void HandleOnAdClosed(object sender, System.EventArgs args)
    {
        Score.score = 0;
        Score.organic = 0;
        Score.carrot = 0;
        Score.kickthepoo = 0;
        Stage.stagelevel = 0;
        Stage.nextStageScore = 10;
        PlayerMove.energy = 0.1f;
        MakeCarrot.isBeingCarrot = false;
        SceneManager.LoadScene("PlayScene");
    }
}
