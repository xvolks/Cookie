using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cookie.Core.Frame
{
    public class LatencyFrame
    {
        private const uint LatencyAvgBufferSize = 50;
        private readonly List<uint> _latencyBuffer;
        private uint _latestSent;
        private readonly Account _account;

        public int Sequence { get; set; }

        public LatencyFrame(Account account)
        {
            _latencyBuffer = new List<uint>();
            _account = account;

            Sequence = 0;
        }

        public void LowSend()
        {
            _latestSent = (uint) Environment.TickCount;
        }

        public void UpdateLatency()
        {
            var lastReceive = (uint) Environment.TickCount;

            if (_latestSent == 0) return;
            _latencyBuffer.Add(lastReceive - _latestSent);
            _latestSent = 0;

            if (_latencyBuffer.Count > LatencyAvgBufferSize)
                _latencyBuffer.RemoveAt(0);
        }

        public int GetLatencyAvg()
        {
            if (_latencyBuffer.Count == 0)
                return 0;
            var totalLatency = _latencyBuffer.Aggregate(0, (current, latency) => (int) (current + latency));
            return totalLatency / _latencyBuffer.Count;
        }

        public int GetSamplesCount()
        {
            return _latencyBuffer.Count;
        }

        public int GetSamplesMax()
        {
            return (int) LatencyAvgBufferSize;
        }

        public int RolePlay()
        {
            var pId = (long) _account.Character.Id;
            var ct = Convert.ToUInt32(_account.Ticket);
            const string loaderInfo = "4dd3a4c8490e4517d1883a5c367e1B5f";
            var bytes = Encoding.UTF8.GetBytes(loaderInfo);
            var writer = new BinaryWriter(new MemoryStream());
            var len = bytes.Length;

            for (var i = 0; i < len; i++)
                writer.Write(bytes[i]);

            var reader = new BinaryReader(writer.BaseStream);
            uint h = 0;

            for (var j = 0; j < bytes.Length; j++)
                h = Convert.ToUInt32(h + reader.ReadByte() + (ct & (j << 1)) % 128);

            return Convert.ToUInt16(GetLatencyAvg() + (pId + h) % 20 - 10);
        }
    }
}