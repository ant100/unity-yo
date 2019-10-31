using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public int rotationDegrees = 1;
    private bool rotate;
    private int i;
    private int apos;
    private int dir;

    // Start is called before the first frame update
    void Start()
    {
        apos = 0;
        i = 0;
        dir = 0;
        rotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate)
        {
            i += rotationDegrees;
            if(i <= 90)
            {
                transform.eulerAngles = new Vector3(0, 0, Mathf.Floor(transform.rotation.z + i * dir));
            }
            else
            {
                rotate = false;
                i = 0;
            }
            
        }
    }

    public void ActivateTurn()
    {
        rotate = true;
    }

    public void SetDirectionTurn(int npos)
    {
        Debug.Log("npos" + npos);
        Debug.Log("apos" + apos);
        if(apos < npos)
        {
            apos = npos;
            dir = 1;
        }
        else if(apos > npos)
        {
            apos = npos;
            dir = -1;
        }
    }
}
