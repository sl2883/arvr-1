using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOneToTwo : MonoBehaviour
{
    [SerializeField]
    public GameObject rightObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkForDeath();
    }

    private void checkForDeath()
    {
        if (gameObject.transform.position.z < rightObj.transform.position.z - 20)
        {
            StartCoroutine(EndGame());

        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(1);
    }
}
