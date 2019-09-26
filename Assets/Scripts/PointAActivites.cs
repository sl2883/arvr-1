using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAActivites : MonoBehaviour
{

    private bool alreadyCollided;
    private bool rotateStarted;
    private float rotationSmooth = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        alreadyCollided = false;
        rotateStarted = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO Check if the collision object has a tag of "Ball", if so then set the boolean isColliding to true
        if (collision.gameObject.name == "PlayerCube")
        {
            alreadyCollided = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rotateStarted)
        {
            Rotate();
        }

        if (alreadyCollided && Input.GetMouseButtonUp(0))
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
        if (hit.collider.gameObject.name == "PointAWall1"
           || hit.collider.gameObject.name == "PointAWall2"
           || hit.collider.gameObject.name == "PointAWall3"
           || hit.collider.gameObject.name == "PointAPlatform")
        {
            rotateStarted = true;
        }
    }

    void Rotate()
    {
        Transform transformS = gameObject.transform;
        //Quaternion targetRotation = Quaternion.AngleAxis(-35, new Vector3(1, 0, 0));
        Quaternion targetRotation = Quaternion.Euler(new Vector3(35, 90, 0));
        var step = Time.deltaTime * rotationSmooth;
        transformS.rotation = Quaternion.RotateTowards(transformS.rotation, targetRotation, step);

    }
}
