using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroytext : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    // Destroy text after some time
    void Start()
    {
        Destroy(gameObject,destroyTime);
    }

}
