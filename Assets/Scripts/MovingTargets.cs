using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargets : MonoBehaviour
{
    [SerializeField]
    Transform[] wayPoints;
    int currentWayPoint = 0;

    Rigidbody rb;
    [SerializeField]
    float moveSpeed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(Vector3.Distance(transform.position, wayPoints[currentWayPoint].position) < 2.5f)
        {
            currentWayPoint += 1;
            currentWayPoint = currentWayPoint % wayPoints.Length;
        }
        Vector3 direction = (wayPoints[currentWayPoint].position - transform.position);//.normalized;
        rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
    }
}
