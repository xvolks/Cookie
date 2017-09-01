package com.ankamagames.dofus.network.messages.game.shortcut
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ShortcutBarRemovedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6224;
       
      
      private var _isInitialized:Boolean = false;
      
      public var barType:uint = 0;
      
      public var slot:uint = 0;
      
      public function ShortcutBarRemovedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6224;
      }
      
      public function initShortcutBarRemovedMessage(param1:uint = 0, param2:uint = 0) : ShortcutBarRemovedMessage
      {
         this.barType = param1;
         this.slot = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.barType = 0;
         this.slot = 0;
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
         this.serializeAs_ShortcutBarRemovedMessage(param1);
      }
      
      public function serializeAs_ShortcutBarRemovedMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.barType);
         if(this.slot < 0 || this.slot > 99)
         {
            throw new Error("Forbidden value (" + this.slot + ") on element slot.");
         }
         param1.writeByte(this.slot);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ShortcutBarRemovedMessage(param1);
      }
      
      public function deserializeAs_ShortcutBarRemovedMessage(param1:ICustomDataInput) : void
      {
         this._barTypeFunc(param1);
         this._slotFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ShortcutBarRemovedMessage(param1);
      }
      
      public function deserializeAsyncAs_ShortcutBarRemovedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._barTypeFunc);
         param1.addChild(this._slotFunc);
      }
      
      private function _barTypeFunc(param1:ICustomDataInput) : void
      {
         this.barType = param1.readByte();
         if(this.barType < 0)
         {
            throw new Error("Forbidden value (" + this.barType + ") on element of ShortcutBarRemovedMessage.barType.");
         }
      }
      
      private function _slotFunc(param1:ICustomDataInput) : void
      {
         this.slot = param1.readByte();
         if(this.slot < 0 || this.slot > 99)
         {
            throw new Error("Forbidden value (" + this.slot + ") on element of ShortcutBarRemovedMessage.slot.");
         }
      }
   }
}
