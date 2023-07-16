using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionForActivePickup : MonoBehaviour
{
    private Rigidbody rig;      // Component Rigidbody from current GameObject
    private GameObject player;
    private Rigidbody playerRig;
    public TMP_Text incrementText;       // Text, that shows "score"

    private void Start()
    {
        rig = gameObject.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            rig.constraints = RigidbodyConstraints.None;        // Enable full-fledged Rigidbody to current object

            if (gameObject.GetComponent<MoveActivePickup>())
            {
                Destroy(gameObject.GetComponent<MoveActivePickup>());
            }
            if (gameObject.GetComponent<CollisionForActivePickup>())
            {
                Destroy(gameObject.GetComponent<CollisionForActivePickup>());
            }

            Destroy(gameObject, 5);
        }
        if (other.gameObject.tag == "Pickup")
        {
            if(GameObject.FindGameObjectWithTag("Player"))
                playerRig = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
            player = GameObject.FindGameObjectWithTag("Player");
            incrementText = GameObject.Find("Increment").GetComponent<TMP_Text>();

            Vector3 newPosPlayer = player.transform.position;       // New position for player
            newPosPlayer.y += 1;
            player.transform.position = newPosPlayer;

            other.gameObject.tag = "Untagged";

            Transform posPoint = other.transform;       // Position for current point(cube)
            posPoint.SetParent(player.transform);
            posPoint.localPosition = new Vector3(0, -1, 0);
            posPoint.SetParent(null);

            other.gameObject.AddComponent<CollisionForActivePickup>();
            other.gameObject.AddComponent<MoveActivePickup>();

            incrementText.text = "+1";
        }
    }
}
