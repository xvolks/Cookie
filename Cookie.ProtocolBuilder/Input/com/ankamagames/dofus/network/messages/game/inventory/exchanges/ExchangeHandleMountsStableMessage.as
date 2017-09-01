package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeHandleMountsStableMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6562;
       
      
      private var _isInitialized:Boolean = false;
      
      public var actionType:int = 0;
      
      public var ridesId:Vector.<uint>;
      
      private var _ridesIdtree:FuncTree;
      
      public function ExchangeHandleMountsStableMessage()
      {
         this.ridesId = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6562;
      }
      
      public function initExchangeHandleMountsStableMessage(param1:int = 0, param2:Vector.<uint> = null) : ExchangeHandleMountsStableMessage
      {
         this.actionType = param1;
         this.ridesId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.actionType = 0;
         this.ridesId = new Vector.<uint>();
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
         this.serializeAs_ExchangeHandleMountsStableMessage(param1);
      }
      
      public function serializeAs_ExchangeHandleMountsStableMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.actionType);
         param1.writeShort(this.ridesId.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.ridesId.length)
         {
            if(this.ridesId[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.ridesId[_loc2_] + ") on element 2 (starting at 1) of ridesId.");
            }
            param1.writeVarInt(this.ridesId[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeHandleMountsStableMessage(param1);
      }
      
      public function deserializeAs_ExchangeHandleMountsStableMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         this._actionTypeFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readVarUhInt();
            if(_loc4_ < 0)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of ridesId.");
            }
            this.ridesId.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeHandleMountsStableMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeHandleMountsStableMessage(param1:FuncTree) : void
      {
         param1.addChild(this._actionTypeFunc);
         this._ridesIdtree = param1.addChild(this._ridesIdtreeFunc);
      }
      
      private function _actionTypeFunc(param1:ICustomDataInput) : void
      {
         this.actionType = param1.readByte();
      }
      
      private function _ridesIdtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._ridesIdtree.addChild(this._ridesIdFunc);
            _loc3_++;
         }
      }
      
      private function _ridesIdFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhInt();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of ridesId.");
         }
         this.ridesId.push(_loc2_);
      }
   }
}
