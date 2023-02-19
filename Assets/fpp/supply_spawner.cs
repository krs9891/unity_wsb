using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supply_spawner : MonoBehaviour
{
    private float nextSpawnTime;
    private bool empty = false;

    [SerializeField]
    private GameObject supply;
    [SerializeField]
    private float spawnDelay = 15;
    //public float size;
    
    
    
    // Start is called before the first frame update
    
    void Start()
    {
        Spawn();
    }
    
    void Update()
    {
        if (empty)
        {
            if (ShouldSpawn())
            {
                Spawn();
            }
        }
        
    }

    private void Spawn()
    {
        var tempSupply = Instantiate(supply, transform.position, transform.rotation);
        empty = false;
    }

    private bool ShouldSpawn()
    {
        return Time.time > nextSpawnTime;
    }

    public void EmptySlot()
    {
        empty = true;
        nextSpawnTime = Time.time + spawnDelay;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EmptySlot();
        }
    }


}
