using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Head : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clang, pickup;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Pickup")
        {
            audioSource.PlayOneShot(pickup);
            FindObjectOfType<PlantController>().GrowTicks += collider.gameObject.GetComponent<Pickup>().Charges;
            FindObjectOfType<PlantController>().collectPickup();
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
        audioSource.PlayOneShot(clang);
    }

}
