using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CybercowGames {

    public class JumpingState : InAirState
    {

        public JumpingState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.movement.Jump();

        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
          
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

        }

    }
}
