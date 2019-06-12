using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    public void Start()
    {
    }

    public void NextLevel()
    {
        if (GameManager.Pickups >= GameManager.MaxPickups / 2)
            SceneManager.LoadScene("Level" + GameManager.Level);
        else
        {
            GetComponent<Button>().enabled = false;
            GetComponentInChildren<Text>().text = "Next level locked";
        }
    }

    public void Retry()
    {
        int level = GameManager.Level - 1;
        SceneManager.LoadScene("Level" + level);
    }

}
