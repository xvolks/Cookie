package com.ankamagames.dofus.network.types.game.house
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class HouseInformationsForGuild extends HouseInformations implements INetworkType
   {
      
      public static const protocolId:uint = 170;
       
      
      public var instanceId:uint = 0;
      
      public var secondHand:Boolean = false;
      
      public var ownerName:String = "";
      
      public var worldX:int = 0;
      
      public var worldY:int = 0;
      
      public var mapId:int = 0;
      
      public var subAreaId:uint = 0;
      
      public var skillListIds:Vector.<int>;
      
      public var guildshareParams:uint = 0;
      
      private var _skillListIdstree:FuncTree;
      
      public function HouseInformationsForGuild()
      {
         this.skillListIds = new Vector.<int>();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 170;
      }
      
      public function initHouseInformationsForGuild(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:Boolean = false, param5:String = "", param6:int = 0, param7:int = 0, param8:int = 0, param9:uint = 0, param10:Vector.<int> = null, param11:uint = 0) : HouseInformationsForGuild
      {
         super.initHouseInformations(param1,param2);
         this.instanceId = param3;
         this.secondHand = param4;
         this.ownerName = param5;
         this.worldX = param6;
         this.worldY = param7;
         this.mapId = param8;
         this.subAreaId = param9;
         this.skillListIds = param10;
         this.guildshareParams = param11;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.instanceId = 0;
         this.secondHand = false;
         this.ownerName = "";
         this.worldX = 0;
         this.worldY = 0;
         this.mapId = 0;
         this.subAreaId = 0;
         this.skillListIds = new Vector.<int>();
         this.guildshareParams = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HouseInformationsForGuild(param1);
      }
      
      public function serializeAs_HouseInformationsForGuild(param1:ICustomDataOutput) : void
      {
         super.serializeAs_HouseInformations(param1);
         if(this.instanceId < 0)
         {
            throw new Error("Forbidden value (" + this.instanceId + ") on element instanceId.");
         }
         param1.writeInt(this.instanceId);
         param1.writeBoolean(this.secondHand);
         param1.writeUTF(this.ownerName);
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
         param1.writeInt(this.mapId);
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element subAreaId.");
         }
         param1.writeVarShort(this.subAreaId);
         param1.writeShort(this.skillListIds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.skillListIds.length)
         {
            param1.writeInt(this.skillListIds[_loc2_]);
            _loc2_++;
         }
         if(this.guildshareParams < 0)
         {
            throw new Error("Forbidden value (" + this.guildshareParams + ") on element guildshareParams.");
         }
         param1.writeVarInt(this.guildshareParams);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HouseInformationsForGuild(param1);
      }
      
      public function deserializeAs_HouseInformationsForGuild(param1:ICustomDataInput) : void
      {
         var _loc4_:int = 0;
         super.deserialize(param1);
         this._instanceIdFunc(param1);
         this._secondHandFunc(param1);
         this._ownerNameFunc(param1);
         this._worldXFunc(param1);
         this._worldYFunc(param1);
         this._mapIdFunc(param1);
         this._subAreaIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readInt();
            this.skillListIds.push(_loc4_);
            _loc3_++;
         }
         this._guildshareParamsFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HouseInformationsForGuild(param1);
      }
      
      public function deserializeAsyncAs_HouseInformationsForGuild(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._instanceIdFunc);
         param1.addChild(this._secondHandFunc);
         param1.addChild(this._ownerNameFunc);
         param1.addChild(this._worldXFunc);
         param1.addChild(this._worldYFunc);
         param1.addChild(this._mapIdFunc);
         param1.addChild(this._subAreaIdFunc);
         this._skillListIdstree = param1.addChild(this._skillListIdstreeFunc);
         param1.addChild(this._guildshareParamsFunc);
      }
      
      private function _instanceIdFunc(param1:ICustomDataInput) : void
      {
         this.instanceId = param1.readInt();
         if(this.instanceId < 0)
         {
            throw new Error("Forbidden value (" + this.instanceId + ") on element of HouseInformationsForGuild.instanceId.");
         }
      }
      
      private function _secondHandFunc(param1:ICustomDataInput) : void
      {
         this.secondHand = param1.readBoolean();
      }
      
      private function _ownerNameFunc(param1:ICustomDataInput) : void
      {
         this.ownerName = param1.readUTF();
      }
      
      private function _worldXFunc(param1:ICustomDataInput) : void
      {
         this.worldX = param1.readShort();
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element of HouseInformationsForGuild.worldX.");
         }
      }
      
      private function _worldYFunc(param1:ICustomDataInput) : void
      {
         this.worldY = param1.readShort();
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element of HouseInformationsForGuild.worldY.");
         }
      }
      
      private function _mapIdFunc(param1:ICustomDataInput) : void
      {
         this.mapId = param1.readInt();
      }
      
      private function _subAreaIdFunc(param1:ICustomDataInput) : void
      {
         this.subAreaId = param1.readVarUhShort();
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element of HouseInformationsForGuild.subAreaId.");
         }
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
      
      private function _guildshareParamsFunc(param1:ICustomDataInput) : void
      {
         this.guildshareParams = param1.readVarUhInt();
         if(this.guildshareParams < 0)
         {
            throw new Error("Forbidden value (" + this.guildshareParams + ") on element of HouseInformationsForGuild.guildshareParams.");
         }
      }
   }
}
