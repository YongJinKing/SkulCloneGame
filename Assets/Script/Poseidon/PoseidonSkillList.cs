using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;
public class PoseidonSkillList : MonoBehaviour
{
    [SerializeField] private Transform skillSlot;
    
    public static PoseidonSkillList instance;
    private PoseidonSkillStaticDataManager poseidonInstance;
    private PoseidonSkillSlot[] poseidonSkillSlots;
    private Button[] slotsBtn;



    public class OnSkillListBtnActEventArgs : EventArgs
    {
        public int index;
        public PoseidonSkillSlot poseidonSkillSlot;
    }
    public event EventHandler<OnSkillListBtnActEventArgs> OnSkillListBtnAct;
    

    
    private void Awake() 
    {
        instance = this;
        
    }
    private void Start()
    {
        
        poseidonInstance  = PoseidonSkillStaticDataManager.GetInstance();
        PoseidonPreset.instance.OnPresetSlotBtnAct += OnPresetSlotBtnAct_PoseidonPreset;
        Init();
    }
    private void Init()
    {
        
        SlotInit();
        ButtonInit();
        poseidonSkillSlots = GetComponentsInChildren<PoseidonSkillSlot>();
    }
    private void SlotInit()
    {
        poseidonInstance.LoadSkillDatas();
        foreach(var data in poseidonInstance.dicSkill_dataTable)
        {
            var skillInstance = Instantiate(skillSlot,transform);
            
            skillInstance.GetComponent<PoseidonSkillSlot>().Init(data.Key, PoseidonSpriteList.instance.GetSprite(data.Key));
        }
    }
    private void ButtonInit()
    {
        slotsBtn = GetComponentsInChildren<Button>();
        for(int i = 0; i < slotsBtn.Length; i++)
        {
            int index = i;
            slotsBtn[index].onClick.AddListener(() => OnSlotBtnAct(index));
        }
    }
    private void OnSlotBtnAct(int index)
    {
        OnSkillListBtnAct?.Invoke(this, new OnSkillListBtnActEventArgs
        {
            index = index,
            poseidonSkillSlot = poseidonSkillSlots[index],
        });
    }
    private void OnPresetSlotBtnAct_PoseidonPreset(object sender, PoseidonPreset.OnPresetSlotBtnActEventArgs e)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<PoseidonSkillSlot>().riggingStatus(false);
        }
        for(int i = 0; i < e.riggingSkillList.Count; i++)
        {
            for(int j = 0; j < transform.childCount; j++)
            {
                if(e.riggingSkillList[i] == transform.GetChild(j).GetComponent<PoseidonSkillSlot>().id)
                {
                    transform.GetChild(j).GetComponent<PoseidonSkillSlot>().riggingStatus(true);
                    break;
                }
            }
        }
    }
    
    


    
}
