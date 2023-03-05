using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFl: MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private Vector3 offset;
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}