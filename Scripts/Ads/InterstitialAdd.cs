using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAdd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    
    public static InterstitialAdd S;
    public string androidAdUnitId= "Interstitial_Android";
    public string iOsAdUnitId = "Interstitial_iOS";
    private string adUnitId;
    private void Awake()
    {
        S = this;
        LoadAdd();
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            adUnitId = iOsAdUnitId;
        else
            adUnitId = androidAdUnitId;
        //gameId = (Application.platform == RuntimePlatform.IP);
    }
    public void LoadAdd()
    {
        //Debug.Log("loading add" + adUnitId);
        //Advertisement.Load(adUnitId, this);
    }
    public void ShowAdd()
    {
        //Debug.Log("showing add" + adUnitId);
        Advertisement.Show(adUnitId, this);
    }
    public void OnUnityAdsAdLoaded(string placementId)
    {

    }
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error,string message)
    {
        Debug.Log($"Ad's loading Failed:{adUnitId}- {error.ToString()}-{message}");
    }
    public void OnUnityAdsShowClick(string placementId)
    {

    }
    public void OnUnityAdsShowComplete (string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAdd();
    }
    public void OnUnityAdsShowFailure (string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Ad's showing Failed:{adUnitId}-{error.ToString()}-{message}");
    }
    public void OnUnityAdsShowStart (string placementId)
    {

    }
    
}

