using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MovementScript : MonoBehaviour
{
    //Panel ekranlar�na zoom girilsin UI orada ��ks�n.
    public GameObject[] Locations;
    public int State;
    private Sequence sequence;
    private Quaternion nextRot;
    public GameObject[] uiPanels;
    private void Awake()
    {
        State = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && State == 0)
            ChangeState();
    }
    public void MoveToLoc()
    {
        //Camera objesini hareket ettiren kod. Sequence olu�turup Append ile birden fazla tween atayarak �al��t�rd�m.
        Vector3 Rot = new Vector3(16f, 0f, 0f);
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(Locations[State - 1].transform.position, 1)).Append(transform.DORotate(Rot, 1));
        sequence.Play();
    }

    public void ChangeState()
    {
        // Cihazlar aras� ge�i�leri sa�layan fonksiyon.
        for (int i = 0; i < uiPanels.Length; i++)
        {
            uiPanels[i].SetActive(false);
        }
        if(State <=5)
        {
            State++;
            MoveToLoc();
        }
    }
}
