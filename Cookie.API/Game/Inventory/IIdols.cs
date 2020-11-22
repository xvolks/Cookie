using Cookie.API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cookie.API.Game.Inventory
{
    public interface IIdols
    {
        IAccount Account { get; }
        AutoResetEvent IdolsResetEvent { get; }
    }
}
