using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    private PhotonView pv;
    public UILabel txt;
    // Use this for initialization
    bool isReady = false;

	void Start () {
        pv = PhotonView.Get(this);
        txt = GetComponentInChildren<UILabel>();

        if (PhotonNetwork.isMasterClient)
        {
            txt.text = "참가 중";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (isReady)
            {
                // 마스터클라이언트 방입장
                //SceneManager.LoadScene("04-GameRoom");
                SceneManager.LoadScene("03-AR_GameScene");
                pv.RPC("GoGame", PhotonTargets.Others);
            }
        }
        else
        {
            pv.RPC("ReadyGame", PhotonTargets.MasterClient);
            txt.text = "준비 완료";
        }
    }

    [PunRPC]
    void GoGame()
    {
        //게스트 방입장
        //SceneManager.LoadScene("04-GameRoom");
        SceneManager.LoadScene("03-AR_GameScene");
    }

    [PunRPC]
    void ReadyGame()
    {
        txt.text = "게임 시작";
        isReady = true;
    }
}
