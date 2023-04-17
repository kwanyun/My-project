using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MakeArrow : MonoBehaviour
{
    private float speed;
    private Vector3 prevRot = Vector3.zero;
    private Vector3 prevscale = Vector3.zero;
    private Vector3 velocity;
    private Vector3 acc;
    private Vector3 currPos;
    private Vector3 prevPos;
    [SerializeField] private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        prevPos = parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currPos = parent.transform.position;
        velocity = (currPos - prevPos)/Time.deltaTime;
        speed = velocity.magnitude;
        //print(velocity);
        if(speed > 0.001)
        {
            Vector3 normVel = velocity.normalized*90;
            print(normVel);
            Vector3 tempVel = Vector3.Lerp(normVel, prevRot, 0.1f);
            this.transform.rotation = Quaternion.Euler(tempVel.z, tempVel.y, -tempVel.x);
            Vector3 tempScale = Vector3.Lerp(new Vector3(speed * 10, speed * 15, speed * 10), prevscale, 0.1f);
            this.transform.localScale = tempScale;
            prevRot = normVel;
            prevscale = new Vector3(speed * 10, speed * 15, speed * 10);
        }




        prevPos = parent.transform.position;
    }
}
