using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Placement;
using GoogleMobileAds.Api;
public class GameManager : MonoBehaviour
{ 
    [SerializeField]
    private GameObject _pausemenupanel;
    [SerializeField]
    private GameObject _notenoughgemspanel;
    private Player _player;
    [SerializeField]
    private GameObject _endpanel;
    private int CarSelect;
    public bool _ispausepanel = false;
    private int gems;
    public int a;
    private PlayerUIManager _playeruimanager;
    private Animator _anim;
    public int b;
    public AudioSource _audiosource;
    private UIManager _uimanager; 
    public GameObject _respawnadbutton;
    public GameObject _respawngemsbutton;
    private int c =2;
    public Text _respawngemstext;
    public GameObject _noadspanel;
    public Button _pausemenubutton;
    InterstitialAdGameObject interstitialAd;
    private CloudSave _cloudsave;
    void Start()
    {
        _cloudsave = GameObject.Find("CloudSave").GetComponent<CloudSave>();
        MobileAds.Initialize((initStatus) => {});
        interstitialAd = MobileAds.Instance.GetAd<InterstitialAdGameObject>("Interstitial Ad");
        if(PlayerPrefs.GetInt("Music") == 1)
        {
            _audiosource.Play();  
		}
        else if(PlayerPrefs.GetInt("Music") == 0)
        {
            _audiosource.Stop();  
		}
        gems = PlayerPrefs.GetInt("Gems");
        Time.timeScale = 1;
        CarSelection();
        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _playeruimanager = GameObject.Find("PlayerCanvas").GetComponent<PlayerUIManager>();
        _anim = GameObject.FindWithTag("FuelBar").GetComponent<Animator>();
    }
    void Update()
    {
        if(_player._isgameended == false && _ispausepanel == false)
        {
            GamePlay();
        }
        else
        {
            Time.timeScale = 0;  
		}
        if(_player._isgameended == true)
        {
            _pausemenubutton.interactable = false;  
		}
        else
        {
            _pausemenubutton.interactable = true;  
		}
    }
    public void PauseGame()
    {
        _pausemenupanel.SetActive(true);
        _ispausepanel = true;
        Time.timeScale = 0;
	}
    public void ResumeGame()
    {
        Time.timeScale = 1;
        _ispausepanel = false;
        _pausemenupanel.SetActive(false);
	}
    public void RestartGame()
    {
        interstitialAd.ShowIfLoaded();
        PlayerPrefs.SetInt("MainSelection", 1);
        _endpanel.SetActive(false);
        _pausemenupanel.SetActive(false);
        SceneManager.LoadScene("Loading");
	}
    public void EndPanel()
    {
        _endpanel.SetActive(true);
	}
    private void GamePlay()
    {
        if(_player.transform.position.z<5000f)
        {
            Time.timeScale = 1.4f;  
		}
        else if(_player.transform.position.z>=5000f && _player.transform.position.z<10000f)
        {
            Time.timeScale = 1.5f;     
		}
        else if(_player.transform.position.z>=10000f && _player.transform.position.z<20000f)
        {
            Time.timeScale = 1.6f;  
		}
        else if(_player.transform.position.z>=20000f)
        {
            Time.timeScale = 1.7f;  
		}
	}
    public void QuitToMainMenu()
    {
        _cloudsave.Save();
        interstitialAd.ShowIfLoaded();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
	}
    public void Respawngems()
    {
        if(gems>= c)
        {
            Time.timeScale = 1;
            if(a == 1)
            {
                _player.fuel = 100f;
                _anim.Play("1 Fuel", -1, 0f);
            }
            else if(a == 2)
            {
                _player.fuel = 150f;     
                _anim.Play("2 Fuel", -1, 0f);
			}
            else if( a == 3)
            {
                _player.fuel = 200f;
                _anim.Play("3 Fuel", -1, 0f);
			}
            else if( a == 4)
            {
                _player.fuel = 250f;
                _anim.Play("4 Fuel", -1, 0f);
			}
            if(b==1)
            {
                _player.life = 1;
                _playeruimanager.Updatelives(_player.life);
			}
            else if(b==2)
            {
                _player.life = 2;
                _playeruimanager.Updatelives(_player.life);
			}
            else if(b==3)
            {
                _player.life = 3;
                _playeruimanager.Updatelives(_player.life);
			}
            else if(b==4)
            {
                _player.life = 4;
                _playeruimanager.Updatelives(_player.life);
			}
            gems = gems - c;
            PlayerPrefs.SetInt("Gems", gems);
            _player._acceleration = 5f;
            _player._brake = 20f;
            _player._isgameended = false;
            _uimanager._gameover.gameObject.SetActive(false);
            _endpanel.SetActive(false);
            Destroy(_respawnadbutton.gameObject);
            Destroy(_respawngemsbutton.gameObject);
		}
        else
        {
            _notenoughgemspanel.SetActive(true);  
		}
	}
    public void okbutton()
    {
        _notenoughgemspanel.SetActive(false);
	}
    public void RespawnAds()
    {
            Time.timeScale = 1;
            if(a == 1)
            {
                _player.fuel = 100f;
                _anim.Play("1 Fuel", -1, 0f);
            }
            else if(a == 2)
            {
                _player.fuel = 150f;     
                _anim.Play("2 Fuel", -1, 0f);
			}
            else if( a == 3)
            {
                _player.fuel = 200f;
                _anim.Play("3 Fuel", -1, 0f);
			}
            else if( a == 4)
            {
                _player.fuel = 250f;
                _anim.Play("4 Fuel", -1, 0f);
			}
            if(b==1)
            {
                _player.life = 1;
                _playeruimanager.Updatelives(_player.life);
			}
            else if(b==2)
            {
                _player.life = 2;
                _playeruimanager.Updatelives(_player.life);
			}
            else if(b==3)
            {
                _player.life = 3;
                _playeruimanager.Updatelives(_player.life);
			}
            else if(b==4)
            {
                _player.life = 4;
                _playeruimanager.Updatelives(_player.life);
			}
            _player._acceleration = 5f;
            _player._brake = 20f;
            _player._isgameended = false;
            _uimanager._gameover.gameObject.SetActive(false);
            c= 4;
            _respawngemstext.text = "Respawn (4  )";   
            Destroy(_respawnadbutton.gameObject);
            _endpanel.SetActive(false);
	}
    public void NoAdToShow()
    {
        _noadspanel.SetActive(true);
	}
    public void closebutton()
    {
        _noadspanel.SetActive(false);
        Destroy(_respawnadbutton);
	}
    private void CarSelection()
    {
        CarSelect = PlayerPrefs.GetInt("Cars");
        if(CarSelect == 1)
        {
            b=2;
            a=2;
            GameObject instance = (GameObject)Instantiate(Resources.Load("Prefabs/CrossRunner"));
		}
        else if(CarSelect == 2)
        {
            b=3;
            a=1;
            GameObject instance = (GameObject)Instantiate(Resources.Load("Prefabs/MUDRUNNER"));
		}
        else if(CarSelect == 0)
        {
            b=1;
            a=1;
            GameObject instance = (GameObject)Instantiate(Resources.Load("Prefabs/VINTAGE"));
		}
        else if(CarSelect == 3)
        {
            b=2;
            a=2;
            GameObject instance = (GameObject)Instantiate(Resources.Load("Prefabs/VINTAGEXT"));
		}
        else if(CarSelect == 4)
        {
            b=1;
            a=3;
            GameObject instance = (GameObject)Instantiate(Resources.Load("Prefabs/DUNERUNNER"));
		}
        else if(CarSelect == 5)
        {
            b=2;
            a=2;
            GameObject instance = (GameObject)Instantiate(Resources.Load("Prefabs/CITYRUNNER"));
		}
        else if(CarSelect == 6)
        {
            b=3;
            a=3;
            GameObject instance = (GameObject)Instantiate(Resources.Load("Prefabs/RALLYRUNNER"));
		}
        else if(CarSelect == 7)
        {
            b=4;
            a=3;
            GameObject instance = (GameObject)Instantiate(Resources.Load("Prefabs/SUPREMEGT"));
		}
        else if(CarSelect == 8)
        {
            b=4;
            a=3;
            GameObject instance = (GameObject)Instantiate(Resources.Load("Prefabs/CAMAROSRT"));
		}
        else if(CarSelect == 9)
        {
            b=4;
            a=4;
            GameObject instance = (GameObject)Instantiate(Resources.Load("Prefabs/CORVETTEGTR"));
		}
	}
}
