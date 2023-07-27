using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breadcaster : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        // 在Start方法中订阅事件
        EventManager.OnMyEvent += HandleEvent;
    }

    private void OnDestroy()
    {
        // 在对象销毁时取消订阅事件，避免内存泄漏
        EventManager.OnMyEvent -= HandleEvent;
    }

    // 事件处理方法
    private void HandleEvent(string message)
    {
        Debug.Log("Received message: " + message);
    }

    // 在某个条件下触发事件的方法
    public void TriggerMyEvent()
    {
        EventManager.TriggerEvent("Hello, subscribers!");
    }
}
