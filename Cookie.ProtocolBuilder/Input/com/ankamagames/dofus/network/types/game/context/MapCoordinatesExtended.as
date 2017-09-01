package com.ankamagames.dofus.network.types.game.context
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class MapCoordinatesExtended extends MapCoordinatesAndId implements INetworkType
   {
      
      public static const protocolId:uint = 176;
       
      
      public var subAreaId:uint = 0;
      
      public function MapCoordinatesExtended()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 176;
      }
      
      public function initMapCoordinatesExtended(param1:int = 0, param2:int = 0, param3:int = 0, param4:uint = 0) : MapCoordinatesExtended
      {
         super.initMapCoordinatesAndId(param1,param2,param3);
         this.subAreaId = param4;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.subAreaId = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_MapCoordinatesExtended(param1);
      }
      
      public function serializeAs_MapCoordinatesExtended(param1:ICustomDataOutput) : void
      {
         super.serializeAs_MapCoordinatesAndId(param1);
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element subAreaId.");
         }
         param1.writeVarShort(this.subAreaId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MapCoordinatesExtended(param1);
      }
      
      public function deserializeAs_MapCoordinatesExtended(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._subAreaIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MapCoordinatesExtended(param1);
      }
      
      public function deserializeAsyncAs_MapCoordinatesExtended(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._subAreaIdFunc);
      }
      
      private function _subAreaIdFunc(param1:ICustomDataInput) : void
      {
         this.subAreaId = param1.readVarUhShort();
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element of MapCoordinatesExtended.subAreaId.");
         }
      }
   }
}
