using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ss : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;

    public List<GameObject> objs;

    public int mounts;
    // Update is called once per frame
    void Update()
    { 
        if(objs.Count<mounts)
        {
            GameObject one = Instantiate(prefab,gameObject.transform);
            GameObject two = Instantiate(prefab,gameObject.transform);
            objs.Add(one);
            objs.Add(two);
        }
        
    }
}
