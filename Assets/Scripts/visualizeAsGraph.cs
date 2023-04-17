using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public class visualizeAsGraph : MonoBehaviour
{
    public float speed;
    public float distance=0;
    private Vector3 velocity;
    private Vector3 acc;
    private Vector3 currPos;

    private UnityEngine.Vector3 prevPos;
    private float time;
    private GraphMaker graphMaker1;
    private GraphMaker graphMaker2;
    private List<float> speedArray =new List<float>();
    //private List<float> distArray = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        GraphMaker gM = FindObjectOfType<GraphMaker>();
        
        graphMaker1 = gM.GetComponent<GraphMaker>();
        //graphMaker2 = gM[1].GetComponent<GraphMaker>();

        prevPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GraphMaker gM = FindObjectOfType<GraphMaker>();

        graphMaker1 = gM.GetComponent<GraphMaker>();

        time += Time.deltaTime;
        if (time >= 0.2f)
        {
            currPos = this.transform.position;
            velocity = (currPos - prevPos) / 0.2f;
            speed = velocity.magnitude;
            distance+=speed;
            speedArray.Add(speed);
            //distArray.Add(distance/10);
            prevPos = currPos;
            time = 0;
            graphMaker1.DrawGraph(speedArray);
        }
        //when falling down
        if(this.transform.position.y<0)
        {
            //graphMaker1.DrawGraph(speedArray);
            //graphMaker2.DrawGraph(distArray);

            //Debug.Log(this.transform.position.y);
            if (this.transform.position.y <-2)
            {
                Destroy(this.gameObject);
                distance = 0;
            }
         
        }
        
    }
}
