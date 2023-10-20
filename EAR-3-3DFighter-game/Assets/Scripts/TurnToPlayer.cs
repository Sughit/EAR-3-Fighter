using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToPlayer : MonoBehaviour
{
    public Transform cameraPlayer;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(cameraPlayer);
    }
}
