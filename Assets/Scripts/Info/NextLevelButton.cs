using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("Level" + GameManager.Level);
    }

}
