using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    public enum MoveType
    {
        LOOK_AT, WAY_POINT
    }

    //이동방식 결정할 변수
    public MoveType moveType = MoveType.LOOK_AT;

    private Transform camTr;    //하위에 있는 Main Camera의 Transform 컴포넌트
    private CharacterController cc;

    public Transform[] points;
    public float speed = 1.0f;   //이동속도
    public float damping = 3.0f; //회전속도의 감도
    
    // Start is called before the first frame update
    void Start()
    {
        camTr = Camera.main.transform;  //Camera.main  --> 'MainCamera' 태그가 설정된 Camera 리턴
        cc    = this.gameObject.GetComponent<CharacterController>();
        points = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(moveType)
        {
            case MoveType.LOOK_AT:
                MoveLookAt();
                break;
            
            case MoveType.WAY_POINT:
                MoveWayPoint();
                break;
        }
    }

    void MoveLookAt()
    {
        cc.SimpleMove(camTr.forward * 1.0f); //Vector * 속도 (1m/sec)
    }

    void MoveWayPoint()
    {

    }
}
