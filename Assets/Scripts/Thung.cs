using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Thung : MonoBehaviour
{
    public Transform cucan;
    private Vector3 diemcanden;
    private float speed = 2f;
    public LayerMask wallLayer;

    private void Start()
    {
          
    }
    private void Update()
        
    {
        // Check tuong truoc mat lien tuc để tìm diểm cần đến
        //CheckWallFront();

        transform.position = Vector3.MoveTowards(transform.position, diemcanden, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.D))
        {

            /*cucan.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0))*/;
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            //cucan.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //cucan.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            /*cucan.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));*/
        }
    }

    // void CheckWallFront()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(cucan.transform.position, cucan.transform.forward, out hit, 300f, wallLayer))
    //   {
    //hit.point diem raycast ban ra
    //hit.collider.transform.position; tam cua vat khi raycast cham den 

    //    }

    // void FixedUpdate()
    // {

    // }

    public void Move()
    {
        RaycastHit hit;
        Physics.Raycast(cucan.position, cucan.TransformDirection(Vector3.forward), out hit, 20f, wallLayer);
        if (Physics.Raycast(cucan.position, cucan.TransformDirection(Vector3.forward), out hit, 50f, wallLayer))
        {
            Debug.DrawRay(cucan.position, cucan.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            //Debug.Log("Did Hit");
            transform.position = Vector3.MoveTowards(transform.position, transform.position + cucan.TransformDirection(Vector3.forward) * (hit.distance - 0.5f), speed * Time.deltaTime);
        }
        else
        {
            Debug.DrawRay(cucan.position, cucan.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }
    }
}
  
