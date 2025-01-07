using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class PoseidonPresetSlot : MonoBehaviour
{
    [SerializeField] private Sprite slotImage;
    public bool isChange{get; private set;}

    public int id{get; private set;}


    private Transform targetImage;

    private void Awake() 
    {
        targetImage = transform.GetChild(1);
    }
    public void ImageChange()
    {
        isChange = !isChange;
        targetImage.gameObject.SetActive(isChange);
    }
    public void TargetImageClear()
    {
        targetImage.gameObject.SetActive(false);
    }
    public void RiggngSkillInPresetSlot(int id)
    {
        this.id = id;
        
        if(id == 0)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = slotImage;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().sprite = PoseidonSpriteList.instance.GetSprite(id);          
        }

    }

    
}
