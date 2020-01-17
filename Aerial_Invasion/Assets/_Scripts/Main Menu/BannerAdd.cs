using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class BannerAdd : MonoBehaviour {

    private Scene currentScene;
    private string sceneName;

    public BannerView bannerView;

    public bool adLoad = false;

    public void Start()
    {
        this.RequestBanner();

        //Sets the handlers
        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        bannerView.OnAdOpening += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;
    }

    private void RequestBanner()
    {
        #if UNITY_EDITOR
        string adUnitId = "unused";
        #elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-1647146163803964/2423402149";
        #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #else
        string asUnitId = "unexpected_platform";
        #endif

        //Create a banner with size and position.
        // AdSize adSize = new AdSize(300, 40);
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        //Create an empty ad request.
        AdRequest request = new AdRequest.Builder().AddExtra("max_ad_content_rating", "G").Build();
        //.AddExtra("npa", "1")

        //Load the banner with the request.
        bannerView.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        bannerView.Show();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {

    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        bannerView.Destroy();
    }
}
