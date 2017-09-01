package com.ankamagames.dofus.network.messages.game.guild
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.BasicGuildInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GuildInvitedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5552;
       
      
      private var _isInitialized:Boolean = false;
      
      public var recruterId:Number = 0;
      
      public var recruterName:String = "";
      
      public var guildInfo:BasicGuildInformations;
      
      private var _guildInfotree:FuncTree;
      
      public function GuildInvitedMessage()
      {
         this.guildInfo = new BasicGuildInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5552;
      }
      
      public function initGuildInvitedMessage(param1:Number = 0, param2:String = "", param3:BasicGuildInformations = null) : GuildInvitedMessage
      {
         this.recruterId = param1;
         this.recruterName = param2;
         this.guildInfo = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.recruterId = 0;
         this.recruterName = "";
         this.guildInfo = new BasicGuildInformations();
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
         this.serializeAs_GuildInvitedMessage(param1);
      }
      
      public function serializeAs_GuildInvitedMessage(param1:ICustomDataOutput) : void
      {
         if(this.recruterId < 0 || this.recruterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.recruterId + ") on element recruterId.");
         }
         param1.writeVarLong(this.recruterId);
         param1.writeUTF(this.recruterName);
         this.guildInfo.serializeAs_BasicGuildInformations(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildInvitedMessage(param1);
      }
      
      public function deserializeAs_GuildInvitedMessage(param1:ICustomDataInput) : void
      {
         this._recruterIdFunc(param1);
         this._recruterNameFunc(param1);
         this.guildInfo = new BasicGuildInformations();
         this.guildInfo.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildInvitedMessage(param1);
      }
      
      public function deserializeAsyncAs_GuildInvitedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._recruterIdFunc);
         param1.addChild(this._recruterNameFunc);
         this._guildInfotree = param1.addChild(this._guildInfotreeFunc);
      }
      
      private function _recruterIdFunc(param1:ICustomDataInput) : void
      {
         this.recruterId = param1.readVarUhLong();
         if(this.recruterId < 0 || this.recruterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.recruterId + ") on element of GuildInvitedMessage.recruterId.");
         }
      }
      
      private function _recruterNameFunc(param1:ICustomDataInput) : void
      {
         this.recruterName = param1.readUTF();
      }
      
      private function _guildInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.guildInfo = new BasicGuildInformations();
         this.guildInfo.deserializeAsync(this._guildInfotree);
      }
   }
}
