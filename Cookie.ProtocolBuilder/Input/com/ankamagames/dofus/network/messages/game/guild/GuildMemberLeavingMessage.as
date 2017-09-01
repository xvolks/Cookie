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
   public class GuildMemberLeavingMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5923;
       
      
      private var _isInitialized:Boolean = false;
      
      public var kicked:Boolean = false;
      
      public var memberId:Number = 0;
      
      public function GuildMemberLeavingMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5923;
      }
      
      public function initGuildMemberLeavingMessage(param1:Boolean = false, param2:Number = 0) : GuildMemberLeavingMessage
      {
         this.kicked = param1;
         this.memberId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.kicked = false;
         this.memberId = 0;
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
         this.serializeAs_GuildMemberLeavingMessage(param1);
      }
      
      public function serializeAs_GuildMemberLeavingMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.kicked);
         if(this.memberId < 0 || this.memberId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element memberId.");
         }
         param1.writeVarLong(this.memberId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildMemberLeavingMessage(param1);
      }
      
      public function deserializeAs_GuildMemberLeavingMessage(param1:ICustomDataInput) : void
      {
         this._kickedFunc(param1);
         this._memberIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildMemberLeavingMessage(param1);
      }
      
      public function deserializeAsyncAs_GuildMemberLeavingMessage(param1:FuncTree) : void
      {
         param1.addChild(this._kickedFunc);
         param1.addChild(this._memberIdFunc);
      }
      
      private function _kickedFunc(param1:ICustomDataInput) : void
      {
         this.kicked = param1.readBoolean();
      }
      
      private function _memberIdFunc(param1:ICustomDataInput) : void
      {
         this.memberId = param1.readVarUhLong();
         if(this.memberId < 0 || this.memberId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element of GuildMemberLeavingMessage.memberId.");
         }
      }
   }
}
