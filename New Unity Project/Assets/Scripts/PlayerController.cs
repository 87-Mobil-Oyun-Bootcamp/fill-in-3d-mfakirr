using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    Vector3 Startposition;
    Vector3 direction;

    Vector2 beforeMouseChange = Vector2.zero;
    Vector2 afterMouseChange = Vector2.zero;

    Rigidbody rb = default;

    bool IsWalkable = false;
    [SerializeField]
    float speed = 0;
    Vector3 stop = Vector3.zero;

    private void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

        Application.targetFrameRate = 60;
    }

    void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        Startposition = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
    }

    beforeMouseChange = Input.mousePosition;

    if (Input.GetMouseButton(0) )
    {
        direction = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y) - Startposition;
        IsWalkable = true;
        }
        else
        {
            direction = Vector3.zero;
        }

    afterMouseChange = Input.mousePosition;

    }

    private void FixedUpdate()
    {
    Move();

    Rotate();
    }

    private void Rotate()
    {

        transform.LookAt((transform.position + direction));

    }

private void Move()
{
    if (IsWalkable )
    {
            if (direction.magnitude > 1)
            {
                rb.velocity = -direction.normalized * speed * Time.fixedDeltaTime;
            }
        }
    }

    bool CheckIsMouseMoving()
    {
          if (Vector2Int.RoundToInt(beforeMouseChange) != Vector2Int.RoundToInt(afterMouseChange))
          {
              return true;
           
        }
          else
          {
              return false;
          
        }
       
    }
}
