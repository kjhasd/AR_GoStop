using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonInit : MonoBehaviour {
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        PhotonNetwork.ConnectUsingSettings("AR_GoStop 1.0");
    }

    //로비에 입장하였을 때 호출되는 콜백 함수
    void OnJoinedLobby()
    {
        Debug.Log("#1 Joinen Lobby");
        //PhotonNetwork.JoinRandomRoom();
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        RoomOptions opt = new RoomOptions();
        opt.MaxPlayers = 2;
    }

    //랜덤 룸 입장에 실패하였을 때 호출되는 콜백 함수
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("No Room");
        PhotonNetwork.CreateRoom("MyRoom");
    }


    //룸을 생성완료 하였을 때 호출되는 콜백함수
    void OnCreatedRoom()
    {
        Debug.Log("#2 Finish make a room");
        
    }

    //룸에 입장되었을 경우 호출되는 콜백함수
    void OnJoinedRoom()
    {
        Debug.Log("#3 Joined room");

        //플레이어를 생성한다.
        StartCoroutine(MoveToGame());
        //StartCoroutine(SpawnTank());
    }

    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    IEnumerator SpawnTank()
    {
        yield return new WaitForSeconds(1.0f);

        Transform[] sp = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        int idx = Random.Range(1, sp.Length);

        PhotonNetwork.Instantiate("Tank", sp[idx].position, Quaternion.identity, 0);

        PhotonNetwork.isMessageQueueRunning = true;
    }

    IEnumerator MoveToGame()
    {
        SceneManager.LoadScene("02-ReadyRoom");
        PhotonNetwork.isMessageQueueRunning = true;

        yield return null;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
