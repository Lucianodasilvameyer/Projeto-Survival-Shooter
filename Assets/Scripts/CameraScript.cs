using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float distanceFromTargetX;

    void Update()
    {
        transform.position = target.position - transform.forward * distanceFromTargetX  + transform.up;
    }
}
