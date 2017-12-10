﻿using System.Linq;

namespace Console_Application
{
    public class KnotHasher
    {
        private byte[] marks;
        private byte currentPosition = 0;
        private byte skipSize = 0;

        public KnotHasher()
        {
            // Fill the array with the basic values
            marks = Enumerable.Range(0, 256).Select(mark => (byte) mark).ToArray();
        }

        public void PinchAndTwist(byte pinchLength)
        {
            ReverseList(pinchLength, currentPosition);

            currentPosition += (byte)(pinchLength + skipSize++);
        }

        public int CalculateAnswer()
        {
            return marks[0] * marks[1];
        }

        private void ReverseList(byte length, byte startPosition)
        {
            byte sortTill = (byte)(length / 2);
            for (byte i = 0; i < sortTill; i++)
            {
                byte fromIndex = (byte)(startPosition + i);
                byte toIndex = (byte)(startPosition + (length - i) - 1);

                byte fromValue = marks[fromIndex];
                byte toValue = marks[toIndex];

                marks[fromIndex] = toValue;
                marks[toIndex] = fromValue;
            }
        }
    }
}