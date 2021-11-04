using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneIndex : Singleton<SceneIndex>
{
    private void Start()
    {
        SceneManager.LoadScene(PlayerPreferences.PlayerCurrentLevel);
        // SceneManager.LoadScene((int)Constants.GameScenesIndex.Level04);
    }
}
