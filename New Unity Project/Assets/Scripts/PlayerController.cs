using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{   
    Vector3 startPosition;
    Vector3 direction;

    Vector2 beforeMouseChange = Vector2.zero;
    Vector2 afterMouseChange = Vector2.zero;

    Rigidbody rb = default;

    [SerializeField]
    float speed = 0;

    private void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        //
        Application.targetFrameRate = 60;
    }

    void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        startPosition = new Vector3(Input.mousePosition.x, 0,
            Input.mousePosition.y);
    }
    //
    beforeMouseChange = Input.mousePosition;
    //
    if (Input.GetMouseButton(0) && CheckIsMouseMoving())
    {
        direction = new Vector3(Input.mousePosition.x, 0 , 
            Input.mousePosition.y) - startPosition;
    }
    else
    {
        direction = Vector3.zero;
    }
    //
    afterMouseChange = Input.mousePosition;

    }

    private void FixedUpdate()
    {
        //move character
        if (direction.sqrMagnitude > 1)
        {
            rb.velocity = -direction.normalized * speed * Time.fixedDeltaTime;
        }

        //rotate character
        transform.LookAt((transform.position + direction));
    }

    bool CheckIsMouseMoving()
    {
          if ((beforeMouseChange-afterMouseChange).sqrMagnitude>1)
          { return true; }
          else
          { return false; } 
    }
}
