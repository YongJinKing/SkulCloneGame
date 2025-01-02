using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Poseidon_Preset : MonoBehaviour
{
    [SerializeField] private Poseidon_SkillExplain poseidon_SkillExplain;
    [SerializeField] private Poseidon_Identity poseidon_Identity;
    private Transform presetSkillList;
    private Poseidon_PresetSlot[] poseidon_presetSlot;
    private Button[] presetsBtn;
    private int selectedSkillId;
    private bool riggingCheck;
    private List<int> riggingSkillList;

    public class OnPresetSlotBtnActEventArgs : EventArgs
    {
        public List<int> riggingSkillList;
    }
    public event EventHandler<OnPresetSlotBtnActEventArgs> OnPresetSlotBtnAct;
    
    Coroutine onRiggingSkillCoroutine;
    

    private void Start() 
    {
        presetSkillList = transform.GetChild(1);
        poseidon_presetSlot = presetSkillList.GetComponentsInChildren<Poseidon_PresetSlot>();//장착 스킬 클래스 참조
        


        presetsBtn = GetComponentsInChildren<Button>();//장착 스킬 버튼 할당
        for(int i = 0; i < presetsBtn.Length; i++)
        {
            int index = i;
            presetsBtn[index].onClick.AddListener(() => PresetsBtnActInSkillExplain(index));
        }
        poseidon_SkillExplain.OnRiggingSkillAct += OnRiggingSkill_SkillExplain;
        poseidon_Identity.OnIdentityBtnAct += SetRiggingSkillIdentity_Poseidon_Identity;
    }


    

    private void OnRiggingSkill_SkillExplain(object sender, Poseidon_SkillExplain.OnRiggingSkillActEventArgs e)
    {
        selectedSkillId = e.riggingSkillId;
        riggingCheck = e.isRigging;
        RiggingSkillCheck();
        
    }
    private void SetRiggingSkillIdentity_Poseidon_Identity(object sender, Poseidon_Identity.OnIdentityBtnActEventArgs e)
    {
        for(int i = 0; i < presetSkillList.childCount; i++)
        {
            if(selectedSkillId == presetSkillList.GetChild(i).GetComponent<Poseidon_PresetSlot>().id && selectedSkillId != 0)
            {   
                presetSkillList.GetChild(i).GetComponent<Poseidon_PresetSlot>().SetRiggingSkillIdentity(e.index);
                break;
            }
        }
        
    }
    private void RiggingSkillCheck()
    {
        PresetTargetImageInit();
        if(riggingCheck)
        {
            if(onRiggingSkillCoroutine == null)
            {
                onRiggingSkillCoroutine = StartCoroutine(CorRiggingSkill());
            }
        }
        else
        {
            PresetTargetImageInit();
        }
    }
    
    private IEnumerator CorRiggingSkill()
    {
        while(riggingCheck)
        {
            for(int i = 0; i < presetSkillList.childCount; i++)
            {
                poseidon_presetSlot[i].ImageChange();
            }
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
        
    }
    private void PresetsBtnActInSkillExplain(int index)//
    {
        if(riggingCheck)
        {
            SamePresetSlotInit(selectedSkillId);
            PresetTargetImageInit();
            
            presetSkillList.GetChild(index).GetComponent<Poseidon_PresetSlot>().RiggngSkillInPresetSlot(selectedSkillId);
            GetRiggingSkillList();
            riggingCheck = false;

            OnPresetSlotBtnAct?.Invoke(this, new OnPresetSlotBtnActEventArgs
            {
                riggingSkillList = riggingSkillList,
                
            });
        }
    }
    private void SamePresetSlotInit(int id)//프리셋 슬롯에 똑같은 아이디 있으면 초기화 시키는 공정
    {
        for(int i = 0; i < presetSkillList.childCount; i++)
        {
            if(presetSkillList.GetChild(i).GetComponent<Poseidon_PresetSlot>().id == id)
            {
                presetSkillList.GetChild(i).GetComponent<Poseidon_PresetSlot>().RiggngSkillInPresetSlot(0);
                PresetTargetImageInit();
                break;
            }
        }
        
    }

    private void PresetTargetImageInit()
    {
        if(onRiggingSkillCoroutine != null)
        {
            StopCoroutine(CorRiggingSkill());
            onRiggingSkillCoroutine = null;
            
            for(int i = 0; i < presetSkillList.childCount; i++)
            {
                poseidon_presetSlot[i].TargetImageClear();
            }
        }      
    }
    private void GetRiggingSkillList()
    {
        riggingSkillList = new List<int>();
        for(int i = 0; i < presetSkillList.childCount; i++)
        {
            if(presetSkillList.GetChild(i).GetComponent<Poseidon_PresetSlot>().id > 0)
            {

                riggingSkillList.Add(presetSkillList.GetChild(i).GetComponent<Poseidon_PresetSlot>().id);
            }
        }
    }
}
