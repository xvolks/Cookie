package com.ankamagames.dofus.network.messages.game.context.mount
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PaddockMoveItemRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6052;
       
      
      private var _isInitialized:Boolean = false;
      
      public var oldCellId:uint = 0;
      
      public var newCellId:uint = 0;
      
      public function PaddockMoveItemRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6052;
      }
      
      public function initPaddockMoveItemRequestMessage(param1:uint = 0, param2:uint = 0) : PaddockMoveItemRequestMessage
      {
         this.oldCellId = param1;
         this.newCellId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.oldCellId = 0;
         this.newCellId = 0;
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
         this.serializeAs_PaddockMoveItemRequestMessage(param1);
      }
      
      public function serializeAs_PaddockMoveItemRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.oldCellId < 0 || this.oldCellId > 559)
         {
            throw new Error("Forbidden value (" + this.oldCellId + ") on element oldCellId.");
         }
         param1.writeVarShort(this.oldCellId);
         if(this.newCellId < 0 || this.newCellId > 559)
         {
            throw new Error("Forbidden value (" + this.newCellId + ") on element newCellId.");
         }
         param1.writeVarShort(this.newCellId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PaddockMoveItemRequestMessage(param1);
      }
      
      public function deserializeAs_PaddockMoveItemRequestMessage(param1:ICustomDataInput) : void
      {
         this._oldCellIdFunc(param1);
         this._newCellIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PaddockMoveItemRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_PaddockMoveItemRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._oldCellIdFunc);
         param1.addChild(this._newCellIdFunc);
      }
      
      private function _oldCellIdFunc(param1:ICustomDataInput) : void
      {
         this.oldCellId = param1.readVarUhShort();
         if(this.oldCellId < 0 || this.oldCellId > 559)
         {
            throw new Error("Forbidden value (" + this.oldCellId + ") on element of PaddockMoveItemRequestMessage.oldCellId.");
         }
      }
      
      private function _newCellIdFunc(param1:ICustomDataInput) : void
      {
         this.newCellId = param1.readVarUhShort();
         if(this.newCellId < 0 || this.newCellId > 559)
         {
            throw new Error("Forbidden value (" + this.newCellId + ") on element of PaddockMoveItemRequestMessage.newCellId.");
         }
      }
   }
}
