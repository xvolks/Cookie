package com.ankamagames.dofus.network.messages.game.guild
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.GuildInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GuildJoinedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5564;
       
      
      private var _isInitialized:Boolean = false;
      
      public var guildInfo:GuildInformations;
      
      public var memberRights:uint = 0;
      
      private var _guildInfotree:FuncTree;
      
      public function GuildJoinedMessage()
      {
         this.guildInfo = new GuildInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5564;
      }
      
      public function initGuildJoinedMessage(param1:GuildInformations = null, param2:uint = 0) : GuildJoinedMessage
      {
         this.guildInfo = param1;
         this.memberRights = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.guildInfo = new GuildInformations();
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
         this.serializeAs_GuildJoinedMessage(param1);
      }
      
      public function serializeAs_GuildJoinedMessage(param1:ICustomDataOutput) : void
      {
         this.guildInfo.serializeAs_GuildInformations(param1);
         if(this.memberRights < 0)
         {
            throw new Error("Forbidden value (" + this.memberRights + ") on element memberRights.");
         }
         param1.writeVarInt(this.memberRights);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildJoinedMessage(param1);
      }
      
      public function deserializeAs_GuildJoinedMessage(param1:ICustomDataInput) : void
      {
         this.guildInfo = new GuildInformations();
         this.guildInfo.deserialize(param1);
         this._memberRightsFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildJoinedMessage(param1);
      }
      
      public function deserializeAsyncAs_GuildJoinedMessage(param1:FuncTree) : void
      {
         this._guildInfotree = param1.addChild(this._guildInfotreeFunc);
         param1.addChild(this._memberRightsFunc);
      }
      
      private function _guildInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.guildInfo = new GuildInformations();
         this.guildInfo.deserializeAsync(this._guildInfotree);
      }
      
      private function _memberRightsFunc(param1:ICustomDataInput) : void
      {
         this.memberRights = param1.readVarUhInt();
         if(this.memberRights < 0)
         {
            throw new Error("Forbidden value (" + this.memberRights + ") on element of GuildJoinedMessage.memberRights.");
         }
      }
   }
}
