using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineController : MonoBehaviour
{
    public float upSpeed = 0.4f;
    public float horizontalSpeed = 0.3f;

    private LineRenderer lineRenderer;
    private Vector3 pos = Vector3.zero;
    private int index = 1;
    private float timeToUpdate = 0.2f;
    private float timer = 0;

    private DirectionEnum direction = DirectionEnum.NONE;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pos.y > 10) return;
        if (Input.GetKey(KeyCode.A) && pos.x > - 2.8f)
        {
            direction = DirectionEnum.LEFT;
        }
        if (Input.GetKey(KeyCode.D) && pos.x < 2.8f)
        {
            direction = DirectionEnum.RIGHT;
        }

        if (timer > timeToUpdate)
        {
            timer = 0;
            // CODE HERE
            pos.y += upSpeed;
            switch (direction)
            {
                case DirectionEnum.NONE:
                    break;
                case DirectionEnum.LEFT:
                    pos.x -= horizontalSpeed;
                    break;
                case DirectionEnum.RIGHT:
                    pos.x += horizontalSpeed;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            direction = DirectionEnum.NONE;

            lineRenderer.positionCount++;
            lineRenderer.SetPosition(index, pos);
            index++;
        }
        timer += Time.deltaTime;
    }

    void FixedUpdate()
    {


    }
}
