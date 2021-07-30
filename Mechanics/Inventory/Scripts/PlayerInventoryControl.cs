using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine.UI;

public class PlayerInventoryControl : MonoBehaviour
{
    public Inventory playerEnvanter;
    public string savepath;
    public GameObject Interact;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            Load();
        }

        int layerMask = 1 << 8;
        RaycastHit hit;
        if (Physics.Raycast(transform.GetChild(0).position, transform.GetChild(0).forward, out hit, 5f, layerMask))
        {

            Interact.SetActive(true);

            var item = hit.collider.gameObject.GetComponent<WorldItem>();
            Interact.transform.GetChild(0).GetComponent<Image>().sprite = item.item.Icon;
            if (Input.GetKeyDown(KeyCode.F))
            {
                playerEnvanter.AddItem(item.item, item.amount);
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            Interact.SetActive(false);
        }

    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savepath));
        string savedata = JsonUtility.ToJson(playerEnvanter);
        bf.Serialize(file, savedata);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savepath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savepath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), playerEnvanter);
            file.Close();
        }
    }
}
