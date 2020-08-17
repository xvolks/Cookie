package com.ankamagames.dofus.datacenter.world
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class Phoenix implements IDataCenter
   {
      
      public static const MODULE:String = "Phoenixes";
       
      
      public var mapId:uint;
      
      public function Phoenix()
      {
         super();
      }
      
      public static function getAllPhoenixes() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
