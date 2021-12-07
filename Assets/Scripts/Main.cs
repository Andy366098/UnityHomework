using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static private Main mInstance;
    static public Main Instance() { return mInstance; }

    ResourceManager rm;
    ObjectPool objectPool;
    //private List<GameObject> mLoadedObjects;  //沒有要亂數Unload資源池所以不需要
    string sPathName = "Cube";
    private void Awake()
    {
        mInstance = this;
        objectPool = new ObjectPool();
    }
    // Start is called before the first frame update
    void Start()
    {
        rm = ResourceManager.Instance();
        //mLoadedObjects = new List<GameObject>();
        Object o = rm.LoadGameObject2(sPathName);   //從資源管理器讀出物件
        objectPool.InitData1(o, 10);    //讓他在資源池生成十個
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = objectPool.LoadData1();
            if (go != null)
            {
                go.transform.position = new Vector3(-15.0f, 2.0f, -15.0f);      //設置初始位置
                go.SetActive(true);     //顯示物件
                //mLoadedObjects.Add(go);
                go.GetComponent<CubeMove>().InitCallBack(LoadedObjectFinish);   //註冊CallBack以便在進入終點的Trigger時從資源池Unload
            }
        }

    }
    
    
    void LoadedObjectFinish(GameObject go)
    {
        objectPool.UnLoadData1(go);
    }
}
