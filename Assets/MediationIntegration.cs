using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Mediation;
using System;
using Ads;


public class MediationIntegration : MonoBehaviour
{
    IInterstitialAd ad;
    string adUnitId = "Interstitial_Android";

    void Start()
    {
        InitServices();
    }

    public async void InitServices()
    {
        try
        {
            await UnityServices.InitializeAsync();
            InitializationComplete();
        }
        catch(Exception e)
        {
            InitializationFailed(e);
        }
    }

    private void InitializationFailed(Exception e)
    {
        throw new NotImplementedException();
    }

    public void SetupAd()
    {
        //Create
        ad = MediationService.Instance.CreateInterstitialAd(adUnitId);

        ////Subscribe to events
        //ad.OnLoaded += AdLoaded;
        //ad.OnFailedLoad += AdFailedLoad;

        //ad.OnShowed += AdShown;
        //ad.OnFailedShow += AdFailedShow;

        ////Impression Event
        //MediationService.Instance.ImpressionEventPublisher.OnImpression += ImpressionEvent;
    }

    public void ShowAd()
    {
        if(ad.AdState == AdState.Loaded)
        {
            ad.ShowAsync();
        }
    }

    void InitializationComplete()
    {
        SetupAd();
        ad.LoadAsync();
    }
}
