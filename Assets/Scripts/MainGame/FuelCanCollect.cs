using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCanCollect : MonoBehaviour
{
    private MainCamera _player;
    private AudioSource _audiosource;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("MainCamera").GetComponent<MainCamera>();
        _audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < _player.transform.position.z - 20)
        {
            transform.position = new Vector3(Random.Range(-12, 12), transform.position.y, transform.position.z + 1680);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Object")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);
        }
        if (other.gameObject.tag == "Player")
        {
            transform.position = new Vector3(Random.Range(-12, 12), transform.position.y, transform.position.z + 1660);
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
