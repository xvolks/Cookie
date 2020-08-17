package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.party.NamedPartyTeam;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightSpectatorJoinMessage extends GameFightJoinMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6504;
       
      
      private var _isInitialized:Boolean = false;
      
      public var namedPartyTeams:Vector.<NamedPartyTeam>;
      
      private var _namedPartyTeamstree:FuncTree;
      
      public function GameFightSpectatorJoinMessage()
      {
         this.namedPartyTeams = new Vector.<NamedPartyTeam>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6504;
      }
      
      public function initGameFightSpectatorJoinMessage(param1:Boolean = false, param2:Boolean = false, param3:Boolean = false, param4:Boolean = false, param5:uint = 0, param6:uint = 0, param7:Vector.<NamedPartyTeam> = null) : GameFightSpectatorJoinMessage
      {
         super.initGameFightJoinMessage(param1,param2,param3,param4,param5,param6);
         this.namedPartyTeams = param7;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.namedPartyTeams = new Vector.<NamedPartyTeam>();
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
         this.serializeAs_GameFightSpectatorJoinMessage(param1);
      }
      
      public function serializeAs_GameFightSpectatorJoinMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameFightJoinMessage(param1);
         param1.writeShort(this.namedPartyTeams.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.namedPartyTeams.length)
         {
            (this.namedPartyTeams[_loc2_] as NamedPartyTeam).serializeAs_NamedPartyTeam(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightSpectatorJoinMessage(param1);
      }
      
      public function deserializeAs_GameFightSpectatorJoinMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:NamedPartyTeam = null;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new NamedPartyTeam();
            _loc4_.deserialize(param1);
            this.namedPartyTeams.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightSpectatorJoinMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightSpectatorJoinMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._namedPartyTeamstree = param1.addChild(this._namedPartyTeamstreeFunc);
      }
      
      private function _namedPartyTeamstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._namedPartyTeamstree.addChild(this._namedPartyTeamsFunc);
            _loc3_++;
         }
      }
      
      private function _namedPartyTeamsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:NamedPartyTeam = new NamedPartyTeam();
         _loc2_.deserialize(param1);
         this.namedPartyTeams.push(_loc2_);
      }
   }
}
