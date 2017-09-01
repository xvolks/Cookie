package com.ankamagames.dofus.datacenter.world
{
   import com.ankamagames.dofus.datacenter.ambientSounds.AmbientSound;
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.data.IPostInit;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import flash.geom.Point;
   import flash.geom.Rectangle;
   
   public class SubArea implements IDataCenter, IPostInit
   {
      
      public static const MODULE:String = "SubAreas";
      
      private static var _allSubAreas:Array;
       
      
      private var _bounds:Rectangle;
      
      public var id:int;
      
      public var nameId:uint;
      
      public var areaId:int;
      
      public var ambientSounds:Vector.<AmbientSound>;
      
      public var playlists:Vector.<Vector.<int>>;
      
      public var mapIds:Vector.<uint>;
      
      public var bounds:Rectangle;
      
      public var shape:Vector.<int>;
      
      public var customWorldMap:Vector.<uint>;
      
      public var packId:int;
      
      public var level:uint;
      
      public var isConquestVillage:Boolean;
      
      public var basicAccountAllowed:Boolean;
      
      public var displayOnWorldMap:Boolean;
      
      public var monsters:Vector.<uint>;
      
      public var entranceMapIds:Vector.<uint>;
      
      public var exitMapIds:Vector.<uint>;
      
      public var capturable:Boolean;
      
      public var achievements:Vector.<uint>;
      
      public var quests:Vector.<Vector.<int>>;
      
      public var npcs:Vector.<Vector.<int>>;
      
      public var exploreAchievementId:int;
      
      public var isDiscovered:Boolean;
      
      public var harvestables:Vector.<int>;
      
      private var _name:String;
      
      private var _undiatricalName:String;
      
      private var _area:Area;
      
      private var _worldMap:WorldMap;
      
      private var _center:Point;
      
      public function SubArea()
      {
         super();
      }
      
      public static function getSubAreaById(param1:int) : SubArea
      {
         var _loc2_:SubArea = GameData.getObject(MODULE,param1) as SubArea;
         if(!_loc2_ || !_loc2_.area)
         {
            return null;
         }
         return _loc2_;
      }
      
      public static function getSubAreaByMapId(param1:uint) : SubArea
      {
         var _loc2_:MapPosition = MapPosition.getMapPositionById(param1);
         if(_loc2_)
         {
            return _loc2_.subArea;
         }
         return null;
      }
      
      public static function getAllSubArea() : Array
      {
         if(_allSubAreas)
         {
            return _allSubAreas;
         }
         _allSubAreas = GameData.getObjects(MODULE) as Array;
         return _allSubAreas;
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
      
      public function get area() : Area
      {
         if(!this._area)
         {
            this._area = Area.getAreaById(this.areaId);
         }
         return this._area;
      }
      
      public function get worldmap() : WorldMap
      {
         if(!this._worldMap)
         {
            if(this.hasCustomWorldMap)
            {
               this._worldMap = WorldMap.getWorldMapById(this.customWorldMap[0]);
            }
            else
            {
               this._worldMap = this.area.worldmap;
            }
         }
         return this._worldMap;
      }
      
      public function get hasCustomWorldMap() : Boolean
      {
         return this.customWorldMap && this.customWorldMap.length > 0;
      }
      
      public function get center() : Point
      {
         var _loc2_:int = 0;
         var _loc3_:int = 0;
         var _loc4_:int = 0;
         var _loc5_:int = 0;
         var _loc6_:int = 0;
         var _loc7_:int = 0;
         var _loc8_:int = 0;
         var _loc1_:uint = this.shape.length;
         if(!this._center && _loc1_ > 0)
         {
            _loc7_ = this.shape[0];
            _loc8_ = this.shape[1];
            _loc2_ = _loc3_ = _loc7_ > 10000?int(_loc7_ - 11000):int(_loc7_);
            _loc4_ = _loc5_ = _loc8_ > 10000?int(_loc8_ - 11000):int(_loc8_);
            _loc6_ = 2;
            while(_loc6_ < _loc1_)
            {
               _loc7_ = this.shape[_loc6_];
               _loc8_ = this.shape[_loc6_ + 1];
               if(_loc7_ > 10000)
               {
                  _loc7_ = _loc7_ - 11000;
               }
               if(_loc8_ > 10000)
               {
                  _loc8_ = _loc8_ - 11000;
               }
               _loc2_ = _loc7_ < _loc2_?int(_loc7_):int(_loc2_);
               _loc3_ = _loc7_ > _loc3_?int(_loc7_):int(_loc3_);
               _loc4_ = _loc8_ < _loc4_?int(_loc8_):int(_loc4_);
               _loc5_ = _loc8_ > _loc5_?int(_loc8_):int(_loc5_);
               _loc6_ = _loc6_ + 2;
            }
            this._center = new Point((_loc2_ + _loc3_) / 2,(_loc4_ + _loc5_) / 2);
         }
         return this._center;
      }
      
      public function postInit() : void
      {
         this.name;
         this.undiatricalName;
      }
   }
}
