using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarParticlesBehavior : MonoBehaviour
{
    // Variables
    public ParticleSystem particle;
    public bool areParticlesOn = false;

    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (areParticlesOn)
        {
            PlayParticles();
        }
        else
        {
            StopParticles();
        }
    }

    // Functions
    public void PlayParticles()
    {
        particle.Play();
    }

    public void StopParticles()
    {
        particle.Stop();
    }
}
