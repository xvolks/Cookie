package com.ankamagames.dofus.network.messages.game.inventory.storage
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class StorageObjectsRemoveMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6035;
       
      
      private var _isInitialized:Boolean = false;
      
      public var objectUIDList:Vector.<uint>;
      
      private var _objectUIDListtree:FuncTree;
      
      public function StorageObjectsRemoveMessage()
      {
         this.objectUIDList = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6035;
      }
      
      public function initStorageObjectsRemoveMessage(param1:Vector.<uint> = null) : StorageObjectsRemoveMessage
      {
         this.objectUIDList = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.objectUIDList = new Vector.<uint>();
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
         this.serializeAs_StorageObjectsRemoveMessage(param1);
      }
      
      public function serializeAs_StorageObjectsRemoveMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.objectUIDList.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.objectUIDList.length)
         {
            if(this.objectUIDList[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.objectUIDList[_loc2_] + ") on element 1 (starting at 1) of objectUIDList.");
            }
            param1.writeVarInt(this.objectUIDList[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_StorageObjectsRemoveMessage(param1);
      }
      
      public function deserializeAs_StorageObjectsRemoveMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readVarUhInt();
            if(_loc4_ < 0)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of objectUIDList.");
            }
            this.objectUIDList.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_StorageObjectsRemoveMessage(param1);
      }
      
      public function deserializeAsyncAs_StorageObjectsRemoveMessage(param1:FuncTree) : void
      {
         this._objectUIDListtree = param1.addChild(this._objectUIDListtreeFunc);
      }
      
      private function _objectUIDListtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._objectUIDListtree.addChild(this._objectUIDListFunc);
            _loc3_++;
         }
      }
      
      private function _objectUIDListFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhInt();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of objectUIDList.");
         }
         this.objectUIDList.push(_loc2_);
      }
   }
}
