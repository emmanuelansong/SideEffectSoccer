using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    
    public Transform trans;
    public GameObject go;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(go, 3);
        GameObject go2 = Instantiate(go, trans.position, Quaternion.identity);
        //gameObject.transform.position = trans.position;
    }

}