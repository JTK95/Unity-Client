using Client;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UserShooting : MonoBehaviour 
{
    public System.UInt16 UID { get; set; }

    ParticleSystem _gunParticle;
    Light _gunLight;

    LineRenderer _gunLine;
   // AudioSource _gunAudio;

    float timeBetweenBullets = 0.15f;
    float timer;

    void Start()
    {
        _gunLine = GetComponent<LineRenderer>();
       // _gunAudio = GetComponent<AudioSource>();
        _gunParticle = GetComponent<ParticleSystem>();
        _gunLight = GetComponent<Light>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenBullets * 0.2f)
        {
            _gunLight.enabled = false;
            _gunLine.enabled = false;
        }
    }


    public void Shoot()
    {
        if (timer >= timeBetweenBullets)
        {
            //_gunAudio.Play();
            _gunParticle.Stop();
            _gunParticle.Play();
            _gunLight.enabled = true;
            _gunLine.enabled = true;
            _gunLine.SetPosition(0, transform.position);

            Ray shootRay = new Ray();
            shootRay.origin = transform.position; // 총구 위치
            shootRay.direction = transform.forward; // 총구 앞 방향

            // 충돌시 받아 올 정보
            RaycastHit shootHit;
            if (Physics.Raycast(shootRay, out shootHit, Mathf.Infinity,
               LayerMask.GetMask("Floor")))
            {
                PlayerHealth playerHealth = shootHit.collider.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    //// 여기선 true 송신
                    //Client.PK_C_REQ_COLLISION_CHECK collisionPacket = new Client.PK_C_REQ_COLLISION_CHECK();
                    //collisionPacket._check = true;
                    //collisionPacket._roomNumber = AllScene._roomNuber;
                    //collisionPacket._accountId = AllScene._uid;
                    //Client.NetworkManager.GetInstance.sendPacket(collisionPacket);
                    
                    playerHealth.TakeDamage(10);
                }

                Debug.Log("floor");
                _gunLine.SetPosition(1, shootHit.point);
            }
            //else if(Physics.Raycast(shootRay, out shootHit, Mathf.Infinity,
            //  LayerMask.GetMask("Player")))
            //{
            //    PlayerHealth playerHealth = shootHit.collider.GetComponent<PlayerHealth>();
            //    if (playerHealth != null)
            //    {
            //        playerHealth.TakeDamage(10);
            //    }
            //    Debug.Log("player");
            //    _gunLine.SetPosition(1, shootHit.point);
            //}
            else
            {
                Debug.Log("floor");
                _gunLine.SetPosition(1, transform.position + (transform.forward * 50f));
            }

            timer = 0f;
        }
    }

}
