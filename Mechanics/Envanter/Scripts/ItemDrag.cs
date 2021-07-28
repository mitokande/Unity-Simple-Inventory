using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour, IBeginDragHandler,IEndDragHandler,IDragHandler
{
    public DisplayEnvanter displayedslots;
    public GameObject mouseslot;
    public void OnBeginDrag(PointerEventData eventData)
    {
        mouseslot = new GameObject();
        var rect = mouseslot.AddComponent<RectTransform>();
        rect.sizeDelta = new Vector2(50, 50);
        mouseslot.transform.SetParent(displayedslots.envanterUI.transform.parent);
        //Debug.Log(displayedslots.envanterUI.transform.parent);
        if (displayedslots.itemUI[eventData.pointerDrag.gameObject].slotid > 0)
        {
            var img = mouseslot.AddComponent<Image>();
            img.sprite = displayedslots.itemUI[eventData.pointerDrag.gameObject].item.Icon;
            img.raycastTarget = false;
        }
        GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<SmoothMouseLook>()[0].enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<SmoothMouseLook>()[1].enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(mouseslot != null)
        {
            mouseslot.GetComponent<RectTransform>().position = Input.mousePosition;
        }
       
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(mouseslot);
        GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<SmoothMouseLook>()[0].enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<SmoothMouseLook>()[1].enabled = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        displayedslots = GameObject.FindGameObjectWithTag("Player").GetComponent<DisplayEnvanter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

