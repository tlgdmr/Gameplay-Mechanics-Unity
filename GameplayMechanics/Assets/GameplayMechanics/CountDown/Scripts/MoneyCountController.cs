using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameplayMechanics.CountDown.Scripts
{
    public class MoneyCountController : MonoBehaviour
    {
        [SerializeField] private int initialMoneyValue;
        [SerializeField] private float countAnimationDuration;
        [Space]
        [SerializeField] private Button addButton;
        [SerializeField] private Button subtractButton;
        [Space] 
        [SerializeField] private TMP_Text moneyAmountText;
        public TMP_InputField moneyInputField;

        private int _currentMoneyAmount;
        private int _targetMoneyAmount;
        private Coroutine _countCoroutine;
    
        private void Start()
        {
            _currentMoneyAmount = initialMoneyValue;
            _targetMoneyAmount = initialMoneyValue;
            addButton.onClick.AddListener(OnAddButtonClicked);
            subtractButton.onClick.AddListener(OnSubtractButtonClicked);
            UpdateMoneyAmountText(_currentMoneyAmount);
        }
    
        private void OnAddButtonClicked()
        {
            UpdateMoneyAmount(GetGivenMoneyAmount());
        }
    
        private void OnSubtractButtonClicked()
        {
            UpdateMoneyAmount(-GetGivenMoneyAmount());
        }

        private void UpdateMoneyAmount(int changeAmount)
        {
            if (_countCoroutine != null)
            {
                StopCoroutine(_countCoroutine);
            }
            _targetMoneyAmount = CalculateUpdatedMoneyAmount(changeAmount);
            _countCoroutine = StartCoroutine(CountMoney(_currentMoneyAmount, _targetMoneyAmount));
        }

        private IEnumerator CountMoney(int startMoneyValue, int endMoneyValue)
        {
            float elapsedTime = 0;

            while (elapsedTime < countAnimationDuration)
            {
                elapsedTime += Time.deltaTime;
                _currentMoneyAmount = (int)Mathf.Lerp(startMoneyValue, endMoneyValue, elapsedTime / countAnimationDuration);
                UpdateMoneyAmountText(_currentMoneyAmount);
                yield return null;
            }

            _currentMoneyAmount = endMoneyValue;
            UpdateMoneyAmountText(_currentMoneyAmount);
        }
    
        private int GetGivenMoneyAmount()
        {
            int.TryParse(moneyInputField.text, out var moneyValue);
            return moneyValue;
        }

        private int CalculateUpdatedMoneyAmount(int givenMoneyValue)
        {
            return _targetMoneyAmount + givenMoneyValue;
        }

        private void UpdateMoneyAmountText(int currentMoney)
        {
            moneyAmountText.text = $"${currentMoney}";
        }
    }
}
