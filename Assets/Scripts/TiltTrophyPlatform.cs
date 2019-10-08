using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltTrophyPlatform : MonoBehaviour
{
    //A bool to show if the elevator switch has been collided with the ball
    bool alreadyCollided;

    //A float number to tweak the movement speed of the elevators in the editor
    [SerializeField]
    float rotationSmooth = 50f;

    // Start is called before the first frame update
    void Start()
    {
        alreadyCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (alreadyCollided)
        {
            //TODO When the collision with the ball has happened on the switch, call MoveUp() for each elevator in the elevators array.
            Rotate();

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

    void Rotate()
    {
        Transform transformS = gameObject.transform;
        Quaternion targetRotation = Quaternion.AngleAxis(13, Vector3.left);

        var step = Time.deltaTime * rotationSmooth;
        transformS.rotation = Quaternion.RotateTowards(transformS.rotation, targetRotation, step);

    }
}
