using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private bool isPause = false;
    public Vector3 offset;
    public Vector3 target;
    public LayerMask Wall;
    public Transform cucan;
    public Rigidbody rb;
    public float speed;
    public Transform people;
    int pointBrick = 0;
    public Stack<GameObject> stack = new Stack<GameObject>();
    Vector3 Brick = new Vector3(0f, 0.25f, 0f);

    private bool isMoving;
    private void Start()
    {
        offset = new Vector3(0, 0, -1);
        cucan.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) <.0111111111111f) 
        {
            isMoving = false;
        }

        if(isMoving == false)
        {
            if (Input.GetKey(KeyCode.W))
        {
            offset = new Vector3(0, 0, 1); 
            cucan.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        }

        if (Input.GetKey(KeyCode.S))
        {
            offset = new Vector3(0, 0, -1);
            cucan.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            offset = new Vector3(1, 0, 0);
            cucan.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            offset = new Vector3(-1, 0, 0);
            cucan.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        }
        //Move
        
        CheckWallFront();

    }

    public void AddBrick(GameObject brick)
    {
        brick.transform.SetParent(transform);
        //Thêm gạch + tăng chiều cao nhân vật
        brick.transform.position = new Vector3(transform.position.x, transform.position.y + Brick.y * pointBrick, transform.position.z);
        people.transform.position = people.transform.position + Brick;
        stack.Push(brick.gameObject);
        pointBrick++;
    }

    public void RemoveBrick() 
    {
        Destroy(stack.Pop());                                                                                                                          
        people.transform.position = people.transform.position - Brick;
        transform.position -= Brick; // Giảm chiều cao nhân vật khi chạm vào cầu
        pointBrick--;
    }

    //in ra màn hình câu lệnh you win
    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Caro")
        //{
        //    Debug.Log("you win");
        //}
        //if (other.gameObject.tag == "Brick")
        //{
        //    other.transform.SetParent(transform);
        //    //Thêm gạch + tăng chiều cao nhân vật
        //    other.transform.position = new Vector3(transform.position.x, transform.position.y + Brick.y * pointBrick, transform.position.z);
        //    people.transform.position = people.transform.position + Brick;
        //    stack.Push(other.gameObject);

        //    //Destroy(other.gameObject);// xóa brick khi va chạm
        //    gameObject.transform.SetParent(transform);
        //    pointBrick++;
        //}
        //if (other.gameObject.tag.Equals("Bridge"))
        //{
        //    Destroy(stack.Pop());   //    Destroy(other.gameObject);
        //    pointBrick--;
        //    Debug.Log("hit");
        //}
    }
    void CheckWallFront()
    {
        RaycastHit hit;
        if (Physics.Raycast(cucan.transform.position, cucan.transform.forward, out hit, 1000f, Wall))
        {
            //hit.point diem raycast ban ra
            //hit.collider.transform.position; tam cua vat khi raycast cham den 
            Debug.Log(hit.collider.transform.position);
            target = hit.collider.transform.position - offset;
            target.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        }
    }
    public void Move()
    {
        if (isMoving)
        {
            RaycastHit hit;
            Physics.Raycast(cucan.position, cucan.transform.forward, out hit, 20f, Wall);
            if (Physics.Raycast(cucan.position, cucan.transform.forward, out hit, 50f, Wall))
            {
                Debug.DrawRay(cucan.position, cucan.transform.forward * hit.distance, Color.red);
                //Debug.Log("Did Hit");
                transform.position = Vector3.MoveTowards(transform.position, transform.position + cucan.transform.forward * (hit.distance - 0.5f), speed * Time.deltaTime);
            }
            else
            {
                Debug.DrawRay(cucan.position, cucan.transform.forward * 1000, Color.black);
                //Debug.Log("Did not Hit");
            }
        }
    }

    public void SetStop()
    {
        if (isPause)
        {
            Time.timeScale = 1;

        }else
        {
            Time.timeScale = 0; 
        }
        isPause = !isPause;
    }
}
