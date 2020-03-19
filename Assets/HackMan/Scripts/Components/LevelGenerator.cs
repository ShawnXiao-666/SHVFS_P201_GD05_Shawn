using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public BaseGirdObject[] BaseGridObjectPrefabs;

    public static int[,] Grid = new int[,]
    {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 0, 1, 0, 0, 0, 0, 3, 0, 1 },
        { 1, 0, 2, 0, 1, 0, 1, 0, 1, 1 },
        { 1, 0, 1, 0, 1, 0, 0, 0, 0, 1 },
        { 1, 0, 1, 0, 1, 0, 1, 1, 0, 1 },
        { 1, 0, 1, 0, 0, 0, 0, 3, 0, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    private void Awake()
    {
        var gridSizeY = Grid.GetLength(0);
        var gridSizeX = Grid.GetLength(1);

        for (int y = 0; y < gridSizeY; y++)
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                var objectType = Grid[y, x];
                var gridObjectPrefab = BaseGridObjectPrefabs[objectType];
                var gridObjectClone = Instantiate(gridObjectPrefab);

                //Set the grid position
                gridObjectClone.GridPosition = new IntVector2(x, -y); //...

                //Move the object to its grid position
                gridObjectClone.transform.position = gridObjectClone.GridPosition.AsVector3();
            }
        }
    }
}
