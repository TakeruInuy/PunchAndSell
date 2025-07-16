using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    private Rigidbody _rb;
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed = 10f;
    public bool isFollowing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();        
    }

    public void EnableFollow(Transform target, float followSpeed)
    {
        _target = target;
        _moveSpeed = followSpeed;
        isFollowing = true;
    }

    public void DisableFollow()
    {
        _target = null;
        isFollowing = false;
    }

    private void Follow()
    {
        if (isFollowing && _target)
        {
            Vector3 movement = Vector3.Lerp(_rb.position, _target.position, _moveSpeed * Time.fixedDeltaTime);
            _rb.MovePosition(movement);
        }
    }
}
