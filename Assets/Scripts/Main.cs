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
    //private List<GameObject> mLoadedObjects;  //�S���n�ü�Unload�귽���ҥH���ݭn
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
        Object o = rm.LoadGameObject2(sPathName);   //�q�귽�޲z��Ū�X����
        objectPool.InitData1(o, 10);    //���L�b�귽���ͦ��Q��
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = objectPool.LoadData1();
            if (go != null)
            {
                go.transform.position = new Vector3(-15.0f, 2.0f, -15.0f);      //�]�m��l��m
                go.SetActive(true);     //��ܪ���
                //mLoadedObjects.Add(go);
                go.GetComponent<CubeMove>().InitCallBack(LoadedObjectFinish);   //���UCallBack�H�K�b�i�J���I��Trigger�ɱq�귽��Unload
            }
        }

    }
    
    
    void LoadedObjectFinish(GameObject go)
    {
        objectPool.UnLoadData1(go);
    }
}
