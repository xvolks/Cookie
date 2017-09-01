package com.ankamagames.dofus.network.types.game.context.roleplay.job
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.enums.PlayableBreedEnum;
   import com.ankamagames.dofus.network.types.game.character.status.PlayerStatus;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class JobCrafterDirectoryEntryPlayerInfo implements INetworkType
   {
      
      public static const protocolId:uint = 194;
       
      
      public var playerId:Number = 0;
      
      public var playerName:String = "";
      
      public var alignmentSide:int = 0;
      
      public var breed:int = 0;
      
      public var sex:Boolean = false;
      
      public var isInWorkshop:Boolean = false;
      
      public var worldX:int = 0;
      
      public var worldY:int = 0;
      
      public var mapId:int = 0;
      
      public var subAreaId:uint = 0;
      
      public var status:PlayerStatus;
      
      private var _statustree:FuncTree;
      
      public function JobCrafterDirectoryEntryPlayerInfo()
      {
         this.status = new PlayerStatus();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 194;
      }
      
      public function initJobCrafterDirectoryEntryPlayerInfo(param1:Number = 0, param2:String = "", param3:int = 0, param4:int = 0, param5:Boolean = false, param6:Boolean = false, param7:int = 0, param8:int = 0, param9:int = 0, param10:uint = 0, param11:PlayerStatus = null) : JobCrafterDirectoryEntryPlayerInfo
      {
         this.playerId = param1;
         this.playerName = param2;
         this.alignmentSide = param3;
         this.breed = param4;
         this.sex = param5;
         this.isInWorkshop = param6;
         this.worldX = param7;
         this.worldY = param8;
         this.mapId = param9;
         this.subAreaId = param10;
         this.status = param11;
         return this;
      }
      
      public function reset() : void
      {
         this.playerId = 0;
         this.playerName = "";
         this.alignmentSide = 0;
         this.breed = 0;
         this.sex = false;
         this.isInWorkshop = false;
         this.worldX = 0;
         this.worldY = 0;
         this.mapId = 0;
         this.subAreaId = 0;
         this.status = new PlayerStatus();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_JobCrafterDirectoryEntryPlayerInfo(param1);
      }
      
      public function serializeAs_JobCrafterDirectoryEntryPlayerInfo(param1:ICustomDataOutput) : void
      {
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element playerId.");
         }
         param1.writeVarLong(this.playerId);
         param1.writeUTF(this.playerName);
         param1.writeByte(this.alignmentSide);
         param1.writeByte(this.breed);
         param1.writeBoolean(this.sex);
         param1.writeBoolean(this.isInWorkshop);
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
         param1.writeShort(this.status.getTypeId());
         this.status.serialize(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_JobCrafterDirectoryEntryPlayerInfo(param1);
      }
      
      public function deserializeAs_JobCrafterDirectoryEntryPlayerInfo(param1:ICustomDataInput) : void
      {
         this._playerIdFunc(param1);
         this._playerNameFunc(param1);
         this._alignmentSideFunc(param1);
         this._breedFunc(param1);
         this._sexFunc(param1);
         this._isInWorkshopFunc(param1);
         this._worldXFunc(param1);
         this._worldYFunc(param1);
         this._mapIdFunc(param1);
         this._subAreaIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         this.status = ProtocolTypeManager.getInstance(PlayerStatus,_loc2_);
         this.status.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_JobCrafterDirectoryEntryPlayerInfo(param1);
      }
      
      public function deserializeAsyncAs_JobCrafterDirectoryEntryPlayerInfo(param1:FuncTree) : void
      {
         param1.addChild(this._playerIdFunc);
         param1.addChild(this._playerNameFunc);
         param1.addChild(this._alignmentSideFunc);
         param1.addChild(this._breedFunc);
         param1.addChild(this._sexFunc);
         param1.addChild(this._isInWorkshopFunc);
         param1.addChild(this._worldXFunc);
         param1.addChild(this._worldYFunc);
         param1.addChild(this._mapIdFunc);
         param1.addChild(this._subAreaIdFunc);
         this._statustree = param1.addChild(this._statustreeFunc);
      }
      
      private function _playerIdFunc(param1:ICustomDataInput) : void
      {
         this.playerId = param1.readVarUhLong();
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element of JobCrafterDirectoryEntryPlayerInfo.playerId.");
         }
      }
      
      private function _playerNameFunc(param1:ICustomDataInput) : void
      {
         this.playerName = param1.readUTF();
      }
      
      private function _alignmentSideFunc(param1:ICustomDataInput) : void
      {
         this.alignmentSide = param1.readByte();
      }
      
      private function _breedFunc(param1:ICustomDataInput) : void
      {
         this.breed = param1.readByte();
         if(this.breed < PlayableBreedEnum.Feca || this.breed > PlayableBreedEnum.Ouginak)
         {
            throw new Error("Forbidden value (" + this.breed + ") on element of JobCrafterDirectoryEntryPlayerInfo.breed.");
         }
      }
      
      private function _sexFunc(param1:ICustomDataInput) : void
      {
         this.sex = param1.readBoolean();
      }
      
      private function _isInWorkshopFunc(param1:ICustomDataInput) : void
      {
         this.isInWorkshop = param1.readBoolean();
      }
      
      private function _worldXFunc(param1:ICustomDataInput) : void
      {
         this.worldX = param1.readShort();
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element of JobCrafterDirectoryEntryPlayerInfo.worldX.");
         }
      }
      
      private function _worldYFunc(param1:ICustomDataInput) : void
      {
         this.worldY = param1.readShort();
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element of JobCrafterDirectoryEntryPlayerInfo.worldY.");
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
            throw new Error("Forbidden value (" + this.subAreaId + ") on element of JobCrafterDirectoryEntryPlayerInfo.subAreaId.");
         }
      }
      
      private function _statustreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.status = ProtocolTypeManager.getInstance(PlayerStatus,_loc2_);
         this.status.deserializeAsync(this._statustree);
      }
   }
}
