using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Pools : MonoBehaviour
{
    public GameObject prefab;
    public GameObject parent;
    public int row;

    public int col;

    public float spaceX;

    public float spaceZ;

    public List<GameObject> thisPool;

    public bool ifMove;
    public bool ifRotate;
    
    public float amplitude = 1f;  // 正弦振幅
    public float speed = 1f;      // 移动速度

    public float RotateSpeed = 1f;

    [Space(20), Header("FrameCPUTest")] 
    public bool ifFrameTest;
    public int FramePerTime=100;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (parent)
                {
                    thisPool.Add(Instantiate(prefab, pos, Quaternion.identity,parent.transform));
                }
                else
                {
                    thisPool.Add(Instantiate(prefab, pos, Quaternion.identity));
                }

                
                pos.x += spaceX;
            }

            pos.x = 0;
            pos.z += spaceZ;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ifMove)
        {
            foreach (var VARIABLE in thisPool)
            {
                DoSin(VARIABLE.transform);
            }
        }

        if (ifRotate)
        {
            foreach (var VARIABLE in thisPool)
            {
                DoRotate(VARIABLE.transform);
            }
        }

        if (ifFrameTest)
        {
            FrameStressTesting(transform);
        }
    }

    void DoSin(Transform transform)
    {
        float startY = transform.position.y;
        float yOffset = Mathf.Sin(Time.time * speed) * amplitude;
        
        // 更新物体位置
        Vector3 newPosition = transform.position;
        newPosition.y = startY + yOffset;
        transform.position = newPosition;
    }

    void DoRotate(Transform transform)
    {
        
        transform.Rotate(Vector3.up,Time.deltaTime * RotateSpeed);
    }

    void FrameStressTesting(Transform transform)
    {
        for (int i = 0; i < FramePerTime; i++)
        {
            Profiler.BeginSample("logic");
            GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();
            // transform.Rotate(Vector3.up,Time.deltaTime * RotateSpeed);
            // if(prefab==parent){}
            Profiler.EndSample();
        }
        
    }
    
    
}
