using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Variables 
    [SerializeField] private Transform playerTransform; // Player transform component
    [Range(0.1f, 1f)]
    [SerializeField] private float smoothingSpeed = 0.125f;  // Camera follow movements smoothing
    [SerializeField] private Vector3 offsetPosition = new Vector3(0.0f, 6.0f, -5.0f);   // Camera position offset values
    [SerializeField] private Vector3 offsetRotation = new Vector3(35.0f, 0.0f, 0.0f);   // Camera rotation offset values

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void LateUpdate()
    {
        bool isPlayerTransformNull = playerTransform != null;
        if (isPlayerTransformNull)
        {
            // Calculate the player position adding the camera offset
            Vector3 newCameraPosition = playerTransform.position + offsetPosition;

            // Linear Interpolation to smooth the camera movement
            Vector3 smoothedPosition = Vector3.Lerp(playerTransform.position, newCameraPosition, smoothingSpeed);

            // Assigning the new position and rotation to the camera
            transform.position = smoothedPosition;
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, offsetRotation, 1.0f);
        }
    }
}
