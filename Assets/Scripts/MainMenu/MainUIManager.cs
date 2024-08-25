using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    [SerializeField]
    private Text _highscoretext;
    [SerializeField]
    private Text _cointext;
    [SerializeField]
    private Text _GemsText; 
    private int score;
    private int coins;
    private int gems;
    [SerializeField]
    private GameObject[] _buttons;
    int i = 0;
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        score = PlayerPrefs.GetInt("HighScore");
        gems = PlayerPrefs.GetInt("Gems");
        _highscoretext.text = "High Score: " + score;
        _cointext.text = "x" + coins;
        _GemsText.text = "x" + gems;
    }
    public void RightSwipe()
    {
        if(i<5)
        {
            _buttons[i].transform.localPosition = new Vector3(transform.position.x+1000, 5.8f, transform.position.z);
            i = i+1;
            _buttons[i].transform.localPosition = new Vector3(13, 5.8f, transform.position.z);
		}
	}
    public void LeftSwipe()
    {
        if(i>0)
        {
            _buttons[i].transform.localPosition = new Vector3(transform.position.x+1000, 5.8f, transform.position.z);
            i = i-1;
            _buttons[i].transform.localPosition = new Vector3(13, 5.8f, transform.position.z);
		}
	}
}
