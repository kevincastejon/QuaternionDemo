using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FromToRotationDemo : MonoBehaviour
{
    [SerializeField] private Transform _arrow;
    [SerializeField] private TextMeshProUGUI normalText;
    private bool _toRight;
    private void Update()
    {
        Move();
        if (Physics.Raycast(_arrow.position, -_arrow.up, out RaycastHit hit, 10f))
        {
            _arrow.position = hit.point + _arrow.up * 0.1f;
            _arrow.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            normalText.text = "Hit normal (<color=red>"+hit.normal.x.ToString("F2")+"</color>; <color=green>"+hit.normal.y.ToString("F2")+"</color>; <color=blue>"+hit.normal.z.ToString("F2")+"</color>)";
        }
    }

    private void Move()
    {
        if (_toRight)
        {
            if (_arrow.transform.position.x > 1.5f)
            {
                _toRight = false;
            }
            _arrow.transform.Translate(_arrow.transform.right * Time.deltaTime);
        }
        else
        {
            if (_arrow.transform.position.x < -1.5f)
            {
                _toRight = true;
            }
            _arrow.transform.Translate((-_arrow.transform.right) * Time.deltaTime);
        }
    }
}
