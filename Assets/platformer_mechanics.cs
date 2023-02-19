using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class platformer_mechanics : MonoBehaviour
{
    private int Coins = 0;
    public Text coinString;
    public Text endString;
    public bool Alive = true;
    private bool Died = false;

    void Start()
    {
        coinString.text = "Coins: " + Coins.ToString("F0");
        endString.text = "";
    }

    void Update()
    {
        if (!Alive&&!Died)
        {
            Died = true;
            endString.text = "You died! Press 'space' to restart";
            Destroy(GetComponent<platformer_controller>());
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Renderer>());
        }

        if (Died)
        {
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (transform.position.y<-7)
        {
            Alive = false;
        }
    }

    void OnTriggerEnter(Collider collect)
    {
        if (collect.tag == "coin")
        {
            Coins++;
            coinString.text = "Coins: " + Coins.ToString("F0");
            Destroy(collect.gameObject);
        }
        if (collect.tag == "Finish")
        {
            Died = true;
            endString.text = "You won! Press 'space' to restart";
            Destroy(GetComponent<platformer_controller>());
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<Collider>());
        }
    }
}
