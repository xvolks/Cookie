package com.ankamagames.dofus.network.messages.game.chat.smiley
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class MoodSmileyUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6388;
       
      
      private var _isInitialized:Boolean = false;
      
      public var accountId:uint = 0;
      
      public var playerId:Number = 0;
      
      public var smileyId:uint = 0;
      
      public function MoodSmileyUpdateMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6388;
      }
      
      public function initMoodSmileyUpdateMessage(param1:uint = 0, param2:Number = 0, param3:uint = 0) : MoodSmileyUpdateMessage
      {
         this.accountId = param1;
         this.playerId = param2;
         this.smileyId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.accountId = 0;
         this.playerId = 0;
         this.smileyId = 0;
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
         this.serializeAs_MoodSmileyUpdateMessage(param1);
      }
      
      public function serializeAs_MoodSmileyUpdateMessage(param1:ICustomDataOutput) : void
      {
         if(this.accountId < 0)
         {
            throw new Error("Forbidden value (" + this.accountId + ") on element accountId.");
         }
         param1.writeInt(this.accountId);
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element playerId.");
         }
         param1.writeVarLong(this.playerId);
         if(this.smileyId < 0)
         {
            throw new Error("Forbidden value (" + this.smileyId + ") on element smileyId.");
         }
         param1.writeVarShort(this.smileyId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MoodSmileyUpdateMessage(param1);
      }
      
      public function deserializeAs_MoodSmileyUpdateMessage(param1:ICustomDataInput) : void
      {
         this._accountIdFunc(param1);
         this._playerIdFunc(param1);
         this._smileyIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MoodSmileyUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_MoodSmileyUpdateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._accountIdFunc);
         param1.addChild(this._playerIdFunc);
         param1.addChild(this._smileyIdFunc);
      }
      
      private function _accountIdFunc(param1:ICustomDataInput) : void
      {
         this.accountId = param1.readInt();
         if(this.accountId < 0)
         {
            throw new Error("Forbidden value (" + this.accountId + ") on element of MoodSmileyUpdateMessage.accountId.");
         }
      }
      
      private function _playerIdFunc(param1:ICustomDataInput) : void
      {
         this.playerId = param1.readVarUhLong();
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element of MoodSmileyUpdateMessage.playerId.");
         }
      }
      
      private function _smileyIdFunc(param1:ICustomDataInput) : void
      {
         this.smileyId = param1.readVarUhShort();
         if(this.smileyId < 0)
         {
            throw new Error("Forbidden value (" + this.smileyId + ") on element of MoodSmileyUpdateMessage.smileyId.");
         }
      }
   }
}
