package com.ankamagames.dofus.network.types.game.social
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.BasicNamedAllianceInformations;
   import com.ankamagames.dofus.network.types.game.context.roleplay.GuildInformations;
   import com.ankamagames.dofus.network.types.game.guild.GuildEmblem;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class AlliancedGuildFactSheetInformations extends GuildInformations implements INetworkType
   {
      
      public static const protocolId:uint = 422;
       
      
      public var allianceInfos:BasicNamedAllianceInformations;
      
      private var _allianceInfostree:FuncTree;
      
      public function AlliancedGuildFactSheetInformations()
      {
         this.allianceInfos = new BasicNamedAllianceInformations();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 422;
      }
      
      public function initAlliancedGuildFactSheetInformations(param1:uint = 0, param2:String = "", param3:uint = 0, param4:GuildEmblem = null, param5:BasicNamedAllianceInformations = null) : AlliancedGuildFactSheetInformations
      {
         super.initGuildInformations(param1,param2,param3,param4);
         this.allianceInfos = param5;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.allianceInfos = new BasicNamedAllianceInformations();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AlliancedGuildFactSheetInformations(param1);
      }
      
      public function serializeAs_AlliancedGuildFactSheetInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GuildInformations(param1);
         this.allianceInfos.serializeAs_BasicNamedAllianceInformations(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AlliancedGuildFactSheetInformations(param1);
      }
      
      public function deserializeAs_AlliancedGuildFactSheetInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.allianceInfos = new BasicNamedAllianceInformations();
         this.allianceInfos.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AlliancedGuildFactSheetInformations(param1);
      }
      
      public function deserializeAsyncAs_AlliancedGuildFactSheetInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._allianceInfostree = param1.addChild(this._allianceInfostreeFunc);
      }
      
      private function _allianceInfostreeFunc(param1:ICustomDataInput) : void
      {
         this.allianceInfos = new BasicNamedAllianceInformations();
         this.allianceInfos.deserializeAsync(this._allianceInfostree);
      }
   }
}
