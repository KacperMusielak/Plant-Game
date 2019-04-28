using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Head : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Pickup")
        {
            FindObjectOfType<PlantController>().GrowTicks += collider.gameObject.GetComponent<Pickup>().Charges;
            Destroy(collider.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log(collision.gameObject.tag);
            FindObjectOfType<GameController>().GameOver();
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.gameObject.tag);
            FindObjectOfType<GameController>().GameOver();
        }
    }
}
