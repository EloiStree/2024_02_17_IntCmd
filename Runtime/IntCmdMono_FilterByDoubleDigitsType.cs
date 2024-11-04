using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IID
{
    /// <summary>
    /// I am class that filter integer of type DD12345678 where DD filter the passing number.
    /// </summary>
    public class IntCmdMono_FilterByDoubleDigitsType : MonoBehaviour
    {

        public FilterDoubleDigits[] m_filters;

        [System.Serializable]
        public class FilterDoubleDigits
        {
            public int m_mustStartWith = 12;
            public UnityEvent<int> m_onIntEvent;

        }

        [Header("Debug")]
        public int m_lastStartWithValue = 0;
        public int m_lastValue = 0;


        public void PushIn(I_IntCmdGet integer) { 
            if(integer!=null)
                PushIn(integer.GetValue());
        }

        public void PushIn(int value)
        {
            int startDigit = value / 100000000;
            m_lastStartWithValue = startDigit;
            m_lastValue = value;
            foreach (FilterDoubleDigits f in m_filters)
            {
                if (f.m_mustStartWith == startDigit)
                {
                    f.m_onIntEvent.Invoke(value);
                }
            }
        }
    
    }
}

