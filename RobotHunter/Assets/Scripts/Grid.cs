using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform StartPosition;
    public LayerMask WallMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public float Distance;

    Node[,] grid;
    public List<Node> FinalPath;

    float nodeDiameter;
    int gridSizeX;
    int gridSizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreatGrid();

    }

    private void CreatGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 bottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;
        for (int y = 0; y < gridSizeX; y++)
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool Wall = true;

                if (Physics.CheckSphere(worldPoint, nodeRadius, WallMask))
                {
                    Wall = false;
                }

                grid[y, x] = new Node(Wall, worldPoint, x, y);
            }
        }
    }

    private void OnDrawGizmos()
    {

        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

       


        if (grid != null)
        {
            foreach (Node node in grid)
            {
                if (node.IsWall)
                {
                    Gizmos.color = Color.white;
                }
                else
                {
                    Gizmos.color = Color.yellow;
                }

                if (FinalPath != null)
                {
                    Gizmos.color = Color.red;
                }
                //GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                //plane.transform.position = new Vector3(node.Position.x,1, node.Position.z);;
                
                //plane.transform.localScale = new Vector3(nodeRadius * 2 - 5, 0, nodeRadius * 2 - 5);
                Gizmos.DrawWireCube(node.Position, Vector3.one * (nodeDiameter - Distance));
            }
        }
    }
}
