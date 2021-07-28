using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemDrop : MonoBehaviour, IDropHandler
{

    public DisplayEnvanter displayedslots;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.gameObject.name);
        Debug.Log(this.name);
        displayedslots.envanter.SwapItem(displayedslots.itemUI[eventData.pointerDrag.gameObject], displayedslots.itemUI[this.gameObject]);
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
