using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    //To load a level additively, use this method
    public IEnumerator LoadLevelAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    public void LoadLevel(string LevelName) 
    {
        SceneManager.LoadSceneAsync(LevelName, LoadSceneMode.Additive);
    }

    //To unload a level, use this method
    public void UnloadLevel(string LevelName)
    {
        SceneManager.UnloadSceneAsync(LevelName);
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
