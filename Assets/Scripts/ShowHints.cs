using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHints : MonoBehaviour
{
    private bool showHint;

    [SerializeField]
    public GameObject hintList;
    
    // Start is called before the first frame update
    void Start()
    {
        showHint = false;
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
        }
    }

    void Interact(RaycastHit hit)
    {
        if (hit.collider.gameObject.name == "HintOption"
           || hit.collider.gameObject.name == "HintList"
           || hit.collider.gameObject.name == "HintBox")
        {
            showHint = !showHint;
            manageHints();
        }
    }

    void manageHints()
    {
        hintList.SetActive(showHint);

    }
}
