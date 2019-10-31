using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuadro : MonoBehaviour
{
    public bool moved;
    [SerializeField] private Palanca palanca = null;
    [SerializeField] private Muro muro = null;
    [SerializeField] private Cuadro secondCuadro = null;
    [SerializeField] private GameObject[] dialogues = null;
    private Animator animator;
    private AudioSource m_audio;

    void Start()
    {
        moved = false;
        animator = this.gameObject.GetComponent<Animator>();
        m_audio = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (palanca.pushed)
            {
                moved = true;
                animator.SetBool("animar_cuadro", true);
                m_audio.Play();

                foreach (GameObject dialogue in dialogues)
                {
                    dialogue.SetActive(false);
                }
            }
        }
    }

    void AnimationEnded()
    {
        if (secondCuadro.moved)
            muro.startWallDestruction = true;
    }
}
