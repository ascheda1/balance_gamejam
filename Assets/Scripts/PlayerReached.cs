using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReached : MonoBehaviour
{
    public bool playerReached = false;

    private void OnTriggerEnter(Collider other)
    {
        playerReached = true;
    }
}
