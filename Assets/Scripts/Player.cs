using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private Transform people;
    //Khai báo biến
    public Transform people;
    public Rigidbody rb;
    public float speed;
    // khai báo các hàm mình cần dùng
    Vector3 Star = new Vector3(0f, 0.5f, 0f);
    int pointStar = 0;
    // Start is called before the first frame update

    void Update()
    {
        //Move
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(0, 0, 1) * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.back * speed;
        }
    }
    
    //in ra màn hình câu lệnh you win
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Caro")
        {
            Debug.Log("you win");
        }

        if (other.gameObject.tag == "Star")
        {
            other.transform.SetParent(transform); // cho star thành con của Player//
            pointStar++;
            other.transform.position = new Vector3(transform.position.x, transform.position.y + Star.y * pointStar, transform.position.z);
            people.transform.position = people.transform.position + Star; // Tăng chiều cao của people khi ăn ngôi sao + lên 1 ngôi sao //
        }

        
    }

    private void OnTriggerExit(Collider other)
    {

    }
}
