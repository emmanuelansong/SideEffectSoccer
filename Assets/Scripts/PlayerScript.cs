using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    Vector2 startPos, endPos, direction;
    static Rigidbody rb;

    static Vector3 start;
  
    public bool kickable;
    
    public float shotPower = 5f;

    public AudioSource kickAudio;
  
    public Animator anim;

    public float distance;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();    
        start = rb.position;
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            startPos = Input.mousePosition;
           
        }

    }
   
    //on mouse down + movement
    private void OnMouseDrag()
    {
        endPos = Input.mousePosition;
        distance = Vector2.Distance(startPos, endPos);
        
    }

    void OnMouseUp()
    {
        if(kickable)
            if (Input.GetMouseButtonUp(0))
            {
                endPos = Input.mousePosition;
                direction = startPos - endPos;
                rb.isKinematic = false;
                rb.AddRelativeForce(direction * shotPower/4);
                
                rb.velocity = transform.forward * shotPower;
               
                kickAudio.Play();

                distance = 0;
            }
        kickable = false;
    }

    private void Update()
    {
        if (rb.velocity.magnitude == 0)
            kickable = false;
        if (rb.velocity.magnitude < 0.5)
            Respawn();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            Respawn();
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Posts"))
        {
            anim.SetTrigger("post");

        }
    }

    public void Respawn()
    {
        kickable = true;
        rb.position = start;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.rotation = Quaternion.identity;
    }

}
