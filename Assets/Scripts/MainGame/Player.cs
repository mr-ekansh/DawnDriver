
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float _speed = 0f;
    public float _acceleration = 5f;
    private bool _iskeypressed = false;
    private bool _isdownkeypressed = false;
    public float _brake = 20f;
    private UIManager _uimanager;
    private PlayerUIManager _playeruimanager;
    public int Score;
    private AudioSource _audiosource;
    [SerializeField]
    private AudioClip _truck_standing_sound;
    [SerializeField]
    private AudioClip _collision;
    [SerializeField]
    private AudioClip truck_slow_clip;
    [SerializeField]
    private AudioClip truck_moving_clip;
    private bool is_moving = false;
    [SerializeField]
    public float fuel = 100f;
    [SerializeField]
    private AudioClip truck_skid_clip;
    private Collider col;
    [SerializeField]
    public int life = 2;
    [SerializeField]
    private float LeftHandling = -0.4f;
    [SerializeField]
    private float RightHandling = 0.4f;
    private GameManager _gamemanager;
    [SerializeField]
    public int coincounter = 0;
    private bool _isrightkeypressed = false;
    private bool _isleftkeypressed = false;
    public bool _isfuelrefilled = false;
    [SerializeField]
    private float LeftExtreme = -15.50f;
    [SerializeField]
    private float RightExtreme = 10.4f;
    [SerializeField]
    private float GroundClearance = 2.30f;
    public bool _isgameended = false;
    void Start()
    {
        col = GetComponent<Collider>();
        _audiosource = GetComponent<AudioSource>();
        _uimanager = GameObject.FindWithTag("Canvas").GetComponent<UIManager>();
        _playeruimanager = GameObject.Find("PlayerCanvas").GetComponent<PlayerUIManager>();
        transform.position = new Vector3(0f,GroundClearance,0f);
        _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {   
        fuelsystem();
        Sounds();
        CalculateMovement();
        UpdateScore();
        Healthfinished();
        UpdateCoin();
    }
    private void CalculateMovement()
    {
#if UNITY_ANDROID
        if(CrossPlatformInputManager.GetButtonDown("Brake"))
        {
            _isdownkeypressed = true;  
		}
        if(CrossPlatformInputManager.GetButtonUp("Brake"))
        {
            _isdownkeypressed = false;  
		}
        if(CrossPlatformInputManager.GetButtonDown("Accelerate"))
        {
            _iskeypressed = true;  
		}
        if(CrossPlatformInputManager.GetButtonUp("Accelerate"))
        {
            _iskeypressed=false;  
		}
        if(CrossPlatformInputManager.GetButtonDown("Right"))
        {
            _isrightkeypressed = true;  
		}
        if(CrossPlatformInputManager.GetButtonUp("Right"))
        {
            _isrightkeypressed = false;  
		}
        if(CrossPlatformInputManager.GetButtonDown("Left"))
        {
            _isleftkeypressed = true;  
		}
        if(CrossPlatformInputManager.GetButtonUp("Left"))
        {
            _isleftkeypressed = false;  
		}
        Vector3 rightdirection = new Vector3(RightHandling,0,1);
        Vector3 leftdirection = new Vector3(LeftHandling,0,1);
        Vector3 direction = new Vector3(0,0,1);
        Vector3 Afterdirection = new Vector3(0,0,1);
        Vector3 Afterrightdirection = new Vector3(RightHandling,0,1);
        Vector3 Afterleftdirection = new Vector3(LeftHandling,0,1);
        if(_speed<=50f && _iskeypressed==true && _isrightkeypressed == true)
        {   
            _speed += Time.deltaTime*_acceleration;
            transform.Translate(rightdirection*_speed*Time.deltaTime);
            is_moving = true;
        }
        else if(_speed<=50f && _iskeypressed==true && _isleftkeypressed == true)
        {
            _speed += Time.deltaTime*_acceleration;
            transform.Translate(leftdirection*_speed*Time.deltaTime);
            is_moving = true;              
		}
        else if(_speed<=50f && _iskeypressed==true)
        {
            _speed += Time.deltaTime*_acceleration;
            transform.Translate(direction*_speed*Time.deltaTime);
            is_moving = true;                     
		}
        else if(_speed>=0.00000f && _iskeypressed==false && _isrightkeypressed == true)
        {
            _speed -= Time.deltaTime*_acceleration;
            transform.Translate(Afterrightdirection*_speed*Time.deltaTime);
            is_moving = false;
        }
        else if(_speed>=0.00000f && _iskeypressed==false && _isleftkeypressed == true)
        {
            _speed -= Time.deltaTime*_acceleration;
            transform.Translate(Afterleftdirection*_speed*Time.deltaTime);
            is_moving = false;
        }
        else if(_speed>=0.00000f && _iskeypressed==false && _isdownkeypressed == false)
        {
            _speed -= Time.deltaTime*_acceleration;
            transform.Translate(Afterdirection*_speed*Time.deltaTime);
            is_moving = false;
        }
        else if(_speed>=50f && _isrightkeypressed == true && _iskeypressed==true)
        {   
            transform.Translate(rightdirection*_speed*Time.deltaTime);
		}
        else if(_speed>=50f && _isleftkeypressed == true && _iskeypressed==true)
        {
            transform.Translate(leftdirection*_speed*Time.deltaTime);              
		}
        else if(_speed>=0.00000f && _isdownkeypressed==true)
        {
            _speed -= Time.deltaTime*_brake;
            transform.Translate(Afterdirection*_speed*Time.deltaTime);
            is_moving = false;
		}
        else
        {
          transform.Translate(direction*_speed*Time.deltaTime);    
		}
        if(transform.position.x >= RightExtreme)
        {
            transform.position = new Vector3(RightExtreme, GroundClearance, transform.position.z);  
		}
        else if(transform.position.x <= LeftExtreme)
        {
            transform.position = new Vector3(LeftExtreme, GroundClearance, transform.position.z);  
		}
#elif UNITY_IOS
        if(CrossPlatformInputManager.GetButtonDown("Brake"))
        {
            _isdownkeypressed = true;  
		}
        if(CrossPlatformInputManager.GetButtonUp("Brake"))
        {
            _isdownkeypressed = false;  
		}
        if(CrossPlatformInputManager.GetButtonDown("Accelerate"))
        {
            _iskeypressed = true;  
		}
        if(CrossPlatformInputManager.GetButtonUp("Accelerate"))
        {
            _iskeypressed=false;  
		}
        if(CrossPlatformInputManager.GetButtonDown("Right"))
        {
            _isrightkeypressed = true;  
		}
        if(CrossPlatformInputManager.GetButtonUp("Right"))
        {
            _isrightkeypressed = false;  
		}
        if(CrossPlatformInputManager.GetButtonDown("Left"))
        {
            _isleftkeypressed = true;  
		}
        if(CrossPlatformInputManager.GetButtonUp("Left"))
        {
            _isleftkeypressed = false;  
		}
        Vector3 rightdirection = new Vector3(RightHandling,0,1);
        Vector3 leftdirection = new Vector3(LeftHandling,0,1);
        Vector3 direction = new Vector3(0,0,1);
        Vector3 Afterdirection = new Vector3(0,0,1);
        Vector3 Afterrightdirection = new Vector3(RightHandling,0,1);
        Vector3 Afterleftdirection = new Vector3(LeftHandling,0,1);
        if(_speed<=50f && _iskeypressed==true && _isrightkeypressed == true)
        {   
            _speed += Time.deltaTime*_acceleration;
            transform.Translate(rightdirection*_speed*Time.deltaTime);
            is_moving = true;
        }
        else if(_speed<=50f && _iskeypressed==true && _isleftkeypressed == true)
        {
            _speed += Time.deltaTime*_acceleration;
            transform.Translate(leftdirection*_speed*Time.deltaTime);
            is_moving = true;              
		}
        else if(_speed<=50f && _iskeypressed==true)
        {
            _speed += Time.deltaTime*_acceleration;
            transform.Translate(direction*_speed*Time.deltaTime);
            is_moving = true;                     
		}
        else if(_speed>=0.00000f && _iskeypressed==false && _isrightkeypressed == true)
        {
            _speed -= Time.deltaTime*_acceleration;
            transform.Translate(Afterrightdirection*_speed*Time.deltaTime);
            is_moving = false;
        }
        else if(_speed>=0.00000f && _iskeypressed==false && _isleftkeypressed == true)
        {
            _speed -= Time.deltaTime*_acceleration;
            transform.Translate(Afterleftdirection*_speed*Time.deltaTime);
            is_moving = false;
        }
        else if(_speed>=0.00000f && _iskeypressed==false && _isdownkeypressed == false)
        {
            _speed -= Time.deltaTime*_acceleration;
            transform.Translate(Afterdirection*_speed*Time.deltaTime);
            is_moving = false;
        }
        else if(_speed>=50f && _isrightkeypressed == true && _iskeypressed==true)
        {   
            transform.Translate(rightdirection*_speed*Time.deltaTime);
		}
        else if(_speed>=50f && _isleftkeypressed == true && _iskeypressed==true)
        {
            transform.Translate(leftdirection*_speed*Time.deltaTime);              
		}
        else if(_speed>=0.00000f && _isdownkeypressed==true)
        {
            _speed -= Time.deltaTime*_brake;
            transform.Translate(Afterdirection*_speed*Time.deltaTime);
            is_moving = false;
		}
        else
        {
          transform.Translate(direction*_speed*Time.deltaTime);    
		}
        if(transform.position.x >= RightExtreme)
        {
            transform.position = new Vector3(RightExtreme, GroundClearance, transform.position.z);  
		}
        else if(transform.position.x <= LeftExtreme)
        {
            transform.position = new Vector3(LeftExtreme, GroundClearance, transform.position.z);  
		}
#else
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            _isdownkeypressed = true;  
		}
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            _isdownkeypressed = false;  
		}
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            _iskeypressed = true;  
		}
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            _iskeypressed=false;  
		}
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            _isrightkeypressed = true;  
		}
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            _isrightkeypressed = false;  
		}
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _isleftkeypressed = true;  
		}
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _isleftkeypressed = false;  
		}
        Vector3 rightdirection = new Vector3(RightHandling,0,1);
        Vector3 leftdirection = new Vector3(LeftHandling,0,1);
        Vector3 direction = new Vector3(0,0,1);
        Vector3 Afterdirection = new Vector3(0,0,1);
        Vector3 Afterrightdirection = new Vector3(RightHandling,0,1);
        Vector3 Afterleftdirection = new Vector3(LeftHandling,0,1);
        if(_speed<=50f && _iskeypressed==true && _isrightkeypressed == true)
        {   
            _speed += Time.deltaTime*_acceleration;
            transform.Translate(rightdirection*_speed*Time.deltaTime);
            is_moving = true;
        }
        else if(_speed<=50f && _iskeypressed==true && _isleftkeypressed == true)
        {
            _speed += Time.deltaTime*_acceleration;
            transform.Translate(leftdirection*_speed*Time.deltaTime);
            is_moving = true;              
		}
        else if(_speed<=50f && _iskeypressed==true)
        {
            _speed += Time.deltaTime*_acceleration;
            transform.Translate(direction*_speed*Time.deltaTime);
            is_moving = true;                     
		}
        else if(_speed>=0.00000f && _iskeypressed==false && _isrightkeypressed == true)
        {
            _speed -= Time.deltaTime*_acceleration;
            transform.Translate(Afterrightdirection*_speed*Time.deltaTime);
            is_moving = false;
        }
        else if(_speed>=0.00000f && _iskeypressed==false && _isleftkeypressed == true)
        {
            _speed -= Time.deltaTime*_acceleration;
            transform.Translate(Afterleftdirection*_speed*Time.deltaTime);
            is_moving = false;
        }
        else if(_speed>=0.00000f && _iskeypressed==false && _isdownkeypressed == false)
        {
            _speed -= Time.deltaTime*_acceleration;
            transform.Translate(Afterdirection*_speed*Time.deltaTime);
            is_moving = false;
        }
        else if(_speed>=50f && _isrightkeypressed == true && _iskeypressed==true)
        {   
            transform.Translate(rightdirection*_speed*Time.deltaTime);
		}
        else if(_speed>=50f && _isleftkeypressed == true && _iskeypressed==true)
        {
            transform.Translate(leftdirection*_speed*Time.deltaTime);              
		}
        else if(_speed>=0.00000f && _isdownkeypressed==true)
        {
            _speed -= Time.deltaTime*_brake;
            transform.Translate(Afterdirection*_speed*Time.deltaTime);
            is_moving = false;
		}
        else
        {
          transform.Translate(direction*_speed*Time.deltaTime);    
		}
        if(transform.position.x >= RightExtreme)
        {
            transform.position = new Vector3(RightExtreme, GroundClearance, transform.position.z);  
		}
        else if(transform.position.x <= LeftExtreme)
        {
            transform.position = new Vector3(LeftExtreme, GroundClearance, transform.position.z);  
		} 
