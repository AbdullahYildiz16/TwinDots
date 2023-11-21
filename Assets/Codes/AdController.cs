using UnityEngine;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour
{
    public static AdController instance;
    private string store_Id = "3937847";
    private string video_ad = "video";

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        Advertisement.Initialize(store_Id, false);
    }
    public void showVideoAd()
    {
        if (Advertisement.IsReady(video_ad))
        {
            Advertisement.Show(video_ad);

        }
    }
}

