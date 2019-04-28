using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text Charges;

    private PlantController plantController;
    // Start is called before the first frame update
    private void Start()
    {
        Charges = FindObjectOfType<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (plantController == null)
        {
            plantController = FindObjectOfType<PlantController>();
        }
            Charges.text = plantController.GrowTicks.ToString("D");
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
