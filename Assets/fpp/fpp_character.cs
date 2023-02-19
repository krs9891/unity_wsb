using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpp_character : MonoBehaviour
{
	public float MaxHealth;
	public float Health;
	public float Damage;
    public float AmmoCurrent;
    public float AmmoTotal;
    public float magSize;

    //private GameObject loot;

	
    // Start is called before the first frame update
    public virtual void Start()
    {
    Health=MaxHealth;
    //loot = GameObject.Find("loot");
    }

	public void GotHit(float HitDamage)
	{
	Health-=HitDamage;
	if (gameObject.CompareTag("Player"))
		{
		fpp_manager.Instance.HealthUpdate();
		}

	if (Health<=0)
		{
		if (gameObject.CompareTag("Player"))
			{	
			fpp_manager.Instance.Death();
			} else
				{
				Destroy(gameObject);	
				}
		
        if (gameObject.CompareTag("enemy"))
            {
            Instantiate(fpp_manager.Instance.DropItem, transform.position, transform.rotation);
			fpp_manager.Instance.NextDropItem();
            }
        }
	}

    public void GotHealth(float points)
    {
        Health += points;
        if (Health >= MaxHealth) Health = MaxHealth;
        if (gameObject.CompareTag("Player")) fpp_manager.Instance.HealthUpdate();
    }

    public void GotAmmo(float bullets)
    {
        AmmoTotal += bullets;
        if (gameObject.CompareTag("Player")) fpp_manager.Instance.AmmoUpdate();
    }
    
    public void Reload()
    {
        if (AmmoTotal >= magSize - AmmoCurrent)
        {
            AmmoTotal -= magSize - AmmoCurrent;
            AmmoCurrent = magSize;
        }
        else
        {
            AmmoCurrent += AmmoTotal;
            AmmoTotal = 0;
        }
	    fpp_manager.Instance.EndUpdate("");
	    fpp_manager.Instance.AmmoUpdate();
    }

}
