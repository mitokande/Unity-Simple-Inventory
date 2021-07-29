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
    public GameObject slot;
    public Dictionary<GameObject, EnvanterSlot> itemUI = new Dictionary<GameObject, EnvanterSlot>();
    public Envanter envanter;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        CreateSlots();
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlots();
        if (Input.GetKeyDown(KeyCode.T))
        {
            envanterUI.SetActive(!envanterUI.activeSelf);
        }
    }
    public void UpdateSlots()
    {
        foreach(KeyValuePair<GameObject,EnvanterSlot> slot in itemUI)
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
        itemUI = new Dictionary<GameObject, EnvanterSlot>();
        for (int i = 0; i < envanter.itemlist.Length; i++)
        {
            var obj = Instantiate(slot, Vector3.zero, Quaternion.identity, envanterUI.transform);
            obj.GetComponent<Button>().onClick.AddListener(delegate { player.UseItem(itemUI[obj]); });
            itemUI.Add(obj, envanter.itemlist[i]);

        }
    }


}
