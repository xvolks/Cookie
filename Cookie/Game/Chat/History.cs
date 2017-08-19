using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cookie.API.Utils;

namespace Cookie.Game.Chat
{
    class History
    {
        private short _currentPosition = 0;
        private List<string> _cmdHistory = new List<string>();
        private short _historyMaxSize = 50;
        private uint _total = 0;

        public short CurrentPosition()
        {
            return _currentPosition;
        }

        public void Add(string cmd)
        {
            _cmdHistory.Insert(0 ,cmd);
            _total++;
            if (_cmdHistory.Count > _historyMaxSize)
            {
                _cmdHistory.RemoveAt(_historyMaxSize);
            }
            _currentPosition = 0;
        }

        public string Total()
        {
            return _total.ToString();
        }

        public string Next()
        {
            _currentPosition = _currentPosition <= 0 ? (short)0 : --_currentPosition;
            return Current();
        }

        public string Prev()
        {
            _currentPosition = (short)Math.Min(_currentPosition + 1, _cmdHistory.Count);
            return Current();
        }

        public string Current()
        {
            return _currentPosition == 0 ? "" : _cmdHistory[_currentPosition - 1];
        }
    }
}
