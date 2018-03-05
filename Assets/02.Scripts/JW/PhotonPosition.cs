using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonPosition : MonoBehaviour {

    Transform MasterClientPosition = null;
    Transform SlaveClientPosition = null;

    GameObject temp = null; //프리팹 꺼내오기

    GameObject RaceC = null;    //첫번째 차량
    GameObject RegularC = null; //두번째 차량

    // Use this for initialization
    void Start () {

        MasterClientPosition = GameObject.Find("MasterClientPosition").GetComponent<Transform>();
        SlaveClientPosition = GameObject.Find("SlaveClientPosition").GetComponent<Transform>();

        if (PhotonNetwork.isMasterClient)//room.PlayerCount == 1)
        {           
            //1번 차량 꺼내온다.
            RaceC = Resources.Load<GameObject>("Character/RaceC");

            //프리팹에 있는 화투패 하이어라키뷰에 끄집어내는데 GameObject의 자식으로 넣는다.
            temp = Instantiate(RaceC, GameObject.Find("ImageTarget").transform);
            temp.transform.position = MasterClientPosition.transform.position;  //꺼내온 프리팹의 위치 잡아주기
            temp.transform.localRotation = MasterClientPosition.transform.rotation;   //꺼내온 프리팹의 각도 잡아주기
        }

        if (PhotonNetwork.isMasterClient == false)
        {
            //2번 차량 꺼내온다.
            RegularC = Resources.Load<GameObject>("Character/RegularC");

            //프리팹에 있는 화투패 하이어라키뷰에 끄집어내는데 GameObject의 자식으로 넣는다.
            temp = Instantiate(RaceC, GameObject.Find("ImageTarget").transform);
            temp.transform.position = SlaveClientPosition.transform.position;  //꺼내온 프리팹의 위치 잡아주기
            temp.transform.localRotation = SlaveClientPosition.transform.rotation;   //꺼내온 프리팹의 각도 잡아주기
        }

    }


}
