using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStats : MonoBehaviour
{
    // Variables
    [Header("Fuel")]
    public int fuelTank = 100;
    public int fuelCanister = 4;
    public int barrelFuelLoss = 2;
    [Header("Checkpoint")]
    public Vector3 checkpointResetCarPosition;
    public float yOffset = 5.0f;
    public Quaternion checkpointResetCarRotation;
    [Header("Sound Manager")]
    public AudioSource soundManagerAudioSource;
    public AudioClip hitFuelCanSound;
    [Range(0.0f, 1.0f)]
    public float hitFuelCanVolume = 0.5f;
    public AudioClip hitBarrelSound;
    [Range(0.0f, 1.0f)]
    public float hitBarrelVolume = 0.5f;
    public AudioClip triggeredCheckpointSound;
    [Range(0.0f, 1.0f)]
    public float triggeredCheckpointVolume = 0.5f;
    public AudioClip triggeredFinalCheckpointSound;
    [Range(0.0f, 1.0f)]
    public float triggeredFinalCheckpointVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Setting Car reset position & rotation
        checkpointResetCarPosition = transform.position;
        checkpointResetCarRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    public void ResetCarPosition()
    {
        transform.SetPositionAndRotation(checkpointResetCarPosition, checkpointResetCarRotation);
    }

    // On Collision
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Fuel"))
        {
            Destroy(other.gameObject);
            soundManagerAudioSource.PlayOneShot(hitFuelCanSound, hitFuelCanVolume);
            if (fuelTank < 100)
            {
                fuelTank += fuelCanister;
            }
        }

        if (other.transform.tag.Equals("Checkpoint"))
        {
            checkpointResetCarPosition = other.transform.position;
            checkpointResetCarPosition.y -= yOffset;
            checkpointResetCarRotation = other.transform.rotation;
        }

        if (other.transform.tag.Equals("Barrel"))
        {
            Destroy(other.gameObject);
            soundManagerAudioSource.PlayOneShot(hitBarrelSound, hitBarrelVolume);
            fuelTank -= barrelFuelLoss;
        }
    }
}
