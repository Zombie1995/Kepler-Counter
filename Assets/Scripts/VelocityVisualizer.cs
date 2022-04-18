using UnityEngine;

public class VelocityVisualizer : MonoBehaviour
{
    [Header("Required Assets")]
    [SerializeField] private Transform _direction;

    private Gravity _gravity;

    private void Start()
    {
        _gravity = GetComponent<Gravity>();

    }

    void Update()
    {
        _direction.transform.up = _gravity.CurVel;

        float velocityValue = _gravity.CurVel.magnitude;
        _direction.transform.localScale = new Vector3(1, velocityValue, 1);
        _direction.transform.GetChild(0).transform.localScale = new Vector3(2, 2 / (velocityValue != 0 ? velocityValue : 2), 2);
    }
}
