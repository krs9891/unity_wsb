using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medpack : MonoBehaviour
{
    public float size;
    
    
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 2, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<fpp_character>().Health < other.gameObject.GetComponent<fpp_character>().MaxHealth)
            {
                other.gameObject.GetComponent<fpp_character>().GotHealth(size);
                Destroy(gameObject);
                fpp_manager.Instance.EndUpdate("+" + size.ToString("F0") + "HP points");
            }
        }
    }

}

