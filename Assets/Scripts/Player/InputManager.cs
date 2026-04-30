using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    // Variables
    private InputActions input;
    private InputActions.DriverActions driver;
    
    private PrometeoCarController carController;
    private CarStats carStats;
    private bool brake;

    void Awake()
    {
        input = new InputActions();
        driver = input.Driver;
        carController = GetComponent<PrometeoCarController>();
        carStats = GetComponent<CarStats>();

        driver.Handbrake.performed += ctx => brake = true;
        driver.Handbrake.canceled += ctx => brake = false;
        driver.Reset.performed += ctx => carStats.ResetCarPosition();
        //driver.Handbrake.triggered += ctx => carController.BrakingCar(driver.Handbrake.ReadValue<float>());
    }

    // Start is called before the first frame update
    void Start()
    {
        brake = false;
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Will tell the CarMovement to move using the value from the movement action on MyInputActions
        carController.GoForwardAndBackwards(driver.Movement.ReadValue<Vector2>());
        carController.TurningWheels(driver.Movement.ReadValue<Vector2>());
        carController.CarSlowingDown();
        CarBraking();
    }

    void LateUpdate()
    {
        
    }

    void OnEnable()
    {
        driver.Enable();
    }

    void OnDisable()
    {
        driver.Disable();
    }

    // Functions
    public void CarBraking()
    {
        if (brake)
        {
            carController.BrakingCar(1.0f);
        }
        else
        {
            carController.BrakingCar(0.0f);
        }
    }
}
