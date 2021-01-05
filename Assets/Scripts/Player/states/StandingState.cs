using UnityEngine;

namespace CybercowGames {

    public class StandingState : GroundedState
    {
        private bool jump;
        private bool onWall;

        public StandingState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            jump = false;
        }

        public override void HandleInput()
        {
            base.HandleInput();
            jump = Input.GetKey(player.movement.inputs.up);
        }



        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (jump) stateMachine.ChangeState(player.jumping);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            // onWall = PlayerState.Instance.isColliding("Wall");
        }
    }
}

