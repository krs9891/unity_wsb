using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fpp_manager : MonoBehaviour
{
	private GameObject Player;
	private GameObject Weapon;

	public Text endString;

	public bool Died=false;
	public Text healthString;
    public Text ammoString;
	public int TextDelay;

	public bool Key=false;
    public bool Alert = false;
    public GameObject[] items = new GameObject[4];
    public GameObject DropItem;
    int i = 0;

	
	public static fpp_manager Instance;
	
	void Awake()
	{
	if (Instance==null)
		{
		Instance=this;	
		} else
			{
			Debug.Log("Multiple manager scripts!");
			return;
			}
	}
	
    void Start()
	{
	Player=GameObject.FindWithTag("Player");
	Weapon=GameObject.Find("Weapon");

	endString.text="";
	HealthUpdate();
    AmmoUpdate();
    DropOrder();
    DropItem = items[i];
    

	}

    // Update is called once per frame
    void Update()
    {
    if (Died)
		{
		if (Input.GetButtonDown("Jump"))
			{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);	
			}
		}    
    }
	
	void FixedUpdate()
	{
	if (TextDelay>0)
		{
		TextDelay--;	
		}
	if (TextDelay==0)
		{
		endString.text="";	
		}

	}
	
	public void Death()
	{
	Died=true;
	endString.text="You died! Press 'space' to restart.";
	TextDelay=int.MaxValue;
	Destroy(Player.GetComponent<fpp_character>());
	Destroy(Player.GetComponent<Rigidbody>());
	Destroy(Player.GetComponent<Collider>());
    Destroy(Player.GetComponent<Renderer>());

	Destroy(Weapon.GetComponent<fpp_weapon>());
	Destroy(Weapon.GetComponent<Rigidbody>());
	Destroy(Weapon.GetComponent<Collider>());
    Destroy(Weapon.GetComponent<Renderer>());



	}
	
	public void HealthUpdate()
	{
	    healthString.text= "HP\n" + Player.GetComponent<fpp_character>().Health.ToString("F0");	
	}
    
    public void AmmoUpdate()
    {
        ammoString.text = "AMMO\n" + Player.GetComponent<fpp_character>().AmmoCurrent.ToString("F0") + "/" + Player.GetComponent<fpp_character>().AmmoTotal.ToString("F0");
    }

	
	public void EndUpdate(string Message)
	{
	endString.text=Message;
	TextDelay=150;
	}

    
	
	public void Win()
	{
	if (Key==true)
		{		
		Died=true;
		endString.text="You Won! Press 'space' to restart.";
		TextDelay=int.MaxValue;
		Destroy(Player.GetComponent<fpp_character>());
		Destroy(Player.GetComponent<Rigidbody>());
		Destroy(Player.GetComponent<Collider>());
		} else
			{
			EndUpdate("Collect the key and then get back here!");	
			}
	}
    public void DropOrder()
    {
        for (int positionOfArray = 0; positionOfArray < items.Length; positionOfArray++)
        {
            GameObject item = items[positionOfArray];
            int randomizeArray = Random.Range(0, positionOfArray);
            items[positionOfArray] = items[randomizeArray];
            items[randomizeArray] = item;
        }
    
    
    }
    
    public void NextDropItem()
    {
        i++;
        if (i < items.Length)
        {
            DropItem = items[i];
        }
    }
}
