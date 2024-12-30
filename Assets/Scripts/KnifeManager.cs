using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> KnifeList = new List<GameObject>();
    [SerializeField] private List<GameObject> KnifeIconList = new List<GameObject>();

    [SerializeField] private GameObject KnifePrefab;
    [SerializeField] private GameObject KnifeIconPrefab;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color deActiveColor;
    [SerializeField] private Vector2 knifeIconPosition;
    [SerializeField] private int KnifeCount;
    private int knifeIndex=0;
    private void Start()
    {
        CreateKnives();
        createKnifeIcons();
    }
    private void CreateKnives()
    {
        for(int i=0; i<KnifeCount; i++)
        {
            // harchizi ra ba 3 soal misazad : chi ? koja ? chejori becharkhoonamesh ? 
            GameObject newKnife = Instantiate(KnifePrefab,transform.position,quaternion.identity);
            newKnife.SetActive(false);
            KnifeList.Add(newKnife);
        }
        KnifeList[0].SetActive(true);
    }
    public void setDisableKnifeIconColor()
    {
        KnifeIconList[(KnifeIconList.Count-1) - knifeIndex].GetComponent<SpriteRenderer>().color = deActiveColor;
    }
    private void createKnifeIcons()
    {
        for(int i =0 ; i< KnifeCount ; i++)
        {
            GameObject newKnifeIcon = Instantiate(KnifeIconPrefab,knifeIconPosition,KnifeIconPrefab.transform.rotation);
            // Quaternion.identity = saaf mikhore
            newKnifeIcon.GetComponent<SpriteRenderer>().color=activeColor; 
            knifeIconPosition.y += 0.5f;
            KnifeIconList.Add(newKnifeIcon);
        }
    }



    public void SetActiveKnife()
    {
        if(knifeIndex < KnifeCount )
        {
            knifeIndex++;
            KnifeList[knifeIndex].SetActive(true);
        }
    }

}
