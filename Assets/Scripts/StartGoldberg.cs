using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGoldberg : MonoBehaviour
{
    private Camera cameraC;

    [SerializeField]
    public TextMeshProUGUI textBox;

    public string standByText = "Click Here";
    public string startedText = "Good Luck, Sunny!";

    // Start is called before the first frame update
    void Start()
    {
        cameraC = Camera.main;
        textBox.text = standByText;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                textBox.text = startedText;
                Interact(hit);
                
            }


            Debug.Log("Pressed left click.");
        }

    }

    void Interact(RaycastHit hit) 
    {
        Debug.Log("Hiting " + hit.collider.name);
        if(hit.collider.name == "StartPlatform")
        {
            gameObject.SetActive(false);
        }
    }
}
