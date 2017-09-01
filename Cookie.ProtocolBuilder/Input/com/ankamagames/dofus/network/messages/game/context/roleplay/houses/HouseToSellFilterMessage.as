package com.ankamagames.dofus.network.messages.game.context.roleplay.houses
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class HouseToSellFilterMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6137;
       
      
      private var _isInitialized:Boolean = false;
      
      public var areaId:int = 0;
      
      public var atLeastNbRoom:uint = 0;
      
      public var atLeastNbChest:uint = 0;
      
      public var skillRequested:uint = 0;
      
      public var maxPrice:Number = 0;
      
      public function HouseToSellFilterMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6137;
      }
      
      public function initHouseToSellFilterMessage(param1:int = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0, param5:Number = 0) : HouseToSellFilterMessage
      {
         this.areaId = param1;
         this.atLeastNbRoom = param2;
         this.atLeastNbChest = param3;
         this.skillRequested = param4;
         this.maxPrice = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.areaId = 0;
         this.atLeastNbRoom = 0;
         this.atLeastNbChest = 0;
         this.skillRequested = 0;
         this.maxPrice = 0;
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
         this.serializeAs_HouseToSellFilterMessage(param1);
      }
      
      public function serializeAs_HouseToSellFilterMessage(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.areaId);
         if(this.atLeastNbRoom < 0)
         {
            throw new Error("Forbidden value (" + this.atLeastNbRoom + ") on element atLeastNbRoom.");
         }
         param1.writeByte(this.atLeastNbRoom);
         if(this.atLeastNbChest < 0)
         {
            throw new Error("Forbidden value (" + this.atLeastNbChest + ") on element atLeastNbChest.");
         }
         param1.writeByte(this.atLeastNbChest);
         if(this.skillRequested < 0)
         {
            throw new Error("Forbidden value (" + this.skillRequested + ") on element skillRequested.");
         }
         param1.writeVarShort(this.skillRequested);
         if(this.maxPrice < 0 || this.maxPrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.maxPrice + ") on element maxPrice.");
         }
         param1.writeVarLong(this.maxPrice);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HouseToSellFilterMessage(param1);
      }
      
      public function deserializeAs_HouseToSellFilterMessage(param1:ICustomDataInput) : void
      {
         this._areaIdFunc(param1);
         this._atLeastNbRoomFunc(param1);
         this._atLeastNbChestFunc(param1);
         this._skillRequestedFunc(param1);
         this._maxPriceFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HouseToSellFilterMessage(param1);
      }
      
      public function deserializeAsyncAs_HouseToSellFilterMessage(param1:FuncTree) : void
      {
         param1.addChild(this._areaIdFunc);
         param1.addChild(this._atLeastNbRoomFunc);
         param1.addChild(this._atLeastNbChestFunc);
         param1.addChild(this._skillRequestedFunc);
         param1.addChild(this._maxPriceFunc);
      }
      
      private function _areaIdFunc(param1:ICustomDataInput) : void
      {
         this.areaId = param1.readInt();
      }
      
      private function _atLeastNbRoomFunc(param1:ICustomDataInput) : void
      {
         this.atLeastNbRoom = param1.readByte();
         if(this.atLeastNbRoom < 0)
         {
            throw new Error("Forbidden value (" + this.atLeastNbRoom + ") on element of HouseToSellFilterMessage.atLeastNbRoom.");
         }
      }
      
      private function _atLeastNbChestFunc(param1:ICustomDataInput) : void
      {
         this.atLeastNbChest = param1.readByte();
         if(this.atLeastNbChest < 0)
         {
            throw new Error("Forbidden value (" + this.atLeastNbChest + ") on element of HouseToSellFilterMessage.atLeastNbChest.");
         }
      }
      
      private function _skillRequestedFunc(param1:ICustomDataInput) : void
      {
         this.skillRequested = param1.readVarUhShort();
         if(this.skillRequested < 0)
         {
            throw new Error("Forbidden value (" + this.skillRequested + ") on element of HouseToSellFilterMessage.skillRequested.");
         }
      }
      
      private function _maxPriceFunc(param1:ICustomDataInput) : void
      {
         this.maxPrice = param1.readVarUhLong();
         if(this.maxPrice < 0 || this.maxPrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.maxPrice + ") on element of HouseToSellFilterMessage.maxPrice.");
         }
      }
   }
}
