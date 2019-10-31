using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public bool collected;
    [SerializeField] private Light linternaLight = null;
    [SerializeField] private Light spotlight = null;
    [SerializeField] private GameObject linternaInventory = null;
    [SerializeField] private GameObject[] dialogues = null;
    private AudioSource m_audio;

    void Start()
    {
        collected = false;
        m_audio = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            collected = true;
            m_audio.Play();
            this.GetComponent<Renderer>().enabled = false;
            linternaLight.enabled = false;
            spotlight.intensity = 2;
            spotlight.spotAngle = 60;
            spotlight.range = 900;
            foreach(GameObject dialogue in dialogues)
            {
                dialogue.SetActive(false);
            }
            linternaInventory.SetActive(true);

        }
    }
}
