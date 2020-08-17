package com.ankamagames.dofus.network.types.game.friend
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.GuildInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FriendSpouseInformations implements INetworkType
   {
      
      public static const protocolId:uint = 77;
       
      
      public var spouseAccountId:uint = 0;
      
      public var spouseId:Number = 0;
      
      public var spouseName:String = "";
      
      public var spouseLevel:uint = 0;
      
      public var breed:int = 0;
      
      public var sex:int = 0;
      
      public var spouseEntityLook:EntityLook;
      
      public var guildInfo:GuildInformations;
      
      public var alignmentSide:int = 0;
      
      private var _spouseEntityLooktree:FuncTree;
      
      private var _guildInfotree:FuncTree;
      
      public function FriendSpouseInformations()
      {
         this.spouseEntityLook = new EntityLook();
         this.guildInfo = new GuildInformations();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 77;
      }
      
      public function initFriendSpouseInformations(param1:uint = 0, param2:Number = 0, param3:String = "", param4:uint = 0, param5:int = 0, param6:int = 0, param7:EntityLook = null, param8:GuildInformations = null, param9:int = 0) : FriendSpouseInformations
      {
         this.spouseAccountId = param1;
         this.spouseId = param2;
         this.spouseName = param3;
         this.spouseLevel = param4;
         this.breed = param5;
         this.sex = param6;
         this.spouseEntityLook = param7;
         this.guildInfo = param8;
         this.alignmentSide = param9;
         return this;
      }
      
      public function reset() : void
      {
         this.spouseAccountId = 0;
         this.spouseId = 0;
         this.spouseName = "";
         this.spouseLevel = 0;
         this.breed = 0;
         this.sex = 0;
         this.spouseEntityLook = new EntityLook();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FriendSpouseInformations(param1);
      }
      
      public function serializeAs_FriendSpouseInformations(param1:ICustomDataOutput) : void
      {
         if(this.spouseAccountId < 0)
         {
            throw new Error("Forbidden value (" + this.spouseAccountId + ") on element spouseAccountId.");
         }
         param1.writeInt(this.spouseAccountId);
         if(this.spouseId < 0 || this.spouseId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.spouseId + ") on element spouseId.");
         }
         param1.writeVarLong(this.spouseId);
         param1.writeUTF(this.spouseName);
         if(this.spouseLevel < 1 || this.spouseLevel > 206)
         {
            throw new Error("Forbidden value (" + this.spouseLevel + ") on element spouseLevel.");
         }
         param1.writeByte(this.spouseLevel);
         param1.writeByte(this.breed);
         param1.writeByte(this.sex);
         this.spouseEntityLook.serializeAs_EntityLook(param1);
         this.guildInfo.serializeAs_GuildInformations(param1);
         param1.writeByte(this.alignmentSide);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FriendSpouseInformations(param1);
      }
      
      public function deserializeAs_FriendSpouseInformations(param1:ICustomDataInput) : void
      {
         this._spouseAccountIdFunc(param1);
         this._spouseIdFunc(param1);
         this._spouseNameFunc(param1);
         this._spouseLevelFunc(param1);
         this._breedFunc(param1);
         this._sexFunc(param1);
         this.spouseEntityLook = new EntityLook();
         this.spouseEntityLook.deserialize(param1);
         this.guildInfo = new GuildInformations();
         this.guildInfo.deserialize(param1);
         this._alignmentSideFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FriendSpouseInformations(param1);
      }
      
      public function deserializeAsyncAs_FriendSpouseInformations(param1:FuncTree) : void
      {
         param1.addChild(this._spouseAccountIdFunc);
         param1.addChild(this._spouseIdFunc);
         param1.addChild(this._spouseNameFunc);
         param1.addChild(this._spouseLevelFunc);
         param1.addChild(this._breedFunc);
         param1.addChild(this._sexFunc);
         this._spouseEntityLooktree = param1.addChild(this._spouseEntityLooktreeFunc);
         this._guildInfotree = param1.addChild(this._guildInfotreeFunc);
         param1.addChild(this._alignmentSideFunc);
      }
      
      private function _spouseAccountIdFunc(param1:ICustomDataInput) : void
      {
         this.spouseAccountId = param1.readInt();
         if(this.spouseAccountId < 0)
         {
            throw new Error("Forbidden value (" + this.spouseAccountId + ") on element of FriendSpouseInformations.spouseAccountId.");
         }
      }
      
      private function _spouseIdFunc(param1:ICustomDataInput) : void
      {
         this.spouseId = param1.readVarUhLong();
         if(this.spouseId < 0 || this.spouseId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.spouseId + ") on element of FriendSpouseInformations.spouseId.");
         }
      }
      
      private function _spouseNameFunc(param1:ICustomDataInput) : void
      {
         this.spouseName = param1.readUTF();
      }
      
      private function _spouseLevelFunc(param1:ICustomDataInput) : void
      {
         this.spouseLevel = param1.readUnsignedByte();
         if(this.spouseLevel < 1 || this.spouseLevel > 206)
         {
            throw new Error("Forbidden value (" + this.spouseLevel + ") on element of FriendSpouseInformations.spouseLevel.");
         }
      }
      
      private function _breedFunc(param1:ICustomDataInput) : void
      {
         this.breed = param1.readByte();
      }
      
      private function _sexFunc(param1:ICustomDataInput) : void
      {
         this.sex = param1.readByte();
      }
      
      private function _spouseEntityLooktreeFunc(param1:ICustomDataInput) : void
      {
         this.spouseEntityLook = new EntityLook();
         this.spouseEntityLook.deserializeAsync(this._spouseEntityLooktree);
      }
      
      private function _guildInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.guildInfo = new GuildInformations();
         this.guildInfo.deserializeAsync(this._guildInfotree);
      }
      
      private function _alignmentSideFunc(param1:ICustomDataInput) : void
      {
         this.alignmentSide = param1.readByte();
      }
   }
}
