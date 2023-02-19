using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformer_ammo : MonoBehaviour
{
    public float moveSpeed;
    private float direction;
    private Rigidbody rb;
    public int LifeExpectancy;
    private int i = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = GameObject.FindWithTag("Player").GetComponent<platformer_controller>().side;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = moveSpeed * direction;
        rb.velocity = new Vector3(move, rb.velocity.y, 0);

        i++;
        if (i > LifeExpectancy)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "enemy")
        {
            Destroy(hit.gameObject);
        }
        if (hit.tag != "coin" && hit.tag != "Finish")
        {
            Destroy(gameObject);
        }
    }
}
