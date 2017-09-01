package com.ankamagames.dofus.network.messages.game.context.roleplay.fight
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameRolePlayPlayerFightFriendlyAnsweredMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5733;
       
      
      private var _isInitialized:Boolean = false;
      
      public var fightId:int = 0;
      
      public var sourceId:Number = 0;
      
      public var targetId:Number = 0;
      
      public var accept:Boolean = false;
      
      public function GameRolePlayPlayerFightFriendlyAnsweredMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5733;
      }
      
      public function initGameRolePlayPlayerFightFriendlyAnsweredMessage(param1:int = 0, param2:Number = 0, param3:Number = 0, param4:Boolean = false) : GameRolePlayPlayerFightFriendlyAnsweredMessage
      {
         this.fightId = param1;
         this.sourceId = param2;
         this.targetId = param3;
         this.accept = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.fightId = 0;
         this.sourceId = 0;
         this.targetId = 0;
         this.accept = false;
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
         this.serializeAs_GameRolePlayPlayerFightFriendlyAnsweredMessage(param1);
      }
      
      public function serializeAs_GameRolePlayPlayerFightFriendlyAnsweredMessage(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.fightId);
         if(this.sourceId < 0 || this.sourceId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.sourceId + ") on element sourceId.");
         }
         param1.writeVarLong(this.sourceId);
         if(this.targetId < 0 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element targetId.");
         }
         param1.writeVarLong(this.targetId);
         param1.writeBoolean(this.accept);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayPlayerFightFriendlyAnsweredMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayPlayerFightFriendlyAnsweredMessage(param1:ICustomDataInput) : void
      {
         this._fightIdFunc(param1);
         this._sourceIdFunc(param1);
         this._targetIdFunc(param1);
         this._acceptFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayPlayerFightFriendlyAnsweredMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayPlayerFightFriendlyAnsweredMessage(param1:FuncTree) : void
      {
         param1.addChild(this._fightIdFunc);
         param1.addChild(this._sourceIdFunc);
         param1.addChild(this._targetIdFunc);
         param1.addChild(this._acceptFunc);
      }
      
      private function _fightIdFunc(param1:ICustomDataInput) : void
      {
         this.fightId = param1.readInt();
      }
      
      private function _sourceIdFunc(param1:ICustomDataInput) : void
      {
         this.sourceId = param1.readVarUhLong();
         if(this.sourceId < 0 || this.sourceId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.sourceId + ") on element of GameRolePlayPlayerFightFriendlyAnsweredMessage.sourceId.");
         }
      }
      
      private function _targetIdFunc(param1:ICustomDataInput) : void
      {
         this.targetId = param1.readVarUhLong();
         if(this.targetId < 0 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element of GameRolePlayPlayerFightFriendlyAnsweredMessage.targetId.");
         }
      }
      
      private function _acceptFunc(param1:ICustomDataInput) : void
      {
         this.accept = param1.readBoolean();
      }
   }
}
