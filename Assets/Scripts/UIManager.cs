using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameData _gameData;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject[] MenuItems;
    [SerializeField] private TextMeshProUGUI rangeLevelText, rangeMoneyText, incomeLevelText, incomeMoneyText,moneyText;

    private void Awake()
    {
        SaveManager.LoadData(_gameData);
        if (instance == null)
        {
            instance = this;
        }
        SetTexts();
    }

    void SetTexts()
    {
        rangeLevelText.text = "Level " + _gameData.RangeIncrementalLevel;
        rangeMoneyText.text = "" + _gameData.RangeUpgradeMoney;

        incomeLevelText.text = "Level " + _gameData.IncomeIncrementalLevel;
        incomeMoneyText.text = "" + _gameData.IncomeUpgradeMoney;
        SetMoneyText();
    }

    public void SetMoneyText()
    {
        moneyText.text = "" + _gameData.Money;

        SaveManager.SaveData(_gameData);


    }

    public void RangeUpgrade()
    {
        if(_gameData.Money > _gameData.RangeUpgradeMoney)
        {
            _gameData.Money -= _gameData.RangeUpgradeMoney;
            _gameData.RangeIncrementalLevel++;
            _gameData.RangeUpgradeMoney += 5;
            _gameData.Range += .1f;

            rangeLevelText.text = "Level " + _gameData.RangeIncrementalLevel;
            rangeMoneyText.text = "" + _gameData.RangeUpgradeMoney;

            SetMoneyText();
            SaveManager.SaveData(_gameData);

        }
    }

    public void IncomeUpgrade()
    {
        if(_gameData.Money > _gameData.IncomeUpgradeMoney)
        {
            _gameData.Money -= _gameData.IncomeUpgradeMoney;
            _gameData.IncomeIncrementalLevel++;
            _gameData.IncomeUpgradeMoney += 5;
            _gameData.Income++;

            incomeLevelText.text = "Level " + _gameData.IncomeIncrementalLevel;
            incomeMoneyText.text = "" + _gameData.IncomeUpgradeMoney;

            SetMoneyText();
            SaveManager.SaveData(_gameData);

        }
    }

    public void OffMenu()
    {
        for(int i=0; i<MenuItems.Length; i++)
        {
            MenuItems[i].SetActive(false);
        }
    }

    public IEnumerator OpenWinPanel()
    {
        yield return new WaitForSeconds(1);

        _winPanel.SetActive(true);
    }
}
