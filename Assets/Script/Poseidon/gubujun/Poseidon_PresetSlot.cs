using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Poseidon_PresetSlot : MonoBehaviour
{
    [SerializeField] private Sprite slotImage;

    public bool isChange{get; private set;}

    public int id{get; private set;}


    private Transform targetImage;
    private Transform identity;

    private void Awake() 
    {
        targetImage = transform.GetChild(1);
        identity = transform.GetChild(2);
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
            transform.GetChild(0).GetComponent<Image>().sprite = Poseidon_SpriteList.instance.GetSprite(id);          
        }
    }
    public void SetRiggingSkillIdentity(int index)
    {
        identity.gameObject.SetActive(true);
        if(index != 0)
        {
            identity.GetChild(1).GetComponent<TMP_Text>().text = index.ToString();
        }
        else
        {
            identity.gameObject.SetActive(false);
        }
        
    }

    
}
