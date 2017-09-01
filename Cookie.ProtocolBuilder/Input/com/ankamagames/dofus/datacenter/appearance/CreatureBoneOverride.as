package com.ankamagames.dofus.datacenter.appearance
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class CreatureBoneOverride implements IDataCenter
   {
      
      public static const MODULE:String = "CreatureBonesOverrides";
       
      
      public var boneId:int;
      
      public var creatureBoneId:int;
      
      public function CreatureBoneOverride()
      {
         super();
      }
      
      public static function getCreatureBones(param1:int) : int
      {
         var _loc2_:CreatureBoneOverride = GameData.getObject(MODULE,param1) as CreatureBoneOverride;
         return !!_loc2_?int(_loc2_.creatureBoneId):-1;
      }
      
      public static function getAllCreatureBonesOverrides() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
