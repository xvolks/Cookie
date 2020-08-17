package com.ankamagames.dofus.network.types.game.context.roleplay.party
{
   import com.ankamagames.dofus.network.enums.PlayableBreedEnum;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class DungeonPartyFinderPlayer implements INetworkType
   {
      
      public static const protocolId:uint = 373;
       
      
      public var playerId:Number = 0;
      
      public var playerName:String = "";
      
      public var breed:int = 0;
      
      public var sex:Boolean = false;
      
      public var level:uint = 0;
      
      public function DungeonPartyFinderPlayer()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 373;
      }
      
      public function initDungeonPartyFinderPlayer(param1:Number = 0, param2:String = "", param3:int = 0, param4:Boolean = false, param5:uint = 0) : DungeonPartyFinderPlayer
      {
         this.playerId = param1;
         this.playerName = param2;
         this.breed = param3;
         this.sex = param4;
         this.level = param5;
         return this;
      }
      
      public function reset() : void
      {
         this.playerId = 0;
         this.playerName = "";
         this.breed = 0;
         this.sex = false;
         this.level = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_DungeonPartyFinderPlayer(param1);
      }
      
      public function serializeAs_DungeonPartyFinderPlayer(param1:ICustomDataOutput) : void
      {
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element playerId.");
         }
         param1.writeVarLong(this.playerId);
         param1.writeUTF(this.playerName);
         param1.writeByte(this.breed);
         param1.writeBoolean(this.sex);
         if(this.level < 0 || this.level > 255)
         {
            throw new Error("Forbidden value (" + this.level + ") on element level.");
         }
         param1.writeByte(this.level);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DungeonPartyFinderPlayer(param1);
      }
      
      public function deserializeAs_DungeonPartyFinderPlayer(param1:ICustomDataInput) : void
      {
         this._playerIdFunc(param1);
         this._playerNameFunc(param1);
         this._breedFunc(param1);
         this._sexFunc(param1);
         this._levelFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DungeonPartyFinderPlayer(param1);
      }
      
      public function deserializeAsyncAs_DungeonPartyFinderPlayer(param1:FuncTree) : void
      {
         param1.addChild(this._playerIdFunc);
         param1.addChild(this._playerNameFunc);
         param1.addChild(this._breedFunc);
         param1.addChild(this._sexFunc);
         param1.addChild(this._levelFunc);
      }
      
      private function _playerIdFunc(param1:ICustomDataInput) : void
      {
         this.playerId = param1.readVarUhLong();
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element of DungeonPartyFinderPlayer.playerId.");
         }
      }
      
      private function _playerNameFunc(param1:ICustomDataInput) : void
      {
         this.playerName = param1.readUTF();
      }
      
      private function _breedFunc(param1:ICustomDataInput) : void
      {
         this.breed = param1.readByte();
         if(this.breed < PlayableBreedEnum.Feca || this.breed > PlayableBreedEnum.Ouginak)
         {
            throw new Error("Forbidden value (" + this.breed + ") on element of DungeonPartyFinderPlayer.breed.");
         }
      }
      
      private function _sexFunc(param1:ICustomDataInput) : void
      {
         this.sex = param1.readBoolean();
      }
      
      private function _levelFunc(param1:ICustomDataInput) : void
      {
         this.level = param1.readUnsignedByte();
         if(this.level < 0 || this.level > 255)
         {
            throw new Error("Forbidden value (" + this.level + ") on element of DungeonPartyFinderPlayer.level.");
         }
      }
   }
}
