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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(InputManager.inputDirection.magnitude != 0)
        {

            Debug.Log("Move Input");

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
