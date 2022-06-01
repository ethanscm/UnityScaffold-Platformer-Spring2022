using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopTreeManager : MonoBehaviour
{
    [SerializeField] private GameObject upTree;
    [SerializeField] private GameObject fallenTree;
    [SerializeField] private GameObject acorn;
    
    void Start()
    {
        fallenTree.SetActive(false);
        acorn.SetActive(false);
    }

    public void chopDownTree()
    {
        upTree.SetActive(false);
        fallenTree.SetActive(true);
        acorn.SetActive(true);
    }
}
