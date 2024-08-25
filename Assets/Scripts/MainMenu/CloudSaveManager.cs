using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CloudOnce;

public class CloudSaveManager : MonoBehaviour
{
    private int highscore;
    private int coins;
    private int gems;
    private MainManager _mainmanager;
    void Start()
    {
        _mainmanager = GameObject.Find("MainManager").GetComponent<MainManager>();
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
        Updatedata();
    }
    private void Updatedata()
    {
        highscore = CloudVariables.HighScore;
        coins = CloudVariables.Coins;
        gems = CloudVariables.Gems;
        SetInfo();
    }
    private void SetInfo()
    {
        PlayerPrefs.SetInt("HighScore", highscore);
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("Gems", gems);
    }
    public void Save()
    {
        CloudVariables.Gems = _mainmanager.gems;
        Cloud.Storage.Save();
    }
}
