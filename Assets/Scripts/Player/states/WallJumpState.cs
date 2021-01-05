using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CybercowGames {

    public class WallJumpState : InAirState
    {
        private bool walljump;

        public WallJumpState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.movement.StartWallHang();
        }

        public override void HandleInput()
        {
            base.HandleInput();
            walljump = Input.GetKey(player.movement.inputs.up);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            // if (walljump) stateMachine.ChangeState(player.standing);
            
            // if (walljump) {
            //     stateMachine.ChangeState(player.standing);
            // }
        }

        public override void PhysicsUpdate()
        {
            if (walljump) player.movement.WallJump();
            base.PhysicsUpdate();
        }

        public override void Exit()
        {
            base.Exit();
            
            // player.movement.StopWallHang();
            // stateMachine.ChangeState(player.standing);

        }

    }
}