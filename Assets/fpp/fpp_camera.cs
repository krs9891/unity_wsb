using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpp_camera : MonoBehaviour
{
	private Vector2 mouseLook;
	public float sensitivity;
	private Transform Target;
	
    // Start is called before the first frame update
    void Start()
    {
    Cursor.lockState=CursorLockMode.Locked;
	Target=transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Escape))
		{
		Cursor.lockState=CursorLockMode.None;	
		}
    
	Vector2 tempLook=new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"))*sensitivity;
	
	mouseLook+=tempLook;
	mouseLook.y=Mathf.Clamp(mouseLook.y,-65,80);
	
	transform.localRotation=Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
	Target.rotation=Quaternion.AngleAxis(mouseLook.x,Target.transform.up);
	}
}
