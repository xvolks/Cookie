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
   public class GameFightNewRoundMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6239;
       
      
      private var _isInitialized:Boolean = false;
      
      public var roundNumber:uint = 0;
      
      public function GameFightNewRoundMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6239;
      }
      
      public function initGameFightNewRoundMessage(param1:uint = 0) : GameFightNewRoundMessage
      {
         this.roundNumber = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.roundNumber = 0;
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
         this.serializeAs_GameFightNewRoundMessage(param1);
      }
      
      public function serializeAs_GameFightNewRoundMessage(param1:ICustomDataOutput) : void
      {
         if(this.roundNumber < 0)
         {
            throw new Error("Forbidden value (" + this.roundNumber + ") on element roundNumber.");
         }
         param1.writeVarInt(this.roundNumber);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightNewRoundMessage(param1);
      }
      
      public function deserializeAs_GameFightNewRoundMessage(param1:ICustomDataInput) : void
      {
         this._roundNumberFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightNewRoundMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightNewRoundMessage(param1:FuncTree) : void
      {
         param1.addChild(this._roundNumberFunc);
      }
      
      private function _roundNumberFunc(param1:ICustomDataInput) : void
      {
         this.roundNumber = param1.readVarUhInt();
         if(this.roundNumber < 0)
         {
            throw new Error("Forbidden value (" + this.roundNumber + ") on element of GameFightNewRoundMessage.roundNumber.");
         }
      }
   }
}
