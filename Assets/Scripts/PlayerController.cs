using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool winZone;
    public int numeroPrueba = 0;
    [SerializeField] private float regularSpeed = 2.0f;
    [SerializeField] private float slowSpeed    = 0.2f;
    [SerializeField] private float currentSpeed = 0.0f;
    [SerializeField] private RotateWorld world  = null;

    private int dir;
    private Vector3 pos;
    private AudioSource m_audio;
    private bool isWalking;
    private bool playerCanMove;
    private Animator animator;
    private enum EnumCurrentDirection { None, Right, Left};
    private EnumCurrentDirection currentDir;
    EnumCurrentDirection previousDir = EnumCurrentDirection.None;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        m_audio = GetComponent<AudioSource>();
        isWalking = false;
        winZone = false;
        playerCanMove = true;
        animator.SetBool("HasChain", true);
        KeyUncollected();
    }

    // Update is called once per frame
    void Update()
    {
        if (winZone) return;

        if (world.rotate) return;

        if (playerCanMove)
            MovePlayer();
    }

    private void MovePlayer()
    {
        if (Input.GetKey("left") && !Input.GetKey("right"))
        {
            previousDir = currentDir;
            ChangeDir(EnumCurrentDirection.Left);
        }
        else if (Input.GetKey("right") && !Input.GetKey("left"))
        {
            previousDir = currentDir;
            ChangeDir(EnumCurrentDirection.Right);
        }
        else if (!Input.GetKey("left") && !Input.GetKey("right") || Input.GetKey("left") && Input.GetKey("right"))
        {
            if (currentDir == EnumCurrentDirection.None) return;
            ChangeDir(EnumCurrentDirection.None);
        }

        pos = transform.position;
        pos.x += dir * currentSpeed * Time.deltaTime;
        transform.position = pos;
    }

    private void ChangeDir(EnumCurrentDirection _currentDir)
    {
        currentDir = _currentDir;

        switch (currentDir)
        {
            case EnumCurrentDirection.None:
                isWalking = false;
                m_audio.Stop();
                if(previousDir == EnumCurrentDirection.Left)
                {   
                    animator.SetTrigger("IdleLeft");
                }
                else if(previousDir == EnumCurrentDirection.Right)
                {
                    animator.SetTrigger("IdleRight");
                }
                dir = 0;
                break;
            case EnumCurrentDirection.Right:
                if (!isWalking)
                {
                    animator.SetTrigger("WalkRight");
                    m_audio.Play();
                }
                isWalking = true;
                dir = 1;
                break;
            case EnumCurrentDirection.Left:
                if (!isWalking)
                {
                    animator.SetTrigger("WalkLeft");
                    m_audio.Play();
                }
                isWalking = true;
                dir = -1;
                break;
            default:
                break;
        }
    }

    [ContextMenu("KeyCollected")]
    public void KeyCollected()
    {
        currentSpeed = regularSpeed;
        animator.SetBool("HasChain", false);
        ChangeDir(EnumCurrentDirection.None);
    }
    
    [ContextMenu("KeyUncollected")]
    private void KeyUncollected()
    {
        currentSpeed = slowSpeed;
        animator.SetBool("HasChain", true); 
        ChangeDir(EnumCurrentDirection.None);
    }

    public void EnterWinZone()
    {
        winZone = true;
        m_audio.Stop();
        animator.SetTrigger("winZone");
    }

    internal void StopPlayer()
    {
        playerCanMove = false;
        ChangeDir(EnumCurrentDirection.None);
    }

    public void StartPlayer()
    {
        playerCanMove = true;
    }
}

