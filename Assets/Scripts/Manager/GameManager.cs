using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelManager levelManager;

    private void Start()
    {
        //Intialize the LevelManager
        levelManager = FindFirstObjectByType<LevelManager>();
        StartCoroutine(LoadSceneSequentially());
    }

    private IEnumerator LoadSceneSequentially() 
    {
        yield return levelManager.LoadLevelAsync("Room1");
        yield return levelManager.LoadLevelAsync("Main");
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
