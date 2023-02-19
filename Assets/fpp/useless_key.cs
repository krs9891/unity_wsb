using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useless_key : MonoBehaviour
{
	public float Range;
	private Transform Target;
    
    // Start is called before the first frame update
    void Start()
    {
        Target=GameObject.FindWithTag("Player").transform;  
    }

    // Update is called once per frame
    void Update()
    {
		if (Vector3.Distance(Target.position,transform.position)<Range && !fpp_manager.Instance.Died)
        {
			fpp_manager.Instance.EndUpdate("Useless item. Press 'E' to collect.");
			if (Input.GetKey(KeyCode.E))
            {
			    fpp_manager.Instance.EndUpdate("Useless item collected!");
                Destroy(gameObject);                
            }

        }
    }
}
