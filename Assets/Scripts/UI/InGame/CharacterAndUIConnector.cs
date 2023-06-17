using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;

public class CharacterAndUIConnector : MonoBehaviour
{
    public static CharacterAndUIConnector instance;

    [SerializeField] private Button nextMoveButton;

    public void Awake()
    {
        if (instance is null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void ConnectUI(Player.Player player)
    {
        nextMoveButton.onClick.AddListener(TurnManager.instance.NextTurn);


        Destroy(gameObject);
    }
}
