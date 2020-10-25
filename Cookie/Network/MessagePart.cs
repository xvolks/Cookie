#region License GNU GPL
// MessagePart.cs
// 
// Copyright (C) 2012 - BehaviorIsManaged
// 
// This program is free software; you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details. 
// You should have received a copy of the GNU General Public License along with this program; 
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
#endregion
using Cookie.IO;
using System;

namespace Cookie
{
    public class MessagePart
    {
        /// <summary>
        /// Set to true when the message is whole
        /// </summary>

        public MessagePart(DataHeader message)
        {
            this.Data = message.MessageData;
            this.MessageId = (int)message.MessageId;
            this.Length = message.MessageData.Length;

        }

        public int MessageId { get; set; }

        public int LengthBytesCount { get; set; }

        public int Length
        {
            get;
            private set;
        }

        private byte[] m_data;

        public byte[] Data
        {
            get { return m_data; }
            set { m_data = value; }
        }

        public byte[] AllByte
        {
            get;
            set;
        }
        /// <summary>
        /// Build or continue building the message. Returns true if the resulted message is valid and ready to be parsed
        /// </summary>
        public bool Build(IDataReader reader)
        {

            AllByte = reader.Data;
            // first case : no data read
            if (Data == null || Data.Length == 0)
            {
                if (Length == 0)
                    Data = new byte[0];

                // enough bytes in the buffer to build a complete message
                if (reader.BytesAvailable >= Length)
                {
                    Data = reader.ReadBytes(Length);
                }
                // not enough bytes, so we read what we can
                else if (Length > reader.BytesAvailable)
                {
                    Data = reader.ReadBytes((int)reader.BytesAvailable);
                }
            }
            //second case : the message was split and it missed some bytes
            if (Data != null && Data.Length < Length)
            {
                int bytesToRead = 0;

                // still miss some bytes ...
                if (Data.Length + reader.BytesAvailable < Length)
                    bytesToRead = (int)reader.BytesAvailable;

                // there is enough bytes in the buffer to complete the message :)
                else if (Data.Length + reader.BytesAvailable >= Length)
                    bytesToRead = Length - Data.Length;

                if (bytesToRead != 0)
                {
                    int oldLength = Data.Length;
                    Array.Resize(ref m_data, (int)(Data.Length + bytesToRead));
                    Array.Copy(reader.ReadBytes(bytesToRead), 0, Data, oldLength, bytesToRead);
                }
            }
            return true;
        }
    }
}