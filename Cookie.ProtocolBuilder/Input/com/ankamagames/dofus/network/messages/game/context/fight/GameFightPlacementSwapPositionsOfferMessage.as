package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightPlacementSwapPositionsOfferMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6542;
       
      
      private var _isInitialized:Boolean = false;
      
      public var requestId:uint = 0;
      
      public var requesterId:Number = 0;
      
      public var requesterCellId:uint = 0;
      
      public var requestedId:Number = 0;
      
      public var requestedCellId:uint = 0;
      
      public function GameFightPlacementSwapPositionsOfferMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6542;
      }
      
      public function initGameFightPlacementSwapPositionsOfferMessage(param1:uint = 0, param2:Number = 0, param3:uint = 0, param4:Number = 0, param5:uint = 0) : GameFightPlacementSwapPositionsOfferMessage
      {
         this.requestId = param1;
         this.requesterId = param2;
         this.requesterCellId = param3;
         this.requestedId = param4;
         this.requestedCellId = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.requestId = 0;
         this.requesterId = 0;
         this.requesterCellId = 0;
         this.requestedId = 0;
         this.requestedCellId = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameFightPlacementSwapPositionsOfferMessage(param1);
      }
      
      public function serializeAs_GameFightPlacementSwapPositionsOfferMessage(param1:ICustomDataOutput) : void
      {
         if(this.requestId < 0)
         {
            throw new Error("Forbidden value (" + this.requestId + ") on element requestId.");
         }
         param1.writeInt(this.requestId);
         if(this.requesterId < -9007199254740990 || this.requesterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.requesterId + ") on element requesterId.");
         }
         param1.writeDouble(this.requesterId);
         if(this.requesterCellId < 0 || this.requesterCellId > 559)
         {
            throw new Error("Forbidden value (" + this.requesterCellId + ") on element requesterCellId.");
         }
         param1.writeVarShort(this.requesterCellId);
         if(this.requestedId < -9007199254740990 || this.requestedId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.requestedId + ") on element requestedId.");
         }
         param1.writeDouble(this.requestedId);
         if(this.requestedCellId < 0 || this.requestedCellId > 559)
         {
            throw new Error("Forbidden value (" + this.requestedCellId + ") on element requestedCellId.");
         }
         param1.writeVarShort(this.requestedCellId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightPlacementSwapPositionsOfferMessage(param1);
      }
      
      public function deserializeAs_GameFightPlacementSwapPositionsOfferMessage(param1:ICustomDataInput) : void
      {
         this._requestIdFunc(param1);
         this._requesterIdFunc(param1);
         this._requesterCellIdFunc(param1);
         this._requestedIdFunc(param1);
         this._requestedCellIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightPlacementSwapPositionsOfferMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightPlacementSwapPositionsOfferMessage(param1:FuncTree) : void
      {
         param1.addChild(this._requestIdFunc);
         param1.addChild(this._requesterIdFunc);
         param1.addChild(this._requesterCellIdFunc);
         param1.addChild(this._requestedIdFunc);
         param1.addChild(this._requestedCellIdFunc);
      }
      
      private function _requestIdFunc(param1:ICustomDataInput) : void
      {
         this.requestId = param1.readInt();
         if(this.requestId < 0)
         {
            throw new Error("Forbidden value (" + this.requestId + ") on element of GameFightPlacementSwapPositionsOfferMessage.requestId.");
         }
      }
      
      private function _requesterIdFunc(param1:ICustomDataInput) : void
      {
         this.requesterId = param1.readDouble();
         if(this.requesterId < -9007199254740990 || this.requesterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.requesterId + ") on element of GameFightPlacementSwapPositionsOfferMessage.requesterId.");
         }
      }
      
      private function _requesterCellIdFunc(param1:ICustomDataInput) : void
      {
         this.requesterCellId = param1.readVarUhShort();
         if(this.requesterCellId < 0 || this.requesterCellId > 559)
         {
            throw new Error("Forbidden value (" + this.requesterCellId + ") on element of GameFightPlacementSwapPositionsOfferMessage.requesterCellId.");
         }
      }
      
      private function _requestedIdFunc(param1:ICustomDataInput) : void
      {
         this.requestedId = param1.readDouble();
         if(this.requestedId < -9007199254740990 || this.requestedId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.requestedId + ") on element of GameFightPlacementSwapPositionsOfferMessage.requestedId.");
         }
      }
      
      private function _requestedCellIdFunc(param1:ICustomDataInput) : void
      {
         this.requestedCellId = param1.readVarUhShort();
         if(this.requestedCellId < 0 || this.requestedCellId > 559)
         {
            throw new Error("Forbidden value (" + this.requestedCellId + ") on element of GameFightPlacementSwapPositionsOfferMessage.requestedCellId.");
         }
      }
   }
}
