using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Texture2D hand;
    [SerializeField] private Texture2D treathand;

    [SerializeField] private Button treat;
    [SerializeField] private Button tickle;
    [SerializeField] private Slider rat1;
    [SerializeField] private Slider rat2;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(hand, Vector2.zero, CursorMode.Auto);
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void holdTreat()
    {
        Cursor.SetCursor(treathand, Vector2.zero, CursorMode.Auto);
    }

    public void dropTreat()
    {
        Cursor.SetCursor(hand, Vector2.zero, CursorMode.Auto);
    }
}
