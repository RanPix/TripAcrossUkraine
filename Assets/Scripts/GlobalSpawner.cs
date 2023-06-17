using System.Collections.Generic;
using UnityEngine;

public class GlobalSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> ItemsToSpawn = new ();
    void Awake()
    {
        foreach (var gameObject in ItemsToSpawn)
        {
            Instantiate(gameObject);
        }
    }

}
