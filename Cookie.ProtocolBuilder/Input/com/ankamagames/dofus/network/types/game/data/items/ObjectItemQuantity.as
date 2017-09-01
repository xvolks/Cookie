package com.ankamagames.dofus.network.types.game.data.items
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class ObjectItemQuantity extends Item implements INetworkType
   {
      
      public static const protocolId:uint = 119;
       
      
      public var objectUID:uint = 0;
      
      public var quantity:uint = 0;
      
      public function ObjectItemQuantity()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 119;
      }
      
      public function initObjectItemQuantity(param1:uint = 0, param2:uint = 0) : ObjectItemQuantity
      {
         this.objectUID = param1;
         this.quantity = param2;
         return this;
      }
      
      override public function reset() : void
      {
         this.objectUID = 0;
         this.quantity = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ObjectItemQuantity(param1);
      }
      
      public function serializeAs_ObjectItemQuantity(param1:ICustomDataOutput) : void
      {
         super.serializeAs_Item(param1);
         if(this.objectUID < 0)
         {
            throw new Error("Forbidden value (" + this.objectUID + ") on element objectUID.");
         }
         param1.writeVarInt(this.objectUID);
         if(this.quantity < 0)
         {
            throw new Error("Forbidden value (" + this.quantity + ") on element quantity.");
         }
         param1.writeVarInt(this.quantity);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectItemQuantity(param1);
      }
      
      public function deserializeAs_ObjectItemQuantity(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._objectUIDFunc(param1);
         this._quantityFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectItemQuantity(param1);
      }
      
      public function deserializeAsyncAs_ObjectItemQuantity(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._objectUIDFunc);
         param1.addChild(this._quantityFunc);
      }
      
      private function _objectUIDFunc(param1:ICustomDataInput) : void
      {
         this.objectUID = param1.readVarUhInt();
         if(this.objectUID < 0)
         {
            throw new Error("Forbidden value (" + this.objectUID + ") on element of ObjectItemQuantity.objectUID.");
         }
      }
      
      private function _quantityFunc(param1:ICustomDataInput) : void
      {
         this.quantity = param1.readVarUhInt();
         if(this.quantity < 0)
         {
            throw new Error("Forbidden value (" + this.quantity + ") on element of ObjectItemQuantity.quantity.");
         }
      }
   }
}
