using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSceneManager
{
    static private CSceneManager mInstance;
    static public CSceneManager Instance() { return mInstance; }
    public CSceneManager()
    {
        mInstance = this;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public string GetCurrentSceneName()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene == null)
            return "";
        else
            return scene.name;
    }
}
