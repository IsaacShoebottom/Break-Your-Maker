using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepUpright : MonoBehaviour
{
    void Update()
    {
        //Set the rotation (z axis) to 0
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
