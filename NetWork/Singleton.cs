using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
    {
        private static T _instance;
        private static object _lockObject = new object();

        public static T GetInstance
        {
            get
            {
                lock(_lockObject)
                {
                    if(_instance == null)
                    {
                        _instance = (T)FindObjectOfType(typeof(T));

                        if(_instance != null && FindObjectsOfType(typeof(T)).Length > 1)
                        {
                            Debug.Log("잘못된 싱글톤 입니다");
                        }

                        if(_instance == null)
                        {
                            GameObject singleton = new GameObject();
                            _instance = singleton.AddComponent<T>();
                            singleton.name = "(singleton)" + typeof(T).ToString();
                        }
                    }

                    return _instance;
                }
            }
        }

        public virtual void OnDestory()
        {
            _instance = null;
        }

    }
}
