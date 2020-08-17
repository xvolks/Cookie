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
   public class GuildChangeMemberParametersMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5549;
       
      
      private var _isInitialized:Boolean = false;
      
      public var memberId:Number = 0;
      
      public var rank:uint = 0;
      
      public var experienceGivenPercent:uint = 0;
      
      public var rights:uint = 0;
      
      public function GuildChangeMemberParametersMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5549;
      }
      
      public function initGuildChangeMemberParametersMessage(param1:Number = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0) : GuildChangeMemberParametersMessage
      {
         this.memberId = param1;
         this.rank = param2;
         this.experienceGivenPercent = param3;
         this.rights = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.memberId = 0;
         this.rank = 0;
         this.experienceGivenPercent = 0;
         this.rights = 0;
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
         this.serializeAs_GuildChangeMemberParametersMessage(param1);
      }
      
      public function serializeAs_GuildChangeMemberParametersMessage(param1:ICustomDataOutput) : void
      {
         if(this.memberId < 0 || this.memberId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element memberId.");
         }
         param1.writeVarLong(this.memberId);
         if(this.rank < 0)
         {
            throw new Error("Forbidden value (" + this.rank + ") on element rank.");
         }
         param1.writeVarShort(this.rank);
         if(this.experienceGivenPercent < 0 || this.experienceGivenPercent > 100)
         {
            throw new Error("Forbidden value (" + this.experienceGivenPercent + ") on element experienceGivenPercent.");
         }
         param1.writeByte(this.experienceGivenPercent);
         if(this.rights < 0)
         {
            throw new Error("Forbidden value (" + this.rights + ") on element rights.");
         }
         param1.writeVarInt(this.rights);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildChangeMemberParametersMessage(param1);
      }
      
      public function deserializeAs_GuildChangeMemberParametersMessage(param1:ICustomDataInput) : void
      {
         this._memberIdFunc(param1);
         this._rankFunc(param1);
         this._experienceGivenPercentFunc(param1);
         this._rightsFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildChangeMemberParametersMessage(param1);
      }
      
      public function deserializeAsyncAs_GuildChangeMemberParametersMessage(param1:FuncTree) : void
      {
         param1.addChild(this._memberIdFunc);
         param1.addChild(this._rankFunc);
         param1.addChild(this._experienceGivenPercentFunc);
         param1.addChild(this._rightsFunc);
      }
      
      private function _memberIdFunc(param1:ICustomDataInput) : void
      {
         this.memberId = param1.readVarUhLong();
         if(this.memberId < 0 || this.memberId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element of GuildChangeMemberParametersMessage.memberId.");
         }
      }
      
      private function _rankFunc(param1:ICustomDataInput) : void
      {
         this.rank = param1.readVarUhShort();
         if(this.rank < 0)
         {
            throw new Error("Forbidden value (" + this.rank + ") on element of GuildChangeMemberParametersMessage.rank.");
         }
      }
      
      private function _experienceGivenPercentFunc(param1:ICustomDataInput) : void
      {
         this.experienceGivenPercent = param1.readByte();
         if(this.experienceGivenPercent < 0 || this.experienceGivenPercent > 100)
         {
            throw new Error("Forbidden value (" + this.experienceGivenPercent + ") on element of GuildChangeMemberParametersMessage.experienceGivenPercent.");
         }
      }
      
      private function _rightsFunc(param1:ICustomDataInput) : void
      {
         this.rights = param1.readVarUhInt();
         if(this.rights < 0)
         {
            throw new Error("Forbidden value (" + this.rights + ") on element of GuildChangeMemberParametersMessage.rights.");
         }
      }
   }
}
