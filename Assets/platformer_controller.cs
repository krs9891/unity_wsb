using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformer_controller : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;
    public float jumpForce;
    private bool onGround = false;
    public int side = 1;
    public GameObject ammo;

	void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float move=moveSpeed*Input.GetAxis("Horizontal");
        if (move > 0)
        {
            side = 1;
        }
        if (move < 0)
        {
            side = -1;
        }
		rb.velocity=new Vector3(move,rb.velocity.y,0);
        if (Input.GetButtonDown("Jump")&&onGround)
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 shootOffset = transform.position + new Vector3(side, 0, 0);
            Instantiate(ammo, shootOffset, transform.rotation);
        }
    }

    void FixedUpdate()
    {
        RaycastHit ground;
        for (float x = -0.45f; x <= 0.45f; x+=0.45f)
        {
            Vector3 pozycja = transform.position + new Vector3(x, 0, 0);
            Debug.DrawRay(pozycja, -Vector3.up, Color.red, 0.1f);
            if (Physics.Raycast(pozycja, -Vector3.up, out ground, 0.7f, 1, QueryTriggerInteraction.Ignore))
            {
                if (ground.collider.tag == "enemy")
                {
                    Destroy(ground.collider.gameObject);
                    Jump();
                    break;
                }
                onGround = true;
                break;
            }
            else
            {
                onGround = false;
            }
        }

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        rb.AddForce(new Vector3(0, jumpForce, 0));
    }
}

