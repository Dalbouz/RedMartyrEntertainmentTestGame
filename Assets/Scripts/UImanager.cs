using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    public static UImanager instance;

    [Header("Player")]
    public GameObject PlayerTextFrame;
    public Text PlayerText;
    [SerializeField]
    private float _offsetPlayerFrame;
    [SerializeField]
    private CharacterControl _player;
    [SerializeField]
    private Transform PlayersHead;
    [Header("NPC")]
    public GameObject NPCTextFrame;
    public Text NPCText;
    public Transform NpcHeadPosition;
    [SerializeField]
    private float _offsetNpcFrame;
    public GameObject LableHotSpotText;
    public bool IsHovered = false;


    private void Awake()
    {
        if (this.gameObject.activeInHierarchy) instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsHovered)
        {
            Vector3 CursorPosition =Input.mousePosition;
            CursorPosition.x -= 5;
            LableHotSpotText.SetActive(true);
            LableHotSpotText.transform.position = CursorPosition;
        }

        if (PlayerTextFrame.activeSelf)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(PlayersHead.position);
            screenPoint.y += Screen.height / _offsetPlayerFrame;
            PlayerTextFrame.transform.position = screenPoint;
        }
    }

    public void OnPlayerClick(string txt)
    {
        PlayerText.text = txt;
        StartCoroutine(OnPlayerClk());
    }

    IEnumerator OnPlayerClk()
    {
        if (!PlayerTextFrame.activeSelf)
        {
            PlayerTextFrame.SetActive(true);
            yield return new WaitForSeconds(3);
            PlayerTextFrame.SetActive(false);
            _player.SetHelloText();
            if (DialogManager.Instance.WantToStartDialog)
            {
                DialogManager.Instance.EndDialog();
                _player.Agent.isStopped = false;
            }
            
        }
    }

    public void OnNpcClick(string txt, float offset)
    {
        NPCText.text = txt;
        _offsetNpcFrame = offset;
        StartCoroutine(OnNpcClk());
    }

    IEnumerator OnNpcClk()
    {
        if (!NPCTextFrame.activeSelf)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(NpcHeadPosition.transform.position);
            screenPoint.y += Screen.height / _offsetNpcFrame;
            NPCTextFrame.transform.position = screenPoint;
            NPCTextFrame.SetActive(true);
            yield return new WaitForSeconds(3);
            NPCTextFrame.SetActive(false);
            OnPlayerClick(_player.PlayerText);
        }
    }

}
