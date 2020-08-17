package com.ankamagames.dofus.network.messages.game.dare
{
   import com.ankamagames.dofus.network.types.game.dare.DareCriteria;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class DareCreationRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6665;
       
      
      private var _isInitialized:Boolean = false;
      
      public var subscriptionFee:Number = 0;
      
      public var jackpot:Number = 0;
      
      public var maxCountWinners:uint = 0;
      
      public var delayBeforeStart:uint = 0;
      
      public var duration:uint = 0;
      
      public var isPrivate:Boolean = false;
      
      public var isForGuild:Boolean = false;
      
      public var isForAlliance:Boolean = false;
      
      public var needNotifications:Boolean = false;
      
      public var criterions:Vector.<DareCriteria>;
      
      private var _criterionstree:FuncTree;
      
      public function DareCreationRequestMessage()
      {
         this.criterions = new Vector.<DareCriteria>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6665;
      }
      
      public function initDareCreationRequestMessage(param1:Number = 0, param2:Number = 0, param3:uint = 0, param4:uint = 0, param5:uint = 0, param6:Boolean = false, param7:Boolean = false, param8:Boolean = false, param9:Boolean = false, param10:Vector.<DareCriteria> = null) : DareCreationRequestMessage
      {
         this.subscriptionFee = param1;
         this.jackpot = param2;
         this.maxCountWinners = param3;
         this.delayBeforeStart = param4;
         this.duration = param5;
         this.isPrivate = param6;
         this.isForGuild = param7;
         this.isForAlliance = param8;
         this.needNotifications = param9;
         this.criterions = param10;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.subscriptionFee = 0;
         this.jackpot = 0;
         this.maxCountWinners = 0;
         this.delayBeforeStart = 0;
         this.duration = 0;
         this.isPrivate = false;
         this.isForGuild = false;
         this.isForAlliance = false;
         this.needNotifications = false;
         this.criterions = new Vector.<DareCriteria>();
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
         this.serializeAs_DareCreationRequestMessage(param1);
      }
      
      public function serializeAs_DareCreationRequestMessage(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.isPrivate);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.isForGuild);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,2,this.isForAlliance);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,3,this.needNotifications);
         param1.writeByte(_loc2_);
         if(this.subscriptionFee < 0 || this.subscriptionFee > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.subscriptionFee + ") on element subscriptionFee.");
         }
         param1.writeVarLong(this.subscriptionFee);
         if(this.jackpot < 0 || this.jackpot > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.jackpot + ") on element jackpot.");
         }
         param1.writeVarLong(this.jackpot);
         if(this.maxCountWinners < 0 || this.maxCountWinners > 65535)
         {
            throw new Error("Forbidden value (" + this.maxCountWinners + ") on element maxCountWinners.");
         }
         param1.writeShort(this.maxCountWinners);
         if(this.delayBeforeStart < 0 || this.delayBeforeStart > 4294967295)
         {
            throw new Error("Forbidden value (" + this.delayBeforeStart + ") on element delayBeforeStart.");
         }
         param1.writeUnsignedInt(this.delayBeforeStart);
         if(this.duration < 0 || this.duration > 4294967295)
         {
            throw new Error("Forbidden value (" + this.duration + ") on element duration.");
         }
         param1.writeUnsignedInt(this.duration);
         param1.writeShort(this.criterions.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.criterions.length)
         {
            (this.criterions[_loc3_] as DareCriteria).serializeAs_DareCriteria(param1);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DareCreationRequestMessage(param1);
      }
      
      public function deserializeAs_DareCreationRequestMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:DareCriteria = null;
         this.deserializeByteBoxes(param1);
         this._subscriptionFeeFunc(param1);
         this._jackpotFunc(param1);
         this._maxCountWinnersFunc(param1);
         this._delayBeforeStartFunc(param1);
         this._durationFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new DareCriteria();
            _loc4_.deserialize(param1);
            this.criterions.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DareCreationRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_DareCreationRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._subscriptionFeeFunc);
         param1.addChild(this._jackpotFunc);
         param1.addChild(this._maxCountWinnersFunc);
         param1.addChild(this._delayBeforeStartFunc);
         param1.addChild(this._durationFunc);
         this._criterionstree = param1.addChild(this._criterionstreeFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.isPrivate = BooleanByteWrapper.getFlag(_loc2_,0);
         this.isForGuild = BooleanByteWrapper.getFlag(_loc2_,1);
         this.isForAlliance = BooleanByteWrapper.getFlag(_loc2_,2);
         this.needNotifications = BooleanByteWrapper.getFlag(_loc2_,3);
      }
      
      private function _subscriptionFeeFunc(param1:ICustomDataInput) : void
      {
         this.subscriptionFee = param1.readVarUhLong();
         if(this.subscriptionFee < 0 || this.subscriptionFee > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.subscriptionFee + ") on element of DareCreationRequestMessage.subscriptionFee.");
         }
      }
      
      private function _jackpotFunc(param1:ICustomDataInput) : void
      {
         this.jackpot = param1.readVarUhLong();
         if(this.jackpot < 0 || this.jackpot > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.jackpot + ") on element of DareCreationRequestMessage.jackpot.");
         }
      }
      
      private function _maxCountWinnersFunc(param1:ICustomDataInput) : void
      {
         this.maxCountWinners = param1.readUnsignedShort();
         if(this.maxCountWinners < 0 || this.maxCountWinners > 65535)
         {
            throw new Error("Forbidden value (" + this.maxCountWinners + ") on element of DareCreationRequestMessage.maxCountWinners.");
         }
      }
      
      private function _delayBeforeStartFunc(param1:ICustomDataInput) : void
      {
         this.delayBeforeStart = param1.readUnsignedInt();
         if(this.delayBeforeStart < 0 || this.delayBeforeStart > 4294967295)
         {
            throw new Error("Forbidden value (" + this.delayBeforeStart + ") on element of DareCreationRequestMessage.delayBeforeStart.");
         }
      }
      
      private function _durationFunc(param1:ICustomDataInput) : void
      {
         this.duration = param1.readUnsignedInt();
         if(this.duration < 0 || this.duration > 4294967295)
         {
            throw new Error("Forbidden value (" + this.duration + ") on element of DareCreationRequestMessage.duration.");
         }
      }
      
      private function _criterionstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._criterionstree.addChild(this._criterionsFunc);
            _loc3_++;
         }
      }
      
      private function _criterionsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:DareCriteria = new DareCriteria();
         _loc2_.deserialize(param1);
         this.criterions.push(_loc2_);
      }
   }
}
