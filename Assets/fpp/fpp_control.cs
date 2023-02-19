using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpp_control : fpp_character
{
	private Rigidbody rb;
	public float speed;
	public float jumpForce;
	private bool onGround=false;
	
	public override void Start()
    {
	base.Start();
	rb=GetComponent<Rigidbody>();	
	}

    // Update is called once per frame
    void Update()
    {
    if (Input.GetButtonDown("Jump")&&onGround)
		{
		Jump();
		}
	if (Input.GetKeyDown(KeyCode.R))
    {
        Reload();
    }
    }
	
	void FixedUpdate()
	{
	Vector3 move=Input.GetAxis("Horizontal")*speed*transform.right+Input.GetAxis("Vertical")*speed*transform.forward;	
	rb.velocity=move+new Vector3(0,rb.velocity.y,0);
	
	RaycastHit ground;
	if (Physics.Raycast(transform.position,-Vector3.up,out ground,1.2f,1,QueryTriggerInteraction.Ignore))
		{
		onGround=true;	
		} else
			{
			onGround=false;
			}
	}
	
	void Jump()
	{
	rb.velocity=new Vector3(rb.velocity.x,0,rb.velocity.z);	
	rb.AddForce(new Vector3(0,jumpForce,0));	
	}
	
	void OnTriggerEnter(Collider Check)
	{
	    if (Check.tag=="Finish")
		{
		    fpp_manager.Instance.Win();	
		}
	    
	}
    
}
