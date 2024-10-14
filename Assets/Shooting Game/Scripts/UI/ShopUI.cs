using ShootingGame;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace ShootingGame
{
}
public class ShopUI : MonoBehaviour
{
    [SerializeField] private List<ItemData> items;
    [SerializeField] private Transform shopItemContainerPrefab;
    [SerializeField] private Transform shopTemplate;
    [SerializeField] private TextMeshProUGUI curGoldText;

    private Button curButtonItem;


    private IShopCustomer shopCustomer;


    void Start()
    {
        GenerateItems();
        this.Hide();
    }

    public void GenerateItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            int index = i;
            Transform itemContainer = Instantiate(shopItemContainerPrefab, shopTemplate);

            Image image = itemContainer.Find("ImageItem").GetComponent<Image>();
            Button btnItem = itemContainer.Find("BtnItem").GetComponent<Button>();
            TextMeshProUGUI textGold = btnItem.transform.Find("GoldText").GetComponent<TextMeshProUGUI>();

            textGold.text = items[index].goldAmount.ToString();
            image.sprite = items[index].sprite;
            btnItem.onClick.AddListener(() =>
            {
                curButtonItem = btnItem;
                TryBuyItem(items[index]);
            });

        }
    }

    public void TryBuyItem(ItemData item)
    {
        if (shopCustomer.TrySpendGoldAmount(item.goldAmount))
        {
            curButtonItem.interactable = false;
            shopCustomer.BoughtItem(item.itemType);
        }

    }

    private void Update()
    {
        UpdateGoldText();
    }

    public void Show(IShopCustomer shopCustomer)
    {
        Debug.Log("Show shop");
        this.shopCustomer = shopCustomer;
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void UpdateGoldText()
    {
        curGoldText.text = GameController.Ins.manager.GetCurrentGold().ToString();
    }
}

