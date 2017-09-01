package com.ankamagames.dofus.network.messages.game.context.roleplay.fight.arena
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameRolePlayArenaFighterStatusMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6281;
       
      
      private var _isInitialized:Boolean = false;
      
      public var fightId:int = 0;
      
      public var playerId:int = 0;
      
      public var accepted:Boolean = false;
      
      public function GameRolePlayArenaFighterStatusMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6281;
      }
      
      public function initGameRolePlayArenaFighterStatusMessage(param1:int = 0, param2:int = 0, param3:Boolean = false) : GameRolePlayArenaFighterStatusMessage
      {
         this.fightId = param1;
         this.playerId = param2;
         this.accepted = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.fightId = 0;
         this.playerId = 0;
         this.accepted = false;
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
         this.serializeAs_GameRolePlayArenaFighterStatusMessage(param1);
      }
      
      public function serializeAs_GameRolePlayArenaFighterStatusMessage(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.fightId);
         param1.writeInt(this.playerId);
         param1.writeBoolean(this.accepted);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayArenaFighterStatusMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayArenaFighterStatusMessage(param1:ICustomDataInput) : void
      {
         this._fightIdFunc(param1);
         this._playerIdFunc(param1);
         this._acceptedFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayArenaFighterStatusMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayArenaFighterStatusMessage(param1:FuncTree) : void
      {
         param1.addChild(this._fightIdFunc);
         param1.addChild(this._playerIdFunc);
         param1.addChild(this._acceptedFunc);
      }
      
      private function _fightIdFunc(param1:ICustomDataInput) : void
      {
         this.fightId = param1.readInt();
      }
      
      private function _playerIdFunc(param1:ICustomDataInput) : void
      {
         this.playerId = param1.readInt();
      }
      
      private function _acceptedFunc(param1:ICustomDataInput) : void
      {
         this.accepted = param1.readBoolean();
      }
   }
}
