using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class showGraph : MonoBehaviour
{
    GameObject ball;
    public GameObject graph1;
    public GameObject graph2;

    public GameObject info;
    public GameObject text;

    float time =0;
    bool setTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        //ball = FindObjectOfType<visualizeAsGraph>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (setTimer)
        {

            time += Time.deltaTime;
            //Debug.Log(time);
            if (time > 4)
            {
                SpriteRenderer[] tr1 = graph1.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer t1 in tr1)
                {
                    Destroy(t1.gameObject);
                }
                SpriteRenderer[] tr2 = graph1.GetComponentsInChildren<SpriteRenderer>();
                /*foreach (SpriteRenderer t2 in tr2)
                {
                    Destroy(t2.gameObject);
                }*/

                graph1.SetActive(false);
                //graph2.SetActive(false);

                info.SetActive(false);
                time = 0;
                setTimer = false;
            }
        }

        var ballViz = FindObjectOfType<visualizeAsGraph>();
        if (ballViz == null)
            return;
        else 
            ball = ballViz.gameObject;

        text.GetComponent<TMPro.TextMeshProUGUI>().text = new string("Weight : 10KG\nSpeed : " + ballViz.speed+"m/s");

        if (ball.transform.position.y < 0.5f)
        {
            setTimer = true;
        }


        print(ball.transform.position.y);
        if(ball.transform.position.y >0.8f)
        {
            //Instantiate(graph,this.gameObject.transform);
            graph1.SetActive(true);
            //graph2.SetActive(true);

            info.SetActive(true);
        }
    }
}
