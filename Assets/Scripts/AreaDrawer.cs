using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AreaDrawer : MonoBehaviour
{
    [Header("Required Assets")]
    [SerializeField] private Transform _sun;
    [SerializeField] private Transform _asteroid;
    [SerializeField] private LineRenderer[] _areas;
    [SerializeField] private RectTransform[] _textCanvases;

    private Text[] _areaTexts;

    [Header("Parameters")]
    public bool Draw = false;
    public float AreaTime = 2f;
    public int AreaTransparency = 4;

    private int _areaTransparencyCount = 0;

    private List<Vector3> _areasPoints = new List<Vector3>();
    private List<Vector3> DrawnAreasPoints = new List<Vector3>();

    private float[] _areasValues;

    private int _chosenArea = 0;
    private float _timer = 0f;

    private void Start()
    {
        _areasValues = new float[2];
        _areasValues[0] = 0;
        _areasValues[1] = 0;

        _areaTexts = new Text[2];
        _areaTexts[0] = _textCanvases[0].GetChild(0).GetComponent<Text>();
        _areaTexts[1] = _textCanvases[1].GetChild(0).GetComponent<Text>();
    }

    private void Update()
    {
        _textCanvases[0].forward = _textCanvases[0].position - transform.position;
        _textCanvases[1].forward = _textCanvases[1].position - transform.position;
    }

    public void DrawAreas(float timeStep)
    {
        if (_chosenArea == 2)
        {
            if (Draw)
            {
                _areas[0].positionCount = 0;
                _areas[1].positionCount = 0;

                _areasValues[0] = 0f;
                _areasValues[1] = 0f;

                _areaTexts[0].text = "";
                _areaTexts[1].text = "";

                _chosenArea = 0;
            }
        }

        if (Draw)
        {
            _areasPoints.Add(_asteroid.position);
            _areasPoints.Add(_sun.position);

            if (_areasPoints.Count > 2)
            {
                _areasValues[_chosenArea] += DeltaArea();
                _areaTexts[_chosenArea].text = "S= " + _areasValues[_chosenArea].ToString();
            }

            if (_areaTransparencyCount >= AreaTransparency)
            {
                DrawnAreasPoints.Add(_areasPoints[_areasPoints.Count - 2]);
                DrawnAreasPoints.Add(_areasPoints[_areasPoints.Count - 1]);

                _areas[_chosenArea].positionCount = DrawnAreasPoints.Count;
                _areas[_chosenArea].SetPositions(DrawnAreasPoints.ToArray());

                int _areaCenterIndex = (DrawnAreasPoints.Count - 1) / 2;
                _areaCenterIndex = _areaCenterIndex % 2 == 0 ? _areaCenterIndex : _areaCenterIndex - 1;
                Vector3 textPosition = DrawnAreasPoints[_areaCenterIndex] / 2 - DrawnAreasPoints[_areaCenterIndex + 1] * 3 / 2;
                _textCanvases[_chosenArea].anchoredPosition3D = textPosition;

                _areaTransparencyCount = 0;
            }
            else
            {
                _areaTransparencyCount++;
            }

            if (_timer > AreaTime)
            {
                _chosenArea++;

                _areasPoints.Clear();
                DrawnAreasPoints.Clear();
                _timer = 0f;
                Draw = false;

                return;
            }
            _timer += timeStep;
        }
    }

    private float DeltaArea()
    {
        Vector3 vector1 = _areasPoints[_areasPoints.Count - 4] - _areasPoints[_areasPoints.Count - 3];
        Vector3 vector2 = _areasPoints[_areasPoints.Count - 2] - _areasPoints[_areasPoints.Count - 1];

        return TriangleArea(vector1, vector2);
    }

    private float TriangleArea(Vector3 a, Vector3 b)
    {
        return (1f / 2f) * Vector3.Cross(a, b).magnitude;
    }
}
