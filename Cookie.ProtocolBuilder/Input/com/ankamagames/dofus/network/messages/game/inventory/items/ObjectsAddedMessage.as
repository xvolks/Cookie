package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItem;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ObjectsAddedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6033;
       
      
      private var _isInitialized:Boolean = false;
      
      public var object:Vector.<ObjectItem>;
      
      private var _objecttree:FuncTree;
      
      public function ObjectsAddedMessage()
      {
         this.object = new Vector.<ObjectItem>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6033;
      }
      
      public function initObjectsAddedMessage(param1:Vector.<ObjectItem> = null) : ObjectsAddedMessage
      {
         this.object = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.object = new Vector.<ObjectItem>();
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
         this.serializeAs_ObjectsAddedMessage(param1);
      }
      
      public function serializeAs_ObjectsAddedMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.object.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.object.length)
         {
            (this.object[_loc2_] as ObjectItem).serializeAs_ObjectItem(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectsAddedMessage(param1);
      }
      
      public function deserializeAs_ObjectsAddedMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:ObjectItem = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new ObjectItem();
            _loc4_.deserialize(param1);
            this.object.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectsAddedMessage(param1);
      }
      
      public function deserializeAsyncAs_ObjectsAddedMessage(param1:FuncTree) : void
      {
         this._objecttree = param1.addChild(this._objecttreeFunc);
      }
      
      private function _objecttreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._objecttree.addChild(this._objectFunc);
            _loc3_++;
         }
      }
      
      private function _objectFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ObjectItem = new ObjectItem();
         _loc2_.deserialize(param1);
         this.object.push(_loc2_);
      }
   }
}
