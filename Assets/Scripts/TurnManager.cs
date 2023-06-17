using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;

    public Action OnNextTurn;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("TURN MANAGER INSTANCE ALREADY EXISTS");
    }

    public void NextTurn()
    {
        if (GameManager.instance.gameIsOver)
            return;

        OnNextTurn?.Invoke();
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
