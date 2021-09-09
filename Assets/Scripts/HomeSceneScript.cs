using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneScript : MonoBehaviour
{
    public LevelObj levelObj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnLevelButtonPressed(int levelID)
    {
        Debug.Log("Start level" + levelID.ToString());
        StartLevel(levelID);
    }

    private void StartLevel(int levelID)
    {
        //Set intermediary level id so other scene can know which level to load
        levelObj.SetToStartLevelID(levelID);
        //Load other scene
        SceneManager.LoadScene(1);
    
    }

}
