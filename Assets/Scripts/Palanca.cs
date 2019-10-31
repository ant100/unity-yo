using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    
    public bool seen;
    public bool pushed;
    [SerializeField] private GameObject aceite = null;
    [SerializeField] private GameObject[] dialogues = null;
    private Animator palancaAnimator;
    private Animator animator;
    private Animator animator2;
    private Animator animator3;
    private AudioSource m_audio;

    // Start is called before the first frame update
    void Awake()
    {
        seen   = false;
        pushed = false;
        animator = GameObject.Find("VentanaAnimacion").GetComponent<Animator>();
        animator2 = GameObject.Find("VentanaAnimacion2").GetComponent<Animator>();
        animator3 = GameObject.Find("VentanaAnimacion3").GetComponent<Animator>();
        palancaAnimator = this.gameObject.GetComponent<Animator>();
        m_audio = this.gameObject.GetComponent<AudioSource>();
    }   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            seen = true;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Aceite aceiteObj = aceite.gameObject.GetComponent<Aceite>();
            if(aceiteObj.collected)
            {
                pushed = true;
                m_audio.Play();
                palancaAnimator.SetBool("animatePalanca", true);
                animator.SetBool("animateCurtains", true);
                animator2.SetBool("animateCurtains2", true);
                animator3.SetBool("animateCurtains3", true);
                foreach (GameObject dialogue in dialogues)
                {
                    dialogue.SetActive(false);
                }
            }
        }
    }
}
