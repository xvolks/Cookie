package com.ankamagames.dofus.network.messages.game.guild
{
   import com.ankamagames.dofus.network.types.game.guild.GuildMember;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GuildInformationsMemberUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5597;
       
      
      private var _isInitialized:Boolean = false;
      
      public var member:GuildMember;
      
      private var _membertree:FuncTree;
      
      public function GuildInformationsMemberUpdateMessage()
      {
         this.member = new GuildMember();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5597;
      }
      
      public function initGuildInformationsMemberUpdateMessage(param1:GuildMember = null) : GuildInformationsMemberUpdateMessage
      {
         this.member = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.member = new GuildMember();
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
         this.serializeAs_GuildInformationsMemberUpdateMessage(param1);
      }
      
      public function serializeAs_GuildInformationsMemberUpdateMessage(param1:ICustomDataOutput) : void
      {
         this.member.serializeAs_GuildMember(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildInformationsMemberUpdateMessage(param1);
      }
      
      public function deserializeAs_GuildInformationsMemberUpdateMessage(param1:ICustomDataInput) : void
      {
         this.member = new GuildMember();
         this.member.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildInformationsMemberUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_GuildInformationsMemberUpdateMessage(param1:FuncTree) : void
      {
         this._membertree = param1.addChild(this._membertreeFunc);
      }
      
      private function _membertreeFunc(param1:ICustomDataInput) : void
      {
         this.member = new GuildMember();
         this.member.deserializeAsync(this._membertree);
      }
   }
}
