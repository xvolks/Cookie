package com.ankamagames.dofus.datacenter.mounts
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class RideFood implements IDataCenter
   {
      
      public static var MODULE:String = "RideFood";
       
      
      public var gid:uint;
      
      public var typeId:uint;
      
      public function RideFood()
      {
         super();
      }
      
      public static function getRideFoods() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
