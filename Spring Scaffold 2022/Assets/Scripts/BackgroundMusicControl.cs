using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicControl : MonoBehaviour
{
    public static BackgroundMusicControl instance; 

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}