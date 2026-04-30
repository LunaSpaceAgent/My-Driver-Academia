using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class CarMovement : MonoBehaviour
{
    // Variables
    [Header("RigidBody and Player Velocity")]
    public Rigidbody carRigidBody;
    public Vector3 carVelocity;
    public Vector3 forwardVelocity;
    public Vector3 wheelTurnValue;

    [Header("Statistics")]
    [Range(20.0f, 190.0f)]
    public float maxSpeed = 90.0f; //The maximum speed that the car can reach in km/h.
    [Range(10.0f, 120.0f)]
    public float maxReverseSpeed = 45.0f; //The maximum speed that the car can reach while going on reverse in km/h.
    [Range(1.0f, 10.0f)]
    public float accelerationMultiplier = 2.0f; // How fast the car can accelerate. 1 is a slow acceleration and 10 is the fastest.
    [Range(10.0f, 45.0f)]
    public float maxSteeringAngle = 27.0f; // The maximum angle that the tires can reach while rotating the steering wheel.
    [Range(0.1f, 1f)]
    public float steeringSpeed = 0.5f; // How fast the steering wheel turns.
    [Range(100.0f, 600.0f)]
    public float brakeForce = 350.0f; // The strength of the wheel brakes.
    [Range(1.0f, 10.0f)]
    public float decelerationMultiplier = 2.0f; // How fast the car decelerates when the user is not using the throttle.
    [Range(1.0f, 10.0f)]
    public float handbrakeDriftMultiplier = 5.0f; // How much grip the car loses when the user hit the handbrake.

    [Header("Parts Meshes and Colliders")]
    public GameObject frontRightWheelMesh;
    public WheelCollider frontRightWheelCollider;
    public GameObject frontLeftWheelMesh;
    public WheelCollider frontLeftWheelCollider;
    public GameObject rearRightWheelMesh;
    public WheelCollider rearRightWheelCollider;
    public GameObject rearLeftWheelMesh;
    public WheelCollider rearLeftWheelCollider;

    [Header("Sound")]
    public AudioSource carAudioSource;

    [Header("Other Statistics")]
    public int lapsCount;
    public TMP_Text lapsCountText;
    public int carSpeed;
    public TMP_Text speedText;
    public int carFuelLeft;
    public TMP_Text fuelText;

    // Start is called before the first frame update
    void Start()
    {
        if (carRigidBody == null)
        {
            carRigidBody = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = carRigidBody.isGrounded;
        Debug.Log($"Acceleration: {forwardVelocity}, Wheels Turning Value: {wheelTurnValue}, Car Velocity: {carVelocity}");
    }

    // Functions
    public void Accelerate(Vector2 input)
    {
        forwardVelocity = Vector3.zero;
        //forwardVelocity.x = input.x;
        forwardVelocity.z = input.y;
        //controller.Move(transform.TransformDirection(forwardVelocity) * (speed * mutliplier) * Time.deltaTime);

        /*playervelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playervelocity.y < 0)
        {
            playervelocity.y = gravity;
        }*/
        //controller.Move(playervelocity * Time.deltaTime);
        //carRigidBody.AddForce(forwardVelocity * (speed * multiplier) * Time.deltaTime);
        //Debug.Log(forwardVelocity);
    }

    public void Brake()
    {

    }

    public void TurnWheels(Vector2 input)
    {
        wheelTurnValue = Vector3.zero;
        wheelTurnValue.x = input.x;
        //wheelTurnValue.z = input.y;
        //controller.Move(transform.TransformDirection(wheelTurnValue) * (speed * mutliplier) * Time.deltaTime);

        /*playervelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playervelocity.y < 0)
        {
            playervelocity.y = gravity;
        }*/
        //controller.Move(playervelocity * Time.deltaTime);
        //carRigidBody.AddForce(wheelTurnValue * (speed * multiplier) * Time.deltaTime);
        //Debug.Log(wheelTurnValue);
    }
}
