using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    public Sprite hand;
    public Sprite treathand;
    //public SpriteRenderer sr;
    public Image cursor;
    private Vector3 mousePos;
    private Vector3 realMouse;

    [SerializeField] private RatFSM rat;

    private IEnumerator pet;
    // Start is called before the first frame update
    void Start()
    {
        cursor = this.GetComponent<Image>();
        if (cursor == null)
        {
            Debug.LogError("Image component not found on this GameObject.");
            return;
        }

        if (hand == null)
        {
            Debug.LogError("Hand sprite is not assigned.");
            return;
        }
        //sr.sprite = hand;
        //Debug.Log(hand);
        cursor.sprite = hand;
        Debug.Log(cursor.sprite);

        pet = Tickle();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //realMouse = new Vector3(mousePos.x, mousePos.y, -1);

        this.transform.position = mousePos;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("rat") && rat.currentState == rat.roamState)
        {
            Debug.Log("TICKLE TICKLE");
            rat.SwitchState(rat.tickleState);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("rat") && rat.currentState == rat.tickleState)
        {
            StartCoroutine(pet);
            //rat.happiness++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("rat"))
        {
            rat.SwitchState(rat.roamState);
        }
    }

    private IEnumerator Tickle()
    {
        rat.happiness += 2;
        yield return new WaitForSeconds(2);
    }
}
