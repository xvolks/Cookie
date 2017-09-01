package com.ankamagames.dofus.network.types.game.context.roleplay.party
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class NamedPartyTeamWithOutcome implements INetworkType
   {
      
      public static const protocolId:uint = 470;
       
      
      public var team:NamedPartyTeam;
      
      public var outcome:uint = 0;
      
      private var _teamtree:FuncTree;
      
      public function NamedPartyTeamWithOutcome()
      {
         this.team = new NamedPartyTeam();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 470;
      }
      
      public function initNamedPartyTeamWithOutcome(param1:NamedPartyTeam = null, param2:uint = 0) : NamedPartyTeamWithOutcome
      {
         this.team = param1;
         this.outcome = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.team = new NamedPartyTeam();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_NamedPartyTeamWithOutcome(param1);
      }
      
      public function serializeAs_NamedPartyTeamWithOutcome(param1:ICustomDataOutput) : void
      {
         this.team.serializeAs_NamedPartyTeam(param1);
         param1.writeVarShort(this.outcome);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_NamedPartyTeamWithOutcome(param1);
      }
      
      public function deserializeAs_NamedPartyTeamWithOutcome(param1:ICustomDataInput) : void
      {
         this.team = new NamedPartyTeam();
         this.team.deserialize(param1);
         this._outcomeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_NamedPartyTeamWithOutcome(param1);
      }
      
      public function deserializeAsyncAs_NamedPartyTeamWithOutcome(param1:FuncTree) : void
      {
         this._teamtree = param1.addChild(this._teamtreeFunc);
         param1.addChild(this._outcomeFunc);
      }
      
      private function _teamtreeFunc(param1:ICustomDataInput) : void
      {
         this.team = new NamedPartyTeam();
         this.team.deserializeAsync(this._teamtree);
      }
      
      private function _outcomeFunc(param1:ICustomDataInput) : void
      {
         this.outcome = param1.readVarUhShort();
         if(this.outcome < 0)
         {
            throw new Error("Forbidden value (" + this.outcome + ") on element of NamedPartyTeamWithOutcome.outcome.");
         }
      }
   }
}
