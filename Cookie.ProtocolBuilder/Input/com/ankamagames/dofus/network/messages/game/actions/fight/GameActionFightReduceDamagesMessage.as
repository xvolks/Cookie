package com.ankamagames.dofus.network.messages.game.actions.fight
{
   import com.ankamagames.dofus.network.messages.game.actions.AbstractGameActionMessage;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameActionFightReduceDamagesMessage extends AbstractGameActionMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5526;
       
      
      private var _isInitialized:Boolean = false;
      
      public var targetId:Number = 0;
      
      public var amount:uint = 0;
      
      public function GameActionFightReduceDamagesMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5526;
      }
      
      public function initGameActionFightReduceDamagesMessage(param1:uint = 0, param2:Number = 0, param3:Number = 0, param4:uint = 0) : GameActionFightReduceDamagesMessage
      {
         super.initAbstractGameActionMessage(param1,param2);
         this.targetId = param3;
         this.amount = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.targetId = 0;
         this.amount = 0;
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
         this.serializeAs_GameActionFightReduceDamagesMessage(param1);
      }
      
      public function serializeAs_GameActionFightReduceDamagesMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionMessage(param1);
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element targetId.");
         }
         param1.writeDouble(this.targetId);
         if(this.amount < 0)
         {
            throw new Error("Forbidden value (" + this.amount + ") on element amount.");
         }
         param1.writeVarInt(this.amount);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionFightReduceDamagesMessage(param1);
      }
      
      public function deserializeAs_GameActionFightReduceDamagesMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._targetIdFunc(param1);
         this._amountFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionFightReduceDamagesMessage(param1);
      }
      
      public function deserializeAsyncAs_GameActionFightReduceDamagesMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._targetIdFunc);
         param1.addChild(this._amountFunc);
      }
      
      private function _targetIdFunc(param1:ICustomDataInput) : void
      {
         this.targetId = param1.readDouble();
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element of GameActionFightReduceDamagesMessage.targetId.");
         }
      }
      
      private function _amountFunc(param1:ICustomDataInput) : void
      {
         this.amount = param1.readVarUhInt();
         if(this.amount < 0)
         {
            throw new Error("Forbidden value (" + this.amount + ") on element of GameActionFightReduceDamagesMessage.amount.");
         }
      }
   }
}
