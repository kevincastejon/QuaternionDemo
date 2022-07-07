using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AngleDemo : MonoBehaviour
{
    [SerializeField] private Transform _arrowA;
    [SerializeField] private Transform _arrowB;
    [SerializeField] private TextMeshProUGUI _angleText;
    [SerializeField] private TextMeshProUGUI _codeViewer;

    private void Start()
    {
        UpdateCode();
    }
    public void Randomize()
    {
        _arrowA.rotation = Random.rotation;
        _arrowB.rotation = Random.rotation;
        UpdateCode();
    }
    private void UpdateCode()
    {
        float angle = Quaternion.Angle(_arrowA.rotation, _arrowB.rotation);
        _angleText.text = "The two arrows rotations forms an angle of " + angle.ToString("F2")+"°";
        _codeViewer.text = "<color=blue>float angle</color> = <color=green>Quaternion</color>.<color=yellow>Angle</color>(_arrowA.rotation, _arrowB.rotation);";
    }
}
