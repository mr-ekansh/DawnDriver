using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public Canvas _canvas;
    [SerializeField]
    private GameObject[] _garage;
    public Text _cointext;
    public Text _gemstext;
    private int coins;
    private int gems;
    public AudioSource _audiosource;
    private CloudSaving _cloudsaving;
    void Start()
    {
        _cloudsaving = GameObject.Find("CloudSaving").GetComponent<CloudSaving>();
        coins = PlayerPrefs.GetInt("Coins");
        _cointext.text = "x" + coins;
        gems = PlayerPrefs.GetInt("Gems");
        _gemstext.text = "x" + gems;
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
    public void BackToMain()
    {
        _cloudsaving.Save();
        SceneManager.LoadScene("MainMenu");
	}
    public void OpenVintage()
    {  
        _canvas.enabled = false;
        Instantiate(_garage[0],new Vector3(488.33f, 71.073f, 1.0798f), Quaternion.identity);
	}
    public void OpenTruck()
    {
        _canvas.enabled = false;
        Instantiate(_garage[1], new Vector3(-3.33887f,-0.169654f,2.779256f), Quaternion.identity);
	}
    public void OpenSuv()
    {
        _canvas.enabled = false;
        Instantiate(_garage[2], new Vector3(-3.33887f,-0.169654f,2.779256f), Quaternion.identity);
	}
    public void OpenVintageSport()
    {
        _canvas.enabled = false;
        Instantiate(_garage[3],new Vector3(4.449582f, 0.01096043f, 4.953323f), Quaternion.identity);
	}
    public void OpenDuneRunner()
    {
        _canvas.enabled = false;
        Instantiate(_garage[4],new Vector3(4.449582f, 0.01096043f, 4.953323f), Quaternion.identity);
	}
    public void OpenCityRunner()
    {
        _canvas.enabled = false;
        Instantiate(_garage[5], new Vector3(4.449582f, 0.01096043f, 4.953323f), Quaternion.identity);
	}
    public void OpenRallyRunner()
    {
        _canvas.enabled = false;
        Instantiate(_garage[6], new Vector3(4.449582f, 0.01096043f, 4.953323f), Quaternion.identity);
	}
    public void OpenSupremeGT()
    {
        _canvas.enabled = false;
        Instantiate(_garage[7], new Vector3(4.449582f, 0.01096043f, 4.953323f), Quaternion.identity);
	}
    public void OpenCamaroSRT()
    {
        _canvas.enabled = false;
        Instantiate(_garage[8], new Vector3(4.449582f, 0.01096043f, 4.953323f), Quaternion.identity);
	}
    public void OpenCorvetteGTR()
    {
        _canvas.enabled = false;
        Instantiate(_garage[9], new Vector3(4.449582f, 0.01096043f, 4.953323f), Quaternion.identity);
	}
}
