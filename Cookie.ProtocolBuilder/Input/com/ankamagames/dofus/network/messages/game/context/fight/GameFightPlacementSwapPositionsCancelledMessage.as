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
   public class GameFightPlacementSwapPositionsCancelledMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6546;
       
      
      private var _isInitialized:Boolean = false;
      
      public var requestId:uint = 0;
      
      public var cancellerId:Number = 0;
      
      public function GameFightPlacementSwapPositionsCancelledMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6546;
      }
      
      public function initGameFightPlacementSwapPositionsCancelledMessage(param1:uint = 0, param2:Number = 0) : GameFightPlacementSwapPositionsCancelledMessage
      {
         this.requestId = param1;
         this.cancellerId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.requestId = 0;
         this.cancellerId = 0;
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
         this.serializeAs_GameFightPlacementSwapPositionsCancelledMessage(param1);
      }
      
      public function serializeAs_GameFightPlacementSwapPositionsCancelledMessage(param1:ICustomDataOutput) : void
      {
         if(this.requestId < 0)
         {
            throw new Error("Forbidden value (" + this.requestId + ") on element requestId.");
         }
         param1.writeInt(this.requestId);
         if(this.cancellerId < -9007199254740990 || this.cancellerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.cancellerId + ") on element cancellerId.");
         }
         param1.writeDouble(this.cancellerId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightPlacementSwapPositionsCancelledMessage(param1);
      }
      
      public function deserializeAs_GameFightPlacementSwapPositionsCancelledMessage(param1:ICustomDataInput) : void
      {
         this._requestIdFunc(param1);
         this._cancellerIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightPlacementSwapPositionsCancelledMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightPlacementSwapPositionsCancelledMessage(param1:FuncTree) : void
      {
         param1.addChild(this._requestIdFunc);
         param1.addChild(this._cancellerIdFunc);
      }
      
      private function _requestIdFunc(param1:ICustomDataInput) : void
      {
         this.requestId = param1.readInt();
         if(this.requestId < 0)
         {
            throw new Error("Forbidden value (" + this.requestId + ") on element of GameFightPlacementSwapPositionsCancelledMessage.requestId.");
         }
      }
      
      private function _cancellerIdFunc(param1:ICustomDataInput) : void
      {
         this.cancellerId = param1.readDouble();
         if(this.cancellerId < -9007199254740990 || this.cancellerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.cancellerId + ") on element of GameFightPlacementSwapPositionsCancelledMessage.cancellerId.");
         }
      }
   }
}
