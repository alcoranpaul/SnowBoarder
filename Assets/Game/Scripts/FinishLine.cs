using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    //Instance Variables
    private float timeDelay = 2;

    //Components
    [SerializeField] ParticleSystem effect;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            effect.Play();
            Invoke(nameof(ReloadScene), timeDelay);
            GetComponent<AudioSource>().Play();
        }
        
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Main");
    }
}
