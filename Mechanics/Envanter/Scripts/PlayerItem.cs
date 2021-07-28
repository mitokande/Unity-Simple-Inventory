using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public Envanter envanter;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("sdfasf"); 
        var item = other.GetComponent<WorldItem>();
        if (item)
        {
            envanter.AddItem(item.item,1);
            Destroy(other.gameObject);
        }
    }
    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    envanter.Save();
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    envanter.Load();
        //}
    }
    private void OnApplicationQuit()
    {
        
    }

}
