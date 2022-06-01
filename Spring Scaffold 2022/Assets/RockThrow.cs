using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrow : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(30, 0, 0) * Time.deltaTime;
    }
}
