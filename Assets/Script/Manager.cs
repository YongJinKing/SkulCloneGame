using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Manager : MonoBehaviour
{
    [SerializeField]private Transform slotGrid;
    [SerializeField]private Transform slot;
    private void Start() 
    {
        var skullInstance = SkullStaticDataManager.GetInstance();
        skullInstance.LoadSkullDatas();
        foreach(var data in skullInstance.dicSkullDataTable)
        {
            Transform instantSlot = Instantiate(slot,slotGrid);
            instantSlot.GetComponent<Slot>().Init(data.Key);
        }
        
    }
}
