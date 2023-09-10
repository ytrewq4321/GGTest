using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;

    [SerializeField] private PlayerUI player1UI;
    [SerializeField] private PlayerUI player2UI;

    [SerializeField] private GameUI gameUI;
    [SerializeField] private List<Buff> buffs;

    private PlayerAdapter player1Adapter;
    private PlayerAdapter player2Adapter;
    private TurnManager turnManager;
    private int roundCount = 1;

    public event Action<int> NewRoundStarted;

    private void Start()
    {
        turnManager = new TurnManager();

        InitializePlayers();
        AddGameUIListeners();
    }

    private void InitializePlayers()
    {
        player1.Initialize(buffs, player2);
        player2.Initialize(buffs, player1);

        player1Adapter = new PlayerAdapter(player1, player1UI);
        player2Adapter = new PlayerAdapter(player2, player2UI);

        player1Adapter.SetListeners();
        player2Adapter.SetListeners();
    }

  
    private void AddGameUIListeners()
    {
        gameUI.AddRestartButtonListener(RestartGame);
        NewRoundStarted += gameUI.SetRoundCount;

        player1UI.AddListenerAttackButton(ChangeTurn);
        player2UI.AddListenerAttackButton(ChangeTurn);
    }

    private void RemoveGameUIListeners()
    {
        gameUI.RemoveRestartButtonListener(RestartGame);
        NewRoundStarted -= gameUI.SetRoundCount;

        player1UI.RemoveListenerAttackButton(ChangeTurn);
        player2UI.RemoveListenerAttackButton(ChangeTurn);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void ChangeTurn()
    {
        if (turnManager.CurrentTurnState == TurnState.Player1Turn)
        {
            player1UI.SetButtonInteractable(false);
            player2UI.SetButtonInteractable(true);

            turnManager.EndTurn();

        }
        else if (turnManager.CurrentTurnState == TurnState.Player2Turn)
        {
            player1UI.SetButtonInteractable(true);
            player2UI.SetButtonInteractable(false);

            turnManager.EndTurn();

            roundCount++;
            NewRoundStarted.Invoke(roundCount);
        }
    }

    private void OnDestroy()
    {
        RemoveGameUIListeners();
    }
}
