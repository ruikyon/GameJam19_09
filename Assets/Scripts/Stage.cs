using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private GameObject wallPrefab, roadPrefab, enemyPrefab;

    public static List<List<int>> route = new List<List<int>>();

    private void Awake()
    {
        var mapText = (Resources.Load("map1", typeof(TextAsset)) as TextAsset).text;
        var mapData = mapText.Split('\n');

        Debug.Log(mapText);

        for (var i = 0; i < mapData.Length; i++)
        {
            Debug.Log(mapData[i].Length);
            for (var j = 0; j < mapData[0].Length; j++)
            {
                var tmp = new List<int>();

                if (mapData[i][j] == '1' || mapData[i][j] == '2')
                {
                    var basePos = new Vector3(2 * i + 1, 1.25f, 2 * j + 1);

                    if (mapData[i][j] == '2')
                    {
                        var enemy = Instantiate(enemyPrefab, basePos - Vector3.up*1.25f, new Quaternion());
                        enemy.GetComponent<Enemy>().Init(i/4, j/4);
                    }
                    Instantiate(roadPrefab, basePos - Vector3.up*1.25f, new Quaternion(), transform);
                    //壁生成
                    //(0, 0), (max, max)は例外的に左、右を開ける
                    if (i == 0 || mapData[i - 1][j] == '0')
                    {
                        if (i % 4 == 0 && j % 4 == 0)
                        {
                            tmp.Add(0);
                        }
                        Instantiate(wallPrefab, basePos + Vector3.left, new Quaternion(), transform);
                    }
                    if (i == mapData.Length - 1 || mapData[i + 1][j] == '0')
                    {
                        if (i % 4 == 0 && j % 4 == 0)
                        {
                            tmp.Add(1);
                        }
                        Instantiate(wallPrefab, basePos + Vector3.right, new Quaternion(), transform);
                    }
                    if (j == 0 || mapData[i][j - 1] == '0')
                    {
                        if (i % 4 == 0 && j % 4 == 0)
                        {
                            tmp.Add(2);
                        }
                        //if (i == 0) continue;
                        Instantiate(wallPrefab, basePos + Vector3.back, Quaternion.Euler(0, 90, 0), transform);
                    }
                    if (j == mapData[0].Length - 2 || mapData[i][j + 1] == '0')
                    {
                        if (i % 4 == 0 && j % 4 == 0)
                        {
                            tmp.Add(3);
                        }
                        if (i >= mapData.Length - 2 && j == mapData[0].Length - 2) continue;
                        Instantiate(wallPrefab, basePos + Vector3.forward, Quaternion.Euler(0, 90, 0), transform);
                    }
                }
                if (i % 4 == 0 && j % 4 == 0)
                {
                    route.Add(tmp);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
