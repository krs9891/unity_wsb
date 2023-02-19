using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformer_camera : MonoBehaviour
{
    public Vector2 GranicaX;
    public Vector2 GranicaY;
    public Vector3 Offset;
    private Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pozycja = Target.position + Offset;
        pozycja.x = Mathf.Clamp(pozycja.x, GranicaX.x, GranicaX.y);
        pozycja.y = Mathf.Clamp(pozycja.y, GranicaY.x, GranicaY.y);
        transform.position = pozycja;
    }
}
