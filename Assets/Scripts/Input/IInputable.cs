using UnityEngine;

public interface IInputable
{
    void ShootPressed();
    //void GetHorizontalAxis(float value);
    //void GetVerticalAxis(float value);
    void GetDirection(Vector3 direction);
}
