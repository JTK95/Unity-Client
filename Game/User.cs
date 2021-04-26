using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
	public class User : MonoBehaviour
	{
		public Text _enemynameText;
		//public GameObject _enemynameText;

		public Vector3 prevPos { get; set; }
		public System.UInt16 UID { get; set; }

		public string CharName { get; set; }

		public bool IsMove = false;

		public UserShooting _gun;
		public UInt16 _uid;

		// userHealth
		int _hp;
		int _maxHp = 100;
		bool IsSinking = false;

		Animator _deadAnim;
		AudioSource _audio;
		public AudioClip _deadClip;
		ParticleSystem _damageParticle;

		void Start()
		{
			_deadAnim = GetComponent<Animator>();
			_audio = GetComponent<AudioSource>();
			_damageParticle = GetComponent<ParticleSystem>();

			_hp = _maxHp;

		//	_enemynameText = GameCanvas.instance.UICanvas.enemynameText;
		}

		void Update()
		{
			this.CheckIsMove();
			this.TryStopWalk();
			this.TryWalk();

		//	_enemynameText.transform.position = Camera.main.WorldToScreenPoint(
		//		  new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z));

			//if (IsSinking)
			//{
			//	gameObject.transform.position += Vector3.down * Time.deltaTime * 0.3f;
			//	if (gameObject.transform.position.y < -2)
			//	{
			//		Destroy(gameObject);
			//	}
			//}
		}

		public void EnemyNamePrint(string name)
		{
			if (_enemynameText == null)
			{
				_enemynameText = GameCanvas.instance.UICanvas.enemynameText;
			}

			_enemynameText.text = name;
		}

		public void CheckIsMove()
		{
			if (prevPos == gameObject.transform.position)
			{
				IsMove = false;
			}

			prevPos = gameObject.transform.position;
		}

		public void TryStopWalk()
		{
			if (IsMove == false)
			{
				gameObject.GetComponent<Animator>().SetBool("IsWalking", false);
			}
		}

		public void TryWalk()
		{
			if (IsMove == true)
			{
				gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
			}
		}

		public void Move(float xpos, float ypos, float zpos, float xrot, float yrot, float zrot)
		{
			gameObject.transform.position = new Vector3(xpos, ypos, zpos);
			gameObject.transform.rotation = Quaternion.Euler(xrot, yrot, zrot);

			IsMove = true;
		}

		public void Shoot()
		{
			_gun.Shoot();
		}

		public void TakeDamage(int damage)
		{
			_damageParticle.Play();

			_hp -= damage;
			if (_hp <= 0)
			{
				Destroy(GetComponent<CapsuleCollider>());
				Destroy(GetComponentInChildren<UserShooting>());

				_deadAnim.SetTrigger("Death");
				_audio.clip = _deadClip;
			}

			_audio.Play();
		}

		public void DeleteCharacter()
		{
			Destroy(gameObject);
		}

		void StartSinking()
		{
			IsSinking = true;
		}

		public void SetUserUID(UInt16 uid)
		{
			_uid = uid;
		}

		public UInt16 GetUserUID()
		{
			return _uid;
		}
	}
}