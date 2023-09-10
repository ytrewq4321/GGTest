using System;

public class TurnManager
{
    public TurnState CurrentTurnState { get; private set; } = TurnState.Player1Turn;

    public void EndTurn()
    {
        switch (CurrentTurnState)
        {
            case TurnState.Player1Turn:
                CurrentTurnState = TurnState.Player2Turn;
                break;
            case TurnState.Player2Turn:
                CurrentTurnState = TurnState.Player1Turn;
                break;
        }
    }
}

public enum TurnState
{
    Player1Turn,
    Player2Turn
}
