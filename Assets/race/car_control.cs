using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_control : MonoBehaviour
{
    private Rigidbody rb;
    public float Acceleration;
    public float Steering;
    public float MaxSpeed;
    public float BackSpeed;
    private float Speed;
    public bool onDirt;
    public float CompensationForces;
    public float CompensationThreshold;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Acceleration * Input.GetAxis("Vertical");
        if (move > 0)
        {
            Speed = MaxSpeed;
        }
        else
        {
            Speed = BackSpeed;
        }
        if (onDirt)
        {
            Speed = BackSpeed;
        }
        if (Mathf.Abs(transform.InverseTransformDirection(rb.velocity).z) < Speed)
        {
            rb.AddRelativeForce(new Vector3(0, 0, move));
        }

        //sily wyrownawcze
        if (transform.InverseTransformDirection(rb.velocity).z > Speed * 3 / 4)
        {
            rb.AddRelativeForce(new Vector3(0, 0, -CompensationForces));            
        }
        if (transform.InverseTransformDirection(rb.velocity).z < -Speed * 3 / 4)
        {
            rb.AddRelativeForce(new Vector3(0, 0, CompensationForces));            
        }
        if (transform.InverseTransformDirection(rb.velocity).z > CompensationThreshold)
        {
            rb.AddRelativeForce(new Vector3(-CompensationThreshold, 0, 0));            
        }
        if (transform.InverseTransformDirection(rb.velocity).z < -CompensationThreshold)
        {
            rb.AddRelativeForce(new Vector3(CompensationThreshold, 0, 0));            
        }
    
        float rotacja = Steering * Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, rotacja, 0));
    }
}
