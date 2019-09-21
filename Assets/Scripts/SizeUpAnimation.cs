using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUpAnimation : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.Lerp(Vector3.up, transform.localScale, Time.deltaTime * 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
