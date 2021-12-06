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
    [Header("NPC")]
    public GameObject NPCTextFrame;
    public Text NPCText;
    public GameObject NPCtransform;
    [SerializeField]
    private float _offsetNpcFrame;


    private void Awake()
    {
        if (this.gameObject.activeInHierarchy) instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTextFrame.activeSelf)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(_player.transform.position);
            screenPoint.y += _offsetPlayerFrame;
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
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(_player.transform.position);
            screenPoint.y += _offsetPlayerFrame;
            PlayerTextFrame.transform.position = screenPoint;
            PlayerTextFrame.SetActive(true);
            yield return new WaitForSeconds(3);
            PlayerTextFrame.SetActive(false);
            _player.SetHelloText();
            if (_player.IsClickedOnNPC)
            {
                DialogManager.Instance.EndNpcAnimation();
                _player.NpcPlayerDialogFinished();
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
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(NPCtransform.transform.position);
            screenPoint.y += _offsetNpcFrame;
            NPCTextFrame.transform.position = screenPoint;
            NPCTextFrame.SetActive(true);
            yield return new WaitForSeconds(3);
            NPCTextFrame.SetActive(false);
            OnPlayerClick(_player.PlayerText);
        }
    }

}
