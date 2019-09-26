using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDActivities : MonoBehaviour
{
    [SerializeField]
    public GameObject platformC;

    [SerializeField]
    public GameObject platformB;

    private bool scaleSet;
    private bool moveStarted;
    private bool rotationStarted;
    private bool scaleStarted;

    private Vector3 newScale;

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
        if (rotationStarted)
        {
            RotateAround();
        }

        if (moveStarted)
        {
            MoveAround();
        }

        if(scaleStarted)
        {
            ScaleAround();
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
        if (hit.collider.gameObject.name == "PointDWall1"
            || hit.collider.gameObject.name == "PointDWall2"
            || hit.collider.gameObject.name == "PointDWall3"
            || hit.collider.gameObject.name == "PointDWall4"
            || hit.collider.gameObject.name == "PointDPlatform")
        {
            moveStarted = true;
            rotationStarted = true;
            scaleStarted = true;
        }
    }

    void RotateAround()
    {
        Transform transformS = platformC.gameObject.transform;
        //Quaternion targetRotation = Quaternion.AngleAxis(-35, new Vector3(1, 0, 0));
        Quaternion targetRotation = Quaternion.Euler(new Vector3(10, -180, 0));
        var step = Time.deltaTime * rotationSmooth;

        if (transformS.rotation == targetRotation)
        {
            rotationStarted = false;
            return;
        }

        transformS.rotation = Quaternion.RotateTowards(transformS.rotation, targetRotation, step);
    }

    void MoveAround()
    {

        Vector3 oldPos = platformB.transform.position;
        Vector3 newPos = new Vector3(19.35f, -9, -8.5f);

        if (platformB.transform.position == newPos)
        {
            moveStarted = false;
            return;
        }

        platformB.transform.position = Vector3.MoveTowards(oldPos, newPos, Time.deltaTime * movementSmooth);
        
    }

    void ScaleAround()
    {
        Transform transformS = gameObject.transform;

        float x = 2.9f;
        float y = 0.47f;
        float z = 4.3f;

        if(!scaleSet)
        {
            newScale = gameObject.transform.localScale + new Vector3(x, y, z);
            scaleSet = true;
        }
        

        if (transformS.localScale == newScale)
        {
            scaleStarted = false;
            return;
        }

        transformS.localScale = newScale;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
