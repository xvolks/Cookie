package com.ankamagames.dofus.network.messages.game.alliance
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.AllianceInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AllianceJoinedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6402;
       
      
      private var _isInitialized:Boolean = false;
      
      public var allianceInfo:AllianceInformations;
      
      public var enabled:Boolean = false;
      
      public var leadingGuildId:uint = 0;
      
      private var _allianceInfotree:FuncTree;
      
      public function AllianceJoinedMessage()
      {
         this.allianceInfo = new AllianceInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6402;
      }
      
      public function initAllianceJoinedMessage(param1:AllianceInformations = null, param2:Boolean = false, param3:uint = 0) : AllianceJoinedMessage
      {
         this.allianceInfo = param1;
         this.enabled = param2;
         this.leadingGuildId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.allianceInfo = new AllianceInformations();
         this.leadingGuildId = 0;
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
         this.serializeAs_AllianceJoinedMessage(param1);
      }
      
      public function serializeAs_AllianceJoinedMessage(param1:ICustomDataOutput) : void
      {
         this.allianceInfo.serializeAs_AllianceInformations(param1);
         param1.writeBoolean(this.enabled);
         if(this.leadingGuildId < 0)
         {
            throw new Error("Forbidden value (" + this.leadingGuildId + ") on element leadingGuildId.");
         }
         param1.writeVarInt(this.leadingGuildId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AllianceJoinedMessage(param1);
      }
      
      public function deserializeAs_AllianceJoinedMessage(param1:ICustomDataInput) : void
      {
         this.allianceInfo = new AllianceInformations();
         this.allianceInfo.deserialize(param1);
         this._enabledFunc(param1);
         this._leadingGuildIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AllianceJoinedMessage(param1);
      }
      
      public function deserializeAsyncAs_AllianceJoinedMessage(param1:FuncTree) : void
      {
         this._allianceInfotree = param1.addChild(this._allianceInfotreeFunc);
         param1.addChild(this._enabledFunc);
         param1.addChild(this._leadingGuildIdFunc);
      }
      
      private function _allianceInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.allianceInfo = new AllianceInformations();
         this.allianceInfo.deserializeAsync(this._allianceInfotree);
      }
      
      private function _enabledFunc(param1:ICustomDataInput) : void
      {
         this.enabled = param1.readBoolean();
      }
      
      private function _leadingGuildIdFunc(param1:ICustomDataInput) : void
      {
         this.leadingGuildId = param1.readVarUhInt();
         if(this.leadingGuildId < 0)
         {
            throw new Error("Forbidden value (" + this.leadingGuildId + ") on element of AllianceJoinedMessage.leadingGuildId.");
         }
      }
   }
}
