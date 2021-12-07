using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private ItemSO _itemSO;
    public ItemSOdatabase ItemSOdatabase;

    private bool InventoryEnabled;
    public GameObject InventoryBag;
    private CloseInvetory CloseInventoryScript;
    private int AllSlots;
    private ItemInfo[] slot;
    [SerializeField]
    private Camera _cam;
    [SerializeField]
    private GameObject _inventoryButton;

    private void Start()
    {
        CloseInventoryScript = InventoryBag.GetComponent<CloseInvetory>();
        AllSlots = InventoryBag.transform.childCount;

        slot = new ItemInfo[AllSlots];

        for (int i = 0; i < slot.Length; i++)
        {
            slot[i] = InventoryBag.transform.GetChild(i).GetComponent<ItemInfo>();
            slot[i].itemSO = ItemSOdatabase.items[i];
            slot[i].GetComponent<Image>().sprite = slot[i].itemSO.ImageOfItem;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CloseInventoryScript.CanClosePanel)
            {
                OpenCloseInventory();
            }
        }
    }

    public void OpenCloseInventory()
    {
        
        InventoryEnabled = !InventoryEnabled;
        if (InventoryEnabled)
        {
            _inventoryButton.SetActive(false);
            CloseInventoryScript.CanClosePanel = true;
            InventoryBag.SetActive(true);
        }
        else
        {
            InventoryBag.SetActive(false);
            CloseInventoryScript.CanClosePanel = false;
            _inventoryButton.SetActive(true);
        }
    }


}
