using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomPositionGeneration : MonoBehaviour
{
    public GameObject prefab;
    private GameObject[] tradersPositionsArray;
    private ArrayList numberTaken;
    public int MIN_inclusive, MAX_exclusive;

    // Start is called before the first frame update
    void Start()
    {
        numberTaken = new ArrayList();
        int index = MIN_inclusive;
        System.Random rnd = new System.Random();

        tradersPositionsArray = GameObject.FindGameObjectsWithTag("standing");
        foreach(GameObject obj in tradersPositionsArray)
        {
            GameObject trader = Instantiate(prefab, obj.transform.position, Quaternion.identity);
            while(numberTaken.Contains(index))
            {
                // index = (int)Random.Range(MIN_inclusive, MAX_inclusive);
                index  = rnd.Next(MIN_inclusive, MAX_exclusive);
            }
            trader.name = "T" + index;
            trader.GetComponentInChildren<TextMeshPro>().text = trader.name;
            numberTaken.Add(index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
