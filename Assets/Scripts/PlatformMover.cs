using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    public bool isMoving = false;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            float pingPong = Mathf.PingPong(Time.time * speed, 1f);
            float newPositionX = Mathf.Lerp(minX, maxX, pingPong);
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

            //if (GetComponent<platformCheck>().isPlayerOnPlatformNow())
            //{
            //    Player.transform.parent = transform;
            //}
            //else
            //{
            //    Player.transform.parent = null;
            //}
        }
    }
}
