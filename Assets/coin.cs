using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 5, 0));
    }
}
