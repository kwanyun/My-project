using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphMaker : MonoBehaviour
{
    public GameObject Dot;
    public List<float> speeds;



    public void DrawGraph(List<float> speeds)
    {
        float startPosition = -100;

        float minPosition = -80;
        

        for (int i = 0; i < speeds.Count; i++)
        {
            // 점 오브젝트 생성 및 부모 설정, 각 컴포넌트 가져오기
            
            GameObject dot = Instantiate(Dot, this.gameObject.transform,false);
            //dot.transform.localScale = Vector3.one;

            //Transform dotRT = dot.GetComponent<Transform>();
            //Image dotImage = dot.GetComponent<Image>();


            dot.transform.localPosition = new Vector3(startPosition + (3 * i), minPosition + speeds[i]*25,0);

        }
    }

}