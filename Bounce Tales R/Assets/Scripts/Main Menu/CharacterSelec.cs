using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterSelec : MonoBehaviour
{
    [SerializeField] RectTransform[] MainMenuButtons;
    [SerializeField] RectTransform indicator;
    [SerializeField] float moveDelay;
    [SerializeField] float Speed;
    [SerializeField] Color colorChange;
    public int indicatorPos;
    public float moveTimer;
    private List<Button> buttons = new List<Button>();

    // Update is called once per frame
    private void Awake()
    {
        if (MainMenuButtons != null)
        {
            foreach (var item in MainMenuButtons)
            {
                buttons.Add(item.transform.GetComponent<Button>());
            }
        }
    }
    void Update()
    {
        if (moveTimer <= moveDelay)
        {
            moveTimer += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (moveTimer > moveDelay)
            {
                if (indicatorPos < MainMenuButtons.Length - 1)
                {
                    indicatorPos++;
                }
                else
                {
                    indicatorPos = 0;
                }
                moveTimer = 0;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (moveTimer > moveDelay)
            {
                if (indicatorPos > 0)
                {
                    indicatorPos--;
                }
                else
                {
                    indicatorPos = MainMenuButtons.Length - 1;
                }
                moveTimer = 0;
            }
        }
        indicator.localPosition = Vector3.Lerp(indicator.localPosition, MainMenuButtons[indicatorPos].localPosition, Time.deltaTime * Speed);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ExecuteEvents.Execute<IPointerClickHandler>(buttons[indicatorPos].gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }
        UpdateColor(indicatorPos);
    }

    public void HoverOnButton(int btnPos)
    {
        indicatorPos = btnPos;
    }

    public void ButtonPress()
    {
        Debug.Log("Character " + (indicatorPos));
    }
    private void UpdateColor(int index)
    {
        for (int i = 0; i < MainMenuButtons.Length; i++)
        {

            ColorBlock cb = buttons[i].colors;
            if (i == index)
            {
                cb.normalColor = colorChange;
                cb.selectedColor = colorChange;
                cb.highlightedColor = colorChange;
                buttons[i].colors = cb;
            }
            else
            {
                cb.normalColor = Color.white;
                cb.selectedColor = Color.white;
                cb.highlightedColor = Color.white;
                buttons[i].colors = cb;
            }
        }
    }
}
