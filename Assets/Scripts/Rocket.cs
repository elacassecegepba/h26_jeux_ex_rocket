using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class Rocket : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private bool _isThrusting;
    [SerializeField] private float _thrustForce = 42f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (_isThrusting) {
            _rigidbody.AddRelativeForce(Vector3.up * _thrustForce, ForceMode.Acceleration);
        }
    }

    void OnJump(InputValue value) {
        _isThrusting = value.isPressed;
    }
}
