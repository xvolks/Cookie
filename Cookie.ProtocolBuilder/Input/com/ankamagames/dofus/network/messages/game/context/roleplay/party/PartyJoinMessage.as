package com.ankamagames.dofus.network.messages.game.context.roleplay.party
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.roleplay.party.PartyGuestInformations;
   import com.ankamagames.dofus.network.types.game.context.roleplay.party.PartyMemberInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   public class PartyJoinMessage extends AbstractPartyMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5576;
       
      
      private var _isInitialized:Boolean = false;
      
      public var partyType:uint = 0;
      
      public var partyLeaderId:Number = 0;
      
      public var maxParticipants:uint = 0;
      
      public var members:Vector.<PartyMemberInformations>;
      
      public var guests:Vector.<PartyGuestInformations>;
      
      public var restricted:Boolean = false;
      
      public var partyName:String = "";
      
      private var _memberstree:FuncTree;
      
      private var _gueststree:FuncTree;
      
      public function PartyJoinMessage()
      {
         this.members = new Vector.<PartyMemberInformations>();
         this.guests = new Vector.<PartyGuestInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5576;
      }
      
      public function initPartyJoinMessage(param1:uint = 0, param2:uint = 0, param3:Number = 0, param4:uint = 0, param5:Vector.<PartyMemberInformations> = null, param6:Vector.<PartyGuestInformations> = null, param7:Boolean = false, param8:String = "") : PartyJoinMessage
      {
         super.initAbstractPartyMessage(param1);
         this.partyType = param2;
         this.partyLeaderId = param3;
         this.maxParticipants = param4;
         this.members = param5;
         this.guests = param6;
         this.restricted = param7;
         this.partyName = param8;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.partyType = 0;
         this.partyLeaderId = 0;
         this.maxParticipants = 0;
         this.members = new Vector.<PartyMemberInformations>();
         this.guests = new Vector.<PartyGuestInformations>();
         this.restricted = false;
         this.partyName = "";
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
         this.serializeAs_PartyJoinMessage(param1);
      }
      
      public function serializeAs_PartyJoinMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractPartyMessage(param1);
         param1.writeByte(this.partyType);
         if(this.partyLeaderId < 0 || this.partyLeaderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.partyLeaderId + ") on element partyLeaderId.");
         }
         param1.writeVarLong(this.partyLeaderId);
         if(this.maxParticipants < 0)
         {
            throw new Error("Forbidden value (" + this.maxParticipants + ") on element maxParticipants.");
         }
         param1.writeByte(this.maxParticipants);
         param1.writeShort(this.members.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.members.length)
         {
            param1.writeShort((this.members[_loc2_] as PartyMemberInformations).getTypeId());
            (this.members[_loc2_] as PartyMemberInformations).serialize(param1);
            _loc2_++;
         }
         param1.writeShort(this.guests.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.guests.length)
         {
            (this.guests[_loc3_] as PartyGuestInformations).serializeAs_PartyGuestInformations(param1);
            _loc3_++;
         }
         param1.writeBoolean(this.restricted);
         param1.writeUTF(this.partyName);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyJoinMessage(param1);
      }
      
      public function deserializeAs_PartyJoinMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:PartyMemberInformations = null;
         var _loc8_:PartyGuestInformations = null;
         super.deserialize(param1);
         this._partyTypeFunc(param1);
         this._partyLeaderIdFunc(param1);
         this._maxParticipantsFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readUnsignedShort();
            _loc7_ = ProtocolTypeManager.getInstance(PartyMemberInformations,_loc6_);
            _loc7_.deserialize(param1);
            this.members.push(_loc7_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc8_ = new PartyGuestInformations();
            _loc8_.deserialize(param1);
            this.guests.push(_loc8_);
            _loc5_++;
         }
         this._restrictedFunc(param1);
         this._partyNameFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyJoinMessage(param1);
      }
      
      public function deserializeAsyncAs_PartyJoinMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._partyTypeFunc);
         param1.addChild(this._partyLeaderIdFunc);
         param1.addChild(this._maxParticipantsFunc);
         this._memberstree = param1.addChild(this._memberstreeFunc);
         this._gueststree = param1.addChild(this._gueststreeFunc);
         param1.addChild(this._restrictedFunc);
         param1.addChild(this._partyNameFunc);
      }
      
      private function _partyTypeFunc(param1:ICustomDataInput) : void
      {
         this.partyType = param1.readByte();
         if(this.partyType < 0)
         {
            throw new Error("Forbidden value (" + this.partyType + ") on element of PartyJoinMessage.partyType.");
         }
      }
      
      private function _partyLeaderIdFunc(param1:ICustomDataInput) : void
      {
         this.partyLeaderId = param1.readVarUhLong();
         if(this.partyLeaderId < 0 || this.partyLeaderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.partyLeaderId + ") on element of PartyJoinMessage.partyLeaderId.");
         }
      }
      
      private function _maxParticipantsFunc(param1:ICustomDataInput) : void
      {
         this.maxParticipants = param1.readByte();
         if(this.maxParticipants < 0)
         {
            throw new Error("Forbidden value (" + this.maxParticipants + ") on element of PartyJoinMessage.maxParticipants.");
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
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:PartyMemberInformations = ProtocolTypeManager.getInstance(PartyMemberInformations,_loc2_);
         _loc3_.deserialize(param1);
         this.members.push(_loc3_);
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
      
      private function _restrictedFunc(param1:ICustomDataInput) : void
      {
         this.restricted = param1.readBoolean();
      }
      
      private function _partyNameFunc(param1:ICustomDataInput) : void
      {
         this.partyName = param1.readUTF();
      }
   }
}
