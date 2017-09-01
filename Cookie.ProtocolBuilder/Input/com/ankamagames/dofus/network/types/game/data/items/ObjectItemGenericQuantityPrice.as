package com.ankamagames.dofus.network.types.game.data.items
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class ObjectItemGenericQuantityPrice extends ObjectItemGenericQuantity implements INetworkType
   {
      
      public static const protocolId:uint = 494;
       
      
      public var price:Number = 0;
      
      public function ObjectItemGenericQuantityPrice()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 494;
      }
      
      public function initObjectItemGenericQuantityPrice(param1:uint = 0, param2:uint = 0, param3:Number = 0) : ObjectItemGenericQuantityPrice
      {
         super.initObjectItemGenericQuantity(param1,param2);
         this.price = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.price = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ObjectItemGenericQuantityPrice(param1);
      }
      
      public function serializeAs_ObjectItemGenericQuantityPrice(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ObjectItemGenericQuantity(param1);
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element price.");
         }
         param1.writeVarLong(this.price);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectItemGenericQuantityPrice(param1);
      }
      
      public function deserializeAs_ObjectItemGenericQuantityPrice(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._priceFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectItemGenericQuantityPrice(param1);
      }
      
      public function deserializeAsyncAs_ObjectItemGenericQuantityPrice(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._priceFunc);
      }
      
      private function _priceFunc(param1:ICustomDataInput) : void
      {
         this.price = param1.readVarUhLong();
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element of ObjectItemGenericQuantityPrice.price.");
         }
      }
   }
}
