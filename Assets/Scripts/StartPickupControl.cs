using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPickupControl : MonoBehaviour
{
    public float limitValue = 2f, speed = 0.2f;     // limitValue to move within a block(in game), speed - point(cube) speed
    private bool startGame = false;
    private void Update()
    {
        if (Input.anyKeyDown)       // For PC
        {
            startGame = true;
        }
        else if (Input.touchCount > 0)      // For Android/IOS
        {
            startGame = true;
        }
        if (startGame)
        {
            transform.Translate(new Vector3(0, 0, speed));      // Static speed for point(cube)
            if (Input.GetMouseButton(0))
            {
                Move();
            }
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Wall")
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;        // Enable full-fledged Rigidbody to current object

            Destroy(gameObject.GetComponent<StartPickupControl>());

            Destroy(gameObject, 5);
        }  
    }
    private void Move()
    {
        float halfScreen = Screen.width / 2;
        float xPos = (Input.mousePosition.x - halfScreen) / halfScreen;     // xPos has limits from -1 to 1
        float finalPos = xPos * limitValue;

        transform.localPosition = new Vector3(finalPos, transform.position.y, transform.position.z);
    }
}
