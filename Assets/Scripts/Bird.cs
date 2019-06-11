using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed = 0.5f;
    public float aggroDistance = 2f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    void Start()
    {
        startPosition = transform.position;

    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, FindObjectOfType<Head>().transform.position) < aggroDistance)
        {
            targetPosition = FindObjectOfType<Head>().transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        else
        {
            targetPosition = startPosition;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }

    }
}
