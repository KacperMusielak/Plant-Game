using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineController : MonoBehaviour
{
    private List<Vector3> positionList = new List<Vector3>();
    private LineRenderer lineRenderer;
    private Vector3 pos = Vector3.zero;
    private int index = 1;
    private float timeToUpdate = 0.2f;
    private float timer = 0;

    private int control_id = 0;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            control_id = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            control_id = 2;
        }

        if (timer > timeToUpdate)
        {
            timer = 0;
            // CODE HERE
            pos.y += 0.1f;
            switch (control_id)
            {
                case 0:
                    break;
                case 1:
                    pos.x += -0.1f;
                    break;
                case 2:
                    pos.x += 0.1f;
                    break;
                default:
                    break;
            }

            control_id = 0;
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
