using System;

namespace Eloi.IID
{
    [System.Serializable]
    public class IntCmdAsChar
    {
        public char m_0_char = (char)0;
        public char m_1_char = (char)0;
        public char m_2_char = (char)0;
        public char m_3_char = (char)0;

        public IntCmdAsChar()
        {
            Set(0);
        }
        public IntCmdAsChar(in int value)
        {
            Set(in value);
        }

        public void Set(in int value)
        {

            byte[] byteArray = BitConverter.GetBytes(value);

            if (byteArray.Length >= 1)
                m_0_char = (char)byteArray[0];
            else m_0_char = ' ';

            if (byteArray.Length >= 2)
                m_1_char = (char)byteArray[1];
            else m_1_char = ' ';

            if (byteArray.Length >= 3)
                m_2_char = (char)byteArray[2];
            else m_2_char = ' ';

            if (byteArray.Length >= 4)
                m_3_char = (char)byteArray[3];
            else m_3_char = ' ';
        }
    }
}