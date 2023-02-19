using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class race_manager : MonoBehaviour
{
    public Text LapString;
    public Text EndString;
    public Text VelocityString;
    public Text TotalTimeString;
    public Text BestTimeString;
    public Text CurrentTimeString;
    private int Lap = 0;
    public int Goal;
    private bool End = false;
    private bool Ended = false;
    private float TotalTime = 0;
    private float CurrentTime = 0;
    private float BestTime;
    private bool PK1 = true;
    private bool PK2 = true;
    private int onGround;

    // Start is called before the first frame update
    void Start()
    {
        LapString.text = "Laps: " + Lap.ToString("F0") + "/" + Goal.ToString("F0");
        EndString.text = "Cross the line to start the race.";
        TotalTimeString.text = "Time: " + (TotalTime / 50).ToString("F2");
        CurrentTimeString.text = "Current lap: " + (CurrentTime / 50).ToString("F2");
        BestTimeString.text = "Best lap: --/--";
        BestTime = float.MaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (End && !Ended)
        {
            Ended = true;
            Destroy(GetComponent<car_control>());
            EndString.text = "You finished the course!\nIt took you: " + (TotalTime / 50).ToString("F2") + "s.\nYour best lap took: " + (BestTime / 50).ToString("F2") + "s.\nPress SPACE to start again!";
        }
        if (Ended)
        {
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void FixedUpdate()
    {
        if (Lap > 0 && !End)
        {
            TotalTime++;
            CurrentTime++;
            TotalTimeString.text = "Time: " + (TotalTime / 50).ToString("F2");
            CurrentTimeString.text = "Current lap: " + (CurrentTime / 50).ToString("F2");
        }

        VelocityString.text = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z.ToString("F0");
        
        onGround = 0;
        RaycastHit ground;
        for (float x = -0.45f; x <= 0.45f; x += 0.9f)
        {
            for (float z = -0.9f; z <= 0.9f; z += 1.8f)
            {
                Vector3 pozycja = transform.position + transform.forward * z + transform.right * x;
                if (Physics.Raycast(pozycja, -Vector3.up, out ground, 0.7f))
                {
                    onGround++;
                    if (ground.collider.tag == "Respawn")
                    {
                        onGround++;
                    }
                }
            }
        }
        if (!End)
        {
            if (onGround > 3)
            {
                GetComponent<car_control>().enabled = true;
            }
            else
            {
                GetComponent<car_control>().enabled = false;
            }
            if (onGround > 5)
            {
                GetComponent<car_control>().onDirt = true;
            }
            else
            {
                GetComponent<car_control>().onDirt = false;
            }
        }
    }

    void OnTriggerEnter(Collider Checkpoint)
    {
        if (Checkpoint.tag == "coin")
        {
            PK1 = true;
        }
        if (Checkpoint.tag == "enemy" && PK1)
        {
            PK2 = true;
        }
        if (Checkpoint.tag == "Finish" && PK1 && PK2)
        {
            if (Lap > 0)
            {
                if (CurrentTime < BestTime)
                {
                    BestTime = CurrentTime;
                    BestTimeString.text = "Best lap: " + (BestTime / 50).ToString("F2");
                }
            }
        Lap++;
        LapString.text = "Laps: " + Lap.ToString("F0") + "/" + Goal.ToString("F0");
        EndString.text = "";
        PK1 = false;
        PK2 = false;
        if (Lap > Goal)
        {
            End = true;
        }
        CurrentTime = 0;
        }
    }
}
