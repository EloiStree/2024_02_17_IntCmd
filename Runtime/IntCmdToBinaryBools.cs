using System;

namespace Eloi.IID
{
    [System.Serializable]
    public class IntCmdToBinaryBools
    {
        public byte[] m_intAsBytes;
        public bool[] m_intAsBools;

        public IntCmdToBinaryBools(in int value)
        {
            Set(in value);
        }
        public IntCmdToBinaryBools()
        {
            Set(0);
        }

        public void Set(in int value)
        {

            m_intAsBytes = BitConverter.GetBytes(value);
            m_intAsBools = BytesToBooleans(m_intAsBytes);

        }
        public static bool[] BytesToBooleans(byte[] bytes)
        {
            bool[] booleans = new bool[bytes.Length * 8];

            for (int i = 0; i < bytes.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int index = i * 8 + j;
                    booleans[index] = (bytes[i] & (1 << (7 - j))) != 0;
                }
            }

            return booleans;
        }
    }
}