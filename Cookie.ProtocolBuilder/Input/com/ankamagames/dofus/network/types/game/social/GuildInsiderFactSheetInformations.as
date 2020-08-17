package com.ankamagames.dofus.network.types.game.social
{
   import com.ankamagames.dofus.network.types.game.guild.GuildEmblem;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class GuildInsiderFactSheetInformations extends GuildFactSheetInformations implements INetworkType
   {
      
      public static const protocolId:uint = 423;
       
      
      public var leaderName:String = "";
      
      public var nbConnectedMembers:uint = 0;
      
      public var nbTaxCollectors:uint = 0;
      
      public var lastActivity:uint = 0;
      
      public function GuildInsiderFactSheetInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 423;
      }
      
      public function initGuildInsiderFactSheetInformations(param1:uint = 0, param2:String = "", param3:uint = 0, param4:GuildEmblem = null, param5:Number = 0, param6:uint = 0, param7:String = "", param8:uint = 0, param9:uint = 0, param10:uint = 0) : GuildInsiderFactSheetInformations
      {
         super.initGuildFactSheetInformations(param1,param2,param3,param4,param5,param6);
         this.leaderName = param7;
         this.nbConnectedMembers = param8;
         this.nbTaxCollectors = param9;
         this.lastActivity = param10;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.leaderName = "";
         this.nbConnectedMembers = 0;
         this.nbTaxCollectors = 0;
         this.lastActivity = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GuildInsiderFactSheetInformations(param1);
      }
      
      public function serializeAs_GuildInsiderFactSheetInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GuildFactSheetInformations(param1);
         param1.writeUTF(this.leaderName);
         if(this.nbConnectedMembers < 0)
         {
            throw new Error("Forbidden value (" + this.nbConnectedMembers + ") on element nbConnectedMembers.");
         }
         param1.writeVarShort(this.nbConnectedMembers);
         if(this.nbTaxCollectors < 0)
         {
            throw new Error("Forbidden value (" + this.nbTaxCollectors + ") on element nbTaxCollectors.");
         }
         param1.writeByte(this.nbTaxCollectors);
         if(this.lastActivity < 0)
         {
            throw new Error("Forbidden value (" + this.lastActivity + ") on element lastActivity.");
         }
         param1.writeInt(this.lastActivity);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildInsiderFactSheetInformations(param1);
      }
      
      public function deserializeAs_GuildInsiderFactSheetInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._leaderNameFunc(param1);
         this._nbConnectedMembersFunc(param1);
         this._nbTaxCollectorsFunc(param1);
         this._lastActivityFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildInsiderFactSheetInformations(param1);
      }
      
      public function deserializeAsyncAs_GuildInsiderFactSheetInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._leaderNameFunc);
         param1.addChild(this._nbConnectedMembersFunc);
         param1.addChild(this._nbTaxCollectorsFunc);
         param1.addChild(this._lastActivityFunc);
      }
      
      private function _leaderNameFunc(param1:ICustomDataInput) : void
      {
         this.leaderName = param1.readUTF();
      }
      
      private function _nbConnectedMembersFunc(param1:ICustomDataInput) : void
      {
         this.nbConnectedMembers = param1.readVarUhShort();
         if(this.nbConnectedMembers < 0)
         {
            throw new Error("Forbidden value (" + this.nbConnectedMembers + ") on element of GuildInsiderFactSheetInformations.nbConnectedMembers.");
         }
      }
      
      private function _nbTaxCollectorsFunc(param1:ICustomDataInput) : void
      {
         this.nbTaxCollectors = param1.readByte();
         if(this.nbTaxCollectors < 0)
         {
            throw new Error("Forbidden value (" + this.nbTaxCollectors + ") on element of GuildInsiderFactSheetInformations.nbTaxCollectors.");
         }
      }
      
      private function _lastActivityFunc(param1:ICustomDataInput) : void
      {
         this.lastActivity = param1.readInt();
         if(this.lastActivity < 0)
         {
            throw new Error("Forbidden value (" + this.lastActivity + ") on element of GuildInsiderFactSheetInformations.lastActivity.");
         }
      }
   }
}
