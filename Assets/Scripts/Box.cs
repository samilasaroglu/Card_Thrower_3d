using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Box : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private RuntimeAnimatorController UnpackAnim;
    [SerializeField] private GameObject _ropes,_hitEffect;
    [SerializeField] private TextMeshProUGUI _remainigRopeText;

    private int _remainigRopeCount;
    private GameObject _cube013,_canvas;

    private void Awake()
    {
        _remainigRopeCount = _ropes.transform.childCount;
        _remainigRopeText.text = "" + _remainigRopeCount;
        _cube013 = transform.GetChild(0).GetChild(1).gameObject;
        _canvas = transform.GetChild(4).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Card"))
        {
            Instantiate(_hitEffect, other.transform.position, Quaternion.identity);
            if(_remainigRopeCount > 1)
            {
                other.gameObject.SetActive(false);
                DecreaseTheRope();
            }
            else
            {
                other.gameObject.SetActive(false);
                DecreaseTheRope();

                anim.runtimeAnimatorController = UnpackAnim;
                GetComponent<BoxCollider>().enabled = false;
                _cube013.SetActive(false);
                _canvas.SetActive(false);
            }
        }
    }

    void DecreaseTheRope()
    {
        _ropes.transform.GetChild(_remainigRopeCount - 1).gameObject.SetActive(false);
        _remainigRopeCount--;
        _remainigRopeText.text = "" + _remainigRopeCount;
    }
}
