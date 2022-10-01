using UnityEngine;

public class KnifeSpinMechanic : MonoBehaviour
{
    [SerializeField] 
    private float forceMultiplier = 5f;
    [SerializeField] 
    private ForceMode forceMode = ForceMode.Acceleration;
    private bool _isFirstSpin = true;
    private bool _isSpinning;
    private Animator _knifeAnimationController;

    private Rigidbody _rb;
    private static readonly int IsFirstSpin = Animator.StringToHash("isFirstSpin");
    private static readonly int IsFreeFalling = Animator.StringToHash("isFreeFalling");
    private static readonly int ContinuousSpinTrigger = Animator.StringToHash("continuousSpinTrigger");


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _knifeAnimationController = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isFirstSpin)
            {
                FirstSpin();
            }
            else
            {
                ContinuousSpin();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            _knifeAnimationController.SetBool(IsFreeFalling, true);
        }

    }

    private void FirstSpin()
    {
        _isFirstSpin = false;
        _knifeAnimationController.SetBool(IsFirstSpin, true);
        _rb.isKinematic = false;
        _rb.AddForce(Vector3.forward * forceMultiplier ,forceMode);
        _rb.AddForce(Vector3.up * (2 * forceMultiplier), forceMode);

    }

    private void ContinuousSpin()
    {
        _knifeAnimationController.SetTrigger(ContinuousSpinTrigger);
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _rb.AddForce(Vector3.right * forceMultiplier ,forceMode);
        _rb.AddForce(Vector3.up * (2 * forceMultiplier), forceMode);
        
    }

}
