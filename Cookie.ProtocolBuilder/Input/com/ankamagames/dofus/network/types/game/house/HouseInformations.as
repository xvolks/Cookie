package com.ankamagames.dofus.network.types.game.house
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class HouseInformations implements INetworkType
   {
      
      public static const protocolId:uint = 111;
       
      
      public var houseId:uint = 0;
      
      public var modelId:uint = 0;
      
      public function HouseInformations()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 111;
      }
      
      public function initHouseInformations(param1:uint = 0, param2:uint = 0) : HouseInformations
      {
         this.houseId = param1;
         this.modelId = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.houseId = 0;
         this.modelId = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HouseInformations(param1);
      }
      
      public function serializeAs_HouseInformations(param1:ICustomDataOutput) : void
      {
         if(this.houseId < 0)
         {
            throw new Error("Forbidden value (" + this.houseId + ") on element houseId.");
         }
         param1.writeVarInt(this.houseId);
         if(this.modelId < 0)
         {
            throw new Error("Forbidden value (" + this.modelId + ") on element modelId.");
         }
         param1.writeVarShort(this.modelId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HouseInformations(param1);
      }
      
      public function deserializeAs_HouseInformations(param1:ICustomDataInput) : void
      {
         this._houseIdFunc(param1);
         this._modelIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HouseInformations(param1);
      }
      
      public function deserializeAsyncAs_HouseInformations(param1:FuncTree) : void
      {
         param1.addChild(this._houseIdFunc);
         param1.addChild(this._modelIdFunc);
      }
      
      private function _houseIdFunc(param1:ICustomDataInput) : void
      {
         this.houseId = param1.readVarUhInt();
         if(this.houseId < 0)
         {
            throw new Error("Forbidden value (" + this.houseId + ") on element of HouseInformations.houseId.");
         }
      }
      
      private function _modelIdFunc(param1:ICustomDataInput) : void
      {
         this.modelId = param1.readVarUhShort();
         if(this.modelId < 0)
         {
            throw new Error("Forbidden value (" + this.modelId + ") on element of HouseInformations.modelId.");
         }
      }
   }
}
