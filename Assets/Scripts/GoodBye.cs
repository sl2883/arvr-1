using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBye : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(1);
    }
}
