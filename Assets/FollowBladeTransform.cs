using UnityEngine;

[DefaultExecutionOrder(1000)]
public class FollowBladeTransform : MonoBehaviour
{
    public Transform targetTransform;
    [SerializeField]
    Vector3 _transformOffset;

    GameObject _blade;
    
    void Update()
    {
        TransformBlade();
        FindBlade();
    }

    void FindBlade()
    {
        if (!_blade)
        {
            _blade = GameObject.FindWithTag("Blade");
        }
    }

    void TransformBlade()
    {
        if(_blade)
            targetTransform.position = _blade.transform.position + _transformOffset;
    }
}
