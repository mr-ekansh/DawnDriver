using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTerrainSpawning : MonoBehaviour
{   
    [SerializeField]
    private GameObject RoadPieces;
    [SerializeField]
    private GameObject TerrainPieces; 
    const float RoadLength = 10000f;
    const float RoadSpeed = 5f;
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        RoadSpawn();
        TerrainSpawn();
    }
    private void  RoadSpawn()
    {
        if(_player._speed>5f)
        {
            Vector3 newRoadPos = RoadPieces.transform.position;
            newRoadPos.z -= RoadSpeed * Time.deltaTime;
            if (newRoadPos.z < -RoadLength / 2)
            {
                newRoadPos.z += RoadLength;
            }
            RoadPieces.transform.position = newRoadPos;
        }
    }
    private void TerrainSpawn()
    {
        if(_player._speed>5f)
        {
            Vector3 newRoadPos = TerrainPieces.transform.position;
            newRoadPos.z -= RoadSpeed * Time.deltaTime;
            if (newRoadPos.z < -RoadLength / 2)
            {
                newRoadPos.z += RoadLength;
            }
            TerrainPieces.transform.position = newRoadPos;
        }
	}
}
