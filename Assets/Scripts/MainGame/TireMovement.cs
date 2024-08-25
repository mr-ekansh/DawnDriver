using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TireMovement : MonoBehaviour
{
    [SerializeField]
    public float _speed = 0f;
    [SerializeField]
    private float _acceleration = 50;
    private bool isupkeypressed = false;
    private Player player;
    [SerializeField]
    private int x = 0;
    [SerializeField]
    private int y = 0;
    [SerializeField]
    private int z = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
    
        if(CrossPlatformInputManager.GetButtonDown("Accelerate"))
        {
            isupkeypressed = true;   
		}
        else if(CrossPlatformInputManager.GetButtonUp("Accelerate")||CrossPlatformInputManager.GetButtonDown("Brake"))
        {
            isupkeypressed = false;  
		}
        if(isupkeypressed==true && _speed <=500f)
        {
            _speed += _acceleration*Time.deltaTime;
            transform.Rotate(_speed*Time.deltaTime*x,_speed*y*Time.deltaTime,_speed*z*Time.deltaTime);
		}
        else if(isupkeypressed==false && _speed>=0f)
        {
            _speed -= _acceleration*Time.deltaTime;
            if(player._speed <= 0f)
            {
                _speed = 0f;     
			}
            transform.Rotate(_speed*Time.deltaTime*x,_speed*y*Time.deltaTime,_speed*z*Time.deltaTime);
		}
        else
        {
            transform.Rotate(_speed*Time.deltaTime*x,_speed*Time.deltaTime*y ,_speed*Time.deltaTime*z);  
		}
        if(player.fuel <= 0f && _acceleration >= 0f)
        {
              _speed -= 50*Time.deltaTime;
              isupkeypressed = false;
              if(_speed <= 0f)
              {
                    _speed = 0f;
                    _acceleration = 0f;
			  }
		}
#elif UNITY_IOS

        if(CrossPlatformInputManager.GetButtonDown("Accelerate"))
        {
            isupkeypressed = true;   
		}
        else if(CrossPlatformInputManager.GetButtonUp("Accelerate")||CrossPlatformInputManager.GetButtonDown("Brake"))
        {
            isupkeypressed = false;  
		}
        if(isupkeypressed==true && _speed <=500f)
        {
            _speed += _acceleration*Time.deltaTime;
            transform.Rotate(_speed*Time.deltaTime*x,_speed*y*Time.deltaTime,_speed*z*Time.deltaTime);
		}
        else if(isupkeypressed==false && _speed>=0f)
        {
            _speed -= _acceleration*Time.deltaTime;
            if(player._speed <= 0f)
            {
                _speed = 0f;     
			}
            transform.Rotate(_speed*Time.deltaTime*x,_speed*y*Time.deltaTime,_speed*z*Time.deltaTime);
		}
        else
        {
            transform.Rotate(_speed*Time.deltaTime*x,_speed*Time.deltaTime*y ,_speed*Time.deltaTime*z);  
		}
        if(player.fuel <= 0f && _acceleration >= 0f)
        {
              _speed -= 50*Time.deltaTime;
              isupkeypressed = false;
              if(_speed <= 0f)
              {
                    _speed = 0f;
                    _acceleration = 0f;
			  }
		}
#else
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            isupkeypressed = true;   
		}
        else if(Input.GetKeyUp(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.DownArrow))
        {
            isupkeypressed = false;  
		}
        if(isupkeypressed==true && _speed <=500f)
        {
            _speed += _acceleration*Time.deltaTime;
            transform.Rotate(_speed*Time.deltaTime*x,_speed*Time.deltaTime*y,_speed*Time.deltaTime*z);
		}
        else if(isupkeypressed==false && _speed>=0f)
        {
            _speed -= _acceleration*Time.deltaTime;
            if(player._speed <= 0f)
            {
                _speed = 0f;     
			}
            transform.Rotate(_speed*Time.deltaTime*x, _speed*Time.deltaTime*y, _speed*Time.deltaTime*z);
		}
        else
        {
            transform.Rotate(_speed*Time.deltaTime*x, _speed*Time.deltaTime*y, _speed*Time.deltaTime*z);  
		}
        if(player.fuel <= 0f && _acceleration >= 0f)
        {
              _speed -= 50*Time.deltaTime;
              isupkeypressed = false;
              if(_speed <= 0f)
              {
                    _speed = 0f;
                    _acceleration = 0f;
			  }
		}
#endif
    }
}
