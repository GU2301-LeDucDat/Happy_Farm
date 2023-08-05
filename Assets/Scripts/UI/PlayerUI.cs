using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerName;
    [SerializeField]
    private TextMeshProUGUI money;
    [SerializeField]
    private TextMeshProUGUI moneyInShop;
    [SerializeField]
    private Slider hp;
    private void Start()
    {
        StartCoroutine(loadInfoPlayer());
    }

    private IEnumerator loadInfoPlayer()
    {
        yield return new WaitUntil(() => PlayerProfile.Instance.IsInit == true);
        playerName.text = PlayerProfile.Instance.GetPlayerName();
        money.text = PlayerProfile.Instance.GetMoneyAmount().ToString();
        hp.value = PlayerProfile.Instance.GetPlayerHP();
    }

    private void OnEnable()
    {
        PlayerProfile.MONEY_CHANGED += OnCoinChange;
        PlayerProfile.MONEY_CHANGED += OnCoinShopChange;
        PlayerProfile.NAME_CHANGED += NameChanged;
        PlayerProfile.HP_CHANGED += HPChanged;
    }
    private void OnDisable()
    {
        PlayerProfile.MONEY_CHANGED -= OnCoinChange;
        PlayerProfile.MONEY_CHANGED -= OnCoinShopChange;
        PlayerProfile.NAME_CHANGED -= NameChanged;
        PlayerProfile.HP_CHANGED -= HPChanged;
    }

    private void OnCoinChange()
    {
        money.text = PlayerProfile.Instance.SaveGame.Money_Amount.ToString();
    }

    private void OnCoinShopChange()
    {
        moneyInShop.text = PlayerProfile.Instance.SaveGame.Money_Amount.ToString();
    }

    private void NameChanged()
    {
        playerName.text = PlayerProfile.Instance.GetPlayerName();
    }

    private void HPChanged()
    {
        hp.value = PlayerProfile.Instance.GetPlayerHP();
    }
}
