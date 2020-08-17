package com.ankamagames.dofus.network.types.game.context.roleplay.party.companion
{
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class PartyCompanionMemberInformations extends PartyCompanionBaseInformations implements INetworkType
   {
      
      public static const protocolId:uint = 452;
       
      
      public var initiative:uint = 0;
      
      public var lifePoints:uint = 0;
      
      public var maxLifePoints:uint = 0;
      
      public var prospecting:uint = 0;
      
      public var regenRate:uint = 0;
      
      public function PartyCompanionMemberInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 452;
      }
      
      public function initPartyCompanionMemberInformations(param1:uint = 0, param2:uint = 0, param3:EntityLook = null, param4:uint = 0, param5:uint = 0, param6:uint = 0, param7:uint = 0, param8:uint = 0) : PartyCompanionMemberInformations
      {
         super.initPartyCompanionBaseInformations(param1,param2,param3);
         this.initiative = param4;
         this.lifePoints = param5;
         this.maxLifePoints = param6;
         this.prospecting = param7;
         this.regenRate = param8;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.initiative = 0;
         this.lifePoints = 0;
         this.maxLifePoints = 0;
         this.prospecting = 0;
         this.regenRate = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PartyCompanionMemberInformations(param1);
      }
      
      public function serializeAs_PartyCompanionMemberInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_PartyCompanionBaseInformations(param1);
         if(this.initiative < 0)
         {
            throw new Error("Forbidden value (" + this.initiative + ") on element initiative.");
         }
         param1.writeVarShort(this.initiative);
         if(this.lifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.lifePoints + ") on element lifePoints.");
         }
         param1.writeVarInt(this.lifePoints);
         if(this.maxLifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.maxLifePoints + ") on element maxLifePoints.");
         }
         param1.writeVarInt(this.maxLifePoints);
         if(this.prospecting < 0)
         {
            throw new Error("Forbidden value (" + this.prospecting + ") on element prospecting.");
         }
         param1.writeVarShort(this.prospecting);
         if(this.regenRate < 0 || this.regenRate > 255)
         {
            throw new Error("Forbidden value (" + this.regenRate + ") on element regenRate.");
         }
         param1.writeByte(this.regenRate);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyCompanionMemberInformations(param1);
      }
      
      public function deserializeAs_PartyCompanionMemberInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._initiativeFunc(param1);
         this._lifePointsFunc(param1);
         this._maxLifePointsFunc(param1);
         this._prospectingFunc(param1);
         this._regenRateFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyCompanionMemberInformations(param1);
      }
      
      public function deserializeAsyncAs_PartyCompanionMemberInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._initiativeFunc);
         param1.addChild(this._lifePointsFunc);
         param1.addChild(this._maxLifePointsFunc);
         param1.addChild(this._prospectingFunc);
         param1.addChild(this._regenRateFunc);
      }
      
      private function _initiativeFunc(param1:ICustomDataInput) : void
      {
         this.initiative = param1.readVarUhShort();
         if(this.initiative < 0)
         {
            throw new Error("Forbidden value (" + this.initiative + ") on element of PartyCompanionMemberInformations.initiative.");
         }
      }
      
      private function _lifePointsFunc(param1:ICustomDataInput) : void
      {
         this.lifePoints = param1.readVarUhInt();
         if(this.lifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.lifePoints + ") on element of PartyCompanionMemberInformations.lifePoints.");
         }
      }
      
      private function _maxLifePointsFunc(param1:ICustomDataInput) : void
      {
         this.maxLifePoints = param1.readVarUhInt();
         if(this.maxLifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.maxLifePoints + ") on element of PartyCompanionMemberInformations.maxLifePoints.");
         }
      }
      
      private function _prospectingFunc(param1:ICustomDataInput) : void
      {
         this.prospecting = param1.readVarUhShort();
         if(this.prospecting < 0)
         {
            throw new Error("Forbidden value (" + this.prospecting + ") on element of PartyCompanionMemberInformations.prospecting.");
         }
      }
      
      private function _regenRateFunc(param1:ICustomDataInput) : void
      {
         this.regenRate = param1.readUnsignedByte();
         if(this.regenRate < 0 || this.regenRate > 255)
         {
            throw new Error("Forbidden value (" + this.regenRate + ") on element of PartyCompanionMemberInformations.regenRate.");
         }
      }
   }
}
