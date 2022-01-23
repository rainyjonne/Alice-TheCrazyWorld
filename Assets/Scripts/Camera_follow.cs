using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public Transform leading_point;


    void FixedUpdate ()
    {
        transform.position = new Vector3(leading_point.position.x, leading_point.position.y, transform.position.z);
    }
}
