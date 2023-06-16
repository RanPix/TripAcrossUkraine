using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> ItemsToSpawn = new ();
    void Start()
    {
        foreach (var gameObject in ItemsToSpawn)
        {
            Instantiate(gameObject);
        }
    }

}
