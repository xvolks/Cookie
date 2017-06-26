#region License GNU GPL

// IconsManager.cs
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
using System.IO;
using Cookie.API.Gamedata.D2p;
using Cookie.API.Utils.Extensions;

namespace Cookie.API.Gamedata.Icons
{
    public class IconsManager : Singleton<IconsManager>
    {
        private List<D2PFileDlm> files;

        public void Initialize(string path)
        {
            files = new List<D2PFileDlm>();

            foreach (var file in Directory.GetFiles(path))
                if (file.Contains("bitmap"))
                    files.Add(new D2PFileDlm(file));
        }

        public Icon GetIcon(int id)
        {
            foreach (var d2PFile in files)
                if (!d2PFile.ExistsDlm(id + ".png"))
                    throw new ArgumentException(string.Format("Item icon {0} not found", id));
                else
                    return new Icon(id, id + ".png", d2PFile.ReadFile(id + ".png"));

            return null;
        }
    }
}