using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 
    [SerializeField]
    private Text _scoretext;
    [SerializeField] 
    private Text _Cointext;
    [SerializeField]
    private Text _highscoretext;
    public int highscore;
    public int score;
    public int total_coins;
    private Player _player;
    private int check = 0;
    public Text _gameover;
    // Start is called before the first frame update
    void Start()
    {
        _gameover.gameObject.SetActive(false);
        total_coins = PlayerPrefs.GetInt("Coins", 0);
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        _scoretext.text = "Score : " + 0;
        _Cointext.text = "x" + 0;
        _highscoretext.text = "High Score: " + highscore;
    }
    public void UpdateScore(int playerscore)
    {
        _scoretext.text = "Score : " + playerscore;
       score = playerscore;
	}
    public void CheckForBestScore()
    {
        if(score>highscore)
        {
            highscore = score; 
            PlayerPrefs.SetInt("HighScore", highscore);
            _highscoretext.text = "High Score:\n" + score;
		}
	}
    public void UpdateCoins(int coin_num)
    {
        _Cointext.text = "x " + coin_num;
	}
    public void CoinCount()
    {
        if(total_coins>=check)
        {
            total_coins = total_coins + _player.coincounter;
            check = _player.coincounter + total_coins + 1;
            PlayerPrefs.SetInt("Coins", total_coins);
        }
	}
}
