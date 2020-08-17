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
   public class GameActionFightExchangePositionsMessage extends AbstractGameActionMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5527;
       
      
      private var _isInitialized:Boolean = false;
      
      public var targetId:Number = 0;
      
      public var casterCellId:int = 0;
      
      public var targetCellId:int = 0;
      
      public function GameActionFightExchangePositionsMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5527;
      }
      
      public function initGameActionFightExchangePositionsMessage(param1:uint = 0, param2:Number = 0, param3:Number = 0, param4:int = 0, param5:int = 0) : GameActionFightExchangePositionsMessage
      {
         super.initAbstractGameActionMessage(param1,param2);
         this.targetId = param3;
         this.casterCellId = param4;
         this.targetCellId = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.targetId = 0;
         this.casterCellId = 0;
         this.targetCellId = 0;
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
         this.serializeAs_GameActionFightExchangePositionsMessage(param1);
      }
      
      public function serializeAs_GameActionFightExchangePositionsMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionMessage(param1);
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element targetId.");
         }
         param1.writeDouble(this.targetId);
         if(this.casterCellId < -1 || this.casterCellId > 559)
         {
            throw new Error("Forbidden value (" + this.casterCellId + ") on element casterCellId.");
         }
         param1.writeShort(this.casterCellId);
         if(this.targetCellId < -1 || this.targetCellId > 559)
         {
            throw new Error("Forbidden value (" + this.targetCellId + ") on element targetCellId.");
         }
         param1.writeShort(this.targetCellId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionFightExchangePositionsMessage(param1);
      }
      
      public function deserializeAs_GameActionFightExchangePositionsMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._targetIdFunc(param1);
         this._casterCellIdFunc(param1);
         this._targetCellIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionFightExchangePositionsMessage(param1);
      }
      
      public function deserializeAsyncAs_GameActionFightExchangePositionsMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._targetIdFunc);
         param1.addChild(this._casterCellIdFunc);
         param1.addChild(this._targetCellIdFunc);
      }
      
      private function _targetIdFunc(param1:ICustomDataInput) : void
      {
         this.targetId = param1.readDouble();
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element of GameActionFightExchangePositionsMessage.targetId.");
         }
      }
      
      private function _casterCellIdFunc(param1:ICustomDataInput) : void
      {
         this.casterCellId = param1.readShort();
         if(this.casterCellId < -1 || this.casterCellId > 559)
         {
            throw new Error("Forbidden value (" + this.casterCellId + ") on element of GameActionFightExchangePositionsMessage.casterCellId.");
         }
      }
      
      private function _targetCellIdFunc(param1:ICustomDataInput) : void
      {
         this.targetCellId = param1.readShort();
         if(this.targetCellId < -1 || this.targetCellId > 559)
         {
            throw new Error("Forbidden value (" + this.targetCellId + ") on element of GameActionFightExchangePositionsMessage.targetCellId.");
         }
      }
   }
}
