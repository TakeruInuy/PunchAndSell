using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class FollowTarget : MonoBehaviour
{

    private Rigidbody _rb;
    [SerializeField] private Transform _targetToFollow;
    private Transform _forwardTarget;
    [SerializeField] private float _moveSpeed = 10f;
    public bool isFollowing;


    [SerializeField]private Transform _targetToRotate;
    public bool isRotating;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
        RotateToTarget();
    }

    public void EnableFollow(Transform target, float followSpeed)
    {
        _targetToFollow = target;
        _moveSpeed = followSpeed;
        isFollowing = true;
    }

    public void DisableFollow()
    {
        _targetToFollow = null;
        isFollowing = false;
    }

    private void Follow()
    {
        if (isFollowing && _targetToFollow)
        {
            Vector3 movement = Vector3.Lerp(_rb.position, _targetToFollow.position, _moveSpeed * Time.fixedDeltaTime);
            _rb.MovePosition(movement);
        }
    }

    public void EnableRotation(Transform targetToRotate, Transform forwardTargetToRotate)
    {
        _targetToRotate = targetToRotate;
        _forwardTarget = forwardTargetToRotate;
        isRotating = true;
        
    }

    public void DisableRotation()
    {
        _targetToRotate = null;
        _forwardTarget = null;
        isRotating = false;
    }

    public void RotateToTarget()
    {
        if(isRotating) 
        {
            if(_targetToRotate)
            {
                var upDir = -(_targetToRotate.position - _rb.position).normalized;
                Quaternion initialRot = Quaternion.LookRotation(transform.forward, upDir);

                Vector3 euler = initialRot.eulerAngles;
                euler.y = _forwardTarget.eulerAngles.y;

                Quaternion finalRot = Quaternion.Euler(euler);

                _rb.MoveRotation(finalRot);
            }
            else
            {
                Vector3 euler = transform.eulerAngles;
                euler.y = _forwardTarget.eulerAngles.y;

                Quaternion finalRot = Quaternion.Euler(euler);

                _rb.MoveRotation(finalRot);
            }

        }       
    }
}
