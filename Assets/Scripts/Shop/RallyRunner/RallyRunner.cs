using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RallyRunner : MonoBehaviour
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
        if(PlayerPrefs.GetInt("Rallyrunnerlock") != 1)
        {
              _selectbutton.enabled = false;
		}
        else
        {
            _selectbutton.enabled = true;
            Destroy(_buybutton);  
		}
        gems = PlayerPrefs.GetInt("Gems");
        _shopmanager = GameObject.Find("ShopManager").GetComponent<ShopManager>();
        if(PlayerPrefs.GetInt("Cars") == 6)
        {
            myimagecomponent.sprite = newSprite;
            buttonText.text = "Selected";
		}
        _canvas = GameObject.FindWithTag("ScrollCanvas").GetComponent<Canvas>();
    }
    public void BackButton()
    {
        _canvas.enabled = true;
        Destroy(_garage);
	}
    public void SelectButton()
    {
        PlayerPrefs.SetInt("Cars", 6);
        myimagecomponent.sprite = newSprite;
        buttonText.text = "Selected";
	}
    public void BuyButton()
    {
        if(gems >= 70)
        {
            gems = gems - 70;
            PlayerPrefs.SetInt("Gems", gems);
            PlayerPrefs.SetInt("Rallyrunnerlock", 1);
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
