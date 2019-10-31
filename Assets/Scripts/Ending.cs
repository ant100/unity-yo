using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] private FadeDisplay fade = null;
    [SerializeField] private AudioSource cameraAudio = null;
    [SerializeField] private PlayerController player = null;
    [SerializeField] private GameObject textoFinal = null;
    [SerializeField] private GameObject dialogueBox = null;
    private Animator playerAnimator;
    private AudioSource m_audio;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator  = player.GetComponent<Animator>();
        m_audio           = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.EnterWinZone();

            // disable dialogue box
            dialogueBox.SetActive(false);

            // musica
            cameraAudio.Stop();
            m_audio.Play();

            // fadeout
            Invoke("callFadeIn", 3);
        }
    }

    private void callFadeIn()
    {
        fade.DoFadeIn();

        // canvas
        Invoke("callText", 3);
    }

    private void callText()
    {
        textoFinal.SetActive(true);
    }
}
