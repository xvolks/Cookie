package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItemQuantity;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ObjectsQuantityMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6206;
       
      
      private var _isInitialized:Boolean = false;
      
      public var objectsUIDAndQty:Vector.<ObjectItemQuantity>;
      
      private var _objectsUIDAndQtytree:FuncTree;
      
      public function ObjectsQuantityMessage()
      {
         this.objectsUIDAndQty = new Vector.<ObjectItemQuantity>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6206;
      }
      
      public function initObjectsQuantityMessage(param1:Vector.<ObjectItemQuantity> = null) : ObjectsQuantityMessage
      {
         this.objectsUIDAndQty = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.objectsUIDAndQty = new Vector.<ObjectItemQuantity>();
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
         this.serializeAs_ObjectsQuantityMessage(param1);
      }
      
      public function serializeAs_ObjectsQuantityMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.objectsUIDAndQty.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.objectsUIDAndQty.length)
         {
            (this.objectsUIDAndQty[_loc2_] as ObjectItemQuantity).serializeAs_ObjectItemQuantity(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectsQuantityMessage(param1);
      }
      
      public function deserializeAs_ObjectsQuantityMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:ObjectItemQuantity = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new ObjectItemQuantity();
            _loc4_.deserialize(param1);
            this.objectsUIDAndQty.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectsQuantityMessage(param1);
      }
      
      public function deserializeAsyncAs_ObjectsQuantityMessage(param1:FuncTree) : void
      {
         this._objectsUIDAndQtytree = param1.addChild(this._objectsUIDAndQtytreeFunc);
      }
      
      private function _objectsUIDAndQtytreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._objectsUIDAndQtytree.addChild(this._objectsUIDAndQtyFunc);
            _loc3_++;
         }
      }
      
      private function _objectsUIDAndQtyFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ObjectItemQuantity = new ObjectItemQuantity();
         _loc2_.deserialize(param1);
         this.objectsUIDAndQty.push(_loc2_);
      }
   }
}
