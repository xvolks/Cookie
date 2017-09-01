package com.ankamagames.dofus.datacenter.world
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.data.IPostInit;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class Dungeon implements IDataCenter, IPostInit
   {
      
      public static const MODULE:String = "Dungeons";
      
      private static var _allDungeons:Array;
       
      
      public var id:int;
      
      public var nameId:uint;
      
      public var optimalPlayerLevel:int;
      
      public var mapIds:Vector.<int>;
      
      public var entranceMapId:int;
      
      public var exitMapId:int;
      
      private var _name:String;
      
      private var _undiatricalName:String;
      
      public function Dungeon()
      {
         super();
      }
      
      public static function getDungeonById(param1:int) : Dungeon
      {
         var _loc2_:Dungeon = GameData.getObject(MODULE,param1) as Dungeon;
         return _loc2_;
      }
      
      public static function getAllDungeons() : Array
      {
         if(_allDungeons)
         {
            return _allDungeons;
         }
         _allDungeons = GameData.getObjects(MODULE) as Array;
         return _allDungeons;
      }
      
      public function get name() : String
      {
         if(!this._name)
         {
            this._name = I18n.getText(this.nameId);
         }
         return this._name;
      }
      
      public function get undiatricalName() : String
      {
         if(!this._undiatricalName)
         {
            this._undiatricalName = I18n.getUnDiacriticalText(this.nameId);
         }
         return this._undiatricalName;
      }
      
      public function postInit() : void
      {
         this.name;
         this.undiatricalName;
      }
   }
}
