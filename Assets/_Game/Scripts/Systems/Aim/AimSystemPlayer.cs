using UnityEngine;

public class AimSystemPlayer : IAimSystem
{
    public AimSystemPlayer(IAimable self, IAttacker attacker)
    {
        _self = self;
        recoilSystem = new RecoilSystem(attacker, self);
    }

    public RecoilSystem recoilSystem { get; private set; }

    private float _minX = 330f;
    private float _maxX = 40f;
    public override void CalculateAim()
    {
        float axisX = Input.GetAxis("Mouse Y");
        float axisY = Input.GetAxis("Mouse X");

        Vector3 rotationCurrent = directionAim;
        float rotationX = rotationCurrent.x - axisX * _self.GetAimStats.CamSensX;
        float rotationY = rotationCurrent.y + axisY * _self.GetAimStats.CamSensY;

        if(rotationX > _maxX && rotationX < _maxX + 20)
        {
            rotationX = _maxX;
        }
        if (rotationX < _minX && rotationX > _minX - 30)
        {
            rotationX = _minX;
        }

        Vector3 rotationTarget = new Vector3(rotationX, rotationY, 0);
        directionAim = rotationTarget;

        recoilSystem.GoToResetRecoil(Time.deltaTime);
    }

    public override void UpdateAim()
    {
        _self.GetAimTransform.rotation = Quaternion.Euler(directionAim);
    }
}
