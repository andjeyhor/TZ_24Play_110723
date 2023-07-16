using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailControl : MonoBehaviour
{
    [SerializeField] private Transform obj;
    void Update()
    {
        if (obj)
        {
            gameObject.transform.position = new Vector3(
            obj.position.x,
            gameObject.transform.position.y,
            obj.position.z);
        }

    }
}
