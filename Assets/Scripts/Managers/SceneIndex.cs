using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneIndex : Singleton<SceneIndex>
{
    private void Start()
    {
        StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(0.5f);
        // SceneManager.LoadScene(PlayerPreferences.PlayerCurrentLevel);
        SceneManager.LoadScene((int)Constants.GameScenesIndex.Level06);
    }
}
