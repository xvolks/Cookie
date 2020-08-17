package com.ankamagames.dofus.network.messages.game.guild
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ChallengeFightJoinRefusedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5908;
       
      
      private var _isInitialized:Boolean = false;
      
      public var playerId:Number = 0;
      
      public var reason:int = 0;
      
      public function ChallengeFightJoinRefusedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5908;
      }
      
      public function initChallengeFightJoinRefusedMessage(param1:Number = 0, param2:int = 0) : ChallengeFightJoinRefusedMessage
      {
         this.playerId = param1;
         this.reason = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.playerId = 0;
         this.reason = 0;
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
         this.serializeAs_ChallengeFightJoinRefusedMessage(param1);
      }
      
      public function serializeAs_ChallengeFightJoinRefusedMessage(param1:ICustomDataOutput) : void
      {
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element playerId.");
         }
         param1.writeVarLong(this.playerId);
         param1.writeByte(this.reason);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ChallengeFightJoinRefusedMessage(param1);
      }
      
      public function deserializeAs_ChallengeFightJoinRefusedMessage(param1:ICustomDataInput) : void
      {
         this._playerIdFunc(param1);
         this._reasonFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ChallengeFightJoinRefusedMessage(param1);
      }
      
      public function deserializeAsyncAs_ChallengeFightJoinRefusedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._playerIdFunc);
         param1.addChild(this._reasonFunc);
      }
      
      private function _playerIdFunc(param1:ICustomDataInput) : void
      {
         this.playerId = param1.readVarUhLong();
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element of ChallengeFightJoinRefusedMessage.playerId.");
         }
      }
      
      private function _reasonFunc(param1:ICustomDataInput) : void
      {
         this.reason = param1.readByte();
      }
   }
}
