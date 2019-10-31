using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public int index = 0;
    public RotateWorld world;

    private void OnTriggerEnter2D(Collider2D other)
    //private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (world.rotate) return;
            world.SetDirectionTurn(index);
        }
    }
}
