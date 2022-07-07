using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LookRotationDemo : MonoBehaviour
{
    [SerializeField] private Transform _arrow;
    [SerializeField] private Transform _sphere;
    [SerializeField] private Slider _sliderX;
    [SerializeField] private Slider _sliderY;
    [SerializeField] private Slider _sliderZ;
    [SerializeField] private TextMeshProUGUI _staticCodeViewer;
    [SerializeField] private TextMeshProUGUI _codeViewer;

    private void Start()
    {
        _sliderX.value = _sphere.position.x;
        _sliderY.value = _sphere.position.y;
        _sliderZ.value = _sphere.position.z;

        _codeViewer.richText = true;
        _staticCodeViewer.richText = true;
        _staticCodeViewer.text = "<color=green>Vector3</color> <color=blue>targetDirection</color> = _sphere.position - _arrow.position;\n";
        _staticCodeViewer.text += "<color=green>Quaternion</color> <color=blue>rotation</color> = <color=green>Quaternion</color>.<color=yellow>LookRotation</color>(<color=blue>targetDirection</color>);\n";
        _staticCodeViewer.text += "_arrow.rotation = <color=blue>rotation</color>;";
    }

    private void Update()
    {
        Vector3 targetDirection = _sphere.position - _arrow.position;
        Quaternion rotation = Quaternion.LookRotation(targetDirection);
        _arrow.rotation = rotation;

        //_codeViewer.text = _target.position.ToString() + " - " + _arrow.position.ToString() + " = " + targetDirection.ToString() + ";\n";
        _codeViewer.text = VectorToString(_sphere.position) + " - " + VectorToString(_arrow.position) + " = " + VectorToString(targetDirection) + ";\n";
        _codeViewer.text += QuaternionToString(rotation);
        //_staticCodeViewer.text += "<color=green>Quaternion</color> <color=blue>rotation</color> = <color=green>Quaternion</color>.<color=yellow>LookRotation</color>(<color=blue>targetDirection</color>);\n";
        //_staticCodeViewer.text += "_arrow.rotation = <color=blue>rotation</color>;";
    }
    public void SetTargetXPosition(float position)
    {
        _sphere.position = new Vector3(position, _sphere.position.y, _sphere.position.z);
    }
    public void SetTargetYPosition(float position)
    {
        _sphere.position = new Vector3(_sphere.position.x, position, _sphere.position.z);
    }
    public void SetTargetZPosition(float position)
    {
        _sphere.position = new Vector3(_sphere.position.x, _sphere.position.y, position);
    }
    public void RandomizeTargetPosition()
    {
        _sphere.position = new Vector3(Random.Range(_sliderX.minValue, _sliderX.maxValue), Random.Range(_sliderY.minValue, _sliderY.maxValue), Random.Range(_sliderZ.minValue, _sliderZ.maxValue));
        _sliderX.value = _sphere.position.x;
        _sliderY.value = _sphere.position.y;
        _sliderZ.value = _sphere.position.z;
    }
    public string VectorToString(Vector3 vector)
    {
        return "(<color=red>" + vector.x.ToString("F2") + "</color>; " + "<color=green>" + vector.y.ToString("F2") + "</color>; " + "<color=blue>" + vector.z.ToString("F2") + "</color>)";
    }
    public string QuaternionToString(Quaternion quaternion)
    {
        return "(<color=red>" + quaternion.x.ToString("F2") + "</color>; " + "<color=green>" + quaternion.y.ToString("F2") + "</color>; " + "<color=blue>" + quaternion.z.ToString("F2") + "</color>; " + "<color=orange>" + quaternion.w.ToString("F2") + "</color>" + ")";
    }
}
