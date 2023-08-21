using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
   public void Exit()
   {
        SceneManager.LoadScene(0);
   }

    public void LevelEasy()
    {
        SceneManager.LoadScene(2);
    }

    public void Levelmedium()
    {
        SceneManager.LoadScene(3);
    }

    public void LevelHard()
    {
        SceneManager.LoadScene(4);
    }
}
