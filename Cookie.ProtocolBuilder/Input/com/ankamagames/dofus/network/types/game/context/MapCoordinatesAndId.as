package com.ankamagames.dofus.network.types.game.context
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class MapCoordinatesAndId extends MapCoordinates implements INetworkType
   {
      
      public static const protocolId:uint = 392;
       
      
      public var mapId:int = 0;
      
      public function MapCoordinatesAndId()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 392;
      }
      
      public function initMapCoordinatesAndId(param1:int = 0, param2:int = 0, param3:int = 0) : MapCoordinatesAndId
      {
         super.initMapCoordinates(param1,param2);
         this.mapId = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.mapId = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_MapCoordinatesAndId(param1);
      }
      
      public function serializeAs_MapCoordinatesAndId(param1:ICustomDataOutput) : void
      {
         super.serializeAs_MapCoordinates(param1);
         param1.writeInt(this.mapId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MapCoordinatesAndId(param1);
      }
      
      public function deserializeAs_MapCoordinatesAndId(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._mapIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MapCoordinatesAndId(param1);
      }
      
      public function deserializeAsyncAs_MapCoordinatesAndId(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._mapIdFunc);
      }
      
      private function _mapIdFunc(param1:ICustomDataInput) : void
      {
         this.mapId = param1.readInt();
      }
   }
}
