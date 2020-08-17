package com.ankamagames.dofus.datacenter.world
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class MapReference implements IDataCenter
   {
      
      public static const MODULE:String = "MapReferences";
       
      
      public var id:int;
      
      public var mapId:uint;
      
      public var cellId:int;
      
      public function MapReference()
      {
         super();
      }
      
      public static function getMapReferenceById(param1:int) : MapReference
      {
         return GameData.getObject(MODULE,param1) as MapReference;
      }
      
      public static function getAllMapReference() : Array
      {
         return GameData.getObjects(MODULE) as Array;
      }
   }
}
