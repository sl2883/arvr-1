using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEActivities : MonoBehaviour
{

    [SerializeField]
    public GameObject platformD;

    private bool scaleSet;
    private bool moveStarted;
    private bool rotationStarted;
    private bool scaleStarted;

    private Vector3 newScale;

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

        if (scaleStarted)
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
        if (hit.collider.gameObject.name == "PointEUI"
            || hit.collider.gameObject.name == "TrophyCube"
            || hit.collider.gameObject.name == "PointEUI_Text"
            )
        {
            moveStarted = true;
            rotationStarted = true;
            scaleStarted = true;
        }
    }

    void RotateAround()
    {
        
    }

    void MoveAround()
    {

        Vector3 oldPos = platformD.transform.position;
        Vector3 newPos = new Vector3(7.7f, 4.4f, 7.65f);

        if (platformD.transform.position == newPos)
        {
            moveStarted = false;
            return;
        }

        platformD.transform.position = Vector3.MoveTowards(oldPos, newPos, Time.deltaTime * movementSmooth);

    }

    void ScaleAround()
    {
        Transform transformS = platformD.gameObject.transform;

        float x = 2.0f;
        float y = 0.47f;
        float z = 2.3f;

        if (!scaleSet)
        {
            newScale = new Vector3(x, y, z);
            scaleSet = true;
        }


        if (transformS.localScale == newScale)
        {
            scaleStarted = false;
            return;
        }

        //transformS.localScale = newScale;

    }

}
