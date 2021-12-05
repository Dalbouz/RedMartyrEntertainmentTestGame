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
    private Transform _player;
    [SerializeField]
    private float _offsetPlayerFrame;


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
            yield return new WaitForSeconds(2);
            PlayerTextFrame.SetActive(false);
        }
    }
    
}
