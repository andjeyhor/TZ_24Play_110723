using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Generating : MonoBehaviour
{
    [SerializeField] GameObject[] blockPrefabs = new GameObject[4];     // Blocks for spawning
    private TMP_Text incrementText;      // Text that shows "score"

    private int distance = 250;     // Distance between blocks = 60. It's coord Z for new block
    private void Start()
    {
        incrementText = GameObject.Find("Increment").GetComponent<TMP_Text>();  
        StartCoroutine(GenerateNextBlock());        
    }   

    IEnumerator GenerateNextBlock()
    {
        while (true)
        {
            incrementText.text = " ";        // Clean text, that shows "score"

            int index = Random.Range(0, 4);

            distance += 60;

            Instantiate(blockPrefabs[index], new Vector3(
                0, 0, distance), Quaternion.identity
            );

            yield return new WaitForSeconds(3f);
        }
    }
}
