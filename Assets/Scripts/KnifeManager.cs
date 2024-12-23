using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> KnifeList = new List<GameObject>();
    [SerializeField] private GameObject KnifePrefab;
    [SerializeField] private int KnifeCount;
    private int knifeIndex;
    private void Start()
    {
        CreateKnives();
    }
    private void CreateKnives()
    {
        for(int i=0; i<KnifeCount; i++)
        {
            GameObject newKnife = Instantiate(KnifePrefab,transform.position,Quaternion.identity);
            newKnife.SetActive(false);
            KnifeList.Add(newKnife);
        }
        KnifeList[0].SetActive(true);
    }
    public void SetActiveKnife()
    {
        
    }

}
