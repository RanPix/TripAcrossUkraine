using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAndUIConnector : MonoBehaviour
{
    public static CharacterAndUIConnector instance;

    [SerializeField] Button nextMoveButton;

    public void Awake()
    {
        if (instance is null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void ConnectUI(PlayerMovement movement)
    {
        nextMoveButton.onClick.AddListener(movement.Move);

        Destroy(gameObject);
    }
}
