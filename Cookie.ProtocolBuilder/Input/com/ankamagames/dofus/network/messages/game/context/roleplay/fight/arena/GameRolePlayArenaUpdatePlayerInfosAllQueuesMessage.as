package com.ankamagames.dofus.network.messages.game.context.roleplay.fight.arena
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.fight.arena.ArenaRankInfos;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage extends GameRolePlayArenaUpdatePlayerInfosMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6728;
       
      
      private var _isInitialized:Boolean = false;
      
      public var team:ArenaRankInfos;
      
      public var duel:ArenaRankInfos;
      
      private var _teamtree:FuncTree;
      
      private var _dueltree:FuncTree;
      
      public function GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage()
      {
         this.team = new ArenaRankInfos();
         this.duel = new ArenaRankInfos();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6728;
      }
      
      public function initGameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(param1:ArenaRankInfos = null, param2:ArenaRankInfos = null, param3:ArenaRankInfos = null) : GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage
      {
         super.initGameRolePlayArenaUpdatePlayerInfosMessage(param1);
         this.team = param2;
         this.duel = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.team = new ArenaRankInfos();
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
         this.serializeAs_GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(param1);
      }
      
      public function serializeAs_GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameRolePlayArenaUpdatePlayerInfosMessage(param1);
         this.team.serializeAs_ArenaRankInfos(param1);
         this.duel.serializeAs_ArenaRankInfos(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.team = new ArenaRankInfos();
         this.team.deserialize(param1);
         this.duel = new ArenaRankInfos();
         this.duel.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._teamtree = param1.addChild(this._teamtreeFunc);
         this._dueltree = param1.addChild(this._dueltreeFunc);
      }
      
      private function _teamtreeFunc(param1:ICustomDataInput) : void
      {
         this.team = new ArenaRankInfos();
         this.team.deserializeAsync(this._teamtree);
      }
      
      private function _dueltreeFunc(param1:ICustomDataInput) : void
      {
         this.duel = new ArenaRankInfos();
         this.duel.deserializeAsync(this._dueltree);
      }
   }
}
