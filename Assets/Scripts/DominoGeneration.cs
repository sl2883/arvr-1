using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoGeneration : MonoBehaviour
{
    private IEnumerator coroutine;

    bool alreadyCollided;

    [SerializeField]
    public GameObject dominoPrefab;

    [SerializeField]
    public GameObject dominos;

    [SerializeField]
    public int dominosCount = 5;

    private int dominosGeneratedCount;

    // Start is called before the first frame update
    void Start()
    {
        dominosGeneratedCount = 0;
    }

    private void Update()
    {
        if (alreadyCollided)
        {
            //TODO When the collision with the ball has happened on the switch, call MoveUp() for each elevator in the elevators array.
            coroutine = GenerateDominos(0.25f);
            StartCoroutine(coroutine);

            alreadyCollided = false;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO Check if the collision object has a tag of "Ball", if so then set the boolean isColliding to true
        if (collision.gameObject.CompareTag("Ball"))
        {
            alreadyCollided = true;
        }
    }



    IEnumerator GenerateDominos(float waitTime)
    {
        
        GameObject clone;

        while (dominosGeneratedCount < dominosCount)
        {
            yield return new WaitForSeconds(waitTime);

            clone = Instantiate(dominoPrefab);


            Vector3 oldPos = new Vector3(clone.transform.position.x
                                                , -3.0f 
                                                , clone.transform.position.z - 1.0f * dominosGeneratedCount);

            Vector3 newPos = new Vector3(clone.transform.position.x
                                                , clone.transform.position.y
                                                , clone.transform.position.z - 1.5f * dominosGeneratedCount);

            clone.transform.position = Vector3.Lerp(oldPos, newPos, Time.deltaTime * 2.0f);

            dominosGeneratedCount++;
        }
    }
}
