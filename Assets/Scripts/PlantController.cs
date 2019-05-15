using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SwipeManager))]
public class PlantController : MonoBehaviour
{
    public GameObject TailPrefab;
    public float Speed = 1f;
    public float MovementGrid = 0.5f;
    public int MaxGrowTicks = 10;
    public int Level = 1;

    public static bool IsReady = false;

    private int _growTicks = 10;
    private float _timer = 0;
    Vector3 _directionVector3 = Vector3.up;
    private Vector3 _directionVector3last = Vector3.zero;
    private Head _head;
    private List<GameObject> _tailList = new List<GameObject>();

    public int GrowTicks
    {
        get => _growTicks;
        set => _growTicks = value > MaxGrowTicks ? MaxGrowTicks : value;
    }

    // Start is called before the first frame update
    void Start()
    {
        IsReady = Level != 1;
        _growTicks = MaxGrowTicks;
        _head = GetComponentInChildren<Head>();
        SwipeManager swipeManager = GetComponent<SwipeManager>();
        SwipeManager.OnSwipeDetected += HandleSwipe;
    }

    void HandleSwipe(Swipe swipe, Vector2 swipeVelocity)
    {
        _directionVector3last = _directionVector3;

        switch (swipe)
        {
            case Swipe.None:
                break;
            case Swipe.Up:
                if (_directionVector3last != Vector3.down)
                    _directionVector3 = Vector3.up;
                break;
            case Swipe.Down:
                if (_directionVector3last != Vector3.up)
                    _directionVector3 = Vector3.down;
                break;
            case Swipe.Left:
                if (_directionVector3last != Vector3.right)
                    _directionVector3 = Vector3.left;
                break;
            case Swipe.Right:
                if (_directionVector3last != Vector3.left)
                    _directionVector3 = Vector3.right;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsReady)
        {
            EnergyBar.Energy = _growTicks;
            EnergyBar.MaxEnergy = MaxGrowTicks;
            //GetInputVector();

            if (_timer > Speed)
            {
                _timer = 0;
                Vector3 lastHeadPos = _head.transform.position;
                if (_growTicks > 0)
                {
                    MovePlant();
                    SpawnTailObject(lastHeadPos);
                    _growTicks--;
                }
                else
                {
                    FindObjectOfType<GameController>().GameOver();
                }
            }

            _timer += Time.deltaTime;
            ManageLevels();
        }
    }

    private void ManageLevels()
    {
        if (_head.transform.position.y > 4.5f)
        {
            Level++;
            if (Level > 3)
            {
                SceneManager.LoadScene("Victory");
            }
            else
            {
                Debug.Log(Level);
                SceneManager.LoadScene("Level" + Level);
            }
        }
    }

    private void SpawnTailObject(Vector3 pos)
    {
        GameObject tailGameObject = Instantiate(TailPrefab, transform);
        tailGameObject.transform.position = pos;

        _tailList.Add(tailGameObject);
    }

    private void MovePlant()
    {
        _head.transform.up = _directionVector3;
        _head.transform.position += _directionVector3 * MovementGrid;
    }

    private void GetInputVector()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _directionVector3 = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _directionVector3 = Vector3.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _directionVector3 = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _directionVector3 = Vector3.right;
        }
    }
}
