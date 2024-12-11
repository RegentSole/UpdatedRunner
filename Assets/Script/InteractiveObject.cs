using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private GameObject platformToMove;
    [SerializeField] private Vector3 targetPosition;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MovePlatform();
            }
        }
    }

    void MovePlatform()
    {
        platformToMove.transform.position = targetPosition;
    }
}