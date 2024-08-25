using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelRefill : MonoBehaviour
{
    private Animator _anim;
    private Player _player;
    private GameManager _gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _anim = GetComponent<Animator>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_player._isfuelrefilled == true)
        {
            if(_gamemanager.a == 1)
            {     
                _anim.Play("1 Fuel", -1, 0f);
            }
            else if(_gamemanager.a == 2)
            {
                _anim.Play("2 Fuel", -1, 0f);
			}
            else if(_gamemanager.a == 3)
            {
                _anim.Play("3 Fuel", -1, 0f);     
			}
            else if(_gamemanager.a == 4)
            {
                _anim.Play("4 Fuel", -1, 0f);     
			}
            _player._isfuelrefilled = false;
		}
    }
}
