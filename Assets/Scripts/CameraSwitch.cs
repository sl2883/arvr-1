using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
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

    // Use this for initialization
    void Start()
    {
        prevCamera = startCamera;
        //Camera Position Set
        setDefaultCamera(prevCamera);
    }

    void Update()
    {
        //Change Camera Keyboard
        switchCamera();
    }

    //Change Camera Keyboard
    void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            setDefaultCamera(1);
        }
        else if(Input.GetKeyDown(KeyCode.Y))
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
