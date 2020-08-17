package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FightExternalInformations implements INetworkType
   {
      
      public static const protocolId:uint = 117;
       
      
      public var fightId:int = 0;
      
      public var fightType:uint = 0;
      
      public var fightStart:uint = 0;
      
      public var fightSpectatorLocked:Boolean = false;
      
      public var fightTeams:Vector.<FightTeamLightInformations>;
      
      public var fightTeamsOptions:Vector.<FightOptionsInformations>;
      
      private var _fightTeamstree:FuncTree;
      
      private var _fightTeamsindex:uint = 0;
      
      private var _fightTeamsOptionstree:FuncTree;
      
      private var _fightTeamsOptionsindex:uint = 0;
      
      public function FightExternalInformations()
      {
         this.fightTeams = new Vector.<FightTeamLightInformations>(2,true);
         this.fightTeamsOptions = new Vector.<FightOptionsInformations>(2,true);
         super();
      }
      
      public function getTypeId() : uint
      {
         return 117;
      }
      
      public function initFightExternalInformations(param1:int = 0, param2:uint = 0, param3:uint = 0, param4:Boolean = false, param5:Vector.<FightTeamLightInformations> = null, param6:Vector.<FightOptionsInformations> = null) : FightExternalInformations
      {
         this.fightId = param1;
         this.fightType = param2;
         this.fightStart = param3;
         this.fightSpectatorLocked = param4;
         this.fightTeams = param5;
         this.fightTeamsOptions = param6;
         return this;
      }
      
      public function reset() : void
      {
         this.fightId = 0;
         this.fightType = 0;
         this.fightStart = 0;
         this.fightSpectatorLocked = false;
         this.fightTeams = new Vector.<FightTeamLightInformations>(2,true);
         this.fightTeamsOptions = new Vector.<FightOptionsInformations>(2,true);
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightExternalInformations(param1);
      }
      
      public function serializeAs_FightExternalInformations(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.fightId);
         param1.writeByte(this.fightType);
         if(this.fightStart < 0)
         {
            throw new Error("Forbidden value (" + this.fightStart + ") on element fightStart.");
         }
         param1.writeInt(this.fightStart);
         param1.writeBoolean(this.fightSpectatorLocked);
         var _loc2_:uint = 0;
         while(_loc2_ < 2)
         {
            this.fightTeams[_loc2_].serializeAs_FightTeamLightInformations(param1);
            _loc2_++;
         }
         var _loc3_:uint = 0;
         while(_loc3_ < 2)
         {
            this.fightTeamsOptions[_loc3_].serializeAs_FightOptionsInformations(param1);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightExternalInformations(param1);
      }
      
      public function deserializeAs_FightExternalInformations(param1:ICustomDataInput) : void
      {
         this._fightIdFunc(param1);
         this._fightTypeFunc(param1);
         this._fightStartFunc(param1);
         this._fightSpectatorLockedFunc(param1);
         var _loc2_:uint = 0;
         while(_loc2_ < 2)
         {
            this.fightTeams[_loc2_] = new FightTeamLightInformations();
            this.fightTeams[_loc2_].deserialize(param1);
            _loc2_++;
         }
         var _loc3_:uint = 0;
         while(_loc3_ < 2)
         {
            this.fightTeamsOptions[_loc3_] = new FightOptionsInformations();
            this.fightTeamsOptions[_loc3_].deserialize(param1);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightExternalInformations(param1);
      }
      
      public function deserializeAsyncAs_FightExternalInformations(param1:FuncTree) : void
      {
         param1.addChild(this._fightIdFunc);
         param1.addChild(this._fightTypeFunc);
         param1.addChild(this._fightStartFunc);
         param1.addChild(this._fightSpectatorLockedFunc);
         this._fightTeamstree = param1.addChild(this._fightTeamstreeFunc);
         this._fightTeamsOptionstree = param1.addChild(this._fightTeamsOptionstreeFunc);
      }
      
      private function _fightIdFunc(param1:ICustomDataInput) : void
      {
         this.fightId = param1.readInt();
      }
      
      private function _fightTypeFunc(param1:ICustomDataInput) : void
      {
         this.fightType = param1.readByte();
         if(this.fightType < 0)
         {
            throw new Error("Forbidden value (" + this.fightType + ") on element of FightExternalInformations.fightType.");
         }
      }
      
      private function _fightStartFunc(param1:ICustomDataInput) : void
      {
         this.fightStart = param1.readInt();
         if(this.fightStart < 0)
         {
            throw new Error("Forbidden value (" + this.fightStart + ") on element of FightExternalInformations.fightStart.");
         }
      }
      
      private function _fightSpectatorLockedFunc(param1:ICustomDataInput) : void
      {
         this.fightSpectatorLocked = param1.readBoolean();
      }
      
      private function _fightTeamstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = 0;
         while(_loc2_ < 2)
         {
            this._fightTeamstree.addChild(this._fightTeamsFunc);
            _loc2_++;
         }
      }
      
      private function _fightTeamsFunc(param1:ICustomDataInput) : void
      {
         this.fightTeams[this._fightTeamsindex] = new FightTeamLightInformations();
         this.fightTeams[this._fightTeamsindex].deserializeAsync(this._fightTeamstree.children[this._fightTeamsindex]);
         this._fightTeamsindex++;
      }
      
      private function _fightTeamsOptionstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = 0;
         while(_loc2_ < 2)
         {
            this._fightTeamsOptionstree.addChild(this._fightTeamsOptionsFunc);
            _loc2_++;
         }
      }
      
      private function _fightTeamsOptionsFunc(param1:ICustomDataInput) : void
      {
         this.fightTeamsOptions[this._fightTeamsOptionsindex] = new FightOptionsInformations();
         this.fightTeamsOptions[this._fightTeamsOptionsindex].deserializeAsync(this._fightTeamsOptionstree.children[this._fightTeamsOptionsindex]);
         this._fightTeamsOptionsindex++;
      }
   }
}
