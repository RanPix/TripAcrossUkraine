using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public static Builder instance;
    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}
