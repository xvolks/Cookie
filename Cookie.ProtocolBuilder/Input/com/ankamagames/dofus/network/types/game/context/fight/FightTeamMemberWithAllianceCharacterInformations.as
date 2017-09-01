package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.BasicAllianceInformations;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FightTeamMemberWithAllianceCharacterInformations extends FightTeamMemberCharacterInformations implements INetworkType
   {
      
      public static const protocolId:uint = 426;
       
      
      public var allianceInfos:BasicAllianceInformations;
      
      private var _allianceInfostree:FuncTree;
      
      public function FightTeamMemberWithAllianceCharacterInformations()
      {
         this.allianceInfos = new BasicAllianceInformations();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 426;
      }
      
      public function initFightTeamMemberWithAllianceCharacterInformations(param1:Number = 0, param2:String = "", param3:uint = 0, param4:BasicAllianceInformations = null) : FightTeamMemberWithAllianceCharacterInformations
      {
         super.initFightTeamMemberCharacterInformations(param1,param2,param3);
         this.allianceInfos = param4;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.allianceInfos = new BasicAllianceInformations();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightTeamMemberWithAllianceCharacterInformations(param1);
      }
      
      public function serializeAs_FightTeamMemberWithAllianceCharacterInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_FightTeamMemberCharacterInformations(param1);
         this.allianceInfos.serializeAs_BasicAllianceInformations(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightTeamMemberWithAllianceCharacterInformations(param1);
      }
      
      public function deserializeAs_FightTeamMemberWithAllianceCharacterInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.allianceInfos = new BasicAllianceInformations();
         this.allianceInfos.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightTeamMemberWithAllianceCharacterInformations(param1);
      }
      
      public function deserializeAsyncAs_FightTeamMemberWithAllianceCharacterInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._allianceInfostree = param1.addChild(this._allianceInfostreeFunc);
      }
      
      private function _allianceInfostreeFunc(param1:ICustomDataInput) : void
      {
         this.allianceInfos = new BasicAllianceInformations();
         this.allianceInfos.deserializeAsync(this._allianceInfostree);
      }
   }
}
