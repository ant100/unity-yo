using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    [SerializeField] private int rotationDegrees = 1;
    [SerializeField] private GameObject player = null;
    [HideInInspector] public bool rotate;
    private int i;
    private int dir;
    private int apos;
    private float deg;
    

    // Start is called before the first frame update
    void Start()
    {
        apos = 0;
        i    = 0;
        deg  = transform.rotation.eulerAngles.z;
        dir  = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate && dir != 0)
        {
            i += rotationDegrees;
            if (i < 90)
            {
                transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z + rotationDegrees * dir);
                player.transform.eulerAngles = new Vector3(0, 0, player.transform.rotation.eulerAngles.z + rotationDegrees * -dir);
            }
            else
            {                             
                deg += (90.0f * dir);
                transform.eulerAngles = new Vector3(0, 0, deg);
                player.transform.eulerAngles = new Vector3(0, 0, player.transform.rotation.eulerAngles.z + 1*-dir);
                rotate = false;
                i = 0;
                MovePlayerOutOfTrigger();
            }
        }
    }

    private void MovePlayerOutOfTrigger()
    {
        float newYpos = player.transform.localPosition.y;
        float newXpos = player.transform.localPosition.x;
        float distanciaColchon = 0.03f;

        if(apos == 0 && dir > 0) // de 1 a 0
        {
            newXpos -= distanciaColchon;
        }
        else if(apos == 0 && dir < 0) // de 3 a 1
        {
            newXpos += distanciaColchon;
        }
        else if (apos == 1 && dir > 0) // de 2 a 1
        {
            newYpos -= distanciaColchon;
        }
        else if (apos == 1 && dir < 0) // de 0 a 1
        {
            newYpos += distanciaColchon;
        }
        else if (apos == 2 && dir > 0) // de 3 a 2
        {
            newXpos += distanciaColchon;
        }
        else if (apos == 2 && dir < 0) // de 1 a 2
        {
            newXpos -= distanciaColchon;
        }
        else if (apos == 3 && dir > 0) // de 0 a 3
        {
            newYpos += distanciaColchon;
        }
        else if (apos == 3 && dir < 0) // de 2 a 3
        {
            newYpos -= distanciaColchon;
        }

        player.transform.localPosition = new Vector2(newXpos, newYpos);
    }

    public void ActivateTurn()
    {
        rotate = true;
    }

    public void SetDirectionTurn(int npos)
    {
        if (rotate) return;

        if(apos == 0 && npos == 3)
        {
            dir = 1;
        }
        else if(apos == 3 && npos == 0)
        {
            dir = -1;
        }
        else if (apos < npos)
        {
            dir = -1;
        }
        else if (apos > npos)
        {
            dir = 1;
        }
        else
        {
            dir = 0;
        }
        apos = npos;

        if(dir != 0)
        {
            ActivateTurn();
        }

    }

}
