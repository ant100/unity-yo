using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muro : MonoBehaviour
{
    public bool open;
    public bool startWallDestruction;
    [SerializeField] private Cuadro cuadro1 = null;
    [SerializeField] private Cuadro cuadro2 = null;
    [SerializeField] Animator animatorMuro1 = null;
    [SerializeField] Animator animatorMuro2 = null;
    [SerializeField] private GameObject[] dialogues = null;

    void Awake()
    {
        open = false;
        startWallDestruction = false;
    }

    void Update()
    {
        if(cuadro1.moved && cuadro2.moved)
        {
            open = true;

            // turn off dialogues
            foreach(GameObject dialogue in dialogues)
            {
                dialogue.SetActive(false);
            }

            // activate wall destruction
            if(startWallDestruction)
            {
                animatorMuro1.SetBool("wallOpen", true);
                animatorMuro2.SetBool("wallOpen", true);
            }
        }
    }
    
    void DeleteWall()
    {
        transform.parent.gameObject.SetActive(false);
    }

}
