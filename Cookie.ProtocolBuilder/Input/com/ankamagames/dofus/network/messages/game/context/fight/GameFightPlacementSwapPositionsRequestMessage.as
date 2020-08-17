package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightPlacementSwapPositionsRequestMessage extends GameFightPlacementPositionRequestMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6541;
       
      
      private var _isInitialized:Boolean = false;
      
      public var requestedId:Number = 0;
      
      public function GameFightPlacementSwapPositionsRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6541;
      }
      
      public function initGameFightPlacementSwapPositionsRequestMessage(param1:uint = 0, param2:Number = 0) : GameFightPlacementSwapPositionsRequestMessage
      {
         super.initGameFightPlacementPositionRequestMessage(param1);
         this.requestedId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.requestedId = 0;
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameFightPlacementSwapPositionsRequestMessage(param1);
      }
      
      public function serializeAs_GameFightPlacementSwapPositionsRequestMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameFightPlacementPositionRequestMessage(param1);
         if(this.requestedId < -9007199254740990 || this.requestedId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.requestedId + ") on element requestedId.");
         }
         param1.writeDouble(this.requestedId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightPlacementSwapPositionsRequestMessage(param1);
      }
      
      public function deserializeAs_GameFightPlacementSwapPositionsRequestMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._requestedIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightPlacementSwapPositionsRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightPlacementSwapPositionsRequestMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._requestedIdFunc);
      }
      
      private function _requestedIdFunc(param1:ICustomDataInput) : void
      {
         this.requestedId = param1.readDouble();
         if(this.requestedId < -9007199254740990 || this.requestedId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.requestedId + ") on element of GameFightPlacementSwapPositionsRequestMessage.requestedId.");
         }
      }
   }
}
