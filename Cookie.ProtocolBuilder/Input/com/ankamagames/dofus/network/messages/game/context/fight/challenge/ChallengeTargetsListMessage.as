package com.ankamagames.dofus.network.messages.game.context.fight.challenge
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ChallengeTargetsListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5613;
       
      
      private var _isInitialized:Boolean = false;
      
      public var targetIds:Vector.<Number>;
      
      public var targetCells:Vector.<int>;
      
      private var _targetIdstree:FuncTree;
      
      private var _targetCellstree:FuncTree;
      
      public function ChallengeTargetsListMessage()
      {
         this.targetIds = new Vector.<Number>();
         this.targetCells = new Vector.<int>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5613;
      }
      
      public function initChallengeTargetsListMessage(param1:Vector.<Number> = null, param2:Vector.<int> = null) : ChallengeTargetsListMessage
      {
         this.targetIds = param1;
         this.targetCells = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.targetIds = new Vector.<Number>();
         this.targetCells = new Vector.<int>();
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
         this.serializeAs_ChallengeTargetsListMessage(param1);
      }
      
      public function serializeAs_ChallengeTargetsListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.targetIds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.targetIds.length)
         {
            if(this.targetIds[_loc2_] < -9007199254740990 || this.targetIds[_loc2_] > 9007199254740990)
            {
               throw new Error("Forbidden value (" + this.targetIds[_loc2_] + ") on element 1 (starting at 1) of targetIds.");
            }
            param1.writeDouble(this.targetIds[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.targetCells.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.targetCells.length)
         {
            if(this.targetCells[_loc3_] < -1 || this.targetCells[_loc3_] > 559)
            {
               throw new Error("Forbidden value (" + this.targetCells[_loc3_] + ") on element 2 (starting at 1) of targetCells.");
            }
            param1.writeShort(this.targetCells[_loc3_]);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ChallengeTargetsListMessage(param1);
      }
      
      public function deserializeAs_ChallengeTargetsListMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:Number = NaN;
         var _loc7_:int = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readDouble();
            if(_loc6_ < -9007199254740990 || _loc6_ > 9007199254740990)
            {
               throw new Error("Forbidden value (" + _loc6_ + ") on elements of targetIds.");
            }
            this.targetIds.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = param1.readShort();
            if(_loc7_ < -1 || _loc7_ > 559)
            {
               throw new Error("Forbidden value (" + _loc7_ + ") on elements of targetCells.");
            }
            this.targetCells.push(_loc7_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ChallengeTargetsListMessage(param1);
      }
      
      public function deserializeAsyncAs_ChallengeTargetsListMessage(param1:FuncTree) : void
      {
         this._targetIdstree = param1.addChild(this._targetIdstreeFunc);
         this._targetCellstree = param1.addChild(this._targetCellstreeFunc);
      }
      
      private function _targetIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._targetIdstree.addChild(this._targetIdsFunc);
            _loc3_++;
         }
      }
      
      private function _targetIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:Number = param1.readDouble();
         if(_loc2_ < -9007199254740990 || _loc2_ > 9007199254740990)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of targetIds.");
         }
         this.targetIds.push(_loc2_);
      }
      
      private function _targetCellstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._targetCellstree.addChild(this._targetCellsFunc);
            _loc3_++;
         }
      }
      
      private function _targetCellsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:int = param1.readShort();
         if(_loc2_ < -1 || _loc2_ > 559)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of targetCells.");
         }
         this.targetCells.push(_loc2_);
      }
   }
}
