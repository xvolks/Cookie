package com.ankamagames.dofus.network.types.game.friend
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.enums.PlayableBreedEnum;
   import com.ankamagames.dofus.network.types.game.character.status.PlayerStatus;
   import com.ankamagames.dofus.network.types.game.context.roleplay.GuildInformations;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FriendOnlineInformations extends FriendInformations implements INetworkType
   {
      
      public static const protocolId:uint = 92;
       
      
      public var playerId:Number = 0;
      
      public var playerName:String = "";
      
      public var level:uint = 0;
      
      public var alignmentSide:int = 0;
      
      public var breed:int = 0;
      
      public var sex:Boolean = false;
      
      public var guildInfo:GuildInformations;
      
      public var moodSmileyId:uint = 0;
      
      public var status:PlayerStatus;
      
      public var havenBagShared:Boolean = false;
      
      private var _guildInfotree:FuncTree;
      
      private var _statustree:FuncTree;
      
      public function FriendOnlineInformations()
      {
         this.guildInfo = new GuildInformations();
         this.status = new PlayerStatus();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 92;
      }
      
      public function initFriendOnlineInformations(param1:uint = 0, param2:String = "", param3:uint = 99, param4:uint = 0, param5:int = 0, param6:Number = 0, param7:String = "", param8:uint = 0, param9:int = 0, param10:int = 0, param11:Boolean = false, param12:GuildInformations = null, param13:uint = 0, param14:PlayerStatus = null, param15:Boolean = false) : FriendOnlineInformations
      {
         super.initFriendInformations(param1,param2,param3,param4,param5);
         this.playerId = param6;
         this.playerName = param7;
         this.level = param8;
         this.alignmentSide = param9;
         this.breed = param10;
         this.sex = param11;
         this.guildInfo = param12;
         this.moodSmileyId = param13;
         this.status = param14;
         this.havenBagShared = param15;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.playerId = 0;
         this.playerName = "";
         this.level = 0;
         this.alignmentSide = 0;
         this.breed = 0;
         this.sex = false;
         this.guildInfo = new GuildInformations();
         this.status = new PlayerStatus();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FriendOnlineInformations(param1);
      }
      
      public function serializeAs_FriendOnlineInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_FriendInformations(param1);
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.sex);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.havenBagShared);
         param1.writeByte(_loc2_);
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element playerId.");
         }
         param1.writeVarLong(this.playerId);
         param1.writeUTF(this.playerName);
         if(this.level < 0 || this.level > 206)
         {
            throw new Error("Forbidden value (" + this.level + ") on element level.");
         }
         param1.writeByte(this.level);
         param1.writeByte(this.alignmentSide);
         param1.writeByte(this.breed);
         this.guildInfo.serializeAs_GuildInformations(param1);
         if(this.moodSmileyId < 0)
         {
            throw new Error("Forbidden value (" + this.moodSmileyId + ") on element moodSmileyId.");
         }
         param1.writeVarShort(this.moodSmileyId);
         param1.writeShort(this.status.getTypeId());
         this.status.serialize(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FriendOnlineInformations(param1);
      }
      
      public function deserializeAs_FriendOnlineInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.deserializeByteBoxes(param1);
         this._playerIdFunc(param1);
         this._playerNameFunc(param1);
         this._levelFunc(param1);
         this._alignmentSideFunc(param1);
         this._breedFunc(param1);
         this.guildInfo = new GuildInformations();
         this.guildInfo.deserialize(param1);
         this._moodSmileyIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         this.status = ProtocolTypeManager.getInstance(PlayerStatus,_loc2_);
         this.status.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FriendOnlineInformations(param1);
      }
      
      public function deserializeAsyncAs_FriendOnlineInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._playerIdFunc);
         param1.addChild(this._playerNameFunc);
         param1.addChild(this._levelFunc);
         param1.addChild(this._alignmentSideFunc);
         param1.addChild(this._breedFunc);
         this._guildInfotree = param1.addChild(this._guildInfotreeFunc);
         param1.addChild(this._moodSmileyIdFunc);
         this._statustree = param1.addChild(this._statustreeFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.sex = BooleanByteWrapper.getFlag(_loc2_,0);
         this.havenBagShared = BooleanByteWrapper.getFlag(_loc2_,1);
      }
      
      private function _playerIdFunc(param1:ICustomDataInput) : void
      {
         this.playerId = param1.readVarUhLong();
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element of FriendOnlineInformations.playerId.");
         }
      }
      
      private function _playerNameFunc(param1:ICustomDataInput) : void
      {
         this.playerName = param1.readUTF();
      }
      
      private function _levelFunc(param1:ICustomDataInput) : void
      {
         this.level = param1.readUnsignedByte();
         if(this.level < 0 || this.level > 206)
         {
            throw new Error("Forbidden value (" + this.level + ") on element of FriendOnlineInformations.level.");
         }
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
            throw new Error("Forbidden value (" + this.breed + ") on element of FriendOnlineInformations.breed.");
         }
      }
      
      private function _guildInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.guildInfo = new GuildInformations();
         this.guildInfo.deserializeAsync(this._guildInfotree);
      }
      
      private function _moodSmileyIdFunc(param1:ICustomDataInput) : void
      {
         this.moodSmileyId = param1.readVarUhShort();
         if(this.moodSmileyId < 0)
         {
            throw new Error("Forbidden value (" + this.moodSmileyId + ") on element of FriendOnlineInformations.moodSmileyId.");
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
