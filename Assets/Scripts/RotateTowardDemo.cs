using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RotateTowardDemo : MonoBehaviour
{
    [SerializeField] private Transform _arrowStart;
    [SerializeField] private Transform _arrowEnd;
    [SerializeField] private Transform _arrow;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _angleText;
    [SerializeField] private TextMeshProUGUI _codeViewer;

    private void Start()
    {
        _slider.maxValue = Quaternion.Angle(_arrowStart.rotation, _arrowEnd.rotation);
        UpdateCode();
    }

    public void SetAngle(float angle)
    {
        _arrow.rotation = Quaternion.RotateTowards(_arrowStart.rotation, _arrowEnd.rotation, angle);
        _angleText.text = Mathf.RoundToInt(angle) + "°";
        UpdateCode();
    }
    public void Randomize()
    {
        _arrowStart.rotation = Random.rotation;
        _arrowEnd.rotation = Random.rotation;
        _slider.maxValue = Quaternion.Angle(_arrowStart.rotation, _arrowEnd.rotation);
        _slider.value = 0f;
        _arrow.rotation = _arrowStart.rotation;
        UpdateCode();
    }
    private void UpdateCode()
    {
        _codeViewer.text = "_arrow.rotation = <color=green>Quaternion</color>.<color=yellow>RotateTowards</color>(_arrowStart.rotation, _arrowEnd.rotation, <color=green>" + _slider.value.ToString("F2")+ "f</color>);";
    }
}
