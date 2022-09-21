using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _looker;
    [SerializeField] private GameObject _target;

    [Header("Settings")]
    [SerializeField] private bool _ignoreX;
    [SerializeField] private bool _ignoreY;
    [SerializeField] private bool _ignoreZ;

    private Quaternion _finalRotation;

    public Quaternion FinalRotation { get => _finalRotation; }
    public GameObject Target { get => _target; set => _target = value; }

    public void Start()
    {
        if (_looker == null) _looker = this.gameObject;
        if (_target == null) Debug.Log("No target set");
    }

    public void Update()
    {
        if(Target != null)
        {
            _finalRotation = LookAt(_target.transform, _looker.transform);
        }
    }

    private Quaternion LookAt(Transform target, Transform looker)
    {
        Vector3 targetVector = target.transform.position - looker.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetVector);
        Vector3 rotation = lookRotation.eulerAngles;

        return Quaternion.Euler(IgnoreAxis(rotation));
    }

    private Vector3 IgnoreAxis(Vector3 rotation)
    {
        if (_ignoreX) rotation.x = 0f;
        if (_ignoreY) rotation.y = 0f;
        if (_ignoreZ) rotation.z = 0f;

        return rotation;
    }
}
