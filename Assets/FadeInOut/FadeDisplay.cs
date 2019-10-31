using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeDisplay : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    [ContextMenu("DoFadeIn")]
    public void DoFadeIn()
    {
        anim.SetTrigger("FadeIn");
    }

    [ContextMenu("DoFadeOut")]
    public void DoFadeOut()
    {
        anim.SetTrigger("FadeOut");
    }
}
