using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    Vector3 movedirection;
    public PlayerStats _playerStat;
    public Text hunger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hunger.text = "Açlýk: " + _playerStat.Hunger;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movedirection = transform.forward * vertical + transform.right * horizontal;
    }

    public void FixedUpdate()
    {
        transform.position = transform.position + movedirection.normalized * Time.deltaTime * speed;
    }
    public void UseItem(EnvanterSlot slot)
    {
        Debug.Log(slot.item.ItemName);
        if (slot.amount>0)
        {
            if (slot.slotid > 0)
            {
                switch (slot.item.type)
                {
                    case ItemType.Food:
                        if (_playerStat.Hunger >= 2)
                        {
                            _playerStat.Hunger -= 2;
                        }
                        if (slot.amount == 1)
                        {
                            slot.UpdateSlot(0, null, 0);
                        }
                        else
                        {
                            slot.RemoveAmount(1);
                        }
                        break;
                }
            } 
        }
        else if(slot.amount == 1)
        {
            if (slot.slotid > 0)
            {
                switch (slot.item.type)
                {
                    case ItemType.Food:
                        
                        
                        break;
                }
            }
        }
    }
}
