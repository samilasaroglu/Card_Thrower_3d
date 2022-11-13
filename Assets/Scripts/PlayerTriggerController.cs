using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerController : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private GameObject _moneyParticle;
    private float _currentIncome;

    private void Awake()
    {
        _currentIncome = _gameData.Income;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {

            FindGateType(other.GetComponent<Gate>());

            other.GetComponent<BoxCollider>().enabled = false;

            other.GetComponent<Gate>().SetGateColorGray();
        }
        else if (other.CompareTag("Money"))
        {
            _gameData.Money += _currentIncome;
            other.gameObject.SetActive(false);
            UIManager.instance.SetMoneyText();
            Instantiate(_moneyParticle, other.transform.position,Quaternion.identity);
        }
        else if (other.CompareTag("Box"))
        {
            //Finish
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            CardThrower.instance.throwCard = false;
            InputSystem.instance._playerAnimator.SetTrigger("Idle");
            StartCoroutine(UIManager.instance.OpenWinPanel());
        }
    }



    void FindGateType(Gate gate)
    {
        if (gate._gateType == Gate.GateType.SpreadShot)
        {
            CardThrower.instance.spreadShot = true;
        }
        else if (gate._gateType == Gate.GateType.DualShot)
        {
            CardThrower.instance.dualShot = true;

        }
        else if (gate._gateType == Gate.GateType.Range)
        {
            CardThrower.instance.destroyTime += .1f * gate._gateValue;
        }
        else if (gate._gateType == Gate.GateType.ThrowRate)
        {
            CardThrower.instance.spawnTime -= .1f * gate._gateValue;
        }

    }
}
