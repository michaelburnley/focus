using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CybercowGames {
    public class StateMachine
    {
        public GameState CurrentState { get; private set; }

        public void Initialize(GameState startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }

        public void ChangeState(GameState newState)
        {
            CurrentState.Exit();
            Debug.Log(newState);
            CurrentState = newState;
            newState.Enter();
        }
    }
}