using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBActivities : MonoBehaviour
{

    [SerializeField]
    public GameObject bridge;

    private bool moveStarted;
    private bool rotationStarted;

    private float rotationSmooth = 10.0f;

    float movementSmooth = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        moveStarted = false;
        rotationStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(rotationStarted)
        {
            RotateAround();
        }

        if(moveStarted)
        {
            MoveAround();
        }

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
        if (hit.collider.gameObject.name == "PointBWall1"
            || hit.collider.gameObject.name == "PointBWall2"
            || hit.collider.gameObject.name == "PointBWall3"
            || hit.collider.gameObject.name == "PointBPlatform")
        {
            moveStarted = true;
            rotationStarted = true;
        }
    }

    void RotateAround()
    {
        Transform transformS = bridge.gameObject.transform;
        //Quaternion targetRotation = Quaternion.AngleAxis(-35, new Vector3(1, 0, 0));
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 30, -10));
        var step = Time.deltaTime * rotationSmooth;

        if(transformS.rotation == targetRotation)
        {
            rotationStarted = false;
            return;
        }

        transformS.rotation = Quaternion.RotateTowards(transformS.rotation, targetRotation, step);
    }

    void MoveAround()
    {
        
        Vector3 oldPos = transform.position;
        Vector3 newPos = new Vector3(19.35f, -9, -8.5f);

        if (transform.position == newPos)
        {
            moveStarted = false;
            return;
        }

        transform.position = Vector3.Lerp(oldPos, newPos, Time.deltaTime * movementSmooth);
      
    }

}
