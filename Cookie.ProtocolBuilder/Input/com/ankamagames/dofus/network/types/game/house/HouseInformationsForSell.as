package com.ankamagames.dofus.network.types.game.house
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class HouseInformationsForSell implements INetworkType
   {
      
      public static const protocolId:uint = 221;
       
      
      public var instanceId:uint = 0;
      
      public var secondHand:Boolean = false;
      
      public var modelId:uint = 0;
      
      public var ownerName:String = "";
      
      public var ownerConnected:Boolean = false;
      
      public var worldX:int = 0;
      
      public var worldY:int = 0;
      
      public var subAreaId:uint = 0;
      
      public var nbRoom:int = 0;
      
      public var nbChest:int = 0;
      
      public var skillListIds:Vector.<int>;
      
      public var isLocked:Boolean = false;
      
      public var price:Number = 0;
      
      private var _skillListIdstree:FuncTree;
      
      public function HouseInformationsForSell()
      {
         this.skillListIds = new Vector.<int>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 221;
      }
      
      public function initHouseInformationsForSell(param1:uint = 0, param2:Boolean = false, param3:uint = 0, param4:String = "", param5:Boolean = false, param6:int = 0, param7:int = 0, param8:uint = 0, param9:int = 0, param10:int = 0, param11:Vector.<int> = null, param12:Boolean = false, param13:Number = 0) : HouseInformationsForSell
      {
         this.instanceId = param1;
         this.secondHand = param2;
         this.modelId = param3;
         this.ownerName = param4;
         this.ownerConnected = param5;
         this.worldX = param6;
         this.worldY = param7;
         this.subAreaId = param8;
         this.nbRoom = param9;
         this.nbChest = param10;
         this.skillListIds = param11;
         this.isLocked = param12;
         this.price = param13;
         return this;
      }
      
      public function reset() : void
      {
         this.instanceId = 0;
         this.secondHand = false;
         this.modelId = 0;
         this.ownerName = "";
         this.ownerConnected = false;
         this.worldX = 0;
         this.worldY = 0;
         this.subAreaId = 0;
         this.nbRoom = 0;
         this.nbChest = 0;
         this.skillListIds = new Vector.<int>();
         this.isLocked = false;
         this.price = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HouseInformationsForSell(param1);
      }
      
      public function serializeAs_HouseInformationsForSell(param1:ICustomDataOutput) : void
      {
         if(this.instanceId < 0)
         {
            throw new Error("Forbidden value (" + this.instanceId + ") on element instanceId.");
         }
         param1.writeInt(this.instanceId);
         param1.writeBoolean(this.secondHand);
         if(this.modelId < 0)
         {
            throw new Error("Forbidden value (" + this.modelId + ") on element modelId.");
         }
         param1.writeVarInt(this.modelId);
         param1.writeUTF(this.ownerName);
         param1.writeBoolean(this.ownerConnected);
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element worldX.");
         }
         param1.writeShort(this.worldX);
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element worldY.");
         }
         param1.writeShort(this.worldY);
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element subAreaId.");
         }
         param1.writeVarShort(this.subAreaId);
         param1.writeByte(this.nbRoom);
         param1.writeByte(this.nbChest);
         param1.writeShort(this.skillListIds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.skillListIds.length)
         {
            param1.writeInt(this.skillListIds[_loc2_]);
            _loc2_++;
         }
         param1.writeBoolean(this.isLocked);
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element price.");
         }
         param1.writeVarLong(this.price);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HouseInformationsForSell(param1);
      }
      
      public function deserializeAs_HouseInformationsForSell(param1:ICustomDataInput) : void
      {
         var _loc4_:int = 0;
         this._instanceIdFunc(param1);
         this._secondHandFunc(param1);
         this._modelIdFunc(param1);
         this._ownerNameFunc(param1);
         this._ownerConnectedFunc(param1);
         this._worldXFunc(param1);
         this._worldYFunc(param1);
         this._subAreaIdFunc(param1);
         this._nbRoomFunc(param1);
         this._nbChestFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readInt();
            this.skillListIds.push(_loc4_);
            _loc3_++;
         }
         this._isLockedFunc(param1);
         this._priceFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HouseInformationsForSell(param1);
      }
      
      public function deserializeAsyncAs_HouseInformationsForSell(param1:FuncTree) : void
      {
         param1.addChild(this._instanceIdFunc);
         param1.addChild(this._secondHandFunc);
         param1.addChild(this._modelIdFunc);
         param1.addChild(this._ownerNameFunc);
         param1.addChild(this._ownerConnectedFunc);
         param1.addChild(this._worldXFunc);
         param1.addChild(this._worldYFunc);
         param1.addChild(this._subAreaIdFunc);
         param1.addChild(this._nbRoomFunc);
         param1.addChild(this._nbChestFunc);
         this._skillListIdstree = param1.addChild(this._skillListIdstreeFunc);
         param1.addChild(this._isLockedFunc);
         param1.addChild(this._priceFunc);
      }
      
      private function _instanceIdFunc(param1:ICustomDataInput) : void
      {
         this.instanceId = param1.readInt();
         if(this.instanceId < 0)
         {
            throw new Error("Forbidden value (" + this.instanceId + ") on element of HouseInformationsForSell.instanceId.");
         }
      }
      
      private function _secondHandFunc(param1:ICustomDataInput) : void
      {
         this.secondHand = param1.readBoolean();
      }
      
      private function _modelIdFunc(param1:ICustomDataInput) : void
      {
         this.modelId = param1.readVarUhInt();
         if(this.modelId < 0)
         {
            throw new Error("Forbidden value (" + this.modelId + ") on element of HouseInformationsForSell.modelId.");
         }
      }
      
      private function _ownerNameFunc(param1:ICustomDataInput) : void
      {
         this.ownerName = param1.readUTF();
      }
      
      private function _ownerConnectedFunc(param1:ICustomDataInput) : void
      {
         this.ownerConnected = param1.readBoolean();
      }
      
      private function _worldXFunc(param1:ICustomDataInput) : void
      {
         this.worldX = param1.readShort();
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element of HouseInformationsForSell.worldX.");
         }
      }
      
      private function _worldYFunc(param1:ICustomDataInput) : void
      {
         this.worldY = param1.readShort();
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element of HouseInformationsForSell.worldY.");
         }
      }
      
      private function _subAreaIdFunc(param1:ICustomDataInput) : void
      {
         this.subAreaId = param1.readVarUhShort();
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element of HouseInformationsForSell.subAreaId.");
         }
      }
      
      private function _nbRoomFunc(param1:ICustomDataInput) : void
      {
         this.nbRoom = param1.readByte();
      }
      
      private function _nbChestFunc(param1:ICustomDataInput) : void
      {
         this.nbChest = param1.readByte();
      }
      
      private function _skillListIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._skillListIdstree.addChild(this._skillListIdsFunc);
            _loc3_++;
         }
      }
      
      private function _skillListIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:int = param1.readInt();
         this.skillListIds.push(_loc2_);
      }
      
      private function _isLockedFunc(param1:ICustomDataInput) : void
      {
         this.isLocked = param1.readBoolean();
      }
      
      private function _priceFunc(param1:ICustomDataInput) : void
      {
         this.price = param1.readVarUhLong();
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element of HouseInformationsForSell.price.");
         }
      }
   }
}
