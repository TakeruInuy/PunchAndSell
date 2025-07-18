using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _turnSpeed = 720f;
    public bool isMoving;
    public UnityEvent onMovement;
    public UnityEvent onStop;

    [SerializeField]private SoundManager _soundManager;




    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        
        if(InputManager.inputDirection.magnitude != 0)
        {

            RotateToInput();

            Vector3 movement = _rb.rotation * Vector3.forward * _moveSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(_rb.position + movement); //moves forward
            isMoving = true;
            onMovement.Invoke();
        }
        else
        {
            isMoving = false;
            onStop.Invoke();
        }
        _animator.SetBool("isRunning", isMoving);
    }

    private void RotateToInput()
    {
        Quaternion targetRotation = Quaternion.LookRotation(InputManager.inputDirection, Vector3.up); //Rotation to rotate to
        Quaternion newRotation = Quaternion.RotateTowards(_rb.rotation, targetRotation, _turnSpeed * Time.fixedDeltaTime); //smooths rotation based on turn speed

        _rb.MoveRotation(newRotation);
    }


    private void PlayStepSound()
    {
        _soundManager.PlayAudio("Footstep");
    }
}
