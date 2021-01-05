using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CybercowGames {

    public class InAirState : GameState
    {
        private bool walljump;
        private bool grounded;
        private bool onwall;

        public InAirState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (onwall) {
                stateMachine.ChangeState(player.walljump);
            } 
            
            if (grounded) {
                stateMachine.ChangeState(player.standing);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            player.movement.Horizontal();
            grounded = player.IsGrounded();
            onwall = PlayerState.Instance.isColliding("Wall");
            
        }
    }
}