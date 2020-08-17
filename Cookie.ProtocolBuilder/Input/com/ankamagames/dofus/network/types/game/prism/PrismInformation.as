package com.ankamagames.dofus.network.types.game.prism
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class PrismInformation implements INetworkType
   {
      
      public static const protocolId:uint = 428;
       
      
      public var typeId:uint = 0;
      
      public var state:uint = 1;
      
      public var nextVulnerabilityDate:uint = 0;
      
      public var placementDate:uint = 0;
      
      public var rewardTokenCount:uint = 0;
      
      public function PrismInformation()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 428;
      }
      
      public function initPrismInformation(param1:uint = 0, param2:uint = 1, param3:uint = 0, param4:uint = 0, param5:uint = 0) : PrismInformation
      {
         this.typeId = param1;
         this.state = param2;
         this.nextVulnerabilityDate = param3;
         this.placementDate = param4;
         this.rewardTokenCount = param5;
         return this;
      }
      
      public function reset() : void
      {
         this.typeId = 0;
         this.state = 1;
         this.nextVulnerabilityDate = 0;
         this.placementDate = 0;
         this.rewardTokenCount = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PrismInformation(param1);
      }
      
      public function serializeAs_PrismInformation(param1:ICustomDataOutput) : void
      {
         if(this.typeId < 0)
         {
            throw new Error("Forbidden value (" + this.typeId + ") on element typeId.");
         }
         param1.writeByte(this.typeId);
         param1.writeByte(this.state);
         if(this.nextVulnerabilityDate < 0)
         {
            throw new Error("Forbidden value (" + this.nextVulnerabilityDate + ") on element nextVulnerabilityDate.");
         }
         param1.writeInt(this.nextVulnerabilityDate);
         if(this.placementDate < 0)
         {
            throw new Error("Forbidden value (" + this.placementDate + ") on element placementDate.");
         }
         param1.writeInt(this.placementDate);
         if(this.rewardTokenCount < 0)
         {
            throw new Error("Forbidden value (" + this.rewardTokenCount + ") on element rewardTokenCount.");
         }
         param1.writeVarInt(this.rewardTokenCount);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PrismInformation(param1);
      }
      
      public function deserializeAs_PrismInformation(param1:ICustomDataInput) : void
      {
         this._typeIdFunc(param1);
         this._stateFunc(param1);
         this._nextVulnerabilityDateFunc(param1);
         this._placementDateFunc(param1);
         this._rewardTokenCountFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PrismInformation(param1);
      }
      
      public function deserializeAsyncAs_PrismInformation(param1:FuncTree) : void
      {
         param1.addChild(this._typeIdFunc);
         param1.addChild(this._stateFunc);
         param1.addChild(this._nextVulnerabilityDateFunc);
         param1.addChild(this._placementDateFunc);
         param1.addChild(this._rewardTokenCountFunc);
      }
      
      private function _typeIdFunc(param1:ICustomDataInput) : void
      {
         this.typeId = param1.readByte();
         if(this.typeId < 0)
         {
            throw new Error("Forbidden value (" + this.typeId + ") on element of PrismInformation.typeId.");
         }
      }
      
      private function _stateFunc(param1:ICustomDataInput) : void
      {
         this.state = param1.readByte();
         if(this.state < 0)
         {
            throw new Error("Forbidden value (" + this.state + ") on element of PrismInformation.state.");
         }
      }
      
      private function _nextVulnerabilityDateFunc(param1:ICustomDataInput) : void
      {
         this.nextVulnerabilityDate = param1.readInt();
         if(this.nextVulnerabilityDate < 0)
         {
            throw new Error("Forbidden value (" + this.nextVulnerabilityDate + ") on element of PrismInformation.nextVulnerabilityDate.");
         }
      }
      
      private function _placementDateFunc(param1:ICustomDataInput) : void
      {
         this.placementDate = param1.readInt();
         if(this.placementDate < 0)
         {
            throw new Error("Forbidden value (" + this.placementDate + ") on element of PrismInformation.placementDate.");
         }
      }
      
      private function _rewardTokenCountFunc(param1:ICustomDataInput) : void
      {
         this.rewardTokenCount = param1.readVarUhInt();
         if(this.rewardTokenCount < 0)
         {
            throw new Error("Forbidden value (" + this.rewardTokenCount + ") on element of PrismInformation.rewardTokenCount.");
         }
      }
   }
}
