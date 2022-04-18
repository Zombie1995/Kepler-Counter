using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("Required Assets")]
    [SerializeField] private InputField _X;
    [SerializeField] private InputField _Y;
    [SerializeField] private InputField _Z;
    [SerializeField] private InputField _timeStep;
    [SerializeField] private InputField _areaTime;
    [SerializeField] private Toggle _velocityDirection;
    [SerializeField] private RunGravity _gravity;
    [SerializeField] private Gravity _asteroid;
    [SerializeField] private AreaDrawer _areaDrawer;
    [SerializeField] private GameObject _velocityDirectionObject;
    [SerializeField] private InputField _areaTransparency;
    [SerializeField] private InputField _simSpeed;

    void Update()
    {
        _velocityDirectionObject.SetActive(_velocityDirection.isOn);

        if (!_gravity.enabled)
        {
            float.TryParse(_X.text, out float x);
            float.TryParse(_Y.text, out float y);
            float.TryParse(_Z.text, out float z);
            _asteroid.CurVel = new Vector3(x, y, z);
        }
        else
        {
            _X.text = _asteroid.CurVel.x.ToString();
            _Y.text = _asteroid.CurVel.y.ToString();
            _Z.text = _asteroid.CurVel.z.ToString();
        }

        if (!_gravity.enabled)
        {
            float.TryParse(_timeStep.text, out float timeStep);
            _gravity.TimeStep = timeStep != 0 ? timeStep : 0.001f;
        }
        else
        {
            _timeStep.text = _gravity.TimeStep.ToString();
        }

        if (!_gravity.enabled) 
        {
            int.TryParse(_simSpeed.text, out int simSpeed);
            _gravity.SimSpeed = simSpeed != 0 ? simSpeed : 1;
        }
        else 
        {
            _simSpeed.text = _gravity.SimSpeed.ToString();
        }

        if (!float.TryParse(_areaTime.text, out float areaTime)) 
        {
            areaTime = 2;
        }
        _areaDrawer.AreaTime = areaTime;

        if (!int.TryParse(_areaTransparency.text, out int areaTransparency)) 
        {
            areaTransparency = 5;
        }
        _areaDrawer.AreaTransparency = areaTransparency;
    }

    public void StartGravity()
    {
        _gravity.enabled = true;
    }
    public void StopGravity()
    {
        _gravity.enabled = false;
    }

    public void CalcArea() 
    {
        _areaDrawer.Draw = true;
    }

    public void ResetState()
    {
        SceneManager.LoadScene(0);
    }
}
