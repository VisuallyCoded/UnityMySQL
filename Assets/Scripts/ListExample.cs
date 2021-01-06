using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListExample : MonoBehaviour
{
    public List<int> ages = new List<int>();
    public List<GameObjects> objects = new List<GameObjects>();

    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            ages.Add(Random.Range(1, 100));
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ages.Remove(ages[Random.Range(0, ages.Count)]);
        }
    }
}
