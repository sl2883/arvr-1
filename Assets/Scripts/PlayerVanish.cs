using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVanish : MonoBehaviour
{

    [SerializeField]
    public GameObject playerCube;

    private IEnumerator coroutine;

    private Collision collisionG;

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
        gameObject.GetComponent<SphereCollider>().isTrigger = true;
        
        collisionG = collision;
        collision.gameObject.GetComponent<Renderer>().enabled = false;
        coroutine = ChangeToSphere(1f);
        StartCoroutine(coroutine);
    }

    private void startNewPlayer()
    {

    }

    IEnumerator ChangeToSphere(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        collisionG.gameObject.GetComponent<Renderer>().enabled = true;
        // Clears all the data that the mesh currently has
        playerCube.GetComponent<MeshFilter>().mesh = gameObject.GetComponent<MeshFilter>().mesh;
        playerCube.GetComponent<BoxCollider>().enabled = false;
        playerCube.GetComponent<SphereCollider>().enabled = true;
    }


}
