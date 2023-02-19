using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_supply : MonoBehaviour
{
    public float size;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 2, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<fpp_character>().GotAmmo(size);
            Destroy(gameObject);
            fpp_manager.Instance.EndUpdate("+" + size.ToString("F0") + " Ammo");

        }
    }
}
