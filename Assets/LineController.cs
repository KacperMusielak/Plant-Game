using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineController : MonoBehaviour
{
    public float Speed = 0.4f;
    public int points;

    public GameObject[] obstacleColliders;
    public GameObject[] bonusPoints;
    private BoxCollider plantCollider;
    private LineRenderer lineRenderer;
    private Vector3 pos = Vector3.zero;
    private int index = 1;
    public float TimeToUpdate = 0.4f;
    private float timer = 0;
    private Vector3 destiny;
    private DirectionEnum direction = DirectionEnum.NONE;

    void Start()
    {
        obstacleColliders = GameObject.FindGameObjectsWithTag("Obstacle");
        bonusPoints = GameObject.FindGameObjectsWithTag("Pickup");
        lineRenderer = GetComponent<LineRenderer>();
        plantCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        plantCollider.center = pos;
        EnergyBar.energy = points;
        //if (pos.y > 10 || points < 0) return;

        changeDirection();

        if (timer > TimeToUpdate)
        {
            timer = 0;
            // CODE HERE
            Vector3 movementVector = Vector3.zero;
            switch (direction)
            {
                case DirectionEnum.UP:
                    movementVector.y += 1;
                    break;
                case DirectionEnum.DOWN:
                    movementVector.y -= 1;
                    break;
                case DirectionEnum.LEFT:
                    movementVector.x -= 1;
                    break;
                case DirectionEnum.RIGHT:
                    movementVector.x += 1;
                    break;
                case DirectionEnum.NONE:
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            pos += movementVector.normalized * Speed;

            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);
        }
        timer += Time.deltaTime;
    }

    void changeDirection()
    {
        if (Input.GetKey(KeyCode.W))
        {
            direction = DirectionEnum.UP;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction = DirectionEnum.DOWN;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction = DirectionEnum.LEFT;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction = DirectionEnum.RIGHT;
        }
    }

    void setDestination()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            destiny = ray.origin;
        }
    }
}
