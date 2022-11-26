using UnityEngine;

public class MoveSystemPlayer : IMoveSystem
{
    public MoveSystemPlayer(IMovable self, IAttackSystem attackSystem, WeaponSightController weaponSightController, Transform aimTransform)
    {
        _self = self;
        attackSystem.OnShoot += SprintOff;
        weaponSightController.OnActivateSightMode += SprintOff;
        _aimTransform = aimTransform;
    }

    private Transform _aimTransform;
    private Vector3 _directionMove;

    public bool isSprint { get; private set; }
    private const float _sprintMultiplier = 2f;

    public override void CalculateDirection()
    {
        CalculateMove();
        SprintActivate();

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

        void SprintActivate()
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                isSprint = true;
            }
            else if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                isSprint = false;
            }
        }
    }

    private void SprintOff()
    {
        isSprint = false;
    }

    public override void Move()
    {
        float speed = _self.moveStats.speed;
        if(isSprint)
        {
            speed *= _sprintMultiplier;
        }
        isMoving = _directionMove != Vector3.zero;
        
        _self.GetRigidbody.velocity = _directionMove * speed * Time.fixedDeltaTime;
    }
}
