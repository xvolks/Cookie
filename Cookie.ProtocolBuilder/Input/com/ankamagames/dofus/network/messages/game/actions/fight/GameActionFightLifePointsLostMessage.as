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
   public class GameActionFightLifePointsLostMessage extends AbstractGameActionMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6312;
       
      
      private var _isInitialized:Boolean = false;
      
      public var targetId:Number = 0;
      
      public var loss:uint = 0;
      
      public var permanentDamages:uint = 0;
      
      public function GameActionFightLifePointsLostMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6312;
      }
      
      public function initGameActionFightLifePointsLostMessage(param1:uint = 0, param2:Number = 0, param3:Number = 0, param4:uint = 0, param5:uint = 0) : GameActionFightLifePointsLostMessage
      {
         super.initAbstractGameActionMessage(param1,param2);
         this.targetId = param3;
         this.loss = param4;
         this.permanentDamages = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.targetId = 0;
         this.loss = 0;
         this.permanentDamages = 0;
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
         this.serializeAs_GameActionFightLifePointsLostMessage(param1);
      }
      
      public function serializeAs_GameActionFightLifePointsLostMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionMessage(param1);
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element targetId.");
         }
         param1.writeDouble(this.targetId);
         if(this.loss < 0)
         {
            throw new Error("Forbidden value (" + this.loss + ") on element loss.");
         }
         param1.writeVarInt(this.loss);
         if(this.permanentDamages < 0)
         {
            throw new Error("Forbidden value (" + this.permanentDamages + ") on element permanentDamages.");
         }
         param1.writeVarInt(this.permanentDamages);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionFightLifePointsLostMessage(param1);
      }
      
      public function deserializeAs_GameActionFightLifePointsLostMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._targetIdFunc(param1);
         this._lossFunc(param1);
         this._permanentDamagesFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionFightLifePointsLostMessage(param1);
      }
      
      public function deserializeAsyncAs_GameActionFightLifePointsLostMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._targetIdFunc);
         param1.addChild(this._lossFunc);
         param1.addChild(this._permanentDamagesFunc);
      }
      
      private function _targetIdFunc(param1:ICustomDataInput) : void
      {
         this.targetId = param1.readDouble();
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element of GameActionFightLifePointsLostMessage.targetId.");
         }
      }
      
      private function _lossFunc(param1:ICustomDataInput) : void
      {
         this.loss = param1.readVarUhInt();
         if(this.loss < 0)
         {
            throw new Error("Forbidden value (" + this.loss + ") on element of GameActionFightLifePointsLostMessage.loss.");
         }
      }
      
      private function _permanentDamagesFunc(param1:ICustomDataInput) : void
      {
         this.permanentDamages = param1.readVarUhInt();
         if(this.permanentDamages < 0)
         {
            throw new Error("Forbidden value (" + this.permanentDamages + ") on element of GameActionFightLifePointsLostMessage.permanentDamages.");
         }
      }
   }
}
