package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ObjectUseOnCellMessage extends ObjectUseMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 3013;
       
      
      private var _isInitialized:Boolean = false;
      
      public var cells:uint = 0;
      
      public function ObjectUseOnCellMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 3013;
      }
      
      public function initObjectUseOnCellMessage(param1:uint = 0, param2:uint = 0) : ObjectUseOnCellMessage
      {
         super.initObjectUseMessage(param1);
         this.cells = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.cells = 0;
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
         this.serializeAs_ObjectUseOnCellMessage(param1);
      }
      
      public function serializeAs_ObjectUseOnCellMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ObjectUseMessage(param1);
         if(this.cells < 0 || this.cells > 559)
         {
            throw new Error("Forbidden value (" + this.cells + ") on element cells.");
         }
         param1.writeVarShort(this.cells);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectUseOnCellMessage(param1);
      }
      
      public function deserializeAs_ObjectUseOnCellMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._cellsFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectUseOnCellMessage(param1);
      }
      
      public function deserializeAsyncAs_ObjectUseOnCellMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._cellsFunc);
      }
      
      private function _cellsFunc(param1:ICustomDataInput) : void
      {
         this.cells = param1.readVarUhShort();
         if(this.cells < 0 || this.cells > 559)
         {
            throw new Error("Forbidden value (" + this.cells + ") on element of ObjectUseOnCellMessage.cells.");
         }
      }
   }
}
