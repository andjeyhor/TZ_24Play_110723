using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpEffectTransform : MonoBehaviour
{
    [SerializeField] private Transform objTr;
    void Update()
    {
        if (objTr)
        {
            gameObject.transform.position = new Vector3(
            gameObject.transform.position.x,
            gameObject.transform.position.y,
            objTr.position.z + 100
        );
        }

    }
}
