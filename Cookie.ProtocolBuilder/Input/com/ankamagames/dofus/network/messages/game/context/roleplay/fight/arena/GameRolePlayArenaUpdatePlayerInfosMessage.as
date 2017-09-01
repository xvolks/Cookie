package com.ankamagames.dofus.network.messages.game.context.roleplay.fight.arena
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.fight.arena.ArenaRankInfos;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameRolePlayArenaUpdatePlayerInfosMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6301;
       
      
      private var _isInitialized:Boolean = false;
      
      public var solo:ArenaRankInfos;
      
      private var _solotree:FuncTree;
      
      public function GameRolePlayArenaUpdatePlayerInfosMessage()
      {
         this.solo = new ArenaRankInfos();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6301;
      }
      
      public function initGameRolePlayArenaUpdatePlayerInfosMessage(param1:ArenaRankInfos = null) : GameRolePlayArenaUpdatePlayerInfosMessage
      {
         this.solo = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.solo = new ArenaRankInfos();
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
         this.serializeAs_GameRolePlayArenaUpdatePlayerInfosMessage(param1);
      }
      
      public function serializeAs_GameRolePlayArenaUpdatePlayerInfosMessage(param1:ICustomDataOutput) : void
      {
         this.solo.serializeAs_ArenaRankInfos(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayArenaUpdatePlayerInfosMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayArenaUpdatePlayerInfosMessage(param1:ICustomDataInput) : void
      {
         this.solo = new ArenaRankInfos();
         this.solo.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayArenaUpdatePlayerInfosMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayArenaUpdatePlayerInfosMessage(param1:FuncTree) : void
      {
         this._solotree = param1.addChild(this._solotreeFunc);
      }
      
      private function _solotreeFunc(param1:ICustomDataInput) : void
      {
         this.solo = new ArenaRankInfos();
         this.solo.deserializeAsync(this._solotree);
      }
   }
}
