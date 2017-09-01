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
   public class GameRolePlayAggressionMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6073;
       
      
      private var _isInitialized:Boolean = false;
      
      public var attackerId:Number = 0;
      
      public var defenderId:Number = 0;
      
      public function GameRolePlayAggressionMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6073;
      }
      
      public function initGameRolePlayAggressionMessage(param1:Number = 0, param2:Number = 0) : GameRolePlayAggressionMessage
      {
         this.attackerId = param1;
         this.defenderId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.attackerId = 0;
         this.defenderId = 0;
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
         this.serializeAs_GameRolePlayAggressionMessage(param1);
      }
      
      public function serializeAs_GameRolePlayAggressionMessage(param1:ICustomDataOutput) : void
      {
         if(this.attackerId < 0 || this.attackerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.attackerId + ") on element attackerId.");
         }
         param1.writeVarLong(this.attackerId);
         if(this.defenderId < 0 || this.defenderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.defenderId + ") on element defenderId.");
         }
         param1.writeVarLong(this.defenderId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayAggressionMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayAggressionMessage(param1:ICustomDataInput) : void
      {
         this._attackerIdFunc(param1);
         this._defenderIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayAggressionMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayAggressionMessage(param1:FuncTree) : void
      {
         param1.addChild(this._attackerIdFunc);
         param1.addChild(this._defenderIdFunc);
      }
      
      private function _attackerIdFunc(param1:ICustomDataInput) : void
      {
         this.attackerId = param1.readVarUhLong();
         if(this.attackerId < 0 || this.attackerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.attackerId + ") on element of GameRolePlayAggressionMessage.attackerId.");
         }
      }
      
      private function _defenderIdFunc(param1:ICustomDataInput) : void
      {
         this.defenderId = param1.readVarUhLong();
         if(this.defenderId < 0 || this.defenderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.defenderId + ") on element of GameRolePlayAggressionMessage.defenderId.");
         }
      }
   }
}
