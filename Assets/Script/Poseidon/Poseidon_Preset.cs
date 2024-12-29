using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Poseidon_Preset : MonoBehaviour
{
    [SerializeField] private Poseidon_SkillExplain poseidon_SkillExplain;
    private Transform presetSkillList;
    private Poseidon_PresetSlot[] poseidon_PresetSlot;
    private bool riggingCheck;
    Coroutine onRiggingSkillCoroutine;
    

    private void Start() 
    {
        presetSkillList = transform.GetChild(1);
        poseidon_PresetSlot = presetSkillList.GetComponentsInChildren<Poseidon_PresetSlot>();
        poseidon_SkillExplain.OnRiggingSkillAct += OnRiggingSkill;
    }


    

    private void OnRiggingSkill(object sender, Poseidon_SkillExplain.OnRiggingSkillActEventArgs e)
    {
        riggingCheck = e.isRigging;
        if(e.isRigging)
        {
            if(onRiggingSkillCoroutine == null)
            {
                onRiggingSkillCoroutine = StartCoroutine(CanRiggingSkill());
            }
        }
        else
        {
            if(onRiggingSkillCoroutine != null)
            {
                StopCoroutine(CanRiggingSkill());
                onRiggingSkillCoroutine = null;
                for(int i = 0; i < presetSkillList.childCount; i++)
                {
                    poseidon_PresetSlot[i].ImageClear();
                }
            }
            
        }
    }
    private IEnumerator CanRiggingSkill()
    {
        while(riggingCheck)
        {
            for(int i = 0; i < presetSkillList.childCount; i++)
            {
                poseidon_PresetSlot[i].ImageChange();
            }
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
        
    }

}
