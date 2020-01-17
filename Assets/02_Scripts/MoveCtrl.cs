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
    public float speed   = 1.0f; //이동속도
    public float damping = 3.0f; //회전속도의 감도
    public int nextIdx   = 1;

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
        //이동할 웨이포인트를 향하는 벡터 계산
        Vector3 dir = points[nextIdx].position - transform.position;
        //Quaternion 산출
        Quaternion rot = Quaternion.LookRotation (dir);
        //점진적으로 회전 (Slerp)
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * damping);
        //전진
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    /*  정규화 벡터 / Normalized Vector / 단위벡터 / Unit Vector
        Vector3.forward = Vector3(0, 0, 1)
        Vector3.up      = Vector3(0, 1, 0)
        Vector3.right   = Vector3(1, 0, 0)
        Vector3.zero    = Vector3(0, 0, 0)
        Vector3.one     = Vector3(1, 1, 1)    
    */
}
