using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ManyEvent : MonoBehaviour
{
    public UnityEvent WriteName;
    public Action SayJJ;
    public Func<string,string> a;

    public string WhatToSay;

    Button myButton;
    // Start is called before the first frame update
    private void Start()
    {
        myButton = GameObject.Find("Button").GetComponent<Button>();
        myButton.onClick.AddListener(trrigerThis);

        WriteName.AddListener(()=> { Debug.Log("已经调用"); });

        SayJJ += (  ) => { Debug.Log("我说唧唧啊！"); };

        a += retString;

    }

    void trrigerThis()
    {
        SayJJ.Invoke();
        WriteName.Invoke();
        a.Invoke(WhatToSay);

        CheckButtonEvents();
    }

    string retString(string Wats)
    {
        Debug.Log(Wats);
        return Wats;
    }

    private void CheckButtonEvents()
    {
        if (myButton != null)
        {
            // 获取按钮的 UnityEvent
            UnityEvent buttonEvent = myButton.onClick;

            // 获取事件处理函数的数量
            int eventCount = buttonEvent.GetPersistentEventCount();

            Debug.Log("Button Event Count: " + eventCount);

            // 遍历按钮的事件处理函数
            for (int i = 0; i < eventCount; i++)
            {
                // 获取事件处理函数名称
                string methodName = buttonEvent.GetPersistentMethodName(i);
                Debug.Log("Event " + (i + 1) + " Method: " + methodName);
            }
        }
        else
        {
            Debug.Log("Button component not found.");
        }
    }
}
