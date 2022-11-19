using UnityEngine;

public class MoveSystemPlayer : IMoveSystem
{
    public MoveSystemPlayer(IMovable self, Transform aimTransform)
    {
        _self = self;
        _aimTransform = aimTransform;
    }

    private Transform _aimTransform;
    private Vector3 _directionMove;

    public override void CalculateDirection()
    {
        CalculateMove();

        void CalculateMove()
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputZ = Input.GetAxis("Vertical");

            Vector3 forward = _aimTransform.forward;
            forward.y = 0;
            Vector3 directionForward = forward * inputZ;

            Vector3 right = _aimTransform.right;
            right.y = 0;
            Vector3 directionRight = right * inputX;

            _directionMove = (directionForward + directionRight).normalized;
        }
    }

    public override void Move()
    {
        _self.GetRigidbody.velocity = _directionMove * _self.moveStats.speed * Time.deltaTime;
    }
}
