package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ObtainedItemWithBonusMessage extends ObtainedItemMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6520;
       
      
      private var _isInitialized:Boolean = false;
      
      public var bonusQuantity:uint = 0;
      
      public function ObtainedItemWithBonusMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6520;
      }
      
      public function initObtainedItemWithBonusMessage(param1:uint = 0, param2:uint = 0, param3:uint = 0) : ObtainedItemWithBonusMessage
      {
         super.initObtainedItemMessage(param1,param2);
         this.bonusQuantity = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.bonusQuantity = 0;
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
         this.serializeAs_ObtainedItemWithBonusMessage(param1);
      }
      
      public function serializeAs_ObtainedItemWithBonusMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ObtainedItemMessage(param1);
         if(this.bonusQuantity < 0)
         {
            throw new Error("Forbidden value (" + this.bonusQuantity + ") on element bonusQuantity.");
         }
         param1.writeVarInt(this.bonusQuantity);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObtainedItemWithBonusMessage(param1);
      }
      
      public function deserializeAs_ObtainedItemWithBonusMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._bonusQuantityFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObtainedItemWithBonusMessage(param1);
      }
      
      public function deserializeAsyncAs_ObtainedItemWithBonusMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._bonusQuantityFunc);
      }
      
      private function _bonusQuantityFunc(param1:ICustomDataInput) : void
      {
         this.bonusQuantity = param1.readVarUhInt();
         if(this.bonusQuantity < 0)
         {
            throw new Error("Forbidden value (" + this.bonusQuantity + ") on element of ObtainedItemWithBonusMessage.bonusQuantity.");
         }
      }
   }
}
