using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManulLog : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        Application.logMessageReceived += HandleLog;
        
    }

    // Update is called once per frame
    void Update()
    {
        var sprite = spriteRenderer.sprite;
        
        Debug.Log(sprite.rect.width +"     "+sprite.rect.height);
    }

    void HandleLog(string logstring,string stackTrace,LogType type )
    {
        tmp.text += logstring;
        Debug.Log(logstring);
    }
}
