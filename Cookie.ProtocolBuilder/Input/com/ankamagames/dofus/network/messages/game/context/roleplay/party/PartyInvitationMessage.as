package com.ankamagames.dofus.network.messages.game.context.roleplay.party
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PartyInvitationMessage extends AbstractPartyMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5586;
       
      
      private var _isInitialized:Boolean = false;
      
      public var partyType:uint = 0;
      
      public var partyName:String = "";
      
      public var maxParticipants:uint = 0;
      
      public var fromId:Number = 0;
      
      public var fromName:String = "";
      
      public var toId:Number = 0;
      
      public function PartyInvitationMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5586;
      }
      
      public function initPartyInvitationMessage(param1:uint = 0, param2:uint = 0, param3:String = "", param4:uint = 0, param5:Number = 0, param6:String = "", param7:Number = 0) : PartyInvitationMessage
      {
         super.initAbstractPartyMessage(param1);
         this.partyType = param2;
         this.partyName = param3;
         this.maxParticipants = param4;
         this.fromId = param5;
         this.fromName = param6;
         this.toId = param7;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.partyType = 0;
         this.partyName = "";
         this.maxParticipants = 0;
         this.fromId = 0;
         this.fromName = "";
         this.toId = 0;
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
         this.serializeAs_PartyInvitationMessage(param1);
      }
      
      public function serializeAs_PartyInvitationMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractPartyMessage(param1);
         param1.writeByte(this.partyType);
         param1.writeUTF(this.partyName);
         if(this.maxParticipants < 0)
         {
            throw new Error("Forbidden value (" + this.maxParticipants + ") on element maxParticipants.");
         }
         param1.writeByte(this.maxParticipants);
         if(this.fromId < 0 || this.fromId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.fromId + ") on element fromId.");
         }
         param1.writeVarLong(this.fromId);
         param1.writeUTF(this.fromName);
         if(this.toId < 0 || this.toId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.toId + ") on element toId.");
         }
         param1.writeVarLong(this.toId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyInvitationMessage(param1);
      }
      
      public function deserializeAs_PartyInvitationMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._partyTypeFunc(param1);
         this._partyNameFunc(param1);
         this._maxParticipantsFunc(param1);
         this._fromIdFunc(param1);
         this._fromNameFunc(param1);
         this._toIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyInvitationMessage(param1);
      }
      
      public function deserializeAsyncAs_PartyInvitationMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._partyTypeFunc);
         param1.addChild(this._partyNameFunc);
         param1.addChild(this._maxParticipantsFunc);
         param1.addChild(this._fromIdFunc);
         param1.addChild(this._fromNameFunc);
         param1.addChild(this._toIdFunc);
      }
      
      private function _partyTypeFunc(param1:ICustomDataInput) : void
      {
         this.partyType = param1.readByte();
         if(this.partyType < 0)
         {
            throw new Error("Forbidden value (" + this.partyType + ") on element of PartyInvitationMessage.partyType.");
         }
      }
      
      private function _partyNameFunc(param1:ICustomDataInput) : void
      {
         this.partyName = param1.readUTF();
      }
      
      private function _maxParticipantsFunc(param1:ICustomDataInput) : void
      {
         this.maxParticipants = param1.readByte();
         if(this.maxParticipants < 0)
         {
            throw new Error("Forbidden value (" + this.maxParticipants + ") on element of PartyInvitationMessage.maxParticipants.");
         }
      }
      
      private function _fromIdFunc(param1:ICustomDataInput) : void
      {
         this.fromId = param1.readVarUhLong();
         if(this.fromId < 0 || this.fromId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.fromId + ") on element of PartyInvitationMessage.fromId.");
         }
      }
      
      private function _fromNameFunc(param1:ICustomDataInput) : void
      {
         this.fromName = param1.readUTF();
      }
      
      private function _toIdFunc(param1:ICustomDataInput) : void
      {
         this.toId = param1.readVarUhLong();
         if(this.toId < 0 || this.toId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.toId + ") on element of PartyInvitationMessage.toId.");
         }
      }
   }
}
