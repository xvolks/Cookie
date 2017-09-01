package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.dofus.network.types.game.context.fight.FightTeamInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightUpdateTeamMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5572;
       
      
      private var _isInitialized:Boolean = false;
      
      public var fightId:uint = 0;
      
      public var team:FightTeamInformations;
      
      private var _teamtree:FuncTree;
      
      public function GameFightUpdateTeamMessage()
      {
         this.team = new FightTeamInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5572;
      }
      
      public function initGameFightUpdateTeamMessage(param1:uint = 0, param2:FightTeamInformations = null) : GameFightUpdateTeamMessage
      {
         this.fightId = param1;
         this.team = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.fightId = 0;
         this.team = new FightTeamInformations();
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
         this.serializeAs_GameFightUpdateTeamMessage(param1);
      }
      
      public function serializeAs_GameFightUpdateTeamMessage(param1:ICustomDataOutput) : void
      {
         if(this.fightId < 0)
         {
            throw new Error("Forbidden value (" + this.fightId + ") on element fightId.");
         }
         param1.writeShort(this.fightId);
         this.team.serializeAs_FightTeamInformations(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightUpdateTeamMessage(param1);
      }
      
      public function deserializeAs_GameFightUpdateTeamMessage(param1:ICustomDataInput) : void
      {
         this._fightIdFunc(param1);
         this.team = new FightTeamInformations();
         this.team.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightUpdateTeamMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightUpdateTeamMessage(param1:FuncTree) : void
      {
         param1.addChild(this._fightIdFunc);
         this._teamtree = param1.addChild(this._teamtreeFunc);
      }
      
      private function _fightIdFunc(param1:ICustomDataInput) : void
      {
         this.fightId = param1.readShort();
         if(this.fightId < 0)
         {
            throw new Error("Forbidden value (" + this.fightId + ") on element of GameFightUpdateTeamMessage.fightId.");
         }
      }
      
      private function _teamtreeFunc(param1:ICustomDataInput) : void
      {
         this.team = new FightTeamInformations();
         this.team.deserializeAsync(this._teamtree);
      }
   }
}
