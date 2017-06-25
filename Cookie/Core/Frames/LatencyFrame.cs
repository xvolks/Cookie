using System;
using System.Collections.Generic;
using System.Linq;
using Cookie.API.Core.Frames;

namespace Cookie.Core.Frames
{
    public class LatencyFrame : ILatencyFrame
    {
        private const uint LatencyAvgBufferSize = 50;
        private readonly List<uint> _latencyBuffer;
        private uint _latestSent;

        public LatencyFrame()
        {
            _latencyBuffer = new List<uint>();
            Sequence = 0;
        }

        public int Sequence { get; set; }

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
    }
}