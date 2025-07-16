using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _turnSpeed = 720f;



    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if(InputManager.inputDirection.magnitude != 0)
        {

            RotateToInput();

            Vector3 movement = _rb.rotation * Vector3.forward * _moveSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(_rb.position + movement); //moves forward
        }
    }

    private void RotateToInput()
    {
        Quaternion targetRotation = Quaternion.LookRotation(InputManager.inputDirection, Vector3.up); //Rotation to rotate to
        Quaternion newRotation = Quaternion.RotateTowards(_rb.rotation, targetRotation, _turnSpeed * Time.fixedDeltaTime); //smooths rotation based on turn speed

        _rb.MoveRotation(newRotation);
    }
}
