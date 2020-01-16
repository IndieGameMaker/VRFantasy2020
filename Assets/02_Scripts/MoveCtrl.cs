﻿using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        camTr = Camera.main.transform;  //Camera.main  --> 'MainCamera' 태그가 설정된 Camera 리턴
        cc    = this.gameObject.GetComponent<CharacterController>();
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
