using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnClickButtons : MonoBehaviour
{
    private GameObject UI_Current;
    [SerializeField] private GameObject UI_Next;
    [SerializeField] private GameObject UI_More;
    [SerializeField] private GameObject startObj;


    [SerializeField] private bool isLast = false;
    [SerializeField] private bool isMore = false;
    [SerializeField] private bool isRemaining = false;

    private GameObject rightHand;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        UI_Current = this.gameObject;
        rightHand = GameObject.FindWithTag("right");
        startTime = 0;

    }

    float  getL1Dist(GameObject Ga ,GameObject Gb)
    {
        Vector3 a = Ga.transform.position;
        Vector3 b = Gb.transform.position;
        return Mathf.Abs(a.x -0.1f- b.x)+ Mathf.Abs(a.y - b.y)+ Mathf.Abs(a.z - b.z);
    }
    // Update is called once per frame
    void Update()
    {
        if(startTime >1.0f)
        {
            if (getL1Dist(UI_Current, rightHand) < 0.12f)
            {
                OnClicked();
            }
        }
        startTime += Time.deltaTime;
    }

    private void OnClicked()
    {
        
        if (!isLast)
        {
            UI_Next.SetActive(true);
            if(isMore)
            {
                UI_More.SetActive(true);
            }
        }
        else
        {
            Debug.Log("fin1");
            if (this.tag=="Finish")
            {
                Instantiate(startObj, new Vector3(-26.5f, 1.0f, 7.1f),Quaternion.identity);
                startTime = 0;
                
            }
        }
        if(!isRemaining)
            UI_Current.SetActive(false);

    }
}
