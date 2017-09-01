package com.ankamagames.dofus.network.types.game.prism
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class PrismSubareaEmptyInfo implements INetworkType
   {
      
      public static const protocolId:uint = 438;
       
      
      public var subAreaId:uint = 0;
      
      public var allianceId:uint = 0;
      
      public function PrismSubareaEmptyInfo()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 438;
      }
      
      public function initPrismSubareaEmptyInfo(param1:uint = 0, param2:uint = 0) : PrismSubareaEmptyInfo
      {
         this.subAreaId = param1;
         this.allianceId = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.subAreaId = 0;
         this.allianceId = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PrismSubareaEmptyInfo(param1);
      }
      
      public function serializeAs_PrismSubareaEmptyInfo(param1:ICustomDataOutput) : void
      {
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element subAreaId.");
         }
         param1.writeVarShort(this.subAreaId);
         if(this.allianceId < 0)
         {
            throw new Error("Forbidden value (" + this.allianceId + ") on element allianceId.");
         }
         param1.writeVarInt(this.allianceId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PrismSubareaEmptyInfo(param1);
      }
      
      public function deserializeAs_PrismSubareaEmptyInfo(param1:ICustomDataInput) : void
      {
         this._subAreaIdFunc(param1);
         this._allianceIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PrismSubareaEmptyInfo(param1);
      }
      
      public function deserializeAsyncAs_PrismSubareaEmptyInfo(param1:FuncTree) : void
      {
         param1.addChild(this._subAreaIdFunc);
         param1.addChild(this._allianceIdFunc);
      }
      
      private function _subAreaIdFunc(param1:ICustomDataInput) : void
      {
         this.subAreaId = param1.readVarUhShort();
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element of PrismSubareaEmptyInfo.subAreaId.");
         }
      }
      
      private function _allianceIdFunc(param1:ICustomDataInput) : void
      {
         this.allianceId = param1.readVarUhInt();
         if(this.allianceId < 0)
         {
            throw new Error("Forbidden value (" + this.allianceId + ") on element of PrismSubareaEmptyInfo.allianceId.");
         }
      }
   }
}
