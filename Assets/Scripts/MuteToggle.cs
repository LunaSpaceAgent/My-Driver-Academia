using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MuteToggle : MonoBehaviour
{
    // Variables
    public UnityEngine.UI.Toggle toggle;
    public bool isToggleOn;
    public MusicManager musicManager;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<UnityEngine.UI.Toggle>();;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    public void UpdateToggleOnBool()
    {
        isToggleOn = toggle.isOn;
        musicManager.musicAudioSource.mute = isToggleOn;
        if (isToggleOn)
        {
            musicManager.PauseMusic();
        }
        else
        {
            musicManager.PlayMusic();
        }
    }
}
