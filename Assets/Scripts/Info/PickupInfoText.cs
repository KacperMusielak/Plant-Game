using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PickupInfoText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponent<Text>();
        text.text = GameManager.Pickups + " / " + GameManager.MaxPickups;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
