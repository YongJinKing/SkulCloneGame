using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Poseidon_SkillSlot : MonoBehaviour
{
    #region variable

    public int id{get; private set;}
    public int identityValue{get; private set;}
    public Sprite sprite{get; private set;} 
    private Transform riggingDisplay;
    private Transform identityDisplay;
    
    #endregion

    private void Awake()
    {
       
        riggingDisplay = transform.GetChild(1);
        identityDisplay = transform.GetChild(2);
    }
    public void Init(int id ,Sprite sprite)
    { 
        this.id = id;
        this.sprite = sprite;
        transform.GetChild(0).GetComponent<Image>().sprite = sprite;

    }
    public void SetRiggingStatus(bool isRigging)
    {
        riggingDisplay.gameObject.SetActive(isRigging);  
    }
    public void SetIdentity(int value)
    {
        identityValue = value;
        if(value != 0)
        {
            identityDisplay.GetChild(1).GetComponent<TMP_Text>().text = value.ToString();
            identityDisplay.gameObject.SetActive(true);
        }
        else
        {
            identityDisplay.gameObject.SetActive(false);
        }
    }
}
