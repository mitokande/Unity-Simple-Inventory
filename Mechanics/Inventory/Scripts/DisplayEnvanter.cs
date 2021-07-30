using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DisplayEnvanter : MonoBehaviour
{
    public GameObject envanterUI;
    public GameObject inventoryUI;
    public GameObject slot;
    public Dictionary<GameObject, InventorySlot> itemUI = new Dictionary<GameObject, InventorySlot>();
    public Inventory envanter;
    public PlayerController player;

    public List<Text> stattexts = new List<Text>();
    // Start is called before the first frame update
    void Start()
    {
        CreateSlots();
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        stattexts[0].text = "Player Name: " + player._playerStat.PlayerName;
        stattexts[1].text = "Attack Points: " + player._playerStat.attackpoints;
        stattexts[2].text = "Defence Points: " + player._playerStat.defencepoints;
        stattexts[3].text = "Health: " + player._playerStat.Health;
        stattexts[4].text = "Hunger:" + player._playerStat.Hunger;
        UpdateSlots();
        if (Input.GetKeyDown(KeyCode.T))
        {
            envanterUI.SetActive(!envanterUI.activeSelf);
        }
    }
    public void UpdateSlots()
    {
        foreach(KeyValuePair<GameObject, InventorySlot> slot in itemUI)
        {
            if(slot.Value.slotid > 0)
            {
                
                slot.Key.transform.GetChild(0).GetComponent<Image>().sprite = slot.Value.item.Icon;
                slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = slot.Value.amount.ToString();
                slot.Key.transform.GetChild(0).GetComponent<Image>().color = Color.white;
            }
            else
            {
                slot.Key.transform.GetChild(0).GetComponent<Image>().color = Color.gray;
                slot.Key.transform.GetChild(0).GetComponent<Image>().sprite = null;
                slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }
    public void CreateSlots()
    {
        itemUI = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < envanter.itemlist.Length; i++)
        {
            var obj = Instantiate(slot, Vector3.zero, Quaternion.identity, inventoryUI.transform);
            obj.GetComponent<Button>().onClick.AddListener(delegate { player.UseItem(itemUI[obj]); });
            itemUI.Add(obj, envanter.itemlist[i]);

        }
    }


}
