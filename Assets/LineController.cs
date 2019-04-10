using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineController : MonoBehaviour
{
    public float upSpeed = 0.4f;
    public float horizontalSpeed = 0.3f;
    public int points;
    public bool collision;

    public List<Collider> obstacleColliders;
    public List<GameObject> bonusPoints;
    private LineRenderer lineRenderer;
    private Vector3 pos = Vector3.zero;
    private int index = 1;
    private float timeToUpdate = 0.4f;
    private float timer = 0;
    private Vector3 destiny;
    private DirectionEnum direction = DirectionEnum.NONE;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }

    void Update()
    {
        collideWithObstacle();
        setDestination();
        changeDirection();
        if (pos.y > 10 || points < 0 || collision) return;
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
            points--;
            Debug.Log(points);
            addPoints();
        }
        timer += Time.deltaTime;
    }

    void changeDirection()
    {

        if (destiny.x > pos.x)
        {
            direction = DirectionEnum.RIGHT;
        }
        if (destiny.x < pos.x)
        {
            direction = DirectionEnum.LEFT;
        }
    }

    void collideWithObstacle()
    {
        foreach (Collider collider in obstacleColliders)
        {
            if (collider.bounds.Intersects(lineRenderer.bounds))
            {
                Debug.Log("Obstacle");
                collision = true;
            }
        }
    }

    void setDestination()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            destiny = ray.origin;
            Debug.Log(destiny);
        }
    }

    void addPoints()
    {
        foreach (GameObject bonusPoint in bonusPoints)
        {           
            if (bonusPoint.GetComponent<Collider>().bounds.Intersects(lineRenderer.bounds))
            {
                points += 100;
                bonusPoints.Remove(bonusPoint);
                bonusPoint.SetActive(false);
                break;
            }
        }
    }
}
