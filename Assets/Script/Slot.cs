using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using System;

public class Slot : MonoBehaviour
{
    private int id;
    
    public static event Action<int> OnBtnClick;

    private Button button;

    private void Awake() 
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => BtnAct(id));
    }
    private void Start() 
    {
        var skullInstance = SkullStaticDataManager.GetInstance();
        skullInstance.LoadSkullDatas();
        var skullData = skullInstance.dicSkull_DataTable[id];
        transform.GetComponent<Image>().sprite = Resources.Load<Sprite>($"SkulImage/{skullInstance.dicSkull_ImageResourcesTable[skullData.skull_imageName].skull_imageResources_imageName}");
    }
    
    public void Init(int id)
    {
        this.id = id;
    }

    private void BtnAct(int id)
    {
        OnBtnClick?.Invoke(id);
    }

}
