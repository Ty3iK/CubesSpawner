using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private float _timeSleepBeforeChangeColor;

    [SerializeField]
    private float _timeForTransformationColor;

    private Color _currentColor;
    private Color _nextColor;
    private Color _transformationColor;

    private Renderer _renderer;

    private float _timeAfterLastFrameWasChanged;
    private float _recoloringTime;

    private bool _isChangeColor = true;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }
    private void Update()
    {
        _timeAfterLastFrameWasChanged += Time.timeScale;
        if (_timeAfterLastFrameWasChanged / 20 >= _timeSleepBeforeChangeColor)
        {
            _isChangeColor = true;
            if (_isChangeColor)
            {
                ChangeColor();
            }
        }

    }
    private void GenerateNextColor()
    {
        _currentColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0, 1, 0.7f, 1, 0.8f, 1);
    }
    private void ChangeColor()
    {
        _recoloringTime += Time.deltaTime;
        var timeForLerp = _recoloringTime / _timeForTransformationColor;
        
        _transformationColor = Color.Lerp(_currentColor, _nextColor, timeForLerp);
        _renderer.material.color = _transformationColor;

        if (_recoloringTime >= _timeForTransformationColor)
        {
            _recoloringTime = 0f;
            _isChangeColor = false;
            _timeAfterLastFrameWasChanged = 0f;
            GenerateNextColor();
        }
    }
}
