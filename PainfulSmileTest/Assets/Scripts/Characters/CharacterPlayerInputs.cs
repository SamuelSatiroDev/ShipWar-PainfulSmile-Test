using UnityEngine;


public sealed class CharacterPlayerInputs : MonoBehaviour
{

    public delegate void DirectionHandler(sbyte Direction);
    public event DirectionHandler OnTurnLeft;
    public event DirectionHandler OnTurnRight;


    private void Update()
    {
        this.Rotate();
    }

    private void Rotate()
    {
        float axisHorizontal = Input.GetAxisRaw("Horizontal");

        switch (axisHorizontal)
        {
            case -1:
                this.OnTurnLeftHandler();
                break;

            case 1:
                this.OnTurnRightHandler();
                break;
        }
    }

    private void OnTurnLeftHandler()
    {
        this.OnTurnLeft?.Invoke(-1);
    }

    private void OnTurnRightHandler()
    {
        this.OnTurnRight?.Invoke(1);
    }
}