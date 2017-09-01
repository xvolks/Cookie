package com.ankamagames.dofus.network.types.game.paddock
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class PaddockBuyableInformations implements INetworkType
   {
      
      public static const protocolId:uint = 130;
       
      
      public var price:Number = 0;
      
      public var locked:Boolean = false;
      
      public function PaddockBuyableInformations()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 130;
      }
      
      public function initPaddockBuyableInformations(param1:Number = 0, param2:Boolean = false) : PaddockBuyableInformations
      {
         this.price = param1;
         this.locked = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.price = 0;
         this.locked = false;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PaddockBuyableInformations(param1);
      }
      
      public function serializeAs_PaddockBuyableInformations(param1:ICustomDataOutput) : void
      {
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element price.");
         }
         param1.writeVarLong(this.price);
         param1.writeBoolean(this.locked);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PaddockBuyableInformations(param1);
      }
      
      public function deserializeAs_PaddockBuyableInformations(param1:ICustomDataInput) : void
      {
         this._priceFunc(param1);
         this._lockedFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PaddockBuyableInformations(param1);
      }
      
      public function deserializeAsyncAs_PaddockBuyableInformations(param1:FuncTree) : void
      {
         param1.addChild(this._priceFunc);
         param1.addChild(this._lockedFunc);
      }
      
      private function _priceFunc(param1:ICustomDataInput) : void
      {
         this.price = param1.readVarUhLong();
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element of PaddockBuyableInformations.price.");
         }
      }
      
      private function _lockedFunc(param1:ICustomDataInput) : void
      {
         this.locked = param1.readBoolean();
      }
   }
}
