package com.ankamagames.dofus.network.types.game.paddock
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class PaddockInformationsForSell implements INetworkType
   {
      
      public static const protocolId:uint = 222;
       
      
      public var guildOwner:String = "";
      
      public var worldX:int = 0;
      
      public var worldY:int = 0;
      
      public var subAreaId:uint = 0;
      
      public var nbMount:int = 0;
      
      public var nbObject:int = 0;
      
      public var price:Number = 0;
      
      public function PaddockInformationsForSell()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 222;
      }
      
      public function initPaddockInformationsForSell(param1:String = "", param2:int = 0, param3:int = 0, param4:uint = 0, param5:int = 0, param6:int = 0, param7:Number = 0) : PaddockInformationsForSell
      {
         this.guildOwner = param1;
         this.worldX = param2;
         this.worldY = param3;
         this.subAreaId = param4;
         this.nbMount = param5;
         this.nbObject = param6;
         this.price = param7;
         return this;
      }
      
      public function reset() : void
      {
         this.guildOwner = "";
         this.worldX = 0;
         this.worldY = 0;
         this.subAreaId = 0;
         this.nbMount = 0;
         this.nbObject = 0;
         this.price = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PaddockInformationsForSell(param1);
      }
      
      public function serializeAs_PaddockInformationsForSell(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.guildOwner);
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
         param1.writeByte(this.nbMount);
         param1.writeByte(this.nbObject);
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element price.");
         }
         param1.writeVarLong(this.price);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PaddockInformationsForSell(param1);
      }
      
      public function deserializeAs_PaddockInformationsForSell(param1:ICustomDataInput) : void
      {
         this._guildOwnerFunc(param1);
         this._worldXFunc(param1);
         this._worldYFunc(param1);
         this._subAreaIdFunc(param1);
         this._nbMountFunc(param1);
         this._nbObjectFunc(param1);
         this._priceFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PaddockInformationsForSell(param1);
      }
      
      public function deserializeAsyncAs_PaddockInformationsForSell(param1:FuncTree) : void
      {
         param1.addChild(this._guildOwnerFunc);
         param1.addChild(this._worldXFunc);
         param1.addChild(this._worldYFunc);
         param1.addChild(this._subAreaIdFunc);
         param1.addChild(this._nbMountFunc);
         param1.addChild(this._nbObjectFunc);
         param1.addChild(this._priceFunc);
      }
      
      private function _guildOwnerFunc(param1:ICustomDataInput) : void
      {
         this.guildOwner = param1.readUTF();
      }
      
      private function _worldXFunc(param1:ICustomDataInput) : void
      {
         this.worldX = param1.readShort();
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element of PaddockInformationsForSell.worldX.");
         }
      }
      
      private function _worldYFunc(param1:ICustomDataInput) : void
      {
         this.worldY = param1.readShort();
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element of PaddockInformationsForSell.worldY.");
         }
      }
      
      private function _subAreaIdFunc(param1:ICustomDataInput) : void
      {
         this.subAreaId = param1.readVarUhShort();
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element of PaddockInformationsForSell.subAreaId.");
         }
      }
      
      private function _nbMountFunc(param1:ICustomDataInput) : void
      {
         this.nbMount = param1.readByte();
      }
      
      private function _nbObjectFunc(param1:ICustomDataInput) : void
      {
         this.nbObject = param1.readByte();
      }
      
      private function _priceFunc(param1:ICustomDataInput) : void
      {
         this.price = param1.readVarUhLong();
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element of PaddockInformationsForSell.price.");
         }
      }
   }
}
