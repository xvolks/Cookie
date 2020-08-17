package com.ankamagames.dofus.network.messages.game.context.roleplay.party
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.roleplay.party.PartyMemberInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PartyUpdateMessage extends AbstractPartyEventMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5575;
       
      
      private var _isInitialized:Boolean = false;
      
      public var memberInformations:PartyMemberInformations;
      
      private var _memberInformationstree:FuncTree;
      
      public function PartyUpdateMessage()
      {
         this.memberInformations = new PartyMemberInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5575;
      }
      
      public function initPartyUpdateMessage(param1:uint = 0, param2:PartyMemberInformations = null) : PartyUpdateMessage
      {
         super.initAbstractPartyEventMessage(param1);
         this.memberInformations = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.memberInformations = new PartyMemberInformations();
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PartyUpdateMessage(param1);
      }
      
      public function serializeAs_PartyUpdateMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractPartyEventMessage(param1);
         param1.writeShort(this.memberInformations.getTypeId());
         this.memberInformations.serialize(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyUpdateMessage(param1);
      }
      
      public function deserializeAs_PartyUpdateMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         this.memberInformations = ProtocolTypeManager.getInstance(PartyMemberInformations,_loc2_);
         this.memberInformations.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_PartyUpdateMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._memberInformationstree = param1.addChild(this._memberInformationstreeFunc);
      }
      
      private function _memberInformationstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.memberInformations = ProtocolTypeManager.getInstance(PartyMemberInformations,_loc2_);
         this.memberInformations.deserializeAsync(this._memberInformationstree);
      }
   }
}
