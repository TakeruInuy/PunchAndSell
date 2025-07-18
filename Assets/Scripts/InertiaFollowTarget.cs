using UnityEngine;

public class InertiaFollowTarget : MonoBehaviour
{
    [SerializeField] private Rigidbody _bottomTarget;
    [SerializeField] private Transform _targetToLook;
    [SerializeField] private float _height = 2f;
    [SerializeField] private float _depth = 4f;
    public bool isFollowing;

    [Header("Physics Parameters")]
    [SerializeField] private float _stiffness = 1000f;
    [SerializeField] private float _damper = 50f;

    private Rigidbody _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if(_bottomTarget && isFollowing)
        {
            Vector3 targetPos = _bottomTarget.position - _bottomTarget.transform.forward * _depth + Vector3.up * _height;
            Vector3 springForce = (targetPos - _rb.position) * _stiffness;


            Vector3 relativeVelocity = _rb.linearVelocity - _bottomTarget.linearVelocity;
            Vector3 dampingForce = -relativeVelocity * _damper;

            _rb.AddForce(springForce + dampingForce);

            _rb.MoveRotation(_targetToLook.rotation);
            
        }
    }


    public void EnableFollow(Rigidbody followTarget, Transform lookTarget, float positionHeight, float positionDepth, float stiffness, float damper)
    {
        _bottomTarget = followTarget;
        _targetToLook = lookTarget;
        _height = positionHeight;
        _depth = positionDepth;
        _stiffness= stiffness;
        _damper = damper;

        isFollowing = true;
    }

    public void DisableFollow()
    {
        _bottomTarget = null;
        _targetToLook = null;

        isFollowing = false;
    }


}
