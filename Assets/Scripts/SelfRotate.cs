using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    //A bool to show if the elevator switch has been collided with the ball
    bool alreadyCollided;

    //A float number to tweak the movement speed of the elevators in the editor
    [SerializeField]
    float rotateTrophy = 20f;

    public float xAngle, yAngle, zAngle;

    // Start is called before the first frame update
    void Start()
    {
        alreadyCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();

        if (alreadyCollided)
        {
            //TODO When the collision with the ball has happened on the switch, call MoveUp() for each elevator in the elevators array.
            

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")
            || other.gameObject.CompareTag("PlatformD"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")
            || collision.gameObject.CompareTag("PlatformD"))
        {
            gameObject.SetActive(false);
        }
    }
 
    
    void Rotate()
    {
        
        transform.Rotate(rotateTrophy * Time.deltaTime, rotateTrophy * Time.deltaTime, rotateTrophy * Time.deltaTime, Space.Self);
        
        /*
        Quaternion targetRotation = Quaternion.AngleAxis(50, Vector3.back);
        var step = Time.deltaTime * rotateTrophy;
        transformS.rotation = Quaternion.RotateTowards(transformS.rotation, targetRotation, step);
        */

    }
}
