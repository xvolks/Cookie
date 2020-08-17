package com.ankamagames.dofus.network.messages.game.interactive
{
   import com.ankamagames.dofus.network.types.game.interactive.InteractiveElement;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class InteractiveElementUpdatedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5708;
       
      
      private var _isInitialized:Boolean = false;
      
      public var interactiveElement:InteractiveElement;
      
      private var _interactiveElementtree:FuncTree;
      
      public function InteractiveElementUpdatedMessage()
      {
         this.interactiveElement = new InteractiveElement();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5708;
      }
      
      public function initInteractiveElementUpdatedMessage(param1:InteractiveElement = null) : InteractiveElementUpdatedMessage
      {
         this.interactiveElement = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.interactiveElement = new InteractiveElement();
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
         this.serializeAs_InteractiveElementUpdatedMessage(param1);
      }
      
      public function serializeAs_InteractiveElementUpdatedMessage(param1:ICustomDataOutput) : void
      {
         this.interactiveElement.serializeAs_InteractiveElement(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InteractiveElementUpdatedMessage(param1);
      }
      
      public function deserializeAs_InteractiveElementUpdatedMessage(param1:ICustomDataInput) : void
      {
         this.interactiveElement = new InteractiveElement();
         this.interactiveElement.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InteractiveElementUpdatedMessage(param1);
      }
      
      public function deserializeAsyncAs_InteractiveElementUpdatedMessage(param1:FuncTree) : void
      {
         this._interactiveElementtree = param1.addChild(this._interactiveElementtreeFunc);
      }
      
      private function _interactiveElementtreeFunc(param1:ICustomDataInput) : void
      {
         this.interactiveElement = new InteractiveElement();
         this.interactiveElement.deserializeAsync(this._interactiveElementtree);
      }
   }
}
