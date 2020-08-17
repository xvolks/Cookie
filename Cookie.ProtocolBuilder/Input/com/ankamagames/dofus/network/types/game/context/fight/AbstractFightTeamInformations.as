package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class AbstractFightTeamInformations implements INetworkType
   {
      
      public static const protocolId:uint = 116;
       
      
      public var teamId:uint = 2;
      
      public var leaderId:Number = 0;
      
      public var teamSide:int = 0;
      
      public var teamTypeId:uint = 0;
      
      public var nbWaves:uint = 0;
      
      public function AbstractFightTeamInformations()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 116;
      }
      
      public function initAbstractFightTeamInformations(param1:uint = 2, param2:Number = 0, param3:int = 0, param4:uint = 0, param5:uint = 0) : AbstractFightTeamInformations
      {
         this.teamId = param1;
         this.leaderId = param2;
         this.teamSide = param3;
         this.teamTypeId = param4;
         this.nbWaves = param5;
         return this;
      }
      
      public function reset() : void
      {
         this.teamId = 2;
         this.leaderId = 0;
         this.teamSide = 0;
         this.teamTypeId = 0;
         this.nbWaves = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AbstractFightTeamInformations(param1);
      }
      
      public function serializeAs_AbstractFightTeamInformations(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.teamId);
         if(this.leaderId < -9007199254740990 || this.leaderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.leaderId + ") on element leaderId.");
         }
         param1.writeDouble(this.leaderId);
         param1.writeByte(this.teamSide);
         param1.writeByte(this.teamTypeId);
         if(this.nbWaves < 0)
         {
            throw new Error("Forbidden value (" + this.nbWaves + ") on element nbWaves.");
         }
         param1.writeByte(this.nbWaves);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AbstractFightTeamInformations(param1);
      }
      
      public function deserializeAs_AbstractFightTeamInformations(param1:ICustomDataInput) : void
      {
         this._teamIdFunc(param1);
         this._leaderIdFunc(param1);
         this._teamSideFunc(param1);
         this._teamTypeIdFunc(param1);
         this._nbWavesFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AbstractFightTeamInformations(param1);
      }
      
      public function deserializeAsyncAs_AbstractFightTeamInformations(param1:FuncTree) : void
      {
         param1.addChild(this._teamIdFunc);
         param1.addChild(this._leaderIdFunc);
         param1.addChild(this._teamSideFunc);
         param1.addChild(this._teamTypeIdFunc);
         param1.addChild(this._nbWavesFunc);
      }
      
      private function _teamIdFunc(param1:ICustomDataInput) : void
      {
         this.teamId = param1.readByte();
         if(this.teamId < 0)
         {
            throw new Error("Forbidden value (" + this.teamId + ") on element of AbstractFightTeamInformations.teamId.");
         }
      }
      
      private function _leaderIdFunc(param1:ICustomDataInput) : void
      {
         this.leaderId = param1.readDouble();
         if(this.leaderId < -9007199254740990 || this.leaderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.leaderId + ") on element of AbstractFightTeamInformations.leaderId.");
         }
      }
      
      private function _teamSideFunc(param1:ICustomDataInput) : void
      {
         this.teamSide = param1.readByte();
      }
      
      private function _teamTypeIdFunc(param1:ICustomDataInput) : void
      {
         this.teamTypeId = param1.readByte();
         if(this.teamTypeId < 0)
         {
            throw new Error("Forbidden value (" + this.teamTypeId + ") on element of AbstractFightTeamInformations.teamTypeId.");
         }
      }
      
      private function _nbWavesFunc(param1:ICustomDataInput) : void
      {
         this.nbWaves = param1.readByte();
         if(this.nbWaves < 0)
         {
            throw new Error("Forbidden value (" + this.nbWaves + ") on element of AbstractFightTeamInformations.nbWaves.");
         }
      }
   }
}
