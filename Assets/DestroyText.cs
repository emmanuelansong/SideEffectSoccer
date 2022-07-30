using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{

    public float destroyTime = 3f;
    // Start is called before the first frame update
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }

}
