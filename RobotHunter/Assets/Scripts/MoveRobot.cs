using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveRobot : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 10f;

    public Vector3 moveTarget = Vector3.zero;

  

    // Use this for initialization
    void Start()
    {      
        moveTarget = transform.position;      
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.collider.gameObject.tag == "move")
        //        {
        //            moveTarget = hit.point;
        //            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //            cube.transform.position = moveTarget;
        //        }
        //    }
        //}


        if (Vector3.Distance(moveTarget, transform.position) < 1)
        {
            transform.position = moveTarget;
            return;
        }

        transform.position += transform.forward * Time.deltaTime * _moveSpeed;
        Quaternion rawRoation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveTarget - transform.position), _moveSpeed  * Time.deltaTime);
        transform.rotation = new Quaternion(0, rawRoation.y, 0, rawRoation.w);
    }
}
