using UnityEngine;

public class CameraWork : MonoBehaviour 
{
    [SerializeField]
    private Vector3 _center = Vector3.zero;
    [SerializeField]
    private float _speed = 5.0f;

    private Vector3 _axis;

    private void Update() 
    {
        if(Input.GetKey(KeyCode.W)) Move(Direction.Right);
        else if(Input.GetKey(KeyCode.A)) Move(Direction.Down);
        else if(Input.GetKey(KeyCode.S)) Move(Direction.Left);
        else if(Input.GetKey(KeyCode.D)) Move(Direction.Up);
    }

    public void Move(Direction direction)
    {
        if(direction == Direction.Up) _axis = Vector3.up;
        else if(direction == Direction.Down) _axis = Vector3.down;
        else if(direction == Direction.Left) _axis = Vector3.left;
        else _axis = Vector3.right;
        transform.RotateAround(_center, _axis, 360 / _speed * Time.deltaTime);
    }
}