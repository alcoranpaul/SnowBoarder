using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    //Instance Variables
    private float timeDelay = 2;
    private bool crashDetected = false;

    //Components
    [SerializeField] ParticleSystem effect;
    [SerializeField] AudioClip crashSFX;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && !crashDetected)
        {
            crashDetected = true;
            effect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            GetComponent<PlayerController>().StopPlayer();
            GetComponent<DustTrail>().StopParticles();
            Invoke(nameof(ReloadScene), timeDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Main");
    }
}
