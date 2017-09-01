package com.ankamagames.dofus.datacenter.monsters
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class MonsterRace implements IDataCenter
   {
      
      public static const MODULE:String = "MonsterRaces";
       
      
      public var id:int;
      
      public var superRaceId:int;
      
      public var nameId:uint;
      
      public var monsters:Vector.<uint>;
      
      private var _name:String;
      
      public function MonsterRace()
      {
         super();
      }
      
      public static function getMonsterRaceById(param1:uint) : MonsterRace
      {
         return GameData.getObject(MODULE,param1) as MonsterRace;
      }
      
      public static function getMonsterRaces() : Array
      {
         return GameData.getObjects(MODULE);
      }
      
      public function get name() : String
      {
         if(!this._name)
         {
            this._name = I18n.getText(this.nameId);
         }
         return this._name;
      }
   }
}
