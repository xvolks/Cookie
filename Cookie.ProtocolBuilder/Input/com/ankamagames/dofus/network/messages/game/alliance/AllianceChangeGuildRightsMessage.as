package com.ankamagames.dofus.network.messages.game.alliance
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AllianceChangeGuildRightsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6426;
       
      
      private var _isInitialized:Boolean = false;
      
      public var guildId:uint = 0;
      
      public var rights:uint = 0;
      
      public function AllianceChangeGuildRightsMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6426;
      }
      
      public function initAllianceChangeGuildRightsMessage(param1:uint = 0, param2:uint = 0) : AllianceChangeGuildRightsMessage
      {
         this.guildId = param1;
         this.rights = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.guildId = 0;
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
         this.serializeAs_AllianceChangeGuildRightsMessage(param1);
      }
      
      public function serializeAs_AllianceChangeGuildRightsMessage(param1:ICustomDataOutput) : void
      {
         if(this.guildId < 0)
         {
            throw new Error("Forbidden value (" + this.guildId + ") on element guildId.");
         }
         param1.writeVarInt(this.guildId);
         if(this.rights < 0)
         {
            throw new Error("Forbidden value (" + this.rights + ") on element rights.");
         }
         param1.writeByte(this.rights);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AllianceChangeGuildRightsMessage(param1);
      }
      
      public function deserializeAs_AllianceChangeGuildRightsMessage(param1:ICustomDataInput) : void
      {
         this._guildIdFunc(param1);
         this._rightsFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AllianceChangeGuildRightsMessage(param1);
      }
      
      public function deserializeAsyncAs_AllianceChangeGuildRightsMessage(param1:FuncTree) : void
      {
         param1.addChild(this._guildIdFunc);
         param1.addChild(this._rightsFunc);
      }
      
      private function _guildIdFunc(param1:ICustomDataInput) : void
      {
         this.guildId = param1.readVarUhInt();
         if(this.guildId < 0)
         {
            throw new Error("Forbidden value (" + this.guildId + ") on element of AllianceChangeGuildRightsMessage.guildId.");
         }
      }
      
      private function _rightsFunc(param1:ICustomDataInput) : void
      {
         this.rights = param1.readByte();
         if(this.rights < 0)
         {
            throw new Error("Forbidden value (" + this.rights + ") on element of AllianceChangeGuildRightsMessage.rights.");
         }
      }
   }
}
