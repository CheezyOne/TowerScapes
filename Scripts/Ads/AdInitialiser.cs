using UnityEngine;
using UnityEngine.Advertisements;

public class AdInitialiser : MonoBehaviour, IUnityAdsInitializationListener
{
    
    public string androidGameId;
    public string iOSGameId;
    public bool testMode;
    private string gameId;

    private void Awake()
    {
        //InitializeAds();
    }
    public void InitializeAds()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            gameId = iOSGameId;
        else
            gameId = androidGameId;
        //gameId = (Application.platform == RuntimePlatform.IP);
        Advertisement.Initialize(gameId);
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Ad's initialization complete");
    }
    public void OnInitializationFailed(UnityAdsInitializationError error , string message)
    {
        Debug.Log($"Ad's initialization Failed:{error.ToString()}-{message}");
    }
    
}

