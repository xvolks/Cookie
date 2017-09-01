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
   public class ShortcutBarSwapRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6230;
       
      
      private var _isInitialized:Boolean = false;
      
      public var barType:uint = 0;
      
      public var firstSlot:uint = 0;
      
      public var secondSlot:uint = 0;
      
      public function ShortcutBarSwapRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6230;
      }
      
      public function initShortcutBarSwapRequestMessage(param1:uint = 0, param2:uint = 0, param3:uint = 0) : ShortcutBarSwapRequestMessage
      {
         this.barType = param1;
         this.firstSlot = param2;
         this.secondSlot = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.barType = 0;
         this.firstSlot = 0;
         this.secondSlot = 0;
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
         this.serializeAs_ShortcutBarSwapRequestMessage(param1);
      }
      
      public function serializeAs_ShortcutBarSwapRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.barType);
         if(this.firstSlot < 0 || this.firstSlot > 99)
         {
            throw new Error("Forbidden value (" + this.firstSlot + ") on element firstSlot.");
         }
         param1.writeByte(this.firstSlot);
         if(this.secondSlot < 0 || this.secondSlot > 99)
         {
            throw new Error("Forbidden value (" + this.secondSlot + ") on element secondSlot.");
         }
         param1.writeByte(this.secondSlot);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ShortcutBarSwapRequestMessage(param1);
      }
      
      public function deserializeAs_ShortcutBarSwapRequestMessage(param1:ICustomDataInput) : void
      {
         this._barTypeFunc(param1);
         this._firstSlotFunc(param1);
         this._secondSlotFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ShortcutBarSwapRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_ShortcutBarSwapRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._barTypeFunc);
         param1.addChild(this._firstSlotFunc);
         param1.addChild(this._secondSlotFunc);
      }
      
      private function _barTypeFunc(param1:ICustomDataInput) : void
      {
         this.barType = param1.readByte();
         if(this.barType < 0)
         {
            throw new Error("Forbidden value (" + this.barType + ") on element of ShortcutBarSwapRequestMessage.barType.");
         }
      }
      
      private function _firstSlotFunc(param1:ICustomDataInput) : void
      {
         this.firstSlot = param1.readByte();
         if(this.firstSlot < 0 || this.firstSlot > 99)
         {
            throw new Error("Forbidden value (" + this.firstSlot + ") on element of ShortcutBarSwapRequestMessage.firstSlot.");
         }
      }
      
      private function _secondSlotFunc(param1:ICustomDataInput) : void
      {
         this.secondSlot = param1.readByte();
         if(this.secondSlot < 0 || this.secondSlot > 99)
         {
            throw new Error("Forbidden value (" + this.secondSlot + ") on element of ShortcutBarSwapRequestMessage.secondSlot.");
         }
      }
   }
}
