package com.ankamagames.dofus.network.messages.game.context.roleplay.party
{
   import com.ankamagames.dofus.network.types.game.context.MapCoordinatesExtended;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PartyMemberInFightMessage extends AbstractPartyMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6342;
       
      
      private var _isInitialized:Boolean = false;
      
      public var reason:uint = 0;
      
      public var memberId:Number = 0;
      
      public var memberAccountId:uint = 0;
      
      public var memberName:String = "";
      
      public var fightId:int = 0;
      
      public var fightMap:MapCoordinatesExtended;
      
      public var timeBeforeFightStart:int = 0;
      
      private var _fightMaptree:FuncTree;
      
      public function PartyMemberInFightMessage()
      {
         this.fightMap = new MapCoordinatesExtended();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6342;
      }
      
      public function initPartyMemberInFightMessage(param1:uint = 0, param2:uint = 0, param3:Number = 0, param4:uint = 0, param5:String = "", param6:int = 0, param7:MapCoordinatesExtended = null, param8:int = 0) : PartyMemberInFightMessage
      {
         super.initAbstractPartyMessage(param1);
         this.reason = param2;
         this.memberId = param3;
         this.memberAccountId = param4;
         this.memberName = param5;
         this.fightId = param6;
         this.fightMap = param7;
         this.timeBeforeFightStart = param8;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.reason = 0;
         this.memberId = 0;
         this.memberAccountId = 0;
         this.memberName = "";
         this.fightId = 0;
         this.fightMap = new MapCoordinatesExtended();
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
         this.serializeAs_PartyMemberInFightMessage(param1);
      }
      
      public function serializeAs_PartyMemberInFightMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractPartyMessage(param1);
         param1.writeByte(this.reason);
         if(this.memberId < 0 || this.memberId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element memberId.");
         }
         param1.writeVarLong(this.memberId);
         if(this.memberAccountId < 0)
         {
            throw new Error("Forbidden value (" + this.memberAccountId + ") on element memberAccountId.");
         }
         param1.writeInt(this.memberAccountId);
         param1.writeUTF(this.memberName);
         param1.writeInt(this.fightId);
         this.fightMap.serializeAs_MapCoordinatesExtended(param1);
         param1.writeVarShort(this.timeBeforeFightStart);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyMemberInFightMessage(param1);
      }
      
      public function deserializeAs_PartyMemberInFightMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._reasonFunc(param1);
         this._memberIdFunc(param1);
         this._memberAccountIdFunc(param1);
         this._memberNameFunc(param1);
         this._fightIdFunc(param1);
         this.fightMap = new MapCoordinatesExtended();
         this.fightMap.deserialize(param1);
         this._timeBeforeFightStartFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyMemberInFightMessage(param1);
      }
      
      public function deserializeAsyncAs_PartyMemberInFightMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._reasonFunc);
         param1.addChild(this._memberIdFunc);
         param1.addChild(this._memberAccountIdFunc);
         param1.addChild(this._memberNameFunc);
         param1.addChild(this._fightIdFunc);
         this._fightMaptree = param1.addChild(this._fightMaptreeFunc);
         param1.addChild(this._timeBeforeFightStartFunc);
      }
      
      private function _reasonFunc(param1:ICustomDataInput) : void
      {
         this.reason = param1.readByte();
         if(this.reason < 0)
         {
            throw new Error("Forbidden value (" + this.reason + ") on element of PartyMemberInFightMessage.reason.");
         }
      }
      
      private function _memberIdFunc(param1:ICustomDataInput) : void
      {
         this.memberId = param1.readVarUhLong();
         if(this.memberId < 0 || this.memberId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element of PartyMemberInFightMessage.memberId.");
         }
      }
      
      private function _memberAccountIdFunc(param1:ICustomDataInput) : void
      {
         this.memberAccountId = param1.readInt();
         if(this.memberAccountId < 0)
         {
            throw new Error("Forbidden value (" + this.memberAccountId + ") on element of PartyMemberInFightMessage.memberAccountId.");
         }
      }
      
      private function _memberNameFunc(param1:ICustomDataInput) : void
      {
         this.memberName = param1.readUTF();
      }
      
      private function _fightIdFunc(param1:ICustomDataInput) : void
      {
         this.fightId = param1.readInt();
      }
      
      private function _fightMaptreeFunc(param1:ICustomDataInput) : void
      {
         this.fightMap = new MapCoordinatesExtended();
         this.fightMap.deserializeAsync(this._fightMaptree);
      }
      
      private function _timeBeforeFightStartFunc(param1:ICustomDataInput) : void
      {
         this.timeBeforeFightStart = param1.readVarShort();
      }
   }
}
