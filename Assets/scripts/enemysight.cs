using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemysight : MonoBehaviour
{
    public enemy enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            enemy.settarget(collision.GetComponent<charecter>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemy.settarget(null);
        }
    }
}
