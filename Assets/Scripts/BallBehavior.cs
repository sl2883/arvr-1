using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBehavior : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        //TODO When entering a Collider, set that object inactive if it has a tag called "PickUp"
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
