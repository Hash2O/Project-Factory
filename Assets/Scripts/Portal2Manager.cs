using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2Manager : MonoBehaviour
{
    [SerializeField]
    private TestScript testScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && TestScript.isTeleported == false)
        {
            StartCoroutine(testScript.TeleportProcess(other.gameObject, TestScript.newPortal1));

            Debug.Log("Entering Portal 2, ready to go to portal 1");
        }
    }
}
