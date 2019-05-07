using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantController : MonoBehaviour
{
    public GameObject TailPrefab;
    public float Speed = 1f;
    public float MovementGrid = 0.5f;
    public int MaxGrowTicks = 10;
    public int Level = 1;

    private int _growTicks = 10;
    private float _timer = 0;
    Vector3 _directionVector3 = Vector3.up;
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
        _growTicks = MaxGrowTicks;
        _head = GetComponentInChildren<Head>();
    }

    // Update is called once per frame
    void Update()
    {
        EnergyBar.Energy = _growTicks;
        EnergyBar.MaxEnergy = MaxGrowTicks;
        GetInputVector();

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
        }
        _timer += Time.deltaTime;

        if (_head.transform.position.y > 4.2f)
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
