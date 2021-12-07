using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public Transform[] points;
    private int target;
    System.Action<GameObject> ArriveEnd;
    // Start is called before the first frame update
    void Start()
    {
        points = new Transform[3];
        points[0] = GameObject.Find("point0").transform; 
        points[1] = GameObject.Find("point1").transform;
        points[2] = GameObject.Find("point2").transform;
        target = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vMove = Vector3.zero;
        
        
        if (target < points.Length)
        {
            Vector3 pointPos = points[target].position;
            Vector3 currentPos = transform.position;
            Vector3 vec = pointPos - currentPos;
            vec.y = 0.0f;
            transform.forward = vec;
            float vDist = vec.magnitude;
            vMove = transform.forward * 10 * Time.deltaTime;
            transform.position += vMove;
            if (vDist < 1.0f)
            {
                target++;
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2.0f);
    }
    public void InitCallBack(System.Action<GameObject> ArriveEnd)
    {
        this.ArriveEnd = ArriveEnd;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "endPoint")
        {
            ArriveEnd(gameObject);
            target = 0;
        }
    }

}
