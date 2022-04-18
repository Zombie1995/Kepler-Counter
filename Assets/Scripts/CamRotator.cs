using UnityEngine;

public class CamRotator : MonoBehaviour
{
    [Header("Required Assets")]
    [SerializeField] private float _rotationSpeedX = 60f;
    [SerializeField] private float _rotationSpeedY = 60f;

    private Transform _camRotator;

    private Vector3 _prMousePosition;
    private float _rotationX = 0f;
    private float _rotationY = 0f;

    private void Start()
    {
        _camRotator = transform.parent;

        _rotationX = transform.rotation.eulerAngles.x;
        _rotationY = transform.rotation.eulerAngles.y;
    }

    private void Update()
    {
        RotateCam();
    }

    void RotateCam() 
    {
        if (Input.GetMouseButtonDown(1))
        {
            _prMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            Vector3 delta = (Input.mousePosition - _prMousePosition);
            float deltaX = delta.x / Screen.width;
            float deltaY = delta.y / Screen.height;

            _rotationX += -deltaY * _rotationSpeedY;
            if (_rotationX > 90f)
            {
                _rotationX = 90f;
            }
            else if (_rotationX < -90) 
            {
                _rotationX = -90f;
            }

            _rotationY += deltaX * _rotationSpeedX;

            _camRotator.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);

            _prMousePosition = Input.mousePosition;
        }
    }
}
