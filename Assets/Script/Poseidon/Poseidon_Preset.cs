using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Poseidon_Preset : MonoBehaviour
{
    [SerializeField] private Poseidon_SkillExplain poseidon_SkillExplain;
    private Transform presetSkillList;
    private Poseidon_PresetSlot[] poseidon_presetSlot;
    private Button[] presetsBtn;
    private int selectedSkillId;
    private bool riggingCheck;
    public event EventHandler OnPresetSlotBtnAct;
    
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
    }


    

    private void OnRiggingSkill_SkillExplain(object sender, Poseidon_SkillExplain.OnRiggingSkillActEventArgs e)
    {
        selectedSkillId = e.riggingSkillId;
        riggingCheck = e.isRigging;
        RiggingSkillCheck();
        
    }
    private void RiggingSkillCheck()
    {
        if(riggingCheck)
        {
            if(onRiggingSkillCoroutine == null)
            {
                onRiggingSkillCoroutine = StartCoroutine(CorRiggingSkill());
            }
        }
        else
        {
            PresetInit();
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
            PresetIdCheck(selectedSkillId);
            presetSkillList.GetChild(index).GetComponent<Poseidon_PresetSlot>().RiggngSkillInPresetSlot(selectedSkillId);
            PresetInit();   
            riggingCheck = false;
        }
    }
    private void PresetIdCheck(int id)
    {
        for(int i = 0; i < presetSkillList.childCount; i++)
        {
            if(presetSkillList.GetChild(i).GetComponent<Poseidon_PresetSlot>().id == id)
            {
                presetSkillList.GetChild(i).GetComponent<Poseidon_PresetSlot>().RiggngSkillInPresetSlot(0);
                PresetInit();
                break;
            }
        }
        
    }

    private void PresetInit()
    {
        if(onRiggingSkillCoroutine != null)
        {
            StopCoroutine(CorRiggingSkill());
            onRiggingSkillCoroutine = null;
            OnPresetSlotBtnAct?.Invoke(this, EventArgs.Empty);
            for(int i = 0; i < presetSkillList.childCount; i++)
            {
                poseidon_presetSlot[i].ImageClear();
            }
        }
        
        
    }
}
