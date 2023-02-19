using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformer_enemy01 : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;
    private float direction = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = moveSpeed * direction;
        rb.velocity = new Vector3(move, rb.velocity.y, 0);
    }

    void FixedUpdate()
    {
        RaycastHit wall;
        if (Physics.Raycast(transform.position, new Vector3(direction, 0, 0), out wall, 0.55f, 1, QueryTriggerInteraction.Ignore))
        {
            if (wall.collider.tag != "Player")
            {
                direction = -direction;
            }
        }

        if (!Physics.Raycast(transform.position, new Vector3(direction, -1, 0), out wall, 0.72f, 1, QueryTriggerInteraction.Ignore))
        {         
            direction = -direction;        
        }

        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            hit.gameObject.GetComponent<platformer_mechanics>().Alive = false;
        }
    }
}
