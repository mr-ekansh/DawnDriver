using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using GoogleMobileAds.Placement;
public class MainManager : MonoBehaviour
{  
    public Button CorvettePackButton;
    public Button CamaroPackButton;
    public Button SupremeGtButton;
    public Button CamaroButton;
    public Button CorvetteButton;
    public int highscore;
    public GameObject _settingspanel;
    public GameObject _creditspanel;
    public GameObject _tutorialpanel;
    public GameObject _storepanel;
    public Image _musicON;
    public Image _sfxON;
    public Image _musicOFF;
    public Image _sfxOFF;
    public Sprite _newsprite;
    public Sprite _oldsprite;
    public AudioSource _audiosource;
    public GameObject _bannerad;
    static bool _isadclosed = false;
    private string CgkIyJOkwOsREAIQAA;
    InterstitialAdGameObject interstitialAd; 
    public int gems;
    public GameObject NoAdsToShowpanel;
    private CloudSaveManager _cloudsavemanager;
    void Start()
    {
        _cloudsavemanager = GameObject.Find("CloudSaveManager").GetComponent<CloudSaveManager>();
        MobileAds.Initialize((initStatus) => {});
        interstitialAd = MobileAds.Instance.GetAd<InterstitialAdGameObject>("Interstitial Ad");
        if(!PlayerPrefs.HasKey("CorvettePackButton"))
        {
            PlayerPrefs.SetInt("CorvettePackButton", 1);  
		}
        if(!PlayerPrefs.HasKey("CamaroPackButton"))
        {
            PlayerPrefs.SetInt("CamaroPackButton", 1);  
		}
        if(!PlayerPrefs.HasKey("CorvetteButton"))
        {
            PlayerPrefs.SetInt("CorvetteButton", 1);  
		}
        if(!PlayerPrefs.HasKey("CamaroButton"))
        {
            PlayerPrefs.SetInt("CamaroButton", 1);  
		}       
        if(!PlayerPrefs.HasKey("SupremeGtButton"))
        {
            PlayerPrefs.SetInt("SupremeGtButton", 1);  
		}
        if(!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetInt("Music", 1);  
		}
        if(!PlayerPrefs.HasKey("Cars"))
        {
            PlayerPrefs.SetInt("Cars", 0);  
		}
        if(!PlayerPrefs.HasKey("SFX"))
        {
            PlayerPrefs.SetInt("SFX", 1);  
		}
        if(!PlayerPrefs.HasKey("Gems"))
        {
            PlayerPrefs.SetInt("Gems", 5);  
		}
        if(PlayerPrefs.GetInt("Music") == 1)
        {
                _musicON.sprite = _newsprite;
                _musicOFF.sprite = _oldsprite;
		}
        else
        {
                _musicOFF.sprite = _newsprite;
                _musicON.sprite = _oldsprite;
		} 
        if(PlayerPrefs.GetInt("SFX") == 1)
        {
                _sfxON.sprite = _newsprite;
                _sfxOFF.sprite = _oldsprite;     
		}
        else
        {
                _sfxOFF.sprite = _newsprite;
                _sfxON.sprite = _oldsprite;    
		}
        highscore = PlayerPrefs.GetInt("HighScore");
        if(highscore < 1000)
        {
            PlayerPrefs.SetInt("Levels", 0);     
	    }
        else if(highscore >= 1000 && highscore < 2500)
        {
            PlayerPrefs.SetInt("Levels", 1);     
	    }
        else if(highscore >= 2500 && highscore < 4000)
        {
            PlayerPrefs.SetInt("Levels", 2);     
        }
        else if(highscore >= 4000 && highscore < 8000)
        {
            PlayerPrefs.SetInt("Levels", 3);  
		}
        else if(highscore >= 8000)
        {
            PlayerPrefs.SetInt("Levels", 4);  
		}
        gems = PlayerPrefs.GetInt("Gems");
        if(PlayerPrefs.GetInt("CorvetteButton")!=1)
        {
            CorvettePackButton.interactable = false;
            CorvetteButton.interactable = false;  
		}
        if(PlayerPrefs.GetInt("CamaroButton")!=1)
        {
            CamaroPackButton.interactable = false;
            CamaroButton.interactable = false;  
		}        
        if(PlayerPrefs.GetInt("SupremeGtButton")!=1)
        {
            SupremeGtButton.interactable = false;  
		}
        if(PlayerPrefs.GetInt("CorvettePackButton")!=1)
        {
            CorvetteButton.interactable = false;
            CorvettePackButton.interactable = false;  
		}
        if(PlayerPrefs.GetInt("CamaroPackButton")!=1)
        {
            CorvetteButton.interactable = false;
            CamaroPackButton.interactable = false;  
		}
    }
    void Update()
    {
        if(PlayerPrefs.GetInt("Music") == 1)
        {
            if(_audiosource.isPlaying == false)
            {
                _audiosource.Play(); 
            }
		}
        else if(PlayerPrefs.GetInt("Music") == 0)
        {
            _audiosource.Stop();  
		}
	}
    public void PlayGame()
    {
        _cloudsavemanager.Save();
        interstitialAd.ShowIfLoaded();
        PlayerPrefs.SetInt("MainSelection", 1);
        SceneManager.LoadScene("Loading");
	}
    public void EnterShop()
    {
        _cloudsavemanager.Save();
        interstitialAd.ShowIfLoaded();
        PlayerPrefs.SetInt("MainSelection", 2);
        SceneManager.LoadScene("Loading");
	}
    public void QuitApplication()
    {
        Application.Quit();
	}
    public void OpenSettings()
    {
        _settingspanel.SetActive(true);
	}
    public void BackToMain()
    {
        _storepanel.SetActive(false);
        _settingspanel.SetActive(false);
        _creditspanel.SetActive(false);
        _tutorialpanel.SetActive(false);
	}
    public void OpenCredits()
    {
        _creditspanel.SetActive(true);
	}
    public void OpenTutorial()
    {      
        _tutorialpanel.SetActive(true);
	}
    public void OpenStore()
    {
        _storepanel.SetActive(true);
	}
    public void musicon()
    {
        _musicON.sprite = _newsprite;
        _musicOFF.sprite = _oldsprite;
        PlayerPrefs.SetInt("Music", 1);
	}
    public void musicoff()
    {
        _musicOFF.sprite = _newsprite;
        _musicON.sprite = _oldsprite;
        PlayerPrefs.SetInt("Music", 0);
	}
    public void sfxon()
    {
        _sfxON.sprite = _newsprite;
        _sfxOFF.sprite = _oldsprite;
        PlayerPrefs.SetInt("SFX", 1);
	}
    public void sfxoff()
    {
        _sfxOFF.sprite = _newsprite;
        _sfxON.sprite = _oldsprite;
        PlayerPrefs.SetInt("SFX", 0);
	}
    public void Adclosed()
    {
        Destroy(_bannerad); 
        _isadclosed = true;
	}
    public void OpenLink()
    {
        Application.OpenURL("http://www.gforgreen.com/furniture.htm");
	}
    public void GemsReward()
    {
        gems = gems+1;
        PlayerPrefs.SetInt("Gems", gems);
	}
    public void NoAdsToShow()
    {
        NoAdsToShowpanel.SetActive(true);
	}
    public void OKbutton()
    {
        NoAdsToShowpanel.SetActive(false);
	}
}