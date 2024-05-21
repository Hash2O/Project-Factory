using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    public static GameObject newPortal1;
    public static GameObject newPortal2;

    public static bool isTeleported;

    // Start is called before the first frame update
    void Start()
    {
        newPortal1 = GameObject.Find("Portal 1");
        newPortal2 = GameObject.Find("Portal 2");

        isTeleported = false;

        Debug.Log("Portal 1 : " + newPortal1.transform.position);
        Debug.Log("Portal 2 : " + newPortal2.transform.position);
    }

    public IEnumerator CanTeleportAgainAfterThreeSeconds()
    {
        isTeleported = true;
        yield return new WaitForSeconds(3);
        isTeleported = false;
    }

    public IEnumerator TeleportProcess(GameObject player, GameObject portal)
    {
        yield return new WaitForSeconds(2);
        player.GetComponent<MeshRenderer>().material.color = Color.blue;
        player.transform.position = portal.transform.position;
        isTeleported = true;
        yield return new WaitForSeconds(3);
        player.GetComponent<MeshRenderer>().material.color = Color.red;
        isTeleported = false;

    }

    /*
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Player") && isTeleported == false)
        {
            if(gameObject.CompareTag("Portal 1"))
            {
                Debug.Log("Entering Portal 1");
                other.transform.position = new Vector3(-7.38f, 3.69f, 3.35f);
                StartCoroutine(CanTeleportAgainAfterThreeSeconds());
                
            }

            if (gameObject.CompareTag("Portal 2"))
            {
                Debug.Log("Entering Portal 2");
                other.transform.position = new Vector3(10.31f, 1, -8.63f);
                StartCoroutine(CanTeleportAgainAfterThreeSeconds());
                
            }
        }
    }
    */

}
