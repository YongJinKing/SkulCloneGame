using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PoseidonSkillList : MonoBehaviour
{
    [SerializeField] private Transform skillSlot;
    private Poseidon_Preset poseidon_preset;
    private Poseidon_Identity poseidon_identity;
    
    private PoseidonSkillStaticDataManager poseidonInstance;
    private Button[] slotsBtn;



    public class OnSkillListBtnActEventArgs : EventArgs
    {
        public int index;
    }
    public event EventHandler<OnSkillListBtnActEventArgs> OnSkillListBtnAct;

    // Start is called before the first frame update
    private void Start()
    {
        poseidonInstance  = PoseidonSkillStaticDataManager.GetInstance();
        poseidon_preset = PoseidonMainBar.instance.skillPreset.GetComponent<Poseidon_Preset>();
        poseidon_identity = PoseidonMainBar.instance.skillIdentity.GetComponent<Poseidon_Identity>();
        poseidon_preset.OnPresetSlotBtnAct += OnPresetSlotBtnAct_Poseidon_Preset;
        poseidon_identity.OnIdentityBtnAct += OnPresetSlotBtnAct_poseidon_identity;
        Init();
    }
    private void Init()
    {
        poseidonInstance.LoadSkillDatas();
        foreach(var data in poseidonInstance.dicSkill_dataTable)
        {
            var skillInstance = Instantiate(skillSlot,transform);
            
            skillInstance.GetComponent<Poseidon_SkillSlot>().Init(data.Key, Poseidon_SpriteList.instance.GetSprite(data.Key));
        }
        slotsBtn = GetComponentsInChildren<Button>();
        
        for(int i = 0; i < slotsBtn.Length; i++)
        {
            int index = i;
            slotsBtn[index].onClick.AddListener(() => OnSkillListBtnAct?.Invoke(this, new OnSkillListBtnActEventArgs
            {
                index = index
            }));
        }
    }
    private void OnPresetSlotBtnAct_Poseidon_Preset(object sender, Poseidon_Preset.OnPresetSlotBtnActEventArgs e)
    {

        RiggingInit();
        for(int i = 0; i < e.riggingSkillList.Count; i++)
        {
            var slotIndex = GetSkillSlotIndex(e.riggingSkillList[i]);
            if(slotIndex != -1)
            {
                transform.GetChild(slotIndex).GetComponent<Poseidon_SkillSlot>().SetRiggingStatus(true);
                
            }
        }
    }
    private void OnPresetSlotBtnAct_poseidon_identity(object sender, Poseidon_Identity.OnIdentityBtnActEventArgs e)
    {
        var slotIndex = GetSkillSlotIndex(e.selectedSkillId);
        transform.GetChild(slotIndex).GetComponent<Poseidon_SkillSlot>().SetIdentity(e.index);
    }


    private void RiggingInit()//장착 상태 초기화
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Poseidon_SkillSlot>().SetRiggingStatus(false);
        }
    }



    private int GetSkillSlotIndex(int id)//id를 삽입하면, 해당 아이디를 가진 스킬 슬롯의 위치를 반환함
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(id == transform.GetChild(i).GetComponent<Poseidon_SkillSlot>().id)
            {
                return i;
            }
        }
        return -1;
    }
}
