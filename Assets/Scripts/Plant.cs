
using UnityEngine;
using System;

public class Plant : MonoBehaviour
{
    public Sun sun;
    private Vector3 scaling;
    private Vector3 offset;
    bool collision;

	void Start ()
    {
        
        scaling = transform.localScale;
        offset = transform.position;
        transform.rotation = new Quaternion(transform.rotation.x + countRotation()/2, transform.rotation.y, transform.rotation.z, transform.rotation.w);
	}
	

	void Update ()
    {
        //Vector3 targetPosFlattened = new Vector3(sun.transform.position.x, sun.transform.position.y, 0);
        //transform.LookAt(targetPosFlattened);
        grow();

    }

    void grow()
    {
        if (!collision)
        {
            scaling.y += 1f * Time.deltaTime;
            transform.localScale = new Vector3(scaling.x, scaling.y, scaling.z);
        }
        else
        {

        }
    }

    float countRotation()
    {
        double x, y;
        x = transform.position.x - sun.transform.position.x;
        y = transform.position.y - sun.transform.position.y;
        return (float)Math.Atan(x/y);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Sun")
        {
            collision = true;
            Debug.Log("Collision");
        }

    }
}
