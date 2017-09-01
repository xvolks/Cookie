package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FightTeamMemberTaxCollectorInformations extends FightTeamMemberInformations implements INetworkType
   {
      
      public static const protocolId:uint = 177;
       
      
      public var firstNameId:uint = 0;
      
      public var lastNameId:uint = 0;
      
      public var level:uint = 0;
      
      public var guildId:uint = 0;
      
      public var uid:uint = 0;
      
      public function FightTeamMemberTaxCollectorInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 177;
      }
      
      public function initFightTeamMemberTaxCollectorInformations(param1:Number = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0, param5:uint = 0, param6:uint = 0) : FightTeamMemberTaxCollectorInformations
      {
         super.initFightTeamMemberInformations(param1);
         this.firstNameId = param2;
         this.lastNameId = param3;
         this.level = param4;
         this.guildId = param5;
         this.uid = param6;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.firstNameId = 0;
         this.lastNameId = 0;
         this.level = 0;
         this.guildId = 0;
         this.uid = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightTeamMemberTaxCollectorInformations(param1);
      }
      
      public function serializeAs_FightTeamMemberTaxCollectorInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_FightTeamMemberInformations(param1);
         if(this.firstNameId < 0)
         {
            throw new Error("Forbidden value (" + this.firstNameId + ") on element firstNameId.");
         }
         param1.writeVarShort(this.firstNameId);
         if(this.lastNameId < 0)
         {
            throw new Error("Forbidden value (" + this.lastNameId + ") on element lastNameId.");
         }
         param1.writeVarShort(this.lastNameId);
         if(this.level < 1 || this.level > 200)
         {
            throw new Error("Forbidden value (" + this.level + ") on element level.");
         }
         param1.writeByte(this.level);
         if(this.guildId < 0)
         {
            throw new Error("Forbidden value (" + this.guildId + ") on element guildId.");
         }
         param1.writeVarInt(this.guildId);
         if(this.uid < 0)
         {
            throw new Error("Forbidden value (" + this.uid + ") on element uid.");
         }
         param1.writeVarInt(this.uid);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightTeamMemberTaxCollectorInformations(param1);
      }
      
      public function deserializeAs_FightTeamMemberTaxCollectorInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._firstNameIdFunc(param1);
         this._lastNameIdFunc(param1);
         this._levelFunc(param1);
         this._guildIdFunc(param1);
         this._uidFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightTeamMemberTaxCollectorInformations(param1);
      }
      
      public function deserializeAsyncAs_FightTeamMemberTaxCollectorInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._firstNameIdFunc);
         param1.addChild(this._lastNameIdFunc);
         param1.addChild(this._levelFunc);
         param1.addChild(this._guildIdFunc);
         param1.addChild(this._uidFunc);
      }
      
      private function _firstNameIdFunc(param1:ICustomDataInput) : void
      {
         this.firstNameId = param1.readVarUhShort();
         if(this.firstNameId < 0)
         {
            throw new Error("Forbidden value (" + this.firstNameId + ") on element of FightTeamMemberTaxCollectorInformations.firstNameId.");
         }
      }
      
      private function _lastNameIdFunc(param1:ICustomDataInput) : void
      {
         this.lastNameId = param1.readVarUhShort();
         if(this.lastNameId < 0)
         {
            throw new Error("Forbidden value (" + this.lastNameId + ") on element of FightTeamMemberTaxCollectorInformations.lastNameId.");
         }
      }
      
      private function _levelFunc(param1:ICustomDataInput) : void
      {
         this.level = param1.readUnsignedByte();
         if(this.level < 1 || this.level > 200)
         {
            throw new Error("Forbidden value (" + this.level + ") on element of FightTeamMemberTaxCollectorInformations.level.");
         }
      }
      
      private function _guildIdFunc(param1:ICustomDataInput) : void
      {
         this.guildId = param1.readVarUhInt();
         if(this.guildId < 0)
         {
            throw new Error("Forbidden value (" + this.guildId + ") on element of FightTeamMemberTaxCollectorInformations.guildId.");
         }
      }
      
      private function _uidFunc(param1:ICustomDataInput) : void
      {
         this.uid = param1.readVarUhInt();
         if(this.uid < 0)
         {
            throw new Error("Forbidden value (" + this.uid + ") on element of FightTeamMemberTaxCollectorInformations.uid.");
         }
      }
   }
}
