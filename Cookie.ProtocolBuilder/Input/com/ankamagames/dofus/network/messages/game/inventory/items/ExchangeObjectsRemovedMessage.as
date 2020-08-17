package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.dofus.network.messages.game.inventory.exchanges.ExchangeObjectMessage;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeObjectsRemovedMessage extends ExchangeObjectMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6532;
       
      
      private var _isInitialized:Boolean = false;
      
      public var objectUID:Vector.<uint>;
      
      private var _objectUIDtree:FuncTree;
      
      public function ExchangeObjectsRemovedMessage()
      {
         this.objectUID = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6532;
      }
      
      public function initExchangeObjectsRemovedMessage(param1:Boolean = false, param2:Vector.<uint> = null) : ExchangeObjectsRemovedMessage
      {
         super.initExchangeObjectMessage(param1);
         this.objectUID = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.objectUID = new Vector.<uint>();
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
         this.serializeAs_ExchangeObjectsRemovedMessage(param1);
      }
      
      public function serializeAs_ExchangeObjectsRemovedMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ExchangeObjectMessage(param1);
         param1.writeShort(this.objectUID.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.objectUID.length)
         {
            if(this.objectUID[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.objectUID[_loc2_] + ") on element 1 (starting at 1) of objectUID.");
            }
            param1.writeVarInt(this.objectUID[_loc2_]);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeObjectsRemovedMessage(param1);
      }
      
      public function deserializeAs_ExchangeObjectsRemovedMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readVarUhInt();
            if(_loc4_ < 0)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of objectUID.");
            }
            this.objectUID.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeObjectsRemovedMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeObjectsRemovedMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._objectUIDtree = param1.addChild(this._objectUIDtreeFunc);
      }
      
      private function _objectUIDtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._objectUIDtree.addChild(this._objectUIDFunc);
            _loc3_++;
         }
      }
      
      private function _objectUIDFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhInt();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of objectUID.");
         }
         this.objectUID.push(_loc2_);
      }
   }
}
