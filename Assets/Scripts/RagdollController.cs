using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private Rigidbody[] ragdollRigidbodies;
    [SerializeField] private bool ragdollOnEnable = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if(_animator == null)
        {
            _animator = GetComponentInChildren<Animator>();
        }



    }


    private void OnEnable()
    {
        if(ragdollOnEnable)
        {
            EnableRagdoll();
        }
        else
            DisableRagdoll() ;
    }


    public void EnableRagdoll()
    {
        if (_animator)
        {
            _animator.enabled = false;
        }

        foreach (var rb in ragdollRigidbodies)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }

    public void DisableRagdoll()
    {
        if(_animator)
        {
            _animator.enabled = true;
        }
        
        foreach (var rb in ragdollRigidbodies)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }


}
