using UnityEngine;

public class MoveSystemPlayer : IMoveSystem
{
    public MoveSystemPlayer(IMovable self)
    {
        _self = self;
    }

    private Vector3 _directionMove;
    private Vector3 _directionAim;

    public override void CalculateDirection()
    {
        CalculateMove();
        CalculateAim();

        void CalculateMove()
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputZ = Input.GetAxis("Vertical");

            Transform transform = _self.GetRigidbody.transform;
            Vector3 directionForward = transform.forward * inputZ;
            Vector3 directionRight = transform.right * inputX;

            _directionMove = (directionForward + directionRight).normalized;
        }
        void CalculateAim()
        {
            float axisX = Input.GetAxis("Mouse Y");
            float axisY = Input.GetAxis("Mouse X");

            Vector3 rotationCurrent = _self.GetRigidbody.transform.rotation.eulerAngles;
            float rotationX = rotationCurrent.x + axisX;
            float rotationY = rotationCurrent.y + axisY;
            Vector3 rotationTarget = new Vector3(rotationCurrent.x, rotationY,rotationX);
            _directionAim = rotationTarget;
        }
    }

    public override void Move()
    {
        _self.GetRigidbody.velocity = _directionMove * _self.moveStats.speed * Time.deltaTime;
        _self.GetRigidbody.MoveRotation(Quaternion.Euler(_directionAim));
    }
}
