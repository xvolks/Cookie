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
   public class GuildMemberOnlineStatusMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6061;
       
      
      private var _isInitialized:Boolean = false;
      
      public var memberId:Number = 0;
      
      public var online:Boolean = false;
      
      public function GuildMemberOnlineStatusMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6061;
      }
      
      public function initGuildMemberOnlineStatusMessage(param1:Number = 0, param2:Boolean = false) : GuildMemberOnlineStatusMessage
      {
         this.memberId = param1;
         this.online = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.memberId = 0;
         this.online = false;
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
         this.serializeAs_GuildMemberOnlineStatusMessage(param1);
      }
      
      public function serializeAs_GuildMemberOnlineStatusMessage(param1:ICustomDataOutput) : void
      {
         if(this.memberId < 0 || this.memberId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element memberId.");
         }
         param1.writeVarLong(this.memberId);
         param1.writeBoolean(this.online);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildMemberOnlineStatusMessage(param1);
      }
      
      public function deserializeAs_GuildMemberOnlineStatusMessage(param1:ICustomDataInput) : void
      {
         this._memberIdFunc(param1);
         this._onlineFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildMemberOnlineStatusMessage(param1);
      }
      
      public function deserializeAsyncAs_GuildMemberOnlineStatusMessage(param1:FuncTree) : void
      {
         param1.addChild(this._memberIdFunc);
         param1.addChild(this._onlineFunc);
      }
      
      private function _memberIdFunc(param1:ICustomDataInput) : void
      {
         this.memberId = param1.readVarUhLong();
         if(this.memberId < 0 || this.memberId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element of GuildMemberOnlineStatusMessage.memberId.");
         }
      }
      
      private function _onlineFunc(param1:ICustomDataInput) : void
      {
         this.online = param1.readBoolean();
      }
   }
}