#endif
	}
    private void UpdateScore()
    {
        Score = (int)transform.position.z/10;
        _uimanager.UpdateScore(Score);
	}
    private void Sounds()
    {
        if(PlayerPrefs.GetInt("SFX") == 1)
        {
            if(_isgameended == false && _gamemanager._ispausepanel == false)
            {
                if(_speed<=0f)
                {
                    _audiosource.clip = _truck_standing_sound;
                    if(_audiosource.isPlaying == false)
                    {
                        _audiosource.Play();
                    }
                }
                else if(_speed > 0f) 
                {
                    if(is_moving == false)
                    {
                        if(_isdownkeypressed==true)
                        {   
                            _audiosource.clip = truck_skid_clip;
                            if(_audiosource.isPlaying == false)
                            {
                                _audiosource.Play();           
					        }
				        }
                        else
                        {
                            _audiosource.clip = truck_slow_clip;
                            if(_audiosource.isPlaying == false)
                            {
                                _audiosource.Play();     
			                }
                        }
                    }
                    else if(is_moving == true)
                    {
                        _audiosource.clip = truck_moving_clip;
                        if(_audiosource.isPlaying == false)
                        {
                            _audiosource.Play();           
					    }
			        }
		        }   
                else
                {
                    _audiosource.Stop();  
		        }
            }
            else if(_isgameended == true || _gamemanager._ispausepanel == true)
            {
                _audiosource.Stop();  
		    }
        }
        else if(PlayerPrefs.GetInt("SFX") == 0)
        {
            _audiosource.Stop();  
		}
	}
    private void fuelsystem()
    {
        if(fuel>= 0f)
        {
            fuel -= 2*Time.deltaTime;
        }
        if(fuel <= 0f && _acceleration>= 0f)
        {
            _speed -= 5*Time.deltaTime;
            _iskeypressed = false;
            is_moving = false;
            if(_speed <= 0f)
            {
                _acceleration = 0.00000f;
                _speed = 0.00000f;
                _brake = 0.00000f;
                _isgameended = true;
                _uimanager.CheckForBestScore();
                _uimanager.CoinCount();
                _uimanager._gameover.gameObject.SetActive(true);
                _gamemanager.EndPanel();
			}
		}
	}
    private void healthlowsystem()
    {
        if(_speed<=5f)
        {
              col.enabled = false;
		}
        else if(_speed>=5f)
        {
            col.enabled = true;  
		}
	}
    private void Damage()
    {
        life = life-1;
        _playeruimanager.Updatelives(life);
	}
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Object")
        {
            _speed = 0.0000f;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Damage();
		}
        if(other.gameObject.tag == "Coin")
        {
            coincounter ++;
		}
        if(other.gameObject.tag == "Fuel")
        {
            if(_gamemanager.a == 1)
            {
                fuel = 100f;
            }
            else if(_gamemanager.a == 2)
            {
                fuel = 150f;     
			}
            else if(_gamemanager.a == 3)
            {
                fuel = 200f;     
			}
            else if(_gamemanager.a == 4)
            {
                fuel = 250f;     
			}
            _isfuelrefilled = true;
		}
	}
    private void Healthfinished()
    {
        if(life == 0)
        {
            _speed = 0.00000f;
            _acceleration = 0.00000f;
            _brake = 0.00000f;
            _isgameended = true;
            _uimanager.CheckForBestScore();
            _uimanager.CoinCount();
            _uimanager._gameover.gameObject.SetActive(true);
            _gamemanager.EndPanel();
		}
	}
    private void UpdateCoin()
    {
        _uimanager.UpdateCoins(coincounter);
	}
} 
