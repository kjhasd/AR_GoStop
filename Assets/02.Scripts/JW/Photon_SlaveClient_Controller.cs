using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Photon_SlaveClient_Controller : MonoBehaviour
{
    public float moveSpeed =0.0f;
    public float rotSpeed = 120.0f;

    private PhotonView pv;
    private Vector3 currPos;
    private Quaternion currRot1;

    CharacterController characterController = null;

    // Use this for initialization
    void Start()
    {
        pv = GetComponent<PhotonView>();
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        //if (pv.isMine == false && PhotonNetwork.connected == true)
        //{
        //    //네트웍으로 연결된 다른 유저일 경우에는 실시간 전송받는 변수를 이용해 이동시켜준다.
        //    transform.position = Vector3.Lerp(transform.position, currPos, Time.smoothDeltaTime * 100.0f);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, currRot1, Time.smoothDeltaTime * 100.0f);
        //}

        if (PhotonNetwork.isMasterClient)
        {
            //네트웍으로 연결된 다른 유저일 경우에는 실시간 전송받는 변수를 이용해 이동시켜준다.
            transform.position = Vector3.Lerp(transform.position, currPos, Time.deltaTime * 100.0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, currRot1, Time.deltaTime * 100.0f);
        }

        if (PhotonNetwork.isMasterClient == false)
        {

            float amtRot = rotSpeed * Time.deltaTime;

            float x = CrossPlatformInputManager.GetAxis("Horizontal");
            float z = CrossPlatformInputManager.GetAxis("Vertical");
            
            transform.Rotate(-Vector3.up * x * amtRot);

            Vector3 moveDirection = new Vector3(x, 0, z);
            //moveDirection *= moveSpeed;

            //characterController.Move(moveDirection * Time.deltaTime);


            if (CrossPlatformInputManager.GetButton("Move"))
            {
                characterController.Move(transform.forward * moveSpeed * Time.deltaTime);
                if(moveSpeed < 200.0f)
                {
                    moveSpeed += 2.0f;
                }
                
            }
            else
            {
                moveSpeed = 0.0f;
            }
        }
    }
    //동기화 콜백함수
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            //Debug.Log("transform.position == >" + transform.position);
            // Debug.Log("transform.rotation == >" + transform.rotation);
        }
        else
        {
            currPos = (Vector3)stream.ReceiveNext();
            //Debug.Log("currPos ==>" + currPos);
            currRot1 = (Quaternion)stream.ReceiveNext();
            // Debug.Log("currRot1 ==>" + currRot1);
        }
    }

}
