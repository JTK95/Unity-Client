using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System.Net;
using System;

namespace Client
{
    public class PlayerMovement : MonoBehaviour
    {
        SphereMovement sphere;
        public GameObject miniPlayerPrefab;
        public Text _nameText;
        public Text _roomNumberText;

        Animator anim;
        int floorMark;

        public UInt16 _getAccountId;
        public string _getName;
        
        float _horizontal;
        float _vertical;

        Vector3 stopMouse;

        void Start()
        {
            sphere = Instantiate(miniPlayerPrefab, new Vector3(transform.position.x, 65.718f, transform.position.z), new Quaternion(0, 0, 0, 0)).GetComponent<SphereMovement>();
            this.SetID();

            floorMark = LayerMask.GetMask("Floor");
            anim = GetComponent<Animator>();

            stopMouse = Input.mousePosition;

            _nameText = GameCanvas.instance.UICanvas.nameText;
            _nameText.text = AllScene._name;
            _nameText.transform.position = transform.position;

            _roomNumberText = GameCanvas.instance.UICanvas.roomNumberText;
            _roomNumberText.text = "Room : " + AllScene._roomNuber;
        }

        // name 셋팅
        public void SetID()
        {
            _getAccountId = AllScene._uid;
            _getName = AllScene._name;
        }

        void Update()
        {
            _nameText.transform.position = Camera.main.WorldToScreenPoint(
               new Vector3( transform.position.x, transform.position.y + 3f, transform.position.z));

            _horizontal = Input.GetAxisRaw("Vertical");
            _vertical = Input.GetAxisRaw("Horizontal");

            anim.SetBool("IsWalking", _horizontal != 0 || _vertical != 0);

            if (_horizontal != 0 || _vertical != 0 || stopMouse != Input.mousePosition)
            {
                this.Walk();
                stopMouse = Input.mousePosition;
            }

            this.Turning();
        }

        public void Walk()
        {
            Vector3 Direction = new Vector3(_horizontal, 0, -_vertical);
            Direction.Normalize();

            transform.position += Direction * Time.deltaTime * 6f;

            //--------------------------------------------------------------------------------
            // 플레이어 이동 패킷 송신
            // rotation.?값은 쿼터니언값으로 출력이 됨 -> 오일러 각인 eulerAngles로 송신하자
            //--------------------------------------------------------------------------------
            Client.PK_C_REQ_PLAYER_MOVE packet = new Client.PK_C_REQ_PLAYER_MOVE();
            packet._roomNumber = AllScene._roomNuber;
            packet._uid = AllScene._uid;
            packet._charName = AllScene._name;
            packet._Xpos = transform.position.x;
            packet._Ypos = transform.position.y;
            packet._Zpos = transform.position.z;
            packet._Xrot = transform.rotation.eulerAngles.x;
            packet._Yrot = transform.rotation.eulerAngles.y;
            packet._Zrot = transform.rotation.eulerAngles.z;
            Client.NetworkManager.GetInstance.sendPacket(packet);

            // miniPlayer Move
            sphere.SphereMove(packet._Xpos, packet._Zpos);
        }

        void Turning()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit floorHit;
            if (Physics.Raycast(camRay, out floorHit, Mathf.Infinity, floorMark))
            {
                //충돌하면 여기 들어와
                //print(floorHit.point);
                Debug.DrawLine(camRay.origin, floorHit.point);
                transform.LookAt(floorHit.point);
            }
        }
    }
}
