using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    
    
    
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (fpp_manager.Instance.Alert)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        var tempEnemy = Instantiate(enemy, transform.position, transform.rotation);
        fpp_manager.Instance.Alert = false;
    }
    
}
