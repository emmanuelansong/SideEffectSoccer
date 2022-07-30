using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audio;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float collisionForce = collision.impulse.magnitude / Time.fixedDeltaTime;

            audio.volume = Mathf.Clamp(collisionForce / 600f, 0f, 1);
            audio.Play();
        }
    }
    
    // Update is called once per frame
    void Start()
    { 
        audio = GetComponent<AudioSource>();
        audio.volume = 0;
    }


}
