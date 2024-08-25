using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class CloudSave : MonoBehaviour
{
    private UIManager _uimanager;
    void Start()
    {
        _uimanager = GameObject.FindWithTag("Canvas").GetComponent<UIManager>();
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
        CloudVariables.HighScore = _uimanager.highscore;
        CloudVariables.Coins = _uimanager.total_coins;
        Cloud.Storage.Save();
    }
}
