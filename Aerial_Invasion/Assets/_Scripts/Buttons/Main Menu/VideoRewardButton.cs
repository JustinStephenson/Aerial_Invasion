using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class VideoRewardButton : MonoBehaviour {

    private RewardBasedVideoAd rewardBasedVideoAdd;

    private int rewardCoins = 20;
    private bool rewarded = false;

    void Start()
    {
        //Grabs an instance.
        rewardBasedVideoAdd = RewardBasedVideoAd.Instance;

        //Loads the add.
        LoadRewardBasedAd();

        //Sets the handlers
        rewardBasedVideoAdd.OnAdLoaded += HandleOnAdLoaded;
        rewardBasedVideoAdd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        rewardBasedVideoAdd.OnAdOpening += HandleOnAdOpening;
        rewardBasedVideoAdd.OnAdStarted += HandleOnAdStarted;
        rewardBasedVideoAdd.OnAdClosed += HandleOnAdClosed;
        rewardBasedVideoAdd.OnAdRewarded += HandleOnAdRewarded;
        rewardBasedVideoAdd.OnAdLeavingApplication += HandleOnAdLeavingApplication;
    }

    public void VideoReward()
    {
        MenuSounds.sound.menuSound = true;

        ShowRewardBasedAd();
    }

    private void LoadRewardBasedAd()
    {
        #if UNITY_EDITOR
        string adUnitId = "unused";
        #elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-1647146163803964/4541341161";
        #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #else
        string asUnitId = "unexpected_platform";
        #endif

        rewardBasedVideoAdd.LoadAd(new AdRequest.Builder().AddExtra("max_ad_content_rating", "G").Build(), adUnitId);
        //.AddExtra("npa", "1")
    }

    private void ShowRewardBasedAd()
    {
        if (rewardBasedVideoAdd.IsLoaded())
        {
            rewardBasedVideoAdd.Show();
        }
        else
        {
            MonoBehaviour.print("No add is loaded");
        }
    }

    private void ResetReward()
    {
        rewarded = false;
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {

    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

    }

    public void HandleOnAdOpening(object sender, EventArgs args)
    {

    }

    public void HandleOnAdStarted(object sender, EventArgs args)
    {
       
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        LoadRewardBasedAd();
    }

    public void HandleOnAdRewarded(object sender, Reward args)
    {
        if (!rewarded)
        {
            GameControl.control.coins += rewardCoins;
            rewarded = true;
            Invoke("ResetReward", 0.5f);
        }
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {

    }
}
