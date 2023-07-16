using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float limitValue = 2f, speed = 0.2f;     // limitValue to move within a block(in game), speed - player speed
    private bool startGame = false;
    [SerializeField] private GameObject warpEffect;     // "warp" effect when game starts
    [SerializeField] private GameObject startImage;     // Image from Canvas
    [SerializeField] private GameObject startText;      // Text "HOLD TO MOVE" from Canvas
    [SerializeField] private GameObject restartButton;  // Restart button from Canvas
    private void Start()        // Disabling some objects before game starts
    {
        warpEffect.SetActive(false);
        restartButton.SetActive(false);
    }
    private void Update()
    {
        if (Input.anyKeyDown)       // For PC
        {
            startGame = true;
            warpEffect.SetActive(true);
            startImage.SetActive(false);
            startText.SetActive(false);
        }
        else if (Input.touchCount > 0)      // For Android/IOS
        {
            startGame = true;
            warpEffect.SetActive(true);
            startImage.SetActive(false);
            startText.SetActive(false);
        }
        if (startGame)
        {
            transform.Translate(new Vector3(0, 0, -speed));     // Static speed for player
            if (Input.GetMouseButton(0))
            {
                Move();
            }
        }

    }
    private void OnCollisionEnter(Collision other)      // For "GAME OVER"
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            restartButton.SetActive(true);
        }
        else if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            restartButton.SetActive(true);
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
