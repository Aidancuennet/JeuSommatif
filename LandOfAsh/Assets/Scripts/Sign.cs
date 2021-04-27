using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] private GameObject SomeTextPrefab;

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        ShowText();
        Debug.Log("ALORS ?");
        
    }

    private void ShowText()
    {
        Instantiate(SomeTextPrefab, transform.position, Quaternion.identity, transform);
    }
}
