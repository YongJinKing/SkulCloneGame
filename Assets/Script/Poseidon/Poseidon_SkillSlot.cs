using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poseidon_SkillSlot : MonoBehaviour
{
    #region variable

    public int id{get; private set;}
    public Sprite sprite{get; private set;}


    
    private bool isRigging;
    private Transform riggingText;
    
    #endregion

    private void Awake()
    {
       
        riggingText = transform.GetChild(1);
    }
    public void Init(int id ,Sprite sprite)
    { 
        this.id = id;
        this.sprite = sprite;
        transform.GetChild(0).GetComponent<Image>().sprite = sprite;

    }
    public void riggingStatus()
    {
        isRigging = !isRigging;
        riggingText.gameObject.SetActive(isRigging);  
    }
}
