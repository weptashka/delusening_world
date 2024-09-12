using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class AbstractTrigger<T> : MonoBehaviour
    {
        public bool IsTriggered => TriggeredValue != null;

        public T TriggeredValue
        {
            get;
            private set;
        }

        private void Awake()
        {
            //доп проверка
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out T value))
            {
                TriggeredValue = value;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out T value))
            {
                TriggeredValue = default(T);
            }
        }
    }