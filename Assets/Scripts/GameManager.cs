using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    private SceneLoader sceneLoader;
    public AudioSource soundManagerAudioSource;
    [Header("Laps")]
    public TMP_Text lapsText;
    public int maxLaps = 1;
    public int lapsDone = 0;
    [Header("Timer")]
    public TimeManager timeManager;
    public TMP_Text timerText;
    public float time;
    public float maxTime = 450;
    
    [Header("Car")]
    public GameObject car;
    public float carSpeed;
    public CinemachineVirtualCamera virtualCamera;
    public float detachedCameraTime = 5.0f;

    [Header("Fuel")]
    public TMP_Text fuelValue;
    public int fuelInCar;
    public int fuelDropRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();

        timeManager = GetComponent<TimeManager>();

        time = maxTime;

        UpdateTimerText(time, maxTime);

        UpdateFuelGauge();

        StartCoroutine(CountdownTimer());
        StartCoroutine(ConsumingFuel());
    }

    // Update is called once per frame
    void Update()
    {
        carSpeed = int.Parse(car.GetComponent<PrometeoCarController>().carSpeedText.text);
        UpdateFuelGauge();

        UpdateLapsText(lapsDone, maxLaps);

        if (time <= 0.0f || fuelInCar <= 0)
        {
            sceneLoader.LoadSceneAsyncByIndex(4);
        }
    }

    // Functions
    public void UpdateTimerText(float time, float maxTime)
    {
        timeManager.CaculateTimer(time, maxTime);
        timerText.text = timeManager.ReturnStringTimeElapsed();
    }

    public void UpdateLapsText(int lapsDone, int maxLaps)
    {
        lapsText.text = $"{lapsDone}/{maxLaps}";
    }

    public void UpdateFuelGauge()
    {
        fuelInCar = car.GetComponent<CarStats>().fuelTank;
        fuelValue.text = fuelInCar.ToString();
        if (fuelInCar <= 100 && fuelInCar > 40)
        {
            fuelValue.color = new Color(1.0f, 1.0f, 1.0f);
        }
        else if (fuelInCar <= 40 && fuelInCar > 20)
        {
            fuelValue.color = new Color(1.0f, 0.8455281f, 0.0f);
        }
        else if (fuelInCar <= 20 && fuelInCar > 10)
        {
            fuelValue.color = new Color(1.0f, 0.4f, 0.0f);
        }
        else if (fuelInCar <= 10 && fuelInCar > 0)
        {
            fuelValue.color = new Color(1.0f, 0.0f, 0.0f);
        }
    }

    public void LapDone()
    {
        lapsDone += 1;
    }

    public void CheckVictory()
    {
        if (lapsDone == maxLaps)
        {
            soundManagerAudioSource.PlayOneShot(car.GetComponent<CarStats>().triggeredFinalCheckpointSound, car.GetComponent<CarStats>().triggeredFinalCheckpointVolume);
            StartCoroutine(CountdownSeparationCamera());
        }
        else
        {
            soundManagerAudioSource.PlayOneShot(car.GetComponent<CarStats>().triggeredCheckpointSound, car.GetComponent<CarStats>().triggeredCheckpointVolume);
        }
    }

    // Coroutines
    IEnumerator ConsumingFuel()
    {
        while (time >= 0.0f && fuelInCar > 0)
        {
            yield return new WaitForSeconds(3.0f);
            if (carSpeed > 0.0f)
            {
                car.GetComponent<CarStats>().fuelTank -= fuelDropRate;
            }
        }
    }

    IEnumerator CountdownSeparationCamera()
    {
        virtualCamera.Follow = null;
        virtualCamera.LookAt = null;
        while (detachedCameraTime >= 0.0f)
        {
            Debug.Log($"CT: {detachedCameraTime}");
            yield return new WaitForSeconds(1.0f);
            detachedCameraTime--;
        }
        sceneLoader.LoadSceneAsyncByIndex(3);
    }

    IEnumerator CountdownTimer()
    {
        while (time >= 0.0f)
        {
            UpdateTimerText(time, maxTime);
            yield return new WaitForSeconds(1.0f);
            time--;
        }
    }
}
