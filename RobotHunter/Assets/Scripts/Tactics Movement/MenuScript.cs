using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuScript
{

    [MenuItem("Tools/Assing Tile Material")]
    public static void AssingTileMaterial()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        Material material = Resources.Load<Material>("Tile");

        foreach (GameObject tile in tiles)
        {
            tile.GetComponent<Renderer>().material = material;
        }
    }

    [MenuItem("Tools/Assing Tile Script")]
    public static void AssingTileScript()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
      
        foreach (GameObject tile in tiles)
        {
            tile.AddComponent<Tile>();
        }
    }
}
