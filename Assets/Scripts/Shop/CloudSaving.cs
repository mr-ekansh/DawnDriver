using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class CloudSaving : MonoBehaviour
{
    private int coins;
    private int gems;
    private int highscore;
    void Start()
    {
        Cloud.OnInitializeComplete += CloudOnceInitializeComplete;
        Cloud.OnCloudLoadComplete += CloudOnceLoadComplete;
        Cloud.Initialize(true, true);
    }
    void CloudOnceInitializeComplete()
    {
        Cloud.OnInitializeComplete -= CloudOnceInitializeComplete;
        Cloud.Storage.Load();
    }
    void CloudOnceLoadComplete(bool success)
    {
    }
    public void Save()
    {
        GetInfo();
        CloudVariables.HighScore = highscore;
        CloudVariables.Coins = coins;
        CloudVariables.Gems = gems;
        Cloud.Storage.Save();
    }
    private void GetInfo()
    {
        coins = PlayerPrefs.GetInt("Coins");
        gems = PlayerPrefs.GetInt("Gems");
        highscore = PlayerPrefs.GetInt("HighScore");
    }
}
