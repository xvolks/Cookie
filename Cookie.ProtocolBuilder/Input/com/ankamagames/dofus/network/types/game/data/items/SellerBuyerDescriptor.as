package com.ankamagames.dofus.network.types.game.data.items
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class SellerBuyerDescriptor implements INetworkType
   {
      
      public static const protocolId:uint = 121;
       
      
      public var quantities:Vector.<uint>;
      
      public var types:Vector.<uint>;
      
      public var taxPercentage:Number = 0;
      
      public var taxModificationPercentage:Number = 0;
      
      public var maxItemLevel:uint = 0;
      
      public var maxItemPerAccount:uint = 0;
      
      public var npcContextualId:int = 0;
      
      public var unsoldDelay:uint = 0;
      
      private var _quantitiestree:FuncTree;
      
      private var _typestree:FuncTree;
      
      public function SellerBuyerDescriptor()
      {
         this.quantities = new Vector.<uint>();
         this.types = new Vector.<uint>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 121;
      }
      
      public function initSellerBuyerDescriptor(param1:Vector.<uint> = null, param2:Vector.<uint> = null, param3:Number = 0, param4:Number = 0, param5:uint = 0, param6:uint = 0, param7:int = 0, param8:uint = 0) : SellerBuyerDescriptor
      {
         this.quantities = param1;
         this.types = param2;
         this.taxPercentage = param3;
         this.taxModificationPercentage = param4;
         this.maxItemLevel = param5;
         this.maxItemPerAccount = param6;
         this.npcContextualId = param7;
         this.unsoldDelay = param8;
         return this;
      }
      
      public function reset() : void
      {
         this.quantities = new Vector.<uint>();
         this.types = new Vector.<uint>();
         this.taxPercentage = 0;
         this.taxModificationPercentage = 0;
         this.maxItemLevel = 0;
         this.maxItemPerAccount = 0;
         this.npcContextualId = 0;
         this.unsoldDelay = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_SellerBuyerDescriptor(param1);
      }
      
      public function serializeAs_SellerBuyerDescriptor(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.quantities.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.quantities.length)
         {
            if(this.quantities[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.quantities[_loc2_] + ") on element 1 (starting at 1) of quantities.");
            }
            param1.writeVarInt(this.quantities[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.types.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.types.length)
         {
            if(this.types[_loc3_] < 0)
            {
               throw new Error("Forbidden value (" + this.types[_loc3_] + ") on element 2 (starting at 1) of types.");
            }
            param1.writeVarInt(this.types[_loc3_]);
            _loc3_++;
         }
         param1.writeFloat(this.taxPercentage);
         param1.writeFloat(this.taxModificationPercentage);
         if(this.maxItemLevel < 0 || this.maxItemLevel > 255)
         {
            throw new Error("Forbidden value (" + this.maxItemLevel + ") on element maxItemLevel.");
         }
         param1.writeByte(this.maxItemLevel);
         if(this.maxItemPerAccount < 0)
         {
            throw new Error("Forbidden value (" + this.maxItemPerAccount + ") on element maxItemPerAccount.");
         }
         param1.writeVarInt(this.maxItemPerAccount);
         param1.writeInt(this.npcContextualId);
         if(this.unsoldDelay < 0)
         {
            throw new Error("Forbidden value (" + this.unsoldDelay + ") on element unsoldDelay.");
         }
         param1.writeVarShort(this.unsoldDelay);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SellerBuyerDescriptor(param1);
      }
      
      public function deserializeAs_SellerBuyerDescriptor(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:uint = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readVarUhInt();
            if(_loc6_ < 0)
            {
               throw new Error("Forbidden value (" + _loc6_ + ") on elements of quantities.");
            }
            this.quantities.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = param1.readVarUhInt();
            if(_loc7_ < 0)
            {
               throw new Error("Forbidden value (" + _loc7_ + ") on elements of types.");
            }
            this.types.push(_loc7_);
            _loc5_++;
         }
         this._taxPercentageFunc(param1);
         this._taxModificationPercentageFunc(param1);
         this._maxItemLevelFunc(param1);
         this._maxItemPerAccountFunc(param1);
         this._npcContextualIdFunc(param1);
         this._unsoldDelayFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SellerBuyerDescriptor(param1);
      }
      
      public function deserializeAsyncAs_SellerBuyerDescriptor(param1:FuncTree) : void
      {
         this._quantitiestree = param1.addChild(this._quantitiestreeFunc);
         this._typestree = param1.addChild(this._typestreeFunc);
         param1.addChild(this._taxPercentageFunc);
         param1.addChild(this._taxModificationPercentageFunc);
         param1.addChild(this._maxItemLevelFunc);
         param1.addChild(this._maxItemPerAccountFunc);
         param1.addChild(this._npcContextualIdFunc);
         param1.addChild(this._unsoldDelayFunc);
      }
      
      private function _quantitiestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._quantitiestree.addChild(this._quantitiesFunc);
            _loc3_++;
         }
      }
      
      private function _quantitiesFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhInt();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of quantities.");
         }
         this.quantities.push(_loc2_);
      }
      
      private function _typestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._typestree.addChild(this._typesFunc);
            _loc3_++;
         }
      }
      
      private function _typesFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhInt();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of types.");
         }
         this.types.push(_loc2_);
      }
      
      private function _taxPercentageFunc(param1:ICustomDataInput) : void
      {
         this.taxPercentage = param1.readFloat();
      }
      
      private function _taxModificationPercentageFunc(param1:ICustomDataInput) : void
      {
         this.taxModificationPercentage = param1.readFloat();
      }
      
      private function _maxItemLevelFunc(param1:ICustomDataInput) : void
      {
         this.maxItemLevel = param1.readUnsignedByte();
         if(this.maxItemLevel < 0 || this.maxItemLevel > 255)
         {
            throw new Error("Forbidden value (" + this.maxItemLevel + ") on element of SellerBuyerDescriptor.maxItemLevel.");
         }
      }
      
      private function _maxItemPerAccountFunc(param1:ICustomDataInput) : void
      {
         this.maxItemPerAccount = param1.readVarUhInt();
         if(this.maxItemPerAccount < 0)
         {
            throw new Error("Forbidden value (" + this.maxItemPerAccount + ") on element of SellerBuyerDescriptor.maxItemPerAccount.");
         }
      }
      
      private function _npcContextualIdFunc(param1:ICustomDataInput) : void
      {
         this.npcContextualId = param1.readInt();
      }
      
      private function _unsoldDelayFunc(param1:ICustomDataInput) : void
      {
         this.unsoldDelay = param1.readVarUhShort();
         if(this.unsoldDelay < 0)
         {
            throw new Error("Forbidden value (" + this.unsoldDelay + ") on element of SellerBuyerDescriptor.unsoldDelay.");
         }
      }
   }
}
