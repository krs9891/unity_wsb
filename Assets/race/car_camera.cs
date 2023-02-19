using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_camera : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Target.position);

        float Angle = Target.eulerAngles.y;
        Quaternion rotacja = Quaternion.Euler(0, Angle, 0);
        transform.position = Target.position + (rotacja * Offset);
    }
}
