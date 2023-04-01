using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public UnityEvent onInteraction; 
    public UnityEvent onAreaLeave;

    private bool isInsideTrigger = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideTrigger = false;
            onAreaLeave.Invoke();
        }
    }

    void Update()
    {
        if (isInsideTrigger && Input.GetKeyDown(interactionKey))
        {
            onInteraction.Invoke();
        }
    }
}