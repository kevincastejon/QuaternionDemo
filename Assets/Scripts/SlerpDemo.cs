using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlerpDemo : MonoBehaviour
{
    [SerializeField] private Transform _arrowStart;
    [SerializeField] private Transform _arrowEnd;
    [SerializeField] private Transform _arrow;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _ratioText;
    [SerializeField] private TextMeshProUGUI _codeViewer;
    private float _ratio;

    private void Start()
    {
        UpdateCode();
    }

    public void SetRatio(float ratio)
    {
        _ratio = ratio;
        _arrow.rotation = Quaternion.Slerp(_arrowStart.rotation, _arrowEnd.rotation, _ratio);
        _ratioText.text = Mathf.RoundToInt(_ratio * 100f) + "%";
        UpdateCode();
    }
    public void Randomize()
    {
        _arrowStart.rotation = Random.rotation;
        _arrowEnd.rotation = Random.rotation;
        _arrow.rotation = Quaternion.Slerp(_arrowStart.rotation, _arrowEnd.rotation, _ratio);
        UpdateCode();
    }
    private void UpdateCode()
    {
        _codeViewer.text = "_arrow.rotation = <color=green>Quaternion</color>.<color=yellow>Slerp</color>(_arrowStart.rotation, _arrowEnd.rotation, <color=green>" + _slider.value.ToString("F2") + "f</color>);";
    }
}
