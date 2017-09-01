package com.ankamagames.dofus.datacenter.houses
{
   import com.ankamagames.dofus.misc.utils.GameDataQuery;
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class HavenbagTheme implements IDataCenter
   {
      
      public static const MODULE:String = "HavenbagThemes";
      
      private static var _mapIds:Vector.<int>;
       
      
      public var id:int;
      
      public var nameId:int;
      
      public var mapId:int;
      
      private var _name:String;
      
      private var _furnitureIds:Vector.<uint>;
      
      public function HavenbagTheme()
      {
         super();
      }
      
      public static function getAllThemes() : Array
      {
         return GameData.getObjects(MODULE);
      }
      
      public static function getTheme(param1:int) : HavenbagTheme
      {
         return GameData.getObject(MODULE,param1) as HavenbagTheme;
      }
      
      public static function isMapIdInHavenbag(param1:int) : Boolean
      {
         var _loc2_:Array = null;
         var _loc3_:int = 0;
         if(!_mapIds)
         {
            _loc2_ = getAllThemes();
            _mapIds = new Vector.<int>(_loc2_.length,true);
            _loc3_ = 0;
            while(_loc3_ < _loc2_.length)
            {
               _mapIds[_loc3_] = _loc2_[_loc3_].mapId;
               _loc3_++;
            }
         }
         return _mapIds.indexOf(param1) != -1;
      }
      
      public function get name() : String
      {
         if(!this._name)
         {
            this._name = I18n.getText(this.nameId);
         }
         return this._name;
      }
      
      public function get furnitureIds() : Vector.<uint>
      {
         if(!this._furnitureIds)
         {
            this._furnitureIds = GameDataQuery.queryEquals(HavenbagFurniture,"themeId",this.id);
         }
         return this._furnitureIds;
      }
   }
}
