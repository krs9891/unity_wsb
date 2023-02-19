using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpp_weapon : MonoBehaviour
{
	
	public Transform Target;
	public Transform Target2;
	public Vector3 Offset;
	public GameObject ammo;
    

    // Update is called once per frame
    void LateUpdate()
    {
    Quaternion rotacja=Quaternion.Euler(Target2.eulerAngles.x,Target.eulerAngles.y,0);
	transform.position=Target2.position+(rotacja*Offset);
	
	transform.rotation=Target2.rotation*Quaternion.Euler(90,0,0);
	
	if (Input.GetButtonDown("Fire1"))
		{
            if (Target.GetComponent<fpp_character>().AmmoCurrent > 0)
            {
                var tempAmmo=Instantiate(ammo, transform.position,transform.rotation);	
		        tempAmmo.GetComponent<fpp_ammo>().Damage=Target.gameObject.GetComponent<fpp_character>().Damage;
                Target.GetComponent<fpp_character>().AmmoCurrent--;
	            fpp_manager.Instance.AmmoUpdate();

            }
            if (Target.GetComponent<fpp_character>().AmmoCurrent == 0)
            {
			    fpp_manager.Instance.EndUpdate("Press 'R' to reload!");
            }
            if (Target.GetComponent<fpp_character>().AmmoCurrent == 0 && Target.GetComponent<fpp_character>().AmmoTotal == 0)
            {
			    fpp_manager.Instance.EndUpdate("You are out of ammo!");
            }

        }
    }
}
