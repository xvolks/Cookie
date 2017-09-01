package com.ankamagames.dofus.network.messages.game.context.roleplay.party
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.party.PartyGuestInformations;
   import com.ankamagames.dofus.network.types.game.context.roleplay.party.PartyInvitationMemberInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PartyInvitationDetailsMessage extends AbstractPartyMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6263;
       
      
      private var _isInitialized:Boolean = false;
      
      public var partyType:uint = 0;
      
      public var partyName:String = "";
      
      public var fromId:Number = 0;
      
      public var fromName:String = "";
      
      public var leaderId:Number = 0;
      
      public var members:Vector.<PartyInvitationMemberInformations>;
      
      public var guests:Vector.<PartyGuestInformations>;
      
      private var _memberstree:FuncTree;
      
      private var _gueststree:FuncTree;
      
      public function PartyInvitationDetailsMessage()
      {
         this.members = new Vector.<PartyInvitationMemberInformations>();
         this.guests = new Vector.<PartyGuestInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6263;
      }
      
      public function initPartyInvitationDetailsMessage(param1:uint = 0, param2:uint = 0, param3:String = "", param4:Number = 0, param5:String = "", param6:Number = 0, param7:Vector.<PartyInvitationMemberInformations> = null, param8:Vector.<PartyGuestInformations> = null) : PartyInvitationDetailsMessage
      {
         super.initAbstractPartyMessage(param1);
         this.partyType = param2;
         this.partyName = param3;
         this.fromId = param4;
         this.fromName = param5;
         this.leaderId = param6;
         this.members = param7;
         this.guests = param8;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.partyType = 0;
         this.partyName = "";
         this.fromId = 0;
         this.fromName = "";
         this.leaderId = 0;
         this.members = new Vector.<PartyInvitationMemberInformations>();
         this.guests = new Vector.<PartyGuestInformations>();
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
         this.serializeAs_PartyInvitationDetailsMessage(param1);
      }
      
      public function serializeAs_PartyInvitationDetailsMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractPartyMessage(param1);
         param1.writeByte(this.partyType);
         param1.writeUTF(this.partyName);
         if(this.fromId < 0 || this.fromId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.fromId + ") on element fromId.");
         }
         param1.writeVarLong(this.fromId);
         param1.writeUTF(this.fromName);
         if(this.leaderId < 0 || this.leaderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.leaderId + ") on element leaderId.");
         }
         param1.writeVarLong(this.leaderId);
         param1.writeShort(this.members.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.members.length)
         {
            (this.members[_loc2_] as PartyInvitationMemberInformations).serializeAs_PartyInvitationMemberInformations(param1);
            _loc2_++;
         }
         param1.writeShort(this.guests.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.guests.length)
         {
            (this.guests[_loc3_] as PartyGuestInformations).serializeAs_PartyGuestInformations(param1);
            _loc3_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyInvitationDetailsMessage(param1);
      }
      
      public function deserializeAs_PartyInvitationDetailsMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:PartyInvitationMemberInformations = null;
         var _loc7_:PartyGuestInformations = null;
         super.deserialize(param1);
         this._partyTypeFunc(param1);
         this._partyNameFunc(param1);
         this._fromIdFunc(param1);
         this._fromNameFunc(param1);
         this._leaderIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = new PartyInvitationMemberInformations();
            _loc6_.deserialize(param1);
            this.members.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = new PartyGuestInformations();
            _loc7_.deserialize(param1);
            this.guests.push(_loc7_);
            _loc5_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyInvitationDetailsMessage(param1);
      }
      
      public function deserializeAsyncAs_PartyInvitationDetailsMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._partyTypeFunc);
         param1.addChild(this._partyNameFunc);
         param1.addChild(this._fromIdFunc);
         param1.addChild(this._fromNameFunc);
         param1.addChild(this._leaderIdFunc);
         this._memberstree = param1.addChild(this._memberstreeFunc);
         this._gueststree = param1.addChild(this._gueststreeFunc);
      }
      
      private function _partyTypeFunc(param1:ICustomDataInput) : void
      {
         this.partyType = param1.readByte();
         if(this.partyType < 0)
         {
            throw new Error("Forbidden value (" + this.partyType + ") on element of PartyInvitationDetailsMessage.partyType.");
         }
      }
      
      private function _partyNameFunc(param1:ICustomDataInput) : void
      {
         this.partyName = param1.readUTF();
      }
      
      private function _fromIdFunc(param1:ICustomDataInput) : void
      {
         this.fromId = param1.readVarUhLong();
         if(this.fromId < 0 || this.fromId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.fromId + ") on element of PartyInvitationDetailsMessage.fromId.");
         }
      }
      
      private function _fromNameFunc(param1:ICustomDataInput) : void
      {
         this.fromName = param1.readUTF();
      }
      
      private function _leaderIdFunc(param1:ICustomDataInput) : void
      {
         this.leaderId = param1.readVarUhLong();
         if(this.leaderId < 0 || this.leaderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.leaderId + ") on element of PartyInvitationDetailsMessage.leaderId.");
         }
      }
      
      private function _memberstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._memberstree.addChild(this._membersFunc);
            _loc3_++;
         }
      }
      
      private function _membersFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:PartyInvitationMemberInformations = new PartyInvitationMemberInformations();
         _loc2_.deserialize(param1);
         this.members.push(_loc2_);
      }
      
      private function _gueststreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._gueststree.addChild(this._guestsFunc);
            _loc3_++;
         }
      }
      
      private function _guestsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:PartyGuestInformations = new PartyGuestInformations();
         _loc2_.deserialize(param1);
         this.guests.push(_loc2_);
      }
   }
}
