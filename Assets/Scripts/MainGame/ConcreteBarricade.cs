using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteBarricade : MonoBehaviour
{
    private MainCamera _player;
    private AudioSource _audiosource;
    // Start is called before the first frame update
    void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        _player = GameObject.FindWithTag("MainCamera").GetComponent<MainCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < _player.transform.position.z - 20)
        {
            transform.position = new Vector3(Random.Range(-11, 11), transform.position.y, transform.position.z + 350);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.position = new Vector3(Random.Range(-12, 12), transform.position.y, transform.position.z + 315);
            if (PlayerPrefs.GetInt("SFX") == 1)
            {
                _audiosource.Play();
            }
            else if (PlayerPrefs.GetInt("SFX") == 0)
            {
                _audiosource.Stop();
            }
        }
    }
}
