using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static RandomSpawn;

public class RandomSpawn : MonoBehaviour
{
    public List<GameObject> spawnList = new List<GameObject>();

    public List<Transform> spawnPointList = new List<Transform>();

    public Transform spawnParent;

    public Text banFruitText;

    private string[] FRUIT = { "사과", "아보카도", "바나나", "체리", "레몬", "복숭아", "땅콩", "배", "딸기", "수박" };

    void Start()
    {
        StartCoroutine(SpawnPrefab());
        StartCoroutine(BanFruit());
    }

    IEnumerator SpawnPrefab()
    {
        float currentTime = 0;
        while (true)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 2f)
            {
                currentTime = 0;
                int cnt = Random.Range(4, 7);
                for (int i = 0; i < cnt; i++)
                {
                    int idx = Random.Range(0, spawnList.Count);
                    int ran = Random.Range(0, spawnPointList.Count);

                    if (spawnPointList.Count == 0)
                    {
                        for (int j = 0; j < spawnParent.childCount; j++)
                            spawnPointList.Add(spawnParent.GetChild(j));
                    }

                    Instantiate(spawnList[idx], spawnPointList[ran].transform.position, Quaternion.identity);
                    spawnPointList.Remove(spawnPointList[ran]);
                    yield return new WaitForSeconds(.25f);
                }
            }
            yield return null;
        }
    }

    IEnumerator BanFruit()
    {
        for (int i = 0; i < FRUIT.Length; i++)
        {
            spawnList[i].tag = "Fruit";
        }
        int banFruit = Random.Range(0, spawnList.Count);
        spawnList[banFruit].tag = "Alogi";
        banFruitText.text = "알러지 : " + FRUIT[banFruit];
        yield return new WaitForSeconds(10);
        StartCoroutine(BanFruit());
    }
}

