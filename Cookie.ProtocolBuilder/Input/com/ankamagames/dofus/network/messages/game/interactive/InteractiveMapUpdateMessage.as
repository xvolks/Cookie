package com.ankamagames.dofus.network.messages.game.interactive
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.interactive.InteractiveElement;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class InteractiveMapUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5002;
       
      
      private var _isInitialized:Boolean = false;
      
      public var interactiveElements:Vector.<InteractiveElement>;
      
      private var _interactiveElementstree:FuncTree;
      
      public function InteractiveMapUpdateMessage()
      {
         this.interactiveElements = new Vector.<InteractiveElement>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5002;
      }
      
      public function initInteractiveMapUpdateMessage(param1:Vector.<InteractiveElement> = null) : InteractiveMapUpdateMessage
      {
         this.interactiveElements = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.interactiveElements = new Vector.<InteractiveElement>();
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
         this.serializeAs_InteractiveMapUpdateMessage(param1);
      }
      
      public function serializeAs_InteractiveMapUpdateMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.interactiveElements.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.interactiveElements.length)
         {
            param1.writeShort((this.interactiveElements[_loc2_] as InteractiveElement).getTypeId());
            (this.interactiveElements[_loc2_] as InteractiveElement).serialize(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InteractiveMapUpdateMessage(param1);
      }
      
      public function deserializeAs_InteractiveMapUpdateMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:InteractiveElement = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(InteractiveElement,_loc4_);
            _loc5_.deserialize(param1);
            this.interactiveElements.push(_loc5_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InteractiveMapUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_InteractiveMapUpdateMessage(param1:FuncTree) : void
      {
         this._interactiveElementstree = param1.addChild(this._interactiveElementstreeFunc);
      }
      
      private function _interactiveElementstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._interactiveElementstree.addChild(this._interactiveElementsFunc);
            _loc3_++;
         }
      }
      
      private function _interactiveElementsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:InteractiveElement = ProtocolTypeManager.getInstance(InteractiveElement,_loc2_);
         _loc3_.deserialize(param1);
         this.interactiveElements.push(_loc3_);
      }
   }
}
