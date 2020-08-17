package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class InventoryWeightMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 3009;
       
      
      private var _isInitialized:Boolean = false;
      
      public var weight:uint = 0;
      
      public var weightMax:uint = 0;
      
      public function InventoryWeightMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 3009;
      }
      
      public function initInventoryWeightMessage(param1:uint = 0, param2:uint = 0) : InventoryWeightMessage
      {
         this.weight = param1;
         this.weightMax = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.weight = 0;
         this.weightMax = 0;
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
         this.serializeAs_InventoryWeightMessage(param1);
      }
      
      public function serializeAs_InventoryWeightMessage(param1:ICustomDataOutput) : void
      {
         if(this.weight < 0)
         {
            throw new Error("Forbidden value (" + this.weight + ") on element weight.");
         }
         param1.writeVarInt(this.weight);
         if(this.weightMax < 0)
         {
            throw new Error("Forbidden value (" + this.weightMax + ") on element weightMax.");
         }
         param1.writeVarInt(this.weightMax);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InventoryWeightMessage(param1);
      }
      
      public function deserializeAs_InventoryWeightMessage(param1:ICustomDataInput) : void
      {
         this._weightFunc(param1);
         this._weightMaxFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InventoryWeightMessage(param1);
      }
      
      public function deserializeAsyncAs_InventoryWeightMessage(param1:FuncTree) : void
      {
         param1.addChild(this._weightFunc);
         param1.addChild(this._weightMaxFunc);
      }
      
      private function _weightFunc(param1:ICustomDataInput) : void
      {
         this.weight = param1.readVarUhInt();
         if(this.weight < 0)
         {
            throw new Error("Forbidden value (" + this.weight + ") on element of InventoryWeightMessage.weight.");
         }
      }
      
      private function _weightMaxFunc(param1:ICustomDataInput) : void
      {
         this.weightMax = param1.readVarUhInt();
         if(this.weightMax < 0)
         {
            throw new Error("Forbidden value (" + this.weightMax + ") on element of InventoryWeightMessage.weightMax.");
         }
      }
   }
}
