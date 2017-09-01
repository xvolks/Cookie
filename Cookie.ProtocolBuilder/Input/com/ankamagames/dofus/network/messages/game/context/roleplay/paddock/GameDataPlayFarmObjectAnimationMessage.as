package com.ankamagames.dofus.network.messages.game.context.roleplay.paddock
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameDataPlayFarmObjectAnimationMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6026;
       
      
      private var _isInitialized:Boolean = false;
      
      public var cellId:Vector.<uint>;
      
      private var _cellIdtree:FuncTree;
      
      public function GameDataPlayFarmObjectAnimationMessage()
      {
         this.cellId = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6026;
      }
      
      public function initGameDataPlayFarmObjectAnimationMessage(param1:Vector.<uint> = null) : GameDataPlayFarmObjectAnimationMessage
      {
         this.cellId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.cellId = new Vector.<uint>();
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
         this.serializeAs_GameDataPlayFarmObjectAnimationMessage(param1);
      }
      
      public function serializeAs_GameDataPlayFarmObjectAnimationMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.cellId.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.cellId.length)
         {
            if(this.cellId[_loc2_] < 0 || this.cellId[_loc2_] > 559)
            {
               throw new Error("Forbidden value (" + this.cellId[_loc2_] + ") on element 1 (starting at 1) of cellId.");
            }
            param1.writeVarShort(this.cellId[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameDataPlayFarmObjectAnimationMessage(param1);
      }
      
      public function deserializeAs_GameDataPlayFarmObjectAnimationMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readVarUhShort();
            if(_loc4_ < 0 || _loc4_ > 559)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of cellId.");
            }
            this.cellId.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameDataPlayFarmObjectAnimationMessage(param1);
      }
      
      public function deserializeAsyncAs_GameDataPlayFarmObjectAnimationMessage(param1:FuncTree) : void
      {
         this._cellIdtree = param1.addChild(this._cellIdtreeFunc);
      }
      
      private function _cellIdtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._cellIdtree.addChild(this._cellIdFunc);
            _loc3_++;
         }
      }
      
      private function _cellIdFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0 || _loc2_ > 559)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of cellId.");
         }
         this.cellId.push(_loc2_);
      }
   }
}
