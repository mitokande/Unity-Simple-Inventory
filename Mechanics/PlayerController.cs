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
    public GameObject _3dequip;
    private GameObject weapon;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    public void UseItem(InventorySlot slot)
    {
        if (slot.amount>0)
        {
            if (slot.slotid > 0)
            {
                switch (slot.item.type)
                {
                    case ItemType.Food:
                        EatItem(slot);
                        break;
                    case ItemType.Weapon:
                        Equip(slot);
                        break;
                    case ItemType.Armor:
                        Equip(slot);
                        break;
                }
            } 
        }

    }
    public void EatItem(InventorySlot slot)
    {
        if (_playerStat.Hunger >= 2)
        {
            if (slot.amount > 1)
            {
                slot.RemoveAmount(1);
            }
            else{
                slot.UpdateSlot(0, null, 0);
            }
            _playerStat.Hunger -= 2;
        }

    }
    public void Equip(InventorySlot slot)
    {
        if(slot.item.type == ItemType.Weapon && slot.item != _playerStat.playerweapon)
        {
            Destroy(weapon);
            _playerStat.playerweapon = (Weapon)slot.item;
            _playerStat.attackpoints = _playerStat.playerweapon.Attack;
            weapon =  Instantiate(_playerStat.playerweapon._3dOBJ, _3dequip.transform.position, _playerStat.playerweapon._3dOBJ.transform.rotation, _3dequip.transform);
        }
        
    }
}
