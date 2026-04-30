using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehavior : MonoBehaviour
{
    // Variable
    public bool isFinalCheckpoint = false;
    public GameObject nextCheckpointToActivate;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnTrigger
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            gameManager.CheckVictory();
            if (gameManager.lapsDone < gameManager.maxLaps)
            {
                if (isFinalCheckpoint)
                {
                    gameManager.LapDone();
                }
                nextCheckpointToActivate.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
