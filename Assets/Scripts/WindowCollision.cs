using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCollision : MonoBehaviour
{
    [SerializeField] private PlayerController player = null;
    [SerializeField] private Palanca palanca = null;
    private bool PlayerPassed;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPassed = false;
    }

    void Update()
    {
        if (PlayerPassed && player.transform.position.x >= 0.4f)
        {
            if(!palanca.pushed)
            {
                player.transform.position = new Vector3(0.4f, player.transform.position.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (palanca.pushed) return;
            PlayerPassed = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerPassed = false;
    }
}
