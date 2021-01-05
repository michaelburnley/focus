using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CybercowGames {

    public class GroundedState : GameState
    {

        public GroundedState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.rb.velocity = Vector3.zero;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            player.movement.Horizontal();
        }
    }
}