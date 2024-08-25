using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _buttons;
    int i = 0;
    [SerializeField]
    int _uppervalue;
    [SerializeField]
    int _lowervalue;
    public Button _truckbutton;
    public Text _trucktext;
    public Button _SUVbutton;
    public Text _SUVtext; 
    public Button _Dunebutton;
    public Text _Dunetext;
    public Button _Citybutton;
    public Text _Citytext;
    public Button SupremeGtButton;
    public Button CamaroButton;
    public Button CorvetteButton;
    int unlock;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("SupremeLock"))
        {
            PlayerPrefs.SetInt("SupremeLock", 0);  
		} 
        if(!PlayerPrefs.HasKey("CamaroLock"))
        {
            PlayerPrefs.SetInt("CamaroLock", 0);  
		}
        if(!PlayerPrefs.HasKey("CorvetteLock"))
        {
            PlayerPrefs.SetInt("CorvetteLock", 0);  
		}
        if(PlayerPrefs.GetInt("SupremeLock") == 0)
        {
            SupremeGtButton.interactable = false;  
		}
        if(PlayerPrefs.GetInt("CamaroLock") == 0)
        {
            CamaroButton.interactable = false;  
		}
        if(PlayerPrefs.GetInt("CorvetteLock") == 0)
        {
            CorvetteButton.interactable = false;  
		}
        else
        {
            SupremeGtButton.interactable = true;  
		}
        unlock = PlayerPrefs.GetInt("Levels");
        if(unlock == 0)
        {
            _Citybutton.interactable = false;
            _truckbutton.interactable = false;
            _SUVbutton.interactable = false;
            _Dunebutton.interactable = false;
		}
        else if(unlock == 1)
        {
            _Citybutton.interactable = false;
            _SUVbutton.interactable = false;
            _truckbutton.interactable = true;
            _trucktext.text = "";
            _Dunebutton.interactable = false;
		}
        else if(unlock == 2)
        {
            _Citybutton.interactable = false;
            _truckbutton.interactable = true;
            _trucktext.text = "";
            _SUVbutton.interactable = true;
            _SUVtext.text = "";
            _Dunebutton.interactable = false;
		}
        else if(unlock == 3)
        {
            _Citybutton.interactable = false;
            _truckbutton.interactable = true;
            _trucktext.text = "";
            _SUVbutton.interactable = true;
            _SUVtext.text = "";
            _Dunebutton.interactable = true;
            _Dunetext.text = "";
		}
        else if(unlock >= 4)
        {
            _Citybutton.interactable = true;
            _Citytext.text = "";
            _truckbutton.interactable = true;
            _trucktext.text = "";
            _SUVbutton.interactable = true;
            _SUVtext.text = "";
            _Dunebutton.interactable = true;
            _Dunetext.text = "";
		}
    }
    public void RightSwipe()
    {
        if(i<_uppervalue)
        {
            _buttons[i].transform.localPosition = new Vector3(transform.position.x+1000, -56.8f, transform.position.z);
            i = i+1;
            _buttons[i].transform.localPosition = new Vector3(1.1f, -56.8f, transform.position.z);
		}
	}
    public void LeftSwipe()
    {
        if(i>_lowervalue)
        {
            _buttons[i].transform.localPosition = new Vector3(transform.position.x+1000, -56.8f, transform.position.z);
            i = i-1;
            _buttons[i].transform.localPosition = new Vector3(1.1f, -56.8f, transform.position.z);
		}
	}
}
