using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    static private ResourceManager mInstance;
    static public ResourceManager Instance() { return mInstance; }

    private void Awake()
    {
        mInstance = this;
    }

    public GameObject LoadGameObject(string sPath)
    {
        GameObject go = null;
        Object o = Resources.Load(sPath);
        if (o == null)
        {
            return null;
        }
        go = Instantiate(o) as GameObject;
        return go;
    }
    public Object LoadGameObject2(string sPath) //傳回Object以便放入資源池且不實例化出來
    {
        Object o = Resources.Load(sPath);
        if (o == null)
        {
            return null;
        }
        //go = Instantiate(o) as GameObject;
        return o;
    }

    /*public IEnumerator LoadObjectAsync(string sPath,System.Action<Object> afterLoad)
    {
        ResourceRequest rr = Resources.LoadAsync(sPath);
        if (rr == null)
        {
            yield break;
        }
        if (rr.isDone && rr.asset != null)
        {
            afterLoad(rr.asset);
        }
    }*/
}
