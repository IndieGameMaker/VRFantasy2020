using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    public Transform camTr;    //하위에 있는 Main Camera의 Transform 컴포넌트
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
        
    }
}
