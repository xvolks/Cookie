package com.ankamagames.dofus.network.types.game.house
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class HouseOnMapInformations extends HouseInformations implements INetworkType
   {
      
      public static const protocolId:uint = 510;
       
      
      public var doorsOnMap:Vector.<uint>;
      
      public var houseInstances:Vector.<HouseInstanceInformations>;
      
      private var _doorsOnMaptree:FuncTree;
      
      private var _houseInstancestree:FuncTree;
      
      public function HouseOnMapInformations()
      {
         this.doorsOnMap = new Vector.<uint>();
         this.houseInstances = new Vector.<HouseInstanceInformations>();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 510;
      }
      
      public function initHouseOnMapInformations(param1:uint = 0, param2:uint = 0, param3:Vector.<uint> = null, param4:Vector.<HouseInstanceInformations> = null) : HouseOnMapInformations
      {
         super.initHouseInformations(param1,param2);
         this.doorsOnMap = param3;
         this.houseInstances = param4;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.doorsOnMap = new Vector.<uint>();
         this.houseInstances = new Vector.<HouseInstanceInformations>();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HouseOnMapInformations(param1);
      }
      
      public function serializeAs_HouseOnMapInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_HouseInformations(param1);
         param1.writeShort(this.doorsOnMap.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.doorsOnMap.length)
         {
            if(this.doorsOnMap[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.doorsOnMap[_loc2_] + ") on element 1 (starting at 1) of doorsOnMap.");
            }
            param1.writeInt(this.doorsOnMap[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.houseInstances.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.houseInstances.length)
         {
            (this.houseInstances[_loc3_] as HouseInstanceInformations).serializeAs_HouseInstanceInformations(param1);
            _loc3_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HouseOnMapInformations(param1);
      }
      
      public function deserializeAs_HouseOnMapInformations(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:HouseInstanceInformations = null;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readInt();
            if(_loc6_ < 0)
            {
               throw new Error("Forbidden value (" + _loc6_ + ") on elements of doorsOnMap.");
            }
            this.doorsOnMap.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = new HouseInstanceInformations();
            _loc7_.deserialize(param1);
            this.houseInstances.push(_loc7_);
            _loc5_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HouseOnMapInformations(param1);
      }
      
      public function deserializeAsyncAs_HouseOnMapInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._doorsOnMaptree = param1.addChild(this._doorsOnMaptreeFunc);
         this._houseInstancestree = param1.addChild(this._houseInstancestreeFunc);
      }
      
      private function _doorsOnMaptreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._doorsOnMaptree.addChild(this._doorsOnMapFunc);
            _loc3_++;
         }
      }
      
      private function _doorsOnMapFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readInt();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of doorsOnMap.");
         }
         this.doorsOnMap.push(_loc2_);
      }
      
      private function _houseInstancestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._houseInstancestree.addChild(this._houseInstancesFunc);
            _loc3_++;
         }
      }
      
      private function _houseInstancesFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:HouseInstanceInformations = new HouseInstanceInformations();
         _loc2_.deserialize(param1);
         this.houseInstances.push(_loc2_);
      }
   }
}
