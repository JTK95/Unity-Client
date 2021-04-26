using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Client
{
    public class PlayerShooting : MonoBehaviour
    {
        ParticleSystem gunParticle;
        Light gunLight;

        LineRenderer gunLine;
        AudioSource gunAudio;
        float timeBetweenBullets = 0.15f;

        public System.UInt16 _getAccountId;

        void Start()
        {
            this.SetID();

            gunLine = GetComponent<LineRenderer>();
            gunAudio = GetComponent<AudioSource>();
            gunParticle = GetComponent<ParticleSystem>();
            gunLight = GetComponent<Light>();
        }

        void SetID()
        {
            _getAccountId = AllScene._uid;
        }

        void Shoot()
        {
            gunAudio.Play();
            gunParticle.Stop();
            gunParticle.Play();
            gunLight.enabled = true;
            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            Ray ShootRay = new Ray();
            ShootRay.origin = transform.position; // 총구 위치
            ShootRay.direction = transform.forward; // 총구 앞 방향

            // bullet 패킷 송신
            Client.PK_C_REQ_BULLET_SHOOT shootPacket = new Client.PK_C_REQ_BULLET_SHOOT();
            shootPacket._roomNumber = AllScene._roomNuber;
            shootPacket._uid = _getAccountId;
            Client.NetworkManager.GetInstance.sendPacket(shootPacket);

            // 충돌시 받아 올 정보
            RaycastHit ShootHit;
            if (Physics.Raycast(ShootRay, out ShootHit, Mathf.Infinity,
                LayerMask.GetMask("Floor")))
            {
                User user = ShootHit.collider.GetComponent<User>();
                if (user != null)
                {
                    // 여기서 충돌체크 패킷 송신
                    Client.PK_C_REQ_COLLISION_CHECK collisionPacket = new Client.PK_C_REQ_COLLISION_CHECK();
                    collisionPacket._roomNumber = AllScene._roomNuber;
                    collisionPacket._uid = user.GetUserUID();
                    Client.NetworkManager.GetInstance.sendPacket(collisionPacket);
                }

                gunLine.SetPosition(1, ShootHit.point);
            }
            //else if (Physics.Raycast(ShootRay, out ShootHit, Mathf.Infinity,
            //    LayerMask.GetMask("OtherPlayer")))
            //{
            //    User user = ShootHit.collider.GetComponent<User>();
            //    if (user != null)
            //    {
            //        user.TakeDamage(10);
            //    }

            //    gunLine.SetPosition(1, ShootHit.point);
            //}
            else
            {
                gunLine.SetPosition(1, transform.position + (transform.forward * 50f));
            }
        }

        float timer;
        void Update()
        {
            timer += Time.deltaTime;
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
                {
                    this.Shoot();
                    timer = 0f;
                }
            }

            if (timer >= timeBetweenBullets * 0.2f)
            {
                gunLight.enabled = false;
                gunLine.enabled = false;
            }
        }
    }
}