using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorvetteGTRManager : MonoBehaviour
{
    public Sprite newSprite;
    public Text buttonText;
    public Image myimagecomponent;
    private Canvas _canvas;
    public GameObject _garage;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Cars") == 9)
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
        PlayerPrefs.SetInt("Cars", 9);
        myimagecomponent.sprite = newSprite;
        buttonText.text = "Selected";
	}
}
