using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{

    public enum GateType
    {
        DualShot,
        SpreadShot,
        Range,
        ThrowRate
    }

    public GateType _gateType;
    public int _gateValue;

    [SerializeField] TextMeshPro _gateTypeText,_gateValueText;


    private void Awake()
    {
        _gateTypeText.SetText(_gateType.ToString());

        if(_gateType != GateType.DualShot && _gateType != GateType.SpreadShot)
        {
            if (_gateValue > 0)
            {
                _gateValueText.SetText("+" + _gateValue.ToString());
            }
            else if (_gateValue < 0)
            {
                _gateValueText.SetText(_gateValue.ToString());

            }
        }
        else if (_gateType == GateType.DualShot)
        {
            _gateValueText.SetText("x2");
        }
        else if (_gateType == GateType.SpreadShot)
        {
            _gateValueText.SetText("x3");
        }

    }

    public void SetGateColorGray()
    {
        for(int i=0 ; i< transform.GetChild(0).GetComponent<MeshRenderer>().materials.Length ; i++)
        {
          transform.GetChild(0).GetComponent<MeshRenderer>().materials[i].color = Color.gray;
        }
    }
}

