package com.ankamagames.dofus.network.messages.game.context.roleplay.treasureHunt
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.roleplay.treasureHunt.TreasureHuntFlag;
   import com.ankamagames.dofus.network.types.game.context.roleplay.treasureHunt.TreasureHuntStep;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TreasureHuntMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6486;
       
      
      private var _isInitialized:Boolean = false;
      
      public var questType:uint = 0;
      
      public var startMapId:int = 0;
      
      public var knownStepsList:Vector.<TreasureHuntStep>;
      
      public var totalStepCount:uint = 0;
      
      public var checkPointCurrent:uint = 0;
      
      public var checkPointTotal:uint = 0;
      
      public var availableRetryCount:int = 0;
      
      public var flags:Vector.<TreasureHuntFlag>;
      
      private var _knownStepsListtree:FuncTree;
      
      private var _flagstree:FuncTree;
      
      public function TreasureHuntMessage()
      {
         this.knownStepsList = new Vector.<TreasureHuntStep>();
         this.flags = new Vector.<TreasureHuntFlag>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6486;
      }
      
      public function initTreasureHuntMessage(param1:uint = 0, param2:int = 0, param3:Vector.<TreasureHuntStep> = null, param4:uint = 0, param5:uint = 0, param6:uint = 0, param7:int = 0, param8:Vector.<TreasureHuntFlag> = null) : TreasureHuntMessage
      {
         this.questType = param1;
         this.startMapId = param2;
         this.knownStepsList = param3;
         this.totalStepCount = param4;
         this.checkPointCurrent = param5;
         this.checkPointTotal = param6;
         this.availableRetryCount = param7;
         this.flags = param8;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.questType = 0;
         this.startMapId = 0;
         this.knownStepsList = new Vector.<TreasureHuntStep>();
         this.totalStepCount = 0;
         this.checkPointCurrent = 0;
         this.checkPointTotal = 0;
         this.availableRetryCount = 0;
         this.flags = new Vector.<TreasureHuntFlag>();
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
         this.serializeAs_TreasureHuntMessage(param1);
      }
      
      public function serializeAs_TreasureHuntMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.questType);
         param1.writeInt(this.startMapId);
         param1.writeShort(this.knownStepsList.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.knownStepsList.length)
         {
            param1.writeShort((this.knownStepsList[_loc2_] as TreasureHuntStep).getTypeId());
            (this.knownStepsList[_loc2_] as TreasureHuntStep).serialize(param1);
            _loc2_++;
         }
         if(this.totalStepCount < 0)
         {
            throw new Error("Forbidden value (" + this.totalStepCount + ") on element totalStepCount.");
         }
         param1.writeByte(this.totalStepCount);
         if(this.checkPointCurrent < 0)
         {
            throw new Error("Forbidden value (" + this.checkPointCurrent + ") on element checkPointCurrent.");
         }
         param1.writeVarInt(this.checkPointCurrent);
         if(this.checkPointTotal < 0)
         {
            throw new Error("Forbidden value (" + this.checkPointTotal + ") on element checkPointTotal.");
         }
         param1.writeVarInt(this.checkPointTotal);
         param1.writeInt(this.availableRetryCount);
         param1.writeShort(this.flags.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.flags.length)
         {
            (this.flags[_loc3_] as TreasureHuntFlag).serializeAs_TreasureHuntFlag(param1);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TreasureHuntMessage(param1);
      }
      
      public function deserializeAs_TreasureHuntMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:TreasureHuntStep = null;
         var _loc8_:TreasureHuntFlag = null;
         this._questTypeFunc(param1);
         this._startMapIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readUnsignedShort();
            _loc7_ = ProtocolTypeManager.getInstance(TreasureHuntStep,_loc6_);
            _loc7_.deserialize(param1);
            this.knownStepsList.push(_loc7_);
            _loc3_++;
         }
         this._totalStepCountFunc(param1);
         this._checkPointCurrentFunc(param1);
         this._checkPointTotalFunc(param1);
         this._availableRetryCountFunc(param1);
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc8_ = new TreasureHuntFlag();
            _loc8_.deserialize(param1);
            this.flags.push(_loc8_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TreasureHuntMessage(param1);
      }
      
      public function deserializeAsyncAs_TreasureHuntMessage(param1:FuncTree) : void
      {
         param1.addChild(this._questTypeFunc);
         param1.addChild(this._startMapIdFunc);
         this._knownStepsListtree = param1.addChild(this._knownStepsListtreeFunc);
         param1.addChild(this._totalStepCountFunc);
         param1.addChild(this._checkPointCurrentFunc);
         param1.addChild(this._checkPointTotalFunc);
         param1.addChild(this._availableRetryCountFunc);
         this._flagstree = param1.addChild(this._flagstreeFunc);
      }
      
      private function _questTypeFunc(param1:ICustomDataInput) : void
      {
         this.questType = param1.readByte();
         if(this.questType < 0)
         {
            throw new Error("Forbidden value (" + this.questType + ") on element of TreasureHuntMessage.questType.");
         }
      }
      
      private function _startMapIdFunc(param1:ICustomDataInput) : void
      {
         this.startMapId = param1.readInt();
      }
      
      private function _knownStepsListtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._knownStepsListtree.addChild(this._knownStepsListFunc);
            _loc3_++;
         }
      }
      
      private function _knownStepsListFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:TreasureHuntStep = ProtocolTypeManager.getInstance(TreasureHuntStep,_loc2_);
         _loc3_.deserialize(param1);
         this.knownStepsList.push(_loc3_);
      }
      
      private function _totalStepCountFunc(param1:ICustomDataInput) : void
      {
         this.totalStepCount = param1.readByte();
         if(this.totalStepCount < 0)
         {
            throw new Error("Forbidden value (" + this.totalStepCount + ") on element of TreasureHuntMessage.totalStepCount.");
         }
      }
      
      private function _checkPointCurrentFunc(param1:ICustomDataInput) : void
      {
         this.checkPointCurrent = param1.readVarUhInt();
         if(this.checkPointCurrent < 0)
         {
            throw new Error("Forbidden value (" + this.checkPointCurrent + ") on element of TreasureHuntMessage.checkPointCurrent.");
         }
      }
      
      private function _checkPointTotalFunc(param1:ICustomDataInput) : void
      {
         this.checkPointTotal = param1.readVarUhInt();
         if(this.checkPointTotal < 0)
         {
            throw new Error("Forbidden value (" + this.checkPointTotal + ") on element of TreasureHuntMessage.checkPointTotal.");
         }
      }
      
      private function _availableRetryCountFunc(param1:ICustomDataInput) : void
      {
         this.availableRetryCount = param1.readInt();
      }
      
      private function _flagstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._flagstree.addChild(this._flagsFunc);
            _loc3_++;
         }
      }
      
      private function _flagsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:TreasureHuntFlag = new TreasureHuntFlag();
         _loc2_.deserialize(param1);
         this.flags.push(_loc2_);
      }
   }
}
