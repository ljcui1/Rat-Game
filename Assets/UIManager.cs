using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CursorController cc;

    [SerializeField] private Button treat;
    [SerializeField] private Button tickle;
    [SerializeField] private Slider rat1;
    [SerializeField] private Slider rat2;

    [SerializeField] private RatFSM ratFSM;

    [SerializeField] private TMP_Text dropText;

    public bool heldTreat;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.SetCursor(hand, Vector2.zero, CursorMode.Auto);
        //Cursor.visible = true;
        heldTreat = false;
        dropText.enabled = false;

        StartCoroutine(HappyStatDown());
        StartCoroutine(HungerStatUp());
        StartCoroutine(ThirstStatUp());
        StartCoroutine(NotTakenCare());
    }

    // Update is called once per frame
    void Update()
    {
        dropText.enabled = heldTreat;
        rat1.value = ratFSM.happiness;
        if (ratFSM.happiness > 100)
        {
            rat1.value = 100;
        }
        
    }

    public void holdTreat()
    {
        //Cursor.SetCursor(treathand, Vector2.zero, CursorMode.Auto);
        cc.sr.sprite = cc.treathand;
        heldTreat = true;

    }

    public void dropTreat()
    {
        //Cursor.SetCursor(hand, Vector2.zero, CursorMode.Auto);
        cc.sr.sprite = cc.hand;
        heldTreat = false;
    }

    private IEnumerator HappyStatDown()
    {
        //Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
        yield return new WaitForSeconds(10);
        ratFSM.happiness--;
        yield return StartCoroutine(HappyStatDown());
    }
    private IEnumerator HungerStatUp()
    {
        yield return new WaitForSeconds(15);
        ratFSM.hunger -= 5;
        yield return StartCoroutine(HungerStatUp());
    }
    private IEnumerator ThirstStatUp()
    {
        yield return new WaitForSeconds(20);
        ratFSM.thirst -= 5;
        yield return StartCoroutine(ThirstStatUp());
    }
    private IEnumerator NotTakenCare()
    {
        yield return new WaitForSeconds(10);
        if (ratFSM.hunger < 70)
        {
            ratFSM.happiness--;
        }
        if (ratFSM.thirst < 70) 
        {
            ratFSM.happiness--;
        }
        yield return StartCoroutine(NotTakenCare());
    }
}
