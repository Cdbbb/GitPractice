using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    // 声明一个事件委托类型，用于定义事件的回调函数签名
    public delegate void MyEventHandler(string message);
    
    // 声明一个静态事件，使用上面定义的委托类型作为事件类型
    public static event MyEventHandler OnMyEvent;

     //用于触发事件的方法------事件是基于委托类型的
    public static void TriggerEvent(string message)
    {
        // 触发事件，通知所有订阅者
        if (OnMyEvent != null)
        {
            OnMyEvent(message);
            OnMyEvent.Invoke("这是个弯钩");
        }
    }
}
