using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour, IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerEnterHandler,IPointerExitHandler
{
    public DisplayEnvanter displayedslots;
    public MouseItem _mouseitem = new MouseItem();
    public void OnBeginDrag(PointerEventData eventData)
    {
        var mouseslot = new GameObject();
        var rect = mouseslot.AddComponent<RectTransform>();
        rect.sizeDelta = new Vector2(80, 80);
        mouseslot.transform.SetParent(displayedslots.envanterUI.transform.parent);
        //Debug.Log(displayedslots.envanterUI.transform.parent);
        if (displayedslots.itemUI[eventData.pointerDrag.gameObject].slotid > 0)
        {
            var img = mouseslot.AddComponent<Image>();
            img.sprite = displayedslots.itemUI[eventData.pointerDrag.gameObject].item.Icon;
            img.raycastTarget = false;
        }
        _mouseitem.obj = mouseslot;
        _mouseitem.slot = displayedslots.itemUI[eventData.pointerDrag.gameObject];
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(_mouseitem.obj != null)
        {
            _mouseitem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
        }
       
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        ////Debug.Log(_mouseitem.hoveredobj.name);
        //if (_mouseitem.hoveredobj != null)
        //{
        //    Debug.Log(_mouseitem.slot.item.ItemName);
        //    Debug.Log(displayedslots.itemUI[_mouseitem.hoveredobj].item.ItemName);
        //    displayedslots.envanter.SwapItem(_mouseitem.slot, displayedslots.itemUI[_mouseitem.hoveredobj]);
        //}
        //else
        //{
        //  //  Debug.Log(_mouseitem.slot.slotid);
        //}
        Destroy(_mouseitem.obj);
        _mouseitem.slot = null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ////Debug.Log(displayedslots.itemUI[eventData.pointerEnter.gameObject].slotid);
        //_mouseitem.hoveredobj = eventData.pointerEnter.gameObject;
        //if (displayedslots.itemUI.ContainsKey(eventData.pointerEnter.gameObject))
        //{
        //    _mouseitem.hoveredslot = displayedslots.itemUI[eventData.pointerEnter.gameObject];
        //    //
        //}
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //_mouseitem.hoveredslot = null;
        //_mouseitem.hoveredobj = null;
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

public class MouseItem
{
    public GameObject obj;
    public EnvanterSlot slot;
    public EnvanterSlot hoveredslot;
    public GameObject hoveredobj;
}
