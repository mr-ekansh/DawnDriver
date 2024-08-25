using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuneRunnerManager : MonoBehaviour
{
    public Sprite newSprite;
    public Text buttonText;
    public Image myimagecomponent;
    private Canvas _canvas;
    public GameObject _garage;
    public Button _selectbutton;
    public GameObject _buybutton;
    int coins;
    public GameObject _notenoughcoins;
    private ShopManager _shopmanager;
    void Start()
    {
        if(PlayerPrefs.GetInt("Dunelock") != 1)
        {
              _selectbutton.enabled = false;
		}
        else
        {
            _selectbutton.enabled = true;
            Destroy(_buybutton);  
		}
        coins = PlayerPrefs.GetInt("Coins");
        if(PlayerPrefs.GetInt("Cars") == 4)
        {
            myimagecomponent.sprite = newSprite;
            buttonText.text = "Selected";
		}
        _canvas = GameObject.FindWithTag("ScrollCanvas").GetComponent<Canvas>();
        _shopmanager = GameObject.Find("ShopManager").GetComponent<ShopManager>();
    }
    public void BackButton()
    {
        _canvas.enabled = true;
        Destroy(_garage);
	}
    public void SelectButton()
    {
        PlayerPrefs.SetInt("Cars", 4);
        myimagecomponent.sprite = newSprite;
        buttonText.text = "Selected";
	}
    public void BuyButton()
    {
        if(coins >= 165)
        {
            coins = coins - 165;
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.SetInt("Dunelock", 1);
            _selectbutton.enabled = true;
            _shopmanager._cointext.text = "x" + coins; 
            Destroy(_buybutton);
		}
        else
        {
            _notenoughcoins.SetActive(true);  
		}
    }
    public void okbutton()
    {
        _notenoughcoins.SetActive(false);
	}
}
