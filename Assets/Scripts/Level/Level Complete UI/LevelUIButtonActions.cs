using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIButtonActions : MonoBehaviour
{
    public void ResetLevel()
    {
        SceneManager.LoadScene(GetCurrentScene());
    }

    private int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex; ;
    }
}
