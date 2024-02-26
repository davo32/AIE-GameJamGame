using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformCheck : MonoBehaviour
{
    private bool isTriggered = true;
    private BoxCollider boxCollider;
    private GameObject Player;

    [SerializeField] private int PointsAwarded = 1;

    private PlatformMover PM;

    public bool isPlayerOnPlatformNow()
    {
        return Player.transform.position.y > transform.position.y + 1.0f;
    }

    private void Start()
    {
        PM = GetComponent<PlatformMover>();
        Player = GameObject.FindGameObjectWithTag("Player");
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = isTriggered;
    }

    private void Update()
    {
        if (!isTriggered)
        {
            return;
        }

        // Check if player has passed through the platform
        if (Player != null && Player.transform.position.y > transform.position.y + 1.0f)
        {
            isTriggered = false;
            boxCollider.isTrigger = false; // Switch to non-trigger
            Player.GetComponent<DistanceChecker>().AddDistance();
        }
        else
        {
            boxCollider.isTrigger = true; // Switch back to trigger
            isTriggered = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    isTriggered = false;
        //    boxCollider.isTrigger = false; // Switch to non-trigger
        //}
    }
}
