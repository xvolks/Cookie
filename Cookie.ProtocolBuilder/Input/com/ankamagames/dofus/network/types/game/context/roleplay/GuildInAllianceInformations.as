package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.guild.GuildEmblem;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GuildInAllianceInformations extends GuildInformations implements INetworkType
   {
      
      public static const protocolId:uint = 420;
       
      
      public var nbMembers:uint = 0;
      
      public function GuildInAllianceInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 420;
      }
      
      public function initGuildInAllianceInformations(param1:uint = 0, param2:String = "", param3:uint = 0, param4:GuildEmblem = null, param5:uint = 0) : GuildInAllianceInformations
      {
         super.initGuildInformations(param1,param2,param3,param4);
         this.nbMembers = param5;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.nbMembers = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GuildInAllianceInformations(param1);
      }
      
      public function serializeAs_GuildInAllianceInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GuildInformations(param1);
         if(this.nbMembers < 1 || this.nbMembers > 240)
         {
            throw new Error("Forbidden value (" + this.nbMembers + ") on element nbMembers.");
         }
         param1.writeByte(this.nbMembers);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildInAllianceInformations(param1);
      }
      
      public function deserializeAs_GuildInAllianceInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._nbMembersFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildInAllianceInformations(param1);
      }
      
      public function deserializeAsyncAs_GuildInAllianceInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._nbMembersFunc);
      }
      
      private function _nbMembersFunc(param1:ICustomDataInput) : void
      {
         this.nbMembers = param1.readUnsignedByte();
         if(this.nbMembers < 1 || this.nbMembers > 240)
         {
            throw new Error("Forbidden value (" + this.nbMembers + ") on element of GuildInAllianceInformations.nbMembers.");
         }
      }
   }
}
