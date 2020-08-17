package com.ankamagames.dofus.datacenter.monsters
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class MonsterMiniBoss implements IDataCenter
   {
      
      public static const MODULE:String = "MonsterMiniBoss";
       
      
      public var id:int;
      
      public var monsterReplacingId:int;
      
      public function MonsterMiniBoss()
      {
         super();
      }
      
      public static function getMonsterById(param1:uint) : MonsterMiniBoss
      {
         return GameData.getObject(MODULE,param1) as MonsterMiniBoss;
      }
      
      public static function getMonsters() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
