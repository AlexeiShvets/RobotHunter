using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRobot : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 10f;
    public Vector3 moveTarget = Vector3.zero;
    Camera camera;

    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
        moveTarget = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                Debug.Log("hit");
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "Plane")
                {
                    moveTarget = hit.point;
                }
            }
        }


        if (Vector3.Distance(moveTarget, transform.position) <= 2)
            return;

        transform.position += transform.forward * Time.deltaTime * _moveSpeed;
        Quaternion rawRoation = Quaternion.Slerp(transform.rotation,
                                                 Quaternion.LookRotation(moveTarget - transform.position),
                                                 _moveSpeed * 0.3f * Time.deltaTime);
        transform.rotation = new Quaternion(0, rawRoation.y, 0, rawRoation.w);
    }
}
