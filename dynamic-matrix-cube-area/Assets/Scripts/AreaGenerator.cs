using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaGenerator : MonoBehaviour
{
    public GameObject baseCell;
    int areaMatrixX = 10;
    int areaMatrixZ = 10;

    // Start is called before the first frame update
    void Start()
    {
        // エリア生成の元ネタとなるマトリックスを生成する
        int[,] areaMatrix = generateAreaMatrix();

        // マトリックスの大きさを取得する
        int maxX = areaMatrix.GetLength(0);
        int maxZ = areaMatrix.GetLength(1);
        // Cellの大きさを取得する
        float baseScaleX = baseCell.transform.localScale.x;
        float baseScaleZ = baseCell.transform.localScale.z;
        for (int z = 0; z < maxZ; z++)
        {
            float positionZ = baseScaleZ * z;
            for (int x = 0; x < maxX; x++)
            {
                // 配置する位置を決める
                Vector3 basePosition = baseCell.transform.position;
                basePosition.x += baseScaleX * x;
                basePosition.z += positionZ;

                // 生成するCellの種類を決める
                var cellPrefabPath = "Prefabs/Cell";
                if (areaMatrix[x, z] == 1)
                {
                    cellPrefabPath = "Prefabs/Wall";
                }

                // プレハブからCellインスタンスを生成
                GameObject cellResource = (GameObject)Resources.Load(cellPrefabPath);
                GameObject cell = Instantiate(cellResource) as GameObject;

                // 配置
                cell.transform.position = basePosition;
            }
        }
    }

    private int[,] generateAreaMatrix() {
        //int[,] areaMatrix = new int[areaMatrixX, areaMatrixZ];

        //for (int x = 0; x < areaMatrixX; x++)
        //{
        //    for (int z = 0; z < areaMatrixZ; z++)
        //    {
        //        areaMatrix[x,z] = 0;
        //    }
        //}
        int[,] areaMatrix = {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
            { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 1, 1, 1, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 0, 0, 0, 1, 1, 0, 1 },
            { 1, 0, 1, 1, 1, 1, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };
        return areaMatrix;
    }
}
