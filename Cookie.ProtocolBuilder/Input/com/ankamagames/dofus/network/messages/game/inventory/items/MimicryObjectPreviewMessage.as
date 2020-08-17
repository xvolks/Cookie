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
   public class MimicryObjectPreviewMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6458;
       
      
      private var _isInitialized:Boolean = false;
      
      public var result:ObjectItem;
      
      private var _resulttree:FuncTree;
      
      public function MimicryObjectPreviewMessage()
      {
         this.result = new ObjectItem();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6458;
      }
      
      public function initMimicryObjectPreviewMessage(param1:ObjectItem = null) : MimicryObjectPreviewMessage
      {
         this.result = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.result = new ObjectItem();
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
         this.serializeAs_MimicryObjectPreviewMessage(param1);
      }
      
      public function serializeAs_MimicryObjectPreviewMessage(param1:ICustomDataOutput) : void
      {
         this.result.serializeAs_ObjectItem(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MimicryObjectPreviewMessage(param1);
      }
      
      public function deserializeAs_MimicryObjectPreviewMessage(param1:ICustomDataInput) : void
      {
         this.result = new ObjectItem();
         this.result.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MimicryObjectPreviewMessage(param1);
      }
      
      public function deserializeAsyncAs_MimicryObjectPreviewMessage(param1:FuncTree) : void
      {
         this._resulttree = param1.addChild(this._resulttreeFunc);
      }
      
      private function _resulttreeFunc(param1:ICustomDataInput) : void
      {
         this.result = new ObjectItem();
         this.result.deserializeAsync(this._resulttree);
      }
   }
}
