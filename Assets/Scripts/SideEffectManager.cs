using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideEffectManager : MonoBehaviour
{
    private PlayerScript player;
    
    private Animator camAnim;

    private PointSystem points;

    
    public static float slowdownFactor;
    public int duration = 1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        points  = GetComponent<PointSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator SlowMotion()
    {
        //Slows down time
        Time.timeScale = slowdownFactor;
        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
       
        //Time.fixedDeltaTime = Time.timeScale * .02f;
        yield return new WaitForSeconds(duration);

        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public IEnumerator DecreasePower()
    {
        player.shotPower -= 1.5f;
        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        
        yield return new WaitForSeconds(duration);
        
        //Decreases shot power
        player.shotPower += 1.5f;
        Destroy(gameObject);
        
    }
    public IEnumerator IncreasePower()
    {        
        //Increases shot power
        player.shotPower += 2f;

        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        
        yield return new WaitForSeconds(duration);

        player.shotPower -= 2f;
        Destroy(gameObject);
    }



    public IEnumerator CameraShake()
    {
        camAnim.SetTrigger("shake");

        yield return new WaitForSeconds(duration);

        camAnim.SetTrigger("default");
    }
    public IEnumerator BonusPoints() 
    {
        points.value += 100;
        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(duration);
        points.value -= 100;
    }
    public void PostWallShake()
    {
        camAnim.SetTrigger("wall");
    }

}
