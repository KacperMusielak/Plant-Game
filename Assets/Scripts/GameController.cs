using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text Charges;
    public Text collectedPickups;

    private PlantController plantController;
    // Start is called before the first frame update
    private void Start()
    {
        Charges = FindObjectOfType<Text>();
        collectedPickups = GameObject.Find("CollectedPickups").GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (plantController == null)
        {
            plantController = FindObjectOfType<PlantController>();
        }
            //Charges.text = plantController.GrowTicks.ToString("D");
        collectedPickups.text = plantController.getCollectedPickups().ToString("D") + "/" + plantController.getMaxPickups().ToString("D");
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
