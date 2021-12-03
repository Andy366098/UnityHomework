using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMain : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        CSceneManager cSceneManager = new CSceneManager();
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        CSceneManager.Instance().ChangeScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        CSceneManager m = CSceneManager.Instance();
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (m.GetCurrentSceneName().Equals("Menu"))
            {
                m.ChangeScene("MoveCubeScene");
            }else if (m.GetCurrentSceneName().Equals("MoveCubeScene"))
            {
                m.ChangeScene("Menu");
            }
        }
    }
}
