using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject detector;
    [SerializeField] private GameObject acorn;

    void Update()
    {
        transform.position += new Vector3(30, 0, 0) * Time.deltaTime;
        if (transform.position.x > 33)
        {
            target.SetActive(false);
            detector.SetActive(false);
            acorn.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
