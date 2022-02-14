using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] Spawner;
    public GameObject plyPos;
    private float startdelay = 1;
    private float enddelay = 1;
    private Vector3 spawnpos = new Vector3(0f, 0.5f, 10f);
    // Start is called before the first frame update
    //this class spawn various animals in different locations

    void Start()
    {

        InvokeRepeating("spawnObstacle", startdelay, enddelay);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnObstacle()
    {
        plyPos = GameObject.FindGameObjectWithTag("Player");
        float XRange = Random.Range(plyPos.transform.position.x + 10f, plyPos.transform.position.x + 30f);
        float Zaxis = Random.Range(10, -11);
        int i=Random.Range(0, Spawner.Length);
            Instantiate(Spawner[i],new Vector3(XRange,spawnpos.y,Zaxis), Spawner[i].transform.rotation);
        
    }

}
