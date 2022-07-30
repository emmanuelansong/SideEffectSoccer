using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{

    public Transform[] waypoints;

    public int speed;
    private int current;

    private void Start()
    {

    }
    private void Update()
    {
        if (transform.position != waypoints[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, waypoints[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }

        else current = (current + 1) % waypoints.Length;
    }

}
