using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpp_ammo : MonoBehaviour
{
	public float speed;
	private Rigidbody rb;
	private int j;
	public int LifeExpectancy;
	public float Damage;
    // Start is called before the first frame update
    void Start()
    {
    rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    rb.velocity=transform.up*speed;

	j++;
	if (j>LifeExpectancy)
		{
		Destroy(gameObject);	
		}
    }
	
	void OnTriggerEnter(Collider hit)
	{
	if (hit.tag=="enemy"||hit.tag=="Player")
		{
		hit.gameObject.GetComponent<fpp_character>().GotHit(Damage);
		}
	if (hit.isTrigger==false)
		{
		Destroy(gameObject);	
		}
	}
}
