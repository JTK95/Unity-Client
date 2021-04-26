using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    public class PlayerHealth : MonoBehaviour
    {
        private static PlayerHealth instance;
        public static PlayerHealth Instance { get { return instance; } }
        int Hp;
        int MaxHp = 100;
        bool IsSinking = false;
        bool damaged = false;
        
        public UnityEngine.UI.Slider HpSlider;
        public UnityEngine.UI.Image damageImage;

        ParticleSystem deadParticle;
        AudioSource audio;
        public AudioClip DeathClip;

        void Start()
        {
            deadParticle = GetComponent<ParticleSystem>();
            audio = GetComponent<AudioSource>();
            HpSlider.value = HpSlider.maxValue = Hp = MaxHp;
        }

        void Update()
        {
            if (damaged)
            {
                damageImage.color = new Color(1f, 0, 0, 0.2f);
            }
            else
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, Time.deltaTime);
            }

            if(gameObject.transform.position.y < -6)
            {
                EventManager.current.GameOver();

                //Client.PK_C_REQ_EXIT packet = new Client.PK_C_REQ_EXIT();

            }

            //if (IsSinking)
            //{
            //    gameObject.transform.position += Vector3.down * Time.deltaTime * 0.3f;
            //    if (gameObject.transform.position.y < -2)
            //    {
            //        Destroy(gameObject);
            //    }
            //}

            damaged = false;
        }

        public void TakeDamage(int damage)
        {
            deadParticle.Play();

            //if (Hp <= 0)
            //{
            //    return;
            //}
            
            damaged = true;
            Hp -= damage;
            HpSlider.value = Hp;
         
            if (Hp <= 0)
            {
                Destroy(GetComponent<PlayerMovement>());
                Destroy(GetComponent<CapsuleCollider>());
                Destroy(GetComponentInChildren<PlayerShooting>());

                GetComponent<Animator>().SetTrigger("Death");
                audio.clip = DeathClip;

                EventManager.current.GameOver(); //
            } 
            audio.Play();
        }

        void StartSinking()
        {
            IsSinking = true;
        }
    }
}