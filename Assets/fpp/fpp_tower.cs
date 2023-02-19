using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpp_tower : fpp_character
{
	private Transform Target;
	public float Range;
	public GameObject ammo;
	public Transform sphere;
	public float Firerate;
	private float i;
	
    // Start is called before the first frame update
    public override void Start()
    {
	base.Start();
    Target=GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
	i+=Firerate;	
    if (Vector3.Distance(transform.position,Target.position)<Range && !fpp_manager.Instance.Died)
		{
		Vector3 rotacja=Target.position-sphere.position;
		Quaternion obrot=Quaternion.LookRotation(rotacja,Vector3.up);
		sphere.rotation=Quaternion.RotateTowards(sphere.rotation, obrot,3f);
		if (i>200&&sphere.rotation==obrot)
			{
			var tempAmmo=Instantiate(ammo,sphere.GetChild(0).position+sphere.forward*2f,sphere.rotation*Quaternion.Euler(90,0,0));
			tempAmmo.GetComponent<fpp_ammo>().Damage=Damage;
			i=0;
			}
		} else
			{
			sphere.rotation=Quaternion.RotateTowards(sphere.rotation, Quaternion.Euler(0,0,0),3f);	
			}
    }
}
