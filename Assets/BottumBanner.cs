using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class BottumBanner : MonoBehaviour
{
    private BannerView bannerView;
    
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }

    private void RequestBanner()
    {
        //android APP ID : ca-app-pub-9944606947231409~3151448383
        //Temp IOS APP ID : ca-app-pub-3940256099942544~1458002511
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";   //Test Ad
            //string adUnitId = "ca-app-pub-9944606947231409/9071997080";     //Real Ad
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";     //Test Ad
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Clean up banner ad before creating a new one.
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }

        AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        this.bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
}
