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
   public class GameRolePlayAttackMonsterRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6191;
       
      
      private var _isInitialized:Boolean = false;
      
      public var monsterGroupId:Number = 0;
      
      public function GameRolePlayAttackMonsterRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6191;
      }
      
      public function initGameRolePlayAttackMonsterRequestMessage(param1:Number = 0) : GameRolePlayAttackMonsterRequestMessage
      {
         this.monsterGroupId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.monsterGroupId = 0;
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
         this.serializeAs_GameRolePlayAttackMonsterRequestMessage(param1);
      }
      
      public function serializeAs_GameRolePlayAttackMonsterRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.monsterGroupId < -9007199254740990 || this.monsterGroupId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.monsterGroupId + ") on element monsterGroupId.");
         }
         param1.writeDouble(this.monsterGroupId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayAttackMonsterRequestMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayAttackMonsterRequestMessage(param1:ICustomDataInput) : void
      {
         this._monsterGroupIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayAttackMonsterRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayAttackMonsterRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._monsterGroupIdFunc);
      }
      
      private function _monsterGroupIdFunc(param1:ICustomDataInput) : void
      {
         this.monsterGroupId = param1.readDouble();
         if(this.monsterGroupId < -9007199254740990 || this.monsterGroupId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.monsterGroupId + ") on element of GameRolePlayAttackMonsterRequestMessage.monsterGroupId.");
         }
      }
   }
}
