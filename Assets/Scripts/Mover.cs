using UnityEngine;

public class Mover : MonoBehaviour
{
    public float MoveTime = 1f;
    public float StopTime = 1.5f;
    public Vector3 Offset = Vector3.left;
    public bool IsStopped = true;
    public bool IsReverse = false;

    private float _timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (IsStopped)
        {
            if (_timer > StopTime)
            {
                _timer = 0;
                IsStopped = false;
            }
        }
        else
        {
            if (_timer < MoveTime)
            {
                if (IsReverse)
                {
                    transform.position -= Offset * Time.deltaTime / MoveTime;
                }
                else
                {
                    transform.position += Offset * Time.deltaTime / MoveTime;
                }
                
            }
            else
            {
                IsReverse = !IsReverse;
                _timer = 0;
                IsStopped = true;
            }
        }
        
    }
}
