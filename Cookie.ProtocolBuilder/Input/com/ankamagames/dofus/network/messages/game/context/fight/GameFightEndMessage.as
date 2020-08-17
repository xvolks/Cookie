package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.fight.FightResultListEntry;
   import com.ankamagames.dofus.network.types.game.context.roleplay.party.NamedPartyTeamWithOutcome;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightEndMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 720;
       
      
      private var _isInitialized:Boolean = false;
      
      public var duration:uint = 0;
      
      public var ageBonus:int = 0;
      
      public var lootShareLimitMalus:int = 0;
      
      public var results:Vector.<FightResultListEntry>;
      
      public var namedPartyTeamsOutcomes:Vector.<NamedPartyTeamWithOutcome>;
      
      private var _resultstree:FuncTree;
      
      private var _namedPartyTeamsOutcomestree:FuncTree;
      
      public function GameFightEndMessage()
      {
         this.results = new Vector.<FightResultListEntry>();
         this.namedPartyTeamsOutcomes = new Vector.<NamedPartyTeamWithOutcome>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 720;
      }
      
      public function initGameFightEndMessage(param1:uint = 0, param2:int = 0, param3:int = 0, param4:Vector.<FightResultListEntry> = null, param5:Vector.<NamedPartyTeamWithOutcome> = null) : GameFightEndMessage
      {
         this.duration = param1;
         this.ageBonus = param2;
         this.lootShareLimitMalus = param3;
         this.results = param4;
         this.namedPartyTeamsOutcomes = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.duration = 0;
         this.ageBonus = 0;
         this.lootShareLimitMalus = 0;
         this.results = new Vector.<FightResultListEntry>();
         this.namedPartyTeamsOutcomes = new Vector.<NamedPartyTeamWithOutcome>();
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
         this.serializeAs_GameFightEndMessage(param1);
      }
      
      public function serializeAs_GameFightEndMessage(param1:ICustomDataOutput) : void
      {
         if(this.duration < 0)
         {
            throw new Error("Forbidden value (" + this.duration + ") on element duration.");
         }
         param1.writeInt(this.duration);
         param1.writeShort(this.ageBonus);
         param1.writeShort(this.lootShareLimitMalus);
         param1.writeShort(this.results.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.results.length)
         {
            param1.writeShort((this.results[_loc2_] as FightResultListEntry).getTypeId());
            (this.results[_loc2_] as FightResultListEntry).serialize(param1);
            _loc2_++;
         }
         param1.writeShort(this.namedPartyTeamsOutcomes.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.namedPartyTeamsOutcomes.length)
         {
            (this.namedPartyTeamsOutcomes[_loc3_] as NamedPartyTeamWithOutcome).serializeAs_NamedPartyTeamWithOutcome(param1);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightEndMessage(param1);
      }
      
      public function deserializeAs_GameFightEndMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:FightResultListEntry = null;
         var _loc8_:NamedPartyTeamWithOutcome = null;
         this._durationFunc(param1);
         this._ageBonusFunc(param1);
         this._lootShareLimitMalusFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readUnsignedShort();
            _loc7_ = ProtocolTypeManager.getInstance(FightResultListEntry,_loc6_);
            _loc7_.deserialize(param1);
            this.results.push(_loc7_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc8_ = new NamedPartyTeamWithOutcome();
            _loc8_.deserialize(param1);
            this.namedPartyTeamsOutcomes.push(_loc8_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightEndMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightEndMessage(param1:FuncTree) : void
      {
         param1.addChild(this._durationFunc);
         param1.addChild(this._ageBonusFunc);
         param1.addChild(this._lootShareLimitMalusFunc);
         this._resultstree = param1.addChild(this._resultstreeFunc);
         this._namedPartyTeamsOutcomestree = param1.addChild(this._namedPartyTeamsOutcomestreeFunc);
      }
      
      private function _durationFunc(param1:ICustomDataInput) : void
      {
         this.duration = param1.readInt();
         if(this.duration < 0)
         {
            throw new Error("Forbidden value (" + this.duration + ") on element of GameFightEndMessage.duration.");
         }
      }
      
      private function _ageBonusFunc(param1:ICustomDataInput) : void
      {
         this.ageBonus = param1.readShort();
      }
      
      private function _lootShareLimitMalusFunc(param1:ICustomDataInput) : void
      {
         this.lootShareLimitMalus = param1.readShort();
      }
      
      private function _resultstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._resultstree.addChild(this._resultsFunc);
            _loc3_++;
         }
      }
      
      private function _resultsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:FightResultListEntry = ProtocolTypeManager.getInstance(FightResultListEntry,_loc2_);
         _loc3_.deserialize(param1);
         this.results.push(_loc3_);
      }
      
      private function _namedPartyTeamsOutcomestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._namedPartyTeamsOutcomestree.addChild(this._namedPartyTeamsOutcomesFunc);
            _loc3_++;
         }
      }
      
      private function _namedPartyTeamsOutcomesFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:NamedPartyTeamWithOutcome = new NamedPartyTeamWithOutcome();
         _loc2_.deserialize(param1);
         this.namedPartyTeamsOutcomes.push(_loc2_);
      }
   }
}
