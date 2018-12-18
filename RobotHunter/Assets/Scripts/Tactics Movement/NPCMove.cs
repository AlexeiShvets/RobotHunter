using System;//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : TacticsMove
{
    GameObject target;

    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);

        if (!turn)
            return;

        if (!moving)
        {
            FindNearestTarget();
            CalculatePath();
            FinfSelectableTiles();
            actualTargetTile.target = true;
        }
        else
        {
            Move();
        }
    }

    private void CalculatePath()
    {
        Tile targetTile = GetTagretTile(target);
        FindPath(targetTile);
    }
    


    private void FindNearestTarget()
    {
        GameObject[] targes = GameObject.FindGameObjectsWithTag("Player");

        GameObject nearest = null;

        float distance = Mathf.Infinity;

        foreach (GameObject obj in targes)
        {
            float d = Vector3.Distance(transform.position, obj.transform.position);
            if (d < distance)
            {
                distance = d;
                nearest = obj;
            }
               
        }

        target = nearest;
    }

}
