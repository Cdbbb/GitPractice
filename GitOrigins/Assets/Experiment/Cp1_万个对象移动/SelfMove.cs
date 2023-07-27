using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMove : MonoBehaviour
{
    public float amplitude = 1f;  // 正弦振幅
    public float speed = 1f;      // 移动速度
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        DoSin(transform);
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
}
