using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCActivities : MonoBehaviour
{
    [SerializeField]
    public GameObject bridge;

    [SerializeField]
    public GameObject platformB;

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
        if (rotationStarted)
        {
            RotateAround();
        }

        if (moveStarted)
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
        if (hit.collider.gameObject.name == "PointCWall1"
            || hit.collider.gameObject.name == "PointCWall2"
            || hit.collider.gameObject.name == "PointCWall3"
            || hit.collider.gameObject.name == "PointCPlatform")
        {
            moveStarted = true;
            rotationStarted = true;
        }
    }

    void RotateAround()
    {
        Transform transformS = bridge.gameObject.transform;
        //Quaternion targetRotation = Quaternion.AngleAxis(-35, new Vector3(1, 0, 0));
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
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
        Vector3 newPos = new Vector3(7.5f, -9, 8.23f);

        if (platformB.transform.position == newPos)
        {
            moveStarted = false;
            return;
        }

        //platformB.transform.position = Vector3.Lerp(oldPos, newPos, Time.deltaTime * movementSmooth);
        //platformB.GetComponent<Rigidbody>().MovePosition(newPos);
        platformB.transform.position = Vector3.MoveTowards(oldPos, newPos, Time.deltaTime * movementSmooth);
        //platformB.GetComponent<Rigidbody>().transform.position = Vector3.Lerp(oldPos, newPos, Time.deltaTime * movementSmooth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "PlayerCube")
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision colliision)
    {
        if (colliision.transform.tag == "PlayerCube")
        {
            colliision.transform.parent = null;
        }
    }


    /*
    void MoveAround()
    {

        Transform transformS = bridge.gameObject.transform;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        var step = Time.deltaTime * rotationSmooth;
        transformS.rotation = Quaternion.RotateTowards(transformS.rotation, targetRotation, step);

        Vector3 oldPos = platformB.transform.position;
        Vector3 newPos = new Vector3(19.35f, -22, -8.5f);
         platformB.transform.position = Vector3.MoveTowards(oldPos, newPos, Time.deltaTime * movementSmooth);
        //platformB.GetComponent<Rigidbody>().transform.position = Vector3.Lerp(oldPos, newPos, Time.deltaTime * movementSmooth);
        platformB.GetComponent<Rigidbody>().MovePosition(newPos);
          moveStarted = false;

    }

    private void FixedUpdate()
    {
        if (moveStarted)
        {
            MoveAround();
        }
    }
    */
}
