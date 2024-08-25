using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-1.78f, 5.33f, -16);
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,player.position.z -16);
    }
}
