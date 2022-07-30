using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointSystem : MonoBehaviour
{
    public int value;
 
    public GameObject impact;
   // private Shake shake;
    public SideEffectManager side;
    PlayerScript player;
    public AudioSource audio;

    public GameObject particles;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        side = GetComponent<SideEffectManager>();
        audio = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.score += value;
            if (gameObject.tag.Contains("Point/"))
            {
                StartCoroutine(spawnParticles());
                if (gameObject.CompareTag("Point/50"))
                {
                    audio.Play();
                    GetComponentInChildren<MeshRenderer>().enabled = false;
                    GetComponent<Collider>().enabled = false;
                    ShowFloatingText();

                    StartCoroutine(side.DecreasePower());

                }

                if (gameObject.CompareTag("Point/100"))
                {
                    audio.Play();
                    StartCoroutine(side.IncreasePower());
                    ShowFloatingText();
                }

                if (gameObject.CompareTag("Point/200"))
                {
                    audio.Play();
                    StartCoroutine(side.IncreasePower());
                    StartCoroutine(side.SlowMotion());
                    ShowFloatingText();
                }

                if (gameObject.CompareTag("Point/Bonus"))
                {
                    audio.Play();
                    StartCoroutine(side.BonusPoints());
                    ShowFloatingText();

                    Destroy(gameObject, 5);
                }
            }
           // yield return new WaitForSeconds(2);
            player.Respawn();
        }
           

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.score += value;

            if (gameObject.CompareTag("Wall"))
            {
                audio.Play();
                ShowFloatingText();
                side.PostWallShake();
                StartCoroutine(side.CameraShake());
                
                StartCoroutine(spawnParticles());
                
                

            }
        }
    }
    IEnumerator spawnParticles()
    {
        GameObject particlesClone = Instantiate(particles, transform.position, transform.rotation);
        
        Debug.Log("particles enabled");
        yield return new WaitForSeconds(5);
        Destroy(particlesClone);
        Debug.Log("particles disabled");

    }    
    void ShowFloatingText()
    {
        GameObject text = Instantiate(impact, transform.position, Quaternion.identity);

        text.GetComponent<TextMesh>().text = value.ToString();

        // Destroy(text, textTime);

    }

    


}
