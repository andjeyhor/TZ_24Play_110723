using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveActivePickup : MonoBehaviour
{
    private float limitValue = 2f, speed = 0.2f;     // limitValue to move within a block(in game), speed - point(cube) speed
    private void Update()
    {
        transform.Translate(new Vector3(0, 0, speed));      // Static speed for point(cube)
        if (Input.GetMouseButton(0))
        {
            Move();
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
