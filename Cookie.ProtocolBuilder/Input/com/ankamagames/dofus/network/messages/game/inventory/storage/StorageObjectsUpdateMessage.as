package com.ankamagames.dofus.network.messages.game.inventory.storage
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
   public class StorageObjectsUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6036;
       
      
      private var _isInitialized:Boolean = false;
      
      public var objectList:Vector.<ObjectItem>;
      
      private var _objectListtree:FuncTree;
      
      public function StorageObjectsUpdateMessage()
      {
         this.objectList = new Vector.<ObjectItem>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6036;
      }
      
      public function initStorageObjectsUpdateMessage(param1:Vector.<ObjectItem> = null) : StorageObjectsUpdateMessage
      {
         this.objectList = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.objectList = new Vector.<ObjectItem>();
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
         this.serializeAs_StorageObjectsUpdateMessage(param1);
      }
      
      public function serializeAs_StorageObjectsUpdateMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.objectList.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.objectList.length)
         {
            (this.objectList[_loc2_] as ObjectItem).serializeAs_ObjectItem(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_StorageObjectsUpdateMessage(param1);
      }
      
      public function deserializeAs_StorageObjectsUpdateMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:ObjectItem = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new ObjectItem();
            _loc4_.deserialize(param1);
            this.objectList.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_StorageObjectsUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_StorageObjectsUpdateMessage(param1:FuncTree) : void
      {
         this._objectListtree = param1.addChild(this._objectListtreeFunc);
      }
      
      private function _objectListtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._objectListtree.addChild(this._objectListFunc);
            _loc3_++;
         }
      }
      
      private function _objectListFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ObjectItem = new ObjectItem();
         _loc2_.deserialize(param1);
         this.objectList.push(_loc2_);
      }
   }
}
