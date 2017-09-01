package com.ankamagames.dofus.network.types.game.social
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class GuildVersatileInformations implements INetworkType
   {
      
      public static const protocolId:uint = 435;
       
      
      public var guildId:uint = 0;
      
      public var leaderId:Number = 0;
      
      public var guildLevel:uint = 0;
      
      public var nbMembers:uint = 0;
      
      public function GuildVersatileInformations()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 435;
      }
      
      public function initGuildVersatileInformations(param1:uint = 0, param2:Number = 0, param3:uint = 0, param4:uint = 0) : GuildVersatileInformations
      {
         this.guildId = param1;
         this.leaderId = param2;
         this.guildLevel = param3;
         this.nbMembers = param4;
         return this;
      }
      
      public function reset() : void
      {
         this.guildId = 0;
         this.leaderId = 0;
         this.guildLevel = 0;
         this.nbMembers = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GuildVersatileInformations(param1);
      }
      
      public function serializeAs_GuildVersatileInformations(param1:ICustomDataOutput) : void
      {
         if(this.guildId < 0)
         {
            throw new Error("Forbidden value (" + this.guildId + ") on element guildId.");
         }
         param1.writeVarInt(this.guildId);
         if(this.leaderId < 0 || this.leaderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.leaderId + ") on element leaderId.");
         }
         param1.writeVarLong(this.leaderId);
         if(this.guildLevel < 1 || this.guildLevel > 200)
         {
            throw new Error("Forbidden value (" + this.guildLevel + ") on element guildLevel.");
         }
         param1.writeByte(this.guildLevel);
         if(this.nbMembers < 1 || this.nbMembers > 240)
         {
            throw new Error("Forbidden value (" + this.nbMembers + ") on element nbMembers.");
         }
         param1.writeByte(this.nbMembers);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildVersatileInformations(param1);
      }
      
      public function deserializeAs_GuildVersatileInformations(param1:ICustomDataInput) : void
      {
         this._guildIdFunc(param1);
         this._leaderIdFunc(param1);
         this._guildLevelFunc(param1);
         this._nbMembersFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildVersatileInformations(param1);
      }
      
      public function deserializeAsyncAs_GuildVersatileInformations(param1:FuncTree) : void
      {
         param1.addChild(this._guildIdFunc);
         param1.addChild(this._leaderIdFunc);
         param1.addChild(this._guildLevelFunc);
         param1.addChild(this._nbMembersFunc);
      }
      
      private function _guildIdFunc(param1:ICustomDataInput) : void
      {
         this.guildId = param1.readVarUhInt();
         if(this.guildId < 0)
         {
            throw new Error("Forbidden value (" + this.guildId + ") on element of GuildVersatileInformations.guildId.");
         }
      }
      
      private function _leaderIdFunc(param1:ICustomDataInput) : void
      {
         this.leaderId = param1.readVarUhLong();
         if(this.leaderId < 0 || this.leaderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.leaderId + ") on element of GuildVersatileInformations.leaderId.");
         }
      }
      
      private function _guildLevelFunc(param1:ICustomDataInput) : void
      {
         this.guildLevel = param1.readUnsignedByte();
         if(this.guildLevel < 1 || this.guildLevel > 200)
         {
            throw new Error("Forbidden value (" + this.guildLevel + ") on element of GuildVersatileInformations.guildLevel.");
         }
      }
      
      private function _nbMembersFunc(param1:ICustomDataInput) : void
      {
         this.nbMembers = param1.readUnsignedByte();
         if(this.nbMembers < 1 || this.nbMembers > 240)
         {
            throw new Error("Forbidden value (" + this.nbMembers + ") on element of GuildVersatileInformations.nbMembers.");
         }
      }
   }
}
