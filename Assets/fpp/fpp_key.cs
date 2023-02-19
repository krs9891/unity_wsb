using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpp_key : MonoBehaviour
{
	public float TimeNeeded;
	public float Range;
	private Transform Target;
	private Color KeyTint;
	private float i;
	private bool Active=true;
    // Start is called before the first frame update
    void Start()
    {
    Target=GameObject.FindWithTag("Player").transform;  
	KeyTint=new Color(1,0,0,1);
	GetComponent<Renderer>().material.SetVector("_Color",KeyTint);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    if (Active)
		{
		if (Vector3.Distance(Target.position,transform.position)<Range&&!fpp_manager.Instance.Died)
			{
			KeyTint=new Color(1,i/TimeNeeded,0,1);
			GetComponent<Renderer>().material.SetVector("_Color",KeyTint);	
			fpp_manager.Instance.EndUpdate("Press and hold Use key to collect the key! (Default: E)");
			if (Input.GetKey(KeyCode.E))
				{
				i++;
				if (i==TimeNeeded)	
					{
					DeactivateKey();
					}
				} else
					{
					i=0;	
					}
			} else
					{
					i=0;	
					}		
		}
    }
	
	void DeactivateKey()
	{
	fpp_manager.Instance.EndUpdate("");
	fpp_manager.Instance.Key=true;
	Active=false;
	KeyTint=new Color(0,0,0,1);
	GetComponent<Renderer>().material.SetVector("_Color",KeyTint);
    fpp_manager.Instance.Alert = true;
	fpp_manager.Instance.EndUpdate("You have a key. Go back to exit");

	}
}
