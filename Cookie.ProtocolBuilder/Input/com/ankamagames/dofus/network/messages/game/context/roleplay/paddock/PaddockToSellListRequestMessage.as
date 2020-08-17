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
   public class PaddockToSellListRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6141;
       
      
      private var _isInitialized:Boolean = false;
      
      public var pageIndex:uint = 0;
      
      public function PaddockToSellListRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6141;
      }
      
      public function initPaddockToSellListRequestMessage(param1:uint = 0) : PaddockToSellListRequestMessage
      {
         this.pageIndex = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.pageIndex = 0;
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
         this.serializeAs_PaddockToSellListRequestMessage(param1);
      }
      
      public function serializeAs_PaddockToSellListRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.pageIndex < 0)
         {
            throw new Error("Forbidden value (" + this.pageIndex + ") on element pageIndex.");
         }
         param1.writeVarShort(this.pageIndex);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PaddockToSellListRequestMessage(param1);
      }
      
      public function deserializeAs_PaddockToSellListRequestMessage(param1:ICustomDataInput) : void
      {
         this._pageIndexFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PaddockToSellListRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_PaddockToSellListRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._pageIndexFunc);
      }
      
      private function _pageIndexFunc(param1:ICustomDataInput) : void
      {
         this.pageIndex = param1.readVarUhShort();
         if(this.pageIndex < 0)
         {
            throw new Error("Forbidden value (" + this.pageIndex + ") on element of PaddockToSellListRequestMessage.pageIndex.");
         }
      }
   }
}
