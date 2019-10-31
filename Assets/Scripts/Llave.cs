using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    [SerializeField] private Linterna linterna = null;
    [SerializeField] private PlayerController player = null;
    [SerializeField] private GameObject llaveInventory = null;
    private AudioSource m_audio;

    void Start()
    {
        m_audio = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (linterna.collected)
            {
                m_audio.Play();
                this.GetComponent<Renderer>().enabled = false;
                llaveInventory.SetActive(true);
                player.KeyCollected();
            }
        }
    }
}
