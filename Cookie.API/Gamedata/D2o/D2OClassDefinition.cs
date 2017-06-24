#region License GNU GPL

// D2oClassDefinition.cs
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Cookie.API.Gamedata.D2o
{
    [DebuggerDisplay("Name = {Name}")]
    public class D2oClassDefinition
    {
        public D2oClassDefinition(int id, string classname, string packagename, Type classType,
            IEnumerable<D2oFieldDefinition> fields, long offset)
        {
            Id = id;
            Name = classname;
            PackageName = packagename;
            ClassType = classType;
            Fields = fields.ToDictionary(entry => entry.Name);
            Offset = offset;
        }

        public Dictionary<string, D2oFieldDefinition> Fields { get; }

        public int Id { get; }

        public string Name { get; }

        public string PackageName { get; }

        public Type ClassType { get; }

        internal long Offset { get; set; }
    }
}