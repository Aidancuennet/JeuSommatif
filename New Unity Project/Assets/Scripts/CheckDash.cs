using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDash : MonoBehaviour
{
    [SerializeField] Place _place;

    public Place Charplace
    {
        get => _place;
        set => _place = Place.GROUND;
    }
    
    public enum Place
    {
        VOID,
        GROUND,
    }

    
    void OnTriggerEnter2D(Collider2D collision) //checks if above void
        {
            if (collision.tag == "Void")
            {
                _place = Place.VOID;
            }
            else
            {
                _place = Place.GROUND;
            }
        }
}
