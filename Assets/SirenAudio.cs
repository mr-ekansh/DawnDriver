using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenAudio : MonoBehaviour
{   private Player _player;
    private GameManager _gamemanager;
    private AudioSource _audiosource;
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _audiosource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(_player._isgameended == false && _gamemanager._ispausepanel == false)
        {
            if(_audiosource.isPlaying == false)
            {
                _audiosource.Play();     
			}
		}
        else
        {
            _audiosource.Stop();       
		}
    }
}
