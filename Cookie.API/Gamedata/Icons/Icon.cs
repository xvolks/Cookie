#region License GNU GPL

// Icon.cs
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

using System.Drawing;
using System.IO;

namespace Cookie.API.Gamedata.Icons
{
    public class Icon
    {
        public Icon(int id, string name, byte[] data)
        {
            Id = id;
            Name = name;
            Image = Image.FromStream(new MemoryStream(data));
        }

        public int Id { get; }

        public string Name { get; }

        public Image Image { get; }
    }
}