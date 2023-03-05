using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnBrick : MonoBehaviour
{
    private bool isCollect = false;
    public GameObject brick;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollect)
        {
            isCollect = true;
            brick.SetActive(true);
            other.GetComponent<Boss>().RemoveBrick();
        }
    }
}
