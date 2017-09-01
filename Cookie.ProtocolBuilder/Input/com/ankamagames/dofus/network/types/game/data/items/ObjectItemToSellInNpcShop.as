package com.ankamagames.dofus.network.types.game.data.items
{
   import com.ankamagames.dofus.network.types.game.data.items.effects.ObjectEffect;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class ObjectItemToSellInNpcShop extends ObjectItemMinimalInformation implements INetworkType
   {
      
      public static const protocolId:uint = 352;
       
      
      public var objectPrice:Number = 0;
      
      public var buyCriterion:String = "";
      
      public function ObjectItemToSellInNpcShop()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 352;
      }
      
      public function initObjectItemToSellInNpcShop(param1:uint = 0, param2:Vector.<ObjectEffect> = null, param3:Number = 0, param4:String = "") : ObjectItemToSellInNpcShop
      {
         super.initObjectItemMinimalInformation(param1,param2);
         this.objectPrice = param3;
         this.buyCriterion = param4;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.objectPrice = 0;
         this.buyCriterion = "";
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ObjectItemToSellInNpcShop(param1);
      }
      
      public function serializeAs_ObjectItemToSellInNpcShop(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ObjectItemMinimalInformation(param1);
         if(this.objectPrice < 0 || this.objectPrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.objectPrice + ") on element objectPrice.");
         }
         param1.writeVarLong(this.objectPrice);
         param1.writeUTF(this.buyCriterion);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectItemToSellInNpcShop(param1);
      }
      
      public function deserializeAs_ObjectItemToSellInNpcShop(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._objectPriceFunc(param1);
         this._buyCriterionFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectItemToSellInNpcShop(param1);
      }
      
      public function deserializeAsyncAs_ObjectItemToSellInNpcShop(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._objectPriceFunc);
         param1.addChild(this._buyCriterionFunc);
      }
      
      private function _objectPriceFunc(param1:ICustomDataInput) : void
      {
         this.objectPrice = param1.readVarUhLong();
         if(this.objectPrice < 0 || this.objectPrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.objectPrice + ") on element of ObjectItemToSellInNpcShop.objectPrice.");
         }
      }
      
      private function _buyCriterionFunc(param1:ICustomDataInput) : void
      {
         this.buyCriterion = param1.readUTF();
      }
   }
}
