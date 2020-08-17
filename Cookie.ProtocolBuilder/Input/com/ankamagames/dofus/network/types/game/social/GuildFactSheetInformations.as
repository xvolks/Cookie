package com.ankamagames.dofus.network.types.game.social
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.GuildInformations;
   import com.ankamagames.dofus.network.types.game.guild.GuildEmblem;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class GuildFactSheetInformations extends GuildInformations implements INetworkType
   {
      
      public static const protocolId:uint = 424;
       
      
      public var leaderId:Number = 0;
      
      public var nbMembers:uint = 0;
      
      public function GuildFactSheetInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 424;
      }
      
      public function initGuildFactSheetInformations(param1:uint = 0, param2:String = "", param3:uint = 0, param4:GuildEmblem = null, param5:Number = 0, param6:uint = 0) : GuildFactSheetInformations
      {
         super.initGuildInformations(param1,param2,param3,param4);
         this.leaderId = param5;
         this.nbMembers = param6;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.leaderId = 0;
         this.nbMembers = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GuildFactSheetInformations(param1);
      }
      
      public function serializeAs_GuildFactSheetInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GuildInformations(param1);
         if(this.leaderId < 0 || this.leaderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.leaderId + ") on element leaderId.");
         }
         param1.writeVarLong(this.leaderId);
         if(this.nbMembers < 0)
         {
            throw new Error("Forbidden value (" + this.nbMembers + ") on element nbMembers.");
         }
         param1.writeVarShort(this.nbMembers);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildFactSheetInformations(param1);
      }
      
      public function deserializeAs_GuildFactSheetInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._leaderIdFunc(param1);
         this._nbMembersFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildFactSheetInformations(param1);
      }
      
      public function deserializeAsyncAs_GuildFactSheetInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._leaderIdFunc);
         param1.addChild(this._nbMembersFunc);
      }
      
      private function _leaderIdFunc(param1:ICustomDataInput) : void
      {
         this.leaderId = param1.readVarUhLong();
         if(this.leaderId < 0 || this.leaderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.leaderId + ") on element of GuildFactSheetInformations.leaderId.");
         }
      }
      
      private function _nbMembersFunc(param1:ICustomDataInput) : void
      {
         this.nbMembers = param1.readVarUhShort();
         if(this.nbMembers < 0)
         {
            throw new Error("Forbidden value (" + this.nbMembers + ") on element of GuildFactSheetInformations.nbMembers.");
         }
      }
   }
}
