using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance ;


    void Awake()
    {
        if (!_instance)
        {
            _instance = this ;  
        }

        else
        {
            Destroy(gameObject) ;
        }
        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Music/MainStage");
    }
    

   
}