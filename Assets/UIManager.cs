using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Texture2D hand;
    [SerializeField] private Texture2D treathand;

    [SerializeField] private Button treat;
    [SerializeField] private Button tickle;
    [SerializeField] private Slider rat1;
    [SerializeField] private Slider rat2;

    [SerializeField] private RatFSM ratFSM;

    [SerializeField] private TMP_Text dropText;

    public bool heldTreat;

    private IEnumerator statDown;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(hand, Vector2.zero, CursorMode.Auto);
        Cursor.visible = true;
        heldTreat = false;
        dropText.enabled = false;
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
        Cursor.SetCursor(treathand, Vector2.zero, CursorMode.Auto);
        heldTreat = true;

    }

    public void dropTreat()
    {
        Cursor.SetCursor(hand, Vector2.zero, CursorMode.Auto);
        heldTreat = false;
    }

    private IEnumerator StatDown()
    {

        Debug.Log("I was called!");

        yield return new WaitForSeconds(10);
        ratFSM.happiness--;
        yield return new WaitForSeconds(15);
        ratFSM.hunger -= 5;
        yield return new WaitForSeconds(20);
        ratFSM.thirst -= 5;

        if (ratFSM.hunger < 70)
        {
            yield return new WaitForSeconds(10);
            ratFSM.happiness--;
        }
        if (ratFSM.thirst < 70)
        {
            yield return new WaitForSeconds(10);
            ratFSM.happiness--;
        }
    }
}
