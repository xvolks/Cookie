package com.ankamagames.dofus.datacenter.interactives
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class StealthBones implements IDataCenter
   {
      
      public static const MODULE:String = "StealthBones";
       
      
      public var id:uint;
      
      public function StealthBones()
      {
         super();
      }
      
      public static function getStealthBonesById(param1:int) : StealthBones
      {
         return GameData.getObject(MODULE,param1) as StealthBones;
      }
   }
}
