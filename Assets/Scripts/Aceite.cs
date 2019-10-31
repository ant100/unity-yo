using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aceite : MonoBehaviour
{
    public bool collected;
    [SerializeField] private Palanca palanca = null;
    [SerializeField] private GameObject aceiteInventory = null;
    [SerializeField] private GameObject[] dialogues = null;
    private AudioSource m_audio;

    // Start is called before the first frame update
    void Awake()
    {
        collected = false;
        m_audio = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (palanca.seen)
            {
                collected = true;
                m_audio.Play();
                this.GetComponent<Renderer>().enabled = false;
                aceiteInventory.SetActive(true);
                foreach (GameObject dialogue in dialogues)
                {
                    dialogue.SetActive(false);
                }
                dialogues[2].SetActive(true);
            }
        }
    }
}
