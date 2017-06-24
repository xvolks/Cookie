using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieAPI
{
    public interface IDofusClient
    {
        void Register(Type type);
        void Logg(string text);
    }
}
