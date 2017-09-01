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
   public class GameActionFightSlideMessage extends AbstractGameActionMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5525;
       
      
      private var _isInitialized:Boolean = false;
      
      public var targetId:Number = 0;
      
      public var startCellId:int = 0;
      
      public var endCellId:int = 0;
      
      public function GameActionFightSlideMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5525;
      }
      
      public function initGameActionFightSlideMessage(param1:uint = 0, param2:Number = 0, param3:Number = 0, param4:int = 0, param5:int = 0) : GameActionFightSlideMessage
      {
         super.initAbstractGameActionMessage(param1,param2);
         this.targetId = param3;
         this.startCellId = param4;
         this.endCellId = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.targetId = 0;
         this.startCellId = 0;
         this.endCellId = 0;
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
         this.serializeAs_GameActionFightSlideMessage(param1);
      }
      
      public function serializeAs_GameActionFightSlideMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionMessage(param1);
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element targetId.");
         }
         param1.writeDouble(this.targetId);
         if(this.startCellId < -1 || this.startCellId > 559)
         {
            throw new Error("Forbidden value (" + this.startCellId + ") on element startCellId.");
         }
         param1.writeShort(this.startCellId);
         if(this.endCellId < -1 || this.endCellId > 559)
         {
            throw new Error("Forbidden value (" + this.endCellId + ") on element endCellId.");
         }
         param1.writeShort(this.endCellId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionFightSlideMessage(param1);
      }
      
      public function deserializeAs_GameActionFightSlideMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._targetIdFunc(param1);
         this._startCellIdFunc(param1);
         this._endCellIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionFightSlideMessage(param1);
      }
      
      public function deserializeAsyncAs_GameActionFightSlideMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._targetIdFunc);
         param1.addChild(this._startCellIdFunc);
         param1.addChild(this._endCellIdFunc);
      }
      
      private function _targetIdFunc(param1:ICustomDataInput) : void
      {
         this.targetId = param1.readDouble();
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element of GameActionFightSlideMessage.targetId.");
         }
      }
      
      private function _startCellIdFunc(param1:ICustomDataInput) : void
      {
         this.startCellId = param1.readShort();
         if(this.startCellId < -1 || this.startCellId > 559)
         {
            throw new Error("Forbidden value (" + this.startCellId + ") on element of GameActionFightSlideMessage.startCellId.");
         }
      }
      
      private function _endCellIdFunc(param1:ICustomDataInput) : void
      {
         this.endCellId = param1.readShort();
         if(this.endCellId < -1 || this.endCellId > 559)
         {
            throw new Error("Forbidden value (" + this.endCellId + ") on element of GameActionFightSlideMessage.endCellId.");
         }
      }
   }
}
