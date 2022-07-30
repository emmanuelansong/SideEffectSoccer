using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{

    Vector3 lrStartPos, lrEndPos;
    LineRenderer lr;
    Camera camera;
    [SerializeField] AnimationCurve ac;
    Vector3 offset = new Vector3(0, 0, 10);
    private void Start()
    {
        lr  = GetComponent<LineRenderer>();
        camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lr.enabled = true;
            lr.positionCount = 2;
            lrStartPos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + 20, Input.mousePosition.y, 5f));

            lr.SetPosition(0, lrStartPos);
            lr.useWorldSpace = true;
            lr.widthCurve = ac;
            lr.numCapVertices = 10;
        }

        if (Input.GetMouseButton(0))
        {
            lrEndPos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + 20, Input.mousePosition.y, 5f));
            lr.SetPosition(1, lrEndPos);
        }

        if(Input.GetMouseButtonUp(0))
        {
            lr.enabled = false;
        }

    }
}
