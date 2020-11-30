using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCreator : MonoBehaviour
{
    public GameObject pref;
    public int capsuleCount;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < capsuleCount; i++)
        {
            Instantiate(pref);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
