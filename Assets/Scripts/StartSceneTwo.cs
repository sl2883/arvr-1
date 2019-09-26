using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneTwo : MonoBehaviour
{
    private Camera cameraC;

    // Start is called before the first frame update
    void Start()
    {
        cameraC = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Interact(hit);

            }


            Debug.Log("Pressed left click.");
        }
    }

    void Interact(RaycastHit hit)
    {
        Debug.Log("Hiting " + hit.collider.name);
        if (hit.collider.name == "PlayerCube")
        {
            hit.collider.gameObject.AddComponent<Rigidbody>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
