package com.ankamagames.dofus.network.types.game.data.items
{
   import com.ankamagames.dofus.network.types.game.data.items.effects.ObjectEffect;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class ObjectItemInformationWithQuantity extends ObjectItemMinimalInformation implements INetworkType
   {
      
      public static const protocolId:uint = 387;
       
      
      public var quantity:uint = 0;
      
      public function ObjectItemInformationWithQuantity()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 387;
      }
      
      public function initObjectItemInformationWithQuantity(param1:uint = 0, param2:Vector.<ObjectEffect> = null, param3:uint = 0) : ObjectItemInformationWithQuantity
      {
         super.initObjectItemMinimalInformation(param1,param2);
         this.quantity = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.quantity = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ObjectItemInformationWithQuantity(param1);
      }
      
      public function serializeAs_ObjectItemInformationWithQuantity(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ObjectItemMinimalInformation(param1);
         if(this.quantity < 0)
         {
            throw new Error("Forbidden value (" + this.quantity + ") on element quantity.");
         }
         param1.writeVarInt(this.quantity);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectItemInformationWithQuantity(param1);
      }
      
      public function deserializeAs_ObjectItemInformationWithQuantity(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._quantityFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectItemInformationWithQuantity(param1);
      }
      
      public function deserializeAsyncAs_ObjectItemInformationWithQuantity(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._quantityFunc);
      }
      
      private function _quantityFunc(param1:ICustomDataInput) : void
      {
         this.quantity = param1.readVarUhInt();
         if(this.quantity < 0)
         {
            throw new Error("Forbidden value (" + this.quantity + ") on element of ObjectItemInformationWithQuantity.quantity.");
         }
      }
   }
}
