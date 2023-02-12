using System.Collections.Generic;
using UnityEngine;

namespace Rewards
{
    internal class CurrencyView : MonoBehaviour
    {
        private const string WoodKey = nameof(WoodKey);
        private const string DiamondKey = nameof(DiamondKey);
        private const string MetallKey = nameof(MetallKey);
        private const string FoodKey = nameof(FoodKey);
        private const string MoneyKey = nameof(MoneyKey);

        private static CurrencyView _instance;
        public static CurrencyView Instance => _instance;

        [SerializeField] private List<CurrencySlotView> _currencyList;


        private int GetCurrency(RewardType type)
        {
            int currency = 0;
            switch (type)
            {
                case RewardType.Wood:
                    currency = PlayerPrefs.GetInt(WoodKey);
                    break;
                case RewardType.Diamond:
                    currency = PlayerPrefs.GetInt(DiamondKey);
                    break;
                case RewardType.Metall:
                    currency = PlayerPrefs.GetInt(MetallKey);
                    break;
                case RewardType.Food:
                    currency = PlayerPrefs.GetInt(FoodKey);
                    break;
                case RewardType.Money:
                    currency = PlayerPrefs.GetInt(MoneyKey);
                    break;
            }

            return currency;
        }

        private void SetCurrency(RewardType type, int value)
        {
            switch (type)
            {
                case RewardType.Wood:
                    PlayerPrefs.SetInt(WoodKey, value);
                    break;
                case RewardType.Diamond:
                    PlayerPrefs.SetInt(DiamondKey, value);
                    break;
                case RewardType.Metall:
                    PlayerPrefs.SetInt(MetallKey, value);
                    break;
                case RewardType.Food:
                    PlayerPrefs.SetInt(FoodKey, value);
                    break;
                case RewardType.Money:
                    PlayerPrefs.SetInt(MoneyKey, value);
                    break;
            }
        }


        private void Awake() =>
            _instance = this;

        private void OnDestroy() =>
            _instance = null;

        private void Start()
        {
            for (int i = 0; i < _currencyList.Count; i++)
            {
                _currencyList[i].SetData(GetCurrency( _currencyList[i].Type));
            }
        }

        public void AddCurrency(RewardType type, int value)
        {
            SetCurrency(type, GetCurrency(type) + value);

            foreach (CurrencySlotView currency in _currencyList)
            {
                if (currency.Type == type)
                {
                    currency.SetData(GetCurrency(type));
                }
            }
        }
    }
}
