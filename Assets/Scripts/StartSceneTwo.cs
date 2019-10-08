using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneTwo : MonoBehaviour
{
    private Camera cameraC;

    [SerializeField]
    public GameObject messageBox;

    [SerializeField]
    public GameObject startMessage;

    [SerializeField]
    public GameObject cameraOne;
    [SerializeField]
    public GameObject cameraTwo;
    [SerializeField]
    public GameObject cameraThree;
    [SerializeField]
    public GameObject cameraFour;
    [SerializeField]
    public int startCamera = 0;

    private int prevCamera;

    [SerializeField]
    public GameObject lowestObj;

    // Start is called before the first frame update
    void Start()
    {
        cameraC = Camera.main;

        prevCamera = startCamera;
        //Camera Position Set
        setDefaultCamera(prevCamera);

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

        switchCamera();
        checkForDeath();
    }

    void Interact(RaycastHit hit)
    {
        Debug.Log("Hiting " + hit.collider.name);
        if (hit.collider.name == "PlayerCube")
        {
            startMessage.SetActive(false);
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

    private void checkForDeath()
    {
        if (gameObject.transform.position.y < lowestObj.transform.position.y - 30)
        {
            StartCoroutine(EndGame());
            
        }
    }

    private IEnumerator EndGame()
    {
        messageBox.SetActive(true);
        yield return new WaitForSeconds(2);
        messageBox.SetActive(false);
        SceneManager.LoadSceneAsync(1);
        
    }

    //Change Camera Keyboard
    void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            setDefaultCamera(1);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            setDefaultCamera(2);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            setDefaultCamera(3);
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            setDefaultCamera(0);
        }
    }

    //Camera change Logic
    void setDefaultCamera(int camPosition)
    {
        if (camPosition == 0)
        {
            cameraOne.SetActive(true);
            cameraTwo.SetActive(false);
            cameraThree.SetActive(false);
            cameraFour.SetActive(false);
        }
        else if (camPosition == 1)
        {
            cameraOne.SetActive(false);
            cameraTwo.SetActive(true);
            cameraThree.SetActive(false);
            cameraFour.SetActive(false);
        }
        else if (camPosition == 2)
        {
            cameraOne.SetActive(false);
            cameraTwo.SetActive(false);
            cameraThree.SetActive(true);
            cameraFour.SetActive(false);
        }
        else if (camPosition == 3)
        {
            cameraOne.SetActive(false);
            cameraTwo.SetActive(false);
            cameraThree.SetActive(false);
            cameraFour.SetActive(true);
        }

        prevCamera = camPosition;

    }
}
