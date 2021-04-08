using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject item;

    [SerializeField] float spawnDelayTime = 15;

    private float respawnTime = 0;

    bool respawning = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(item, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(respawning)
        {
            if (Time.time > respawnTime)
            {
                Instantiate(item, transform.position, Quaternion.identity);
                respawning = false;
            }
        }

      
    }

    private void OnTriggerEnter(Collider other)
    {
        respawning = true;

        respawnTime = Time.time + spawnDelayTime;
    }
}
