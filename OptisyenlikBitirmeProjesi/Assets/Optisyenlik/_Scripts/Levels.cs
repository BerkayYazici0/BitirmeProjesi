using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Levels : MonoBehaviour
{
    public MovementScript movementScript;
    [Header("Level1 Props")]
    public Transform Lens;
    public Transform lensKonum;
    public GameObject Level1Panel;
    public Text AText; //Lensin açýsýný verir.
    public Text AReçete;
    private int AReceteDeger;
    private int ADegeri = 0;
    public GameObject nextLevelBtn1;

    [Header("Level2 Props")]
    public GameObject level2Panel;
    public GameObject infoText;
    public GameObject clickText;
    public GameObject nextLevelBtn2;

    [Header("Level3 Props")]
    public GameObject level3Panel;
    public GameObject dataTextler; // Tracer butonuna basýnca açýlacaklar.
    public GameObject nextLevelBtn3;
    public GameObject ucNokta; // hareket ettirilecek.

    [Header("Level4 Props")]
    public GameObject level4Panel;
    public GameObject modelBtn;
    public GameObject modelCagir;
    public GameObject nextLevelBtn4;
    private void Awake()
    {
        AReceteDeger = Random.Range(0, 360);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo; //Iþýn atýp lensi makinaya gönderdik.
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Lens")
                {
                    Lens.DOMove(lensKonum.position, 1f).OnComplete(() => Level1Panel.SetActive(true));
                    AReçete.text = AReceteDeger.ToString();
                    Lens.tag = "Untagged";
                }
                if (hitInfo.collider.gameObject.tag == "Gozluk")
                {
                    level2Panel.SetActive(true);
                }
                if (hitInfo.collider.gameObject.tag == "LensSv3")
                {
                    level3Panel.SetActive(true);
                }
                if (hitInfo.collider.gameObject.tag == "LensSv4")
                {
                    level4Panel.SetActive(true);
                }
            }
        }

        if (Input.GetKey(KeyCode.D) && movementScript.State == 1)
        {
            //Lens saða döner.
            ADegeri++;
            AText.text = ADegeri.ToString();

        }
        if (Input.GetKey(KeyCode.A) && movementScript.State == 1)
        {
            //Lens sola döner.
            ADegeri--;
            AText.text = ADegeri.ToString();
        }

        if (ADegeri == AReceteDeger)
        {
            ADegeri = 0;
            nextLevelBtn1.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.A) && movementScript.State == 3)
            ucNokta.GetComponent<RectTransform>().position -= new Vector3(15f, 0f, 0f);
        if (Input.GetKeyDown(KeyCode.D) && movementScript.State == 3)
            ucNokta.GetComponent<RectTransform>().position += new Vector3(15f, 0f, 0f);
        if (Input.GetKeyDown(KeyCode.S) && movementScript.State == 3)
            ucNokta.GetComponent<RectTransform>().position -= new Vector3(0f, 15f, 0f);
        if (Input.GetKeyDown(KeyCode.W) && movementScript.State == 3)
            ucNokta.GetComponent<RectTransform>().position += new Vector3(0f, 15f, 0f);
        if (movementScript.State != 3)
            level3Panel.SetActive(false);
        if (movementScript.State != 4)
            level4Panel.SetActive(false);

        if (movementScript.State == 4 && Input.GetKeyDown(KeyCode.Space))
            nextLevelBtn4.SetActive(true);
    }

    public void SaveButton()
    {
        nextLevelBtn3.SetActive(true);
    }

    public void TracerButton()
    {
        dataTextler.SetActive(true);
    }

    public void ModelCagir()
    {
        modelCagir.SetActive(true);
    }
    public void CamOlcumu()
    {
        infoText.SetActive(false);
        clickText.SetActive(true);
        nextLevelBtn2.SetActive(true);
    }
}
