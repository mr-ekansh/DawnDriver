using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VintageSportManager : MonoBehaviour
{   
    public Sprite newSprite;
    public Text buttonText;
    public Image myimagecomponent;
    private Canvas _canvas;
    public GameObject _garage;
    public Button _selectbutton;
    public GameObject _buybutton;
    int gems;
    private ShopManager _shopmanager;
    public GameObject _notenoughgems;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("VintageXTlock") != 1)
        {
              _selectbutton.enabled = false;
		}
        else
        {
            _selectbutton.enabled = true;
            Destroy(_buybutton);  
		}
        gems = PlayerPrefs.GetInt("Gems");
        if(PlayerPrefs.GetInt("Cars") == 3)
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
        PlayerPrefs.SetInt("Cars", 3);
        myimagecomponent.sprite = newSprite;
        buttonText.text = "Selected";
	}
    public void BuyButton()
    {
        if(gems >= 30)
        {
            gems = gems - 30;
            PlayerPrefs.SetInt("Gems", gems);
            PlayerPrefs.SetInt("VintageXTlock", 1);
            _selectbutton.enabled = true;
            _shopmanager._gemstext.text = "x" + gems; 
            Destroy(_buybutton);
		}
        else 
        {
            _notenoughgems.SetActive(true);  
		}
	}
    public void okbutton()
    {
        _notenoughgems.SetActive(false);
	}
}
