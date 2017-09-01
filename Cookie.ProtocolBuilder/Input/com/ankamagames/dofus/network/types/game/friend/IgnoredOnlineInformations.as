package com.ankamagames.dofus.network.types.game.friend
{
   import com.ankamagames.dofus.network.enums.PlayableBreedEnum;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class IgnoredOnlineInformations extends IgnoredInformations implements INetworkType
   {
      
      public static const protocolId:uint = 105;
       
      
      public var playerId:Number = 0;
      
      public var playerName:String = "";
      
      public var breed:int = 0;
      
      public var sex:Boolean = false;
      
      public function IgnoredOnlineInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 105;
      }
      
      public function initIgnoredOnlineInformations(param1:uint = 0, param2:String = "", param3:Number = 0, param4:String = "", param5:int = 0, param6:Boolean = false) : IgnoredOnlineInformations
      {
         super.initIgnoredInformations(param1,param2);
         this.playerId = param3;
         this.playerName = param4;
         this.breed = param5;
         this.sex = param6;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.playerId = 0;
         this.playerName = "";
         this.breed = 0;
         this.sex = false;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_IgnoredOnlineInformations(param1);
      }
      
      public function serializeAs_IgnoredOnlineInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_IgnoredInformations(param1);
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element playerId.");
         }
         param1.writeVarLong(this.playerId);
         param1.writeUTF(this.playerName);
         param1.writeByte(this.breed);
         param1.writeBoolean(this.sex);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IgnoredOnlineInformations(param1);
      }
      
      public function deserializeAs_IgnoredOnlineInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._playerIdFunc(param1);
         this._playerNameFunc(param1);
         this._breedFunc(param1);
         this._sexFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IgnoredOnlineInformations(param1);
      }
      
      public function deserializeAsyncAs_IgnoredOnlineInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._playerIdFunc);
         param1.addChild(this._playerNameFunc);
         param1.addChild(this._breedFunc);
         param1.addChild(this._sexFunc);
      }
      
      private function _playerIdFunc(param1:ICustomDataInput) : void
      {
         this.playerId = param1.readVarUhLong();
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element of IgnoredOnlineInformations.playerId.");
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
            throw new Error("Forbidden value (" + this.breed + ") on element of IgnoredOnlineInformations.breed.");
         }
      }
      
      private function _sexFunc(param1:ICustomDataInput) : void
      {
         this.sex = param1.readBoolean();
      }
   }
}
