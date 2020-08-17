package com.ankamagames.dofus.datacenter.ambientSounds
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class PlaylistSound implements IDataCenter
   {
      
      public static const MODULE:String = "PlaylistSounds";
       
      
      public var id:String;
      
      public var volume:int;
      
      public var channel:int = 0;
      
      public function PlaylistSound()
      {
         super();
      }
      
      public static function getPlaylistSoundById(param1:uint) : PlaylistSound
      {
         return GameData.getObject(MODULE,param1) as PlaylistSound;
      }
   }
}
