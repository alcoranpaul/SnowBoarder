using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    private bool crashDetected = false;
    [SerializeField] ParticleSystem dustParticles;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !crashDetected)
        {
            dustParticles.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dustParticles.Stop();
        }
        
    }

    public void StopParticles()
    {
        if (!crashDetected)
        {
            dustParticles.Stop();
            crashDetected = true;
        }
    }
}
