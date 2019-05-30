using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("Level" + GameManager.Level);
    }

    public void Retry()
    {
        int level = GameManager.Level - 1;
        SceneManager.LoadScene("Level" + level);
    }

}
