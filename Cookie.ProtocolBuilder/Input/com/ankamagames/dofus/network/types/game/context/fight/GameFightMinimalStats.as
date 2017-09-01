package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameFightMinimalStats implements INetworkType
   {
      
      public static const protocolId:uint = 31;
       
      
      public var lifePoints:uint = 0;
      
      public var maxLifePoints:uint = 0;
      
      public var baseMaxLifePoints:uint = 0;
      
      public var permanentDamagePercent:uint = 0;
      
      public var shieldPoints:uint = 0;
      
      public var actionPoints:int = 0;
      
      public var maxActionPoints:int = 0;
      
      public var movementPoints:int = 0;
      
      public var maxMovementPoints:int = 0;
      
      public var summoner:Number = 0;
      
      public var summoned:Boolean = false;
      
      public var neutralElementResistPercent:int = 0;
      
      public var earthElementResistPercent:int = 0;
      
      public var waterElementResistPercent:int = 0;
      
      public var airElementResistPercent:int = 0;
      
      public var fireElementResistPercent:int = 0;
      
      public var neutralElementReduction:int = 0;
      
      public var earthElementReduction:int = 0;
      
      public var waterElementReduction:int = 0;
      
      public var airElementReduction:int = 0;
      
      public var fireElementReduction:int = 0;
      
      public var criticalDamageFixedResist:int = 0;
      
      public var pushDamageFixedResist:int = 0;
      
      public var pvpNeutralElementResistPercent:int = 0;
      
      public var pvpEarthElementResistPercent:int = 0;
      
      public var pvpWaterElementResistPercent:int = 0;
      
      public var pvpAirElementResistPercent:int = 0;
      
      public var pvpFireElementResistPercent:int = 0;
      
      public var pvpNeutralElementReduction:int = 0;
      
      public var pvpEarthElementReduction:int = 0;
      
      public var pvpWaterElementReduction:int = 0;
      
      public var pvpAirElementReduction:int = 0;
      
      public var pvpFireElementReduction:int = 0;
      
      public var dodgePALostProbability:uint = 0;
      
      public var dodgePMLostProbability:uint = 0;
      
      public var tackleBlock:int = 0;
      
      public var tackleEvade:int = 0;
      
      public var fixedDamageReflection:int = 0;
      
      public var invisibilityState:uint = 0;
      
      public var meleeDamageReceivedPercent:uint = 0;
      
      public var rangedDamageReceivedPercent:uint = 0;
      
      public var weaponDamageReceivedPercent:uint = 0;
      
      public var spellDamageReceivedPercent:uint = 0;
      
      public function GameFightMinimalStats()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 31;
      }
      
      public function initGameFightMinimalStats(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0, param5:uint = 0, param6:int = 0, param7:int = 0, param8:int = 0, param9:int = 0, param10:Number = 0, param11:Boolean = false, param12:int = 0, param13:int = 0, param14:int = 0, param15:int = 0, param16:int = 0, param17:int = 0, param18:int = 0, param19:int = 0, param20:int = 0, param21:int = 0, param22:int = 0, param23:int = 0, param24:int = 0, param25:int = 0, param26:int = 0, param27:int = 0, param28:int = 0, param29:int = 0, param30:int = 0, param31:int = 0, param32:int = 0, param33:int = 0, param34:uint = 0, param35:uint = 0, param36:int = 0, param37:int = 0, param38:int = 0, param39:uint = 0, param40:uint = 0, param41:uint = 0, param42:uint = 0, param43:uint = 0) : GameFightMinimalStats
      {
         this.lifePoints = param1;
         this.maxLifePoints = param2;
         this.baseMaxLifePoints = param3;
         this.permanentDamagePercent = param4;
         this.shieldPoints = param5;
         this.actionPoints = param6;
         this.maxActionPoints = param7;
         this.movementPoints = param8;
         this.maxMovementPoints = param9;
         this.summoner = param10;
         this.summoned = param11;
         this.neutralElementResistPercent = param12;
         this.earthElementResistPercent = param13;
         this.waterElementResistPercent = param14;
         this.airElementResistPercent = param15;
         this.fireElementResistPercent = param16;
         this.neutralElementReduction = param17;
         this.earthElementReduction = param18;
         this.waterElementReduction = param19;
         this.airElementReduction = param20;
         this.fireElementReduction = param21;
         this.criticalDamageFixedResist = param22;
         this.pushDamageFixedResist = param23;
         this.pvpNeutralElementResistPercent = param24;
         this.pvpEarthElementResistPercent = param25;
         this.pvpWaterElementResistPercent = param26;
         this.pvpAirElementResistPercent = param27;
         this.pvpFireElementResistPercent = param28;
         this.pvpNeutralElementReduction = param29;
         this.pvpEarthElementReduction = param30;
         this.pvpWaterElementReduction = param31;
         this.pvpAirElementReduction = param32;
         this.pvpFireElementReduction = param33;
         this.dodgePALostProbability = param34;
         this.dodgePMLostProbability = param35;
         this.tackleBlock = param36;
         this.tackleEvade = param37;
         this.fixedDamageReflection = param38;
         this.invisibilityState = param39;
         this.meleeDamageReceivedPercent = param40;
         this.rangedDamageReceivedPercent = param41;
         this.weaponDamageReceivedPercent = param42;
         this.spellDamageReceivedPercent = param43;
         return this;
      }
      
      public function reset() : void
      {
         this.lifePoints = 0;
         this.maxLifePoints = 0;
         this.baseMaxLifePoints = 0;
         this.permanentDamagePercent = 0;
         this.shieldPoints = 0;
         this.actionPoints = 0;
         this.maxActionPoints = 0;
         this.movementPoints = 0;
         this.maxMovementPoints = 0;
         this.summoner = 0;
         this.summoned = false;
         this.neutralElementResistPercent = 0;
         this.earthElementResistPercent = 0;
         this.waterElementResistPercent = 0;
         this.airElementResistPercent = 0;
         this.fireElementResistPercent = 0;
         this.neutralElementReduction = 0;
         this.earthElementReduction = 0;
         this.waterElementReduction = 0;
         this.airElementReduction = 0;
         this.fireElementReduction = 0;
         this.criticalDamageFixedResist = 0;
         this.pushDamageFixedResist = 0;
         this.pvpNeutralElementResistPercent = 0;
         this.pvpEarthElementResistPercent = 0;
         this.pvpWaterElementResistPercent = 0;
         this.pvpAirElementResistPercent = 0;
         this.pvpFireElementResistPercent = 0;
         this.pvpNeutralElementReduction = 0;
         this.pvpEarthElementReduction = 0;
         this.pvpWaterElementReduction = 0;
         this.pvpAirElementReduction = 0;
         this.pvpFireElementReduction = 0;
         this.dodgePALostProbability = 0;
         this.dodgePMLostProbability = 0;
         this.tackleBlock = 0;
         this.tackleEvade = 0;
         this.fixedDamageReflection = 0;
         this.invisibilityState = 0;
         this.meleeDamageReceivedPercent = 0;
         this.rangedDamageReceivedPercent = 0;
         this.weaponDamageReceivedPercent = 0;
         this.spellDamageReceivedPercent = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameFightMinimalStats(param1);
      }
      
      public function serializeAs_GameFightMinimalStats(param1:ICustomDataOutput) : void
      {
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
         if(this.baseMaxLifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.baseMaxLifePoints + ") on element baseMaxLifePoints.");
         }
         param1.writeVarInt(this.baseMaxLifePoints);
         if(this.permanentDamagePercent < 0)
         {
            throw new Error("Forbidden value (" + this.permanentDamagePercent + ") on element permanentDamagePercent.");
         }
         param1.writeVarInt(this.permanentDamagePercent);
         if(this.shieldPoints < 0)
         {
            throw new Error("Forbidden value (" + this.shieldPoints + ") on element shieldPoints.");
         }
         param1.writeVarInt(this.shieldPoints);
         param1.writeVarShort(this.actionPoints);
         param1.writeVarShort(this.maxActionPoints);
         param1.writeVarShort(this.movementPoints);
         param1.writeVarShort(this.maxMovementPoints);
         if(this.summoner < -9007199254740990 || this.summoner > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.summoner + ") on element summoner.");
         }
         param1.writeDouble(this.summoner);
         param1.writeBoolean(this.summoned);
         param1.writeVarShort(this.neutralElementResistPercent);
         param1.writeVarShort(this.earthElementResistPercent);
         param1.writeVarShort(this.waterElementResistPercent);
         param1.writeVarShort(this.airElementResistPercent);
         param1.writeVarShort(this.fireElementResistPercent);
         param1.writeVarShort(this.neutralElementReduction);
         param1.writeVarShort(this.earthElementReduction);
         param1.writeVarShort(this.waterElementReduction);
         param1.writeVarShort(this.airElementReduction);
         param1.writeVarShort(this.fireElementReduction);
         param1.writeVarShort(this.criticalDamageFixedResist);
         param1.writeVarShort(this.pushDamageFixedResist);
         param1.writeVarShort(this.pvpNeutralElementResistPercent);
         param1.writeVarShort(this.pvpEarthElementResistPercent);
         param1.writeVarShort(this.pvpWaterElementResistPercent);
         param1.writeVarShort(this.pvpAirElementResistPercent);
         param1.writeVarShort(this.pvpFireElementResistPercent);
         param1.writeVarShort(this.pvpNeutralElementReduction);
         param1.writeVarShort(this.pvpEarthElementReduction);
         param1.writeVarShort(this.pvpWaterElementReduction);
         param1.writeVarShort(this.pvpAirElementReduction);
         param1.writeVarShort(this.pvpFireElementReduction);
         if(this.dodgePALostProbability < 0)
         {
            throw new Error("Forbidden value (" + this.dodgePALostProbability + ") on element dodgePALostProbability.");
         }
         param1.writeVarShort(this.dodgePALostProbability);
         if(this.dodgePMLostProbability < 0)
         {
            throw new Error("Forbidden value (" + this.dodgePMLostProbability + ") on element dodgePMLostProbability.");
         }
         param1.writeVarShort(this.dodgePMLostProbability);
         param1.writeVarShort(this.tackleBlock);
         param1.writeVarShort(this.tackleEvade);
         param1.writeVarShort(this.fixedDamageReflection);
         param1.writeByte(this.invisibilityState);
         if(this.meleeDamageReceivedPercent < 0)
         {
            throw new Error("Forbidden value (" + this.meleeDamageReceivedPercent + ") on element meleeDamageReceivedPercent.");
         }
         param1.writeVarShort(this.meleeDamageReceivedPercent);
         if(this.rangedDamageReceivedPercent < 0)
         {
            throw new Error("Forbidden value (" + this.rangedDamageReceivedPercent + ") on element rangedDamageReceivedPercent.");
         }
         param1.writeVarShort(this.rangedDamageReceivedPercent);
         if(this.weaponDamageReceivedPercent < 0)
         {
            throw new Error("Forbidden value (" + this.weaponDamageReceivedPercent + ") on element weaponDamageReceivedPercent.");
         }
         param1.writeVarShort(this.weaponDamageReceivedPercent);
         if(this.spellDamageReceivedPercent < 0)
         {
            throw new Error("Forbidden value (" + this.spellDamageReceivedPercent + ") on element spellDamageReceivedPercent.");
         }
         param1.writeVarShort(this.spellDamageReceivedPercent);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightMinimalStats(param1);
      }
      
      public function deserializeAs_GameFightMinimalStats(param1:ICustomDataInput) : void
      {
         this._lifePointsFunc(param1);
         this._maxLifePointsFunc(param1);
         this._baseMaxLifePointsFunc(param1);
         this._permanentDamagePercentFunc(param1);
         this._shieldPointsFunc(param1);
         this._actionPointsFunc(param1);
         this._maxActionPointsFunc(param1);
         this._movementPointsFunc(param1);
         this._maxMovementPointsFunc(param1);
         this._summonerFunc(param1);
         this._summonedFunc(param1);
         this._neutralElementResistPercentFunc(param1);
         this._earthElementResistPercentFunc(param1);
         this._waterElementResistPercentFunc(param1);
         this._airElementResistPercentFunc(param1);
         this._fireElementResistPercentFunc(param1);
         this._neutralElementReductionFunc(param1);
         this._earthElementReductionFunc(param1);
         this._waterElementReductionFunc(param1);
         this._airElementReductionFunc(param1);
         this._fireElementReductionFunc(param1);
         this._criticalDamageFixedResistFunc(param1);
         this._pushDamageFixedResistFunc(param1);
         this._pvpNeutralElementResistPercentFunc(param1);
         this._pvpEarthElementResistPercentFunc(param1);
         this._pvpWaterElementResistPercentFunc(param1);
         this._pvpAirElementResistPercentFunc(param1);
         this._pvpFireElementResistPercentFunc(param1);
         this._pvpNeutralElementReductionFunc(param1);
         this._pvpEarthElementReductionFunc(param1);
         this._pvpWaterElementReductionFunc(param1);
         this._pvpAirElementReductionFunc(param1);
         this._pvpFireElementReductionFunc(param1);
         this._dodgePALostProbabilityFunc(param1);
         this._dodgePMLostProbabilityFunc(param1);
         this._tackleBlockFunc(param1);
         this._tackleEvadeFunc(param1);
         this._fixedDamageReflectionFunc(param1);
         this._invisibilityStateFunc(param1);
         this._meleeDamageReceivedPercentFunc(param1);
         this._rangedDamageReceivedPercentFunc(param1);
         this._weaponDamageReceivedPercentFunc(param1);
         this._spellDamageReceivedPercentFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightMinimalStats(param1);
      }
      
      public function deserializeAsyncAs_GameFightMinimalStats(param1:FuncTree) : void
      {
         param1.addChild(this._lifePointsFunc);
         param1.addChild(this._maxLifePointsFunc);
         param1.addChild(this._baseMaxLifePointsFunc);
         param1.addChild(this._permanentDamagePercentFunc);
         param1.addChild(this._shieldPointsFunc);
         param1.addChild(this._actionPointsFunc);
         param1.addChild(this._maxActionPointsFunc);
         param1.addChild(this._movementPointsFunc);
         param1.addChild(this._maxMovementPointsFunc);
         param1.addChild(this._summonerFunc);
         param1.addChild(this._summonedFunc);
         param1.addChild(this._neutralElementResistPercentFunc);
         param1.addChild(this._earthElementResistPercentFunc);
         param1.addChild(this._waterElementResistPercentFunc);
         param1.addChild(this._airElementResistPercentFunc);
         param1.addChild(this._fireElementResistPercentFunc);
         param1.addChild(this._neutralElementReductionFunc);
         param1.addChild(this._earthElementReductionFunc);
         param1.addChild(this._waterElementReductionFunc);
         param1.addChild(this._airElementReductionFunc);
         param1.addChild(this._fireElementReductionFunc);
         param1.addChild(this._criticalDamageFixedResistFunc);
         param1.addChild(this._pushDamageFixedResistFunc);
         param1.addChild(this._pvpNeutralElementResistPercentFunc);
         param1.addChild(this._pvpEarthElementResistPercentFunc);
         param1.addChild(this._pvpWaterElementResistPercentFunc);
         param1.addChild(this._pvpAirElementResistPercentFunc);
         param1.addChild(this._pvpFireElementResistPercentFunc);
         param1.addChild(this._pvpNeutralElementReductionFunc);
         param1.addChild(this._pvpEarthElementReductionFunc);
         param1.addChild(this._pvpWaterElementReductionFunc);
         param1.addChild(this._pvpAirElementReductionFunc);
         param1.addChild(this._pvpFireElementReductionFunc);
         param1.addChild(this._dodgePALostProbabilityFunc);
         param1.addChild(this._dodgePMLostProbabilityFunc);
         param1.addChild(this._tackleBlockFunc);
         param1.addChild(this._tackleEvadeFunc);
         param1.addChild(this._fixedDamageReflectionFunc);
         param1.addChild(this._invisibilityStateFunc);
         param1.addChild(this._meleeDamageReceivedPercentFunc);
         param1.addChild(this._rangedDamageReceivedPercentFunc);
         param1.addChild(this._weaponDamageReceivedPercentFunc);
         param1.addChild(this._spellDamageReceivedPercentFunc);
      }
      
      private function _lifePointsFunc(param1:ICustomDataInput) : void
      {
         this.lifePoints = param1.readVarUhInt();
         if(this.lifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.lifePoints + ") on element of GameFightMinimalStats.lifePoints.");
         }
      }
      
      private function _maxLifePointsFunc(param1:ICustomDataInput) : void
      {
         this.maxLifePoints = param1.readVarUhInt();
         if(this.maxLifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.maxLifePoints + ") on element of GameFightMinimalStats.maxLifePoints.");
         }
      }
      
      private function _baseMaxLifePointsFunc(param1:ICustomDataInput) : void
      {
         this.baseMaxLifePoints = param1.readVarUhInt();
         if(this.baseMaxLifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.baseMaxLifePoints + ") on element of GameFightMinimalStats.baseMaxLifePoints.");
         }
      }
      
      private function _permanentDamagePercentFunc(param1:ICustomDataInput) : void
      {
         this.permanentDamagePercent = param1.readVarUhInt();
         if(this.permanentDamagePercent < 0)
         {
            throw new Error("Forbidden value (" + this.permanentDamagePercent + ") on element of GameFightMinimalStats.permanentDamagePercent.");
         }
      }
      
      private function _shieldPointsFunc(param1:ICustomDataInput) : void
      {
         this.shieldPoints = param1.readVarUhInt();
         if(this.shieldPoints < 0)
         {
            throw new Error("Forbidden value (" + this.shieldPoints + ") on element of GameFightMinimalStats.shieldPoints.");
         }
      }
      
      private function _actionPointsFunc(param1:ICustomDataInput) : void
      {
         this.actionPoints = param1.readVarShort();
      }
      
      private function _maxActionPointsFunc(param1:ICustomDataInput) : void
      {
         this.maxActionPoints = param1.readVarShort();
      }
      
      private function _movementPointsFunc(param1:ICustomDataInput) : void
      {
         this.movementPoints = param1.readVarShort();
      }
      
      private function _maxMovementPointsFunc(param1:ICustomDataInput) : void
      {
         this.maxMovementPoints = param1.readVarShort();
      }
      
      private function _summonerFunc(param1:ICustomDataInput) : void
      {
         this.summoner = param1.readDouble();
         if(this.summoner < -9007199254740990 || this.summoner > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.summoner + ") on element of GameFightMinimalStats.summoner.");
         }
      }
      
      private function _summonedFunc(param1:ICustomDataInput) : void
      {
         this.summoned = param1.readBoolean();
      }
      
      private function _neutralElementResistPercentFunc(param1:ICustomDataInput) : void
      {
         this.neutralElementResistPercent = param1.readVarShort();
      }
      
      private function _earthElementResistPercentFunc(param1:ICustomDataInput) : void
      {
         this.earthElementResistPercent = param1.readVarShort();
      }
      
      private function _waterElementResistPercentFunc(param1:ICustomDataInput) : void
      {
         this.waterElementResistPercent = param1.readVarShort();
      }
      
      private function _airElementResistPercentFunc(param1:ICustomDataInput) : void
      {
         this.airElementResistPercent = param1.readVarShort();
      }
      
      private function _fireElementResistPercentFunc(param1:ICustomDataInput) : void
      {
         this.fireElementResistPercent = param1.readVarShort();
      }
      
      private function _neutralElementReductionFunc(param1:ICustomDataInput) : void
      {
         this.neutralElementReduction = param1.readVarShort();
      }
      
      private function _earthElementReductionFunc(param1:ICustomDataInput) : void
      {
         this.earthElementReduction = param1.readVarShort();
      }
      
      private function _waterElementReductionFunc(param1:ICustomDataInput) : void
      {
         this.waterElementReduction = param1.readVarShort();
      }
      
      private function _airElementReductionFunc(param1:ICustomDataInput) : void
      {
         this.airElementReduction = param1.readVarShort();
      }
      
      private function _fireElementReductionFunc(param1:ICustomDataInput) : void
      {
         this.fireElementReduction = param1.readVarShort();
      }
      
      private function _criticalDamageFixedResistFunc(param1:ICustomDataInput) : void
      {
         this.criticalDamageFixedResist = param1.readVarShort();
      }
      
      private function _pushDamageFixedResistFunc(param1:ICustomDataInput) : void
      {
         this.pushDamageFixedResist = param1.readVarShort();
      }
      
      private function _pvpNeutralElementResistPercentFunc(param1:ICustomDataInput) : void
      {
         this.pvpNeutralElementResistPercent = param1.readVarShort();
      }
      
      private function _pvpEarthElementResistPercentFunc(param1:ICustomDataInput) : void
      {
         this.pvpEarthElementResistPercent = param1.readVarShort();
      }
      
      private function _pvpWaterElementResistPercentFunc(param1:ICustomDataInput) : void
      {
         this.pvpWaterElementResistPercent = param1.readVarShort();
      }
      
      private function _pvpAirElementResistPercentFunc(param1:ICustomDataInput) : void
      {
         this.pvpAirElementResistPercent = param1.readVarShort();
      }
      
      private function _pvpFireElementResistPercentFunc(param1:ICustomDataInput) : void
      {
         this.pvpFireElementResistPercent = param1.readVarShort();
      }
      
      private function _pvpNeutralElementReductionFunc(param1:ICustomDataInput) : void
      {
         this.pvpNeutralElementReduction = param1.readVarShort();
      }
      
      private function _pvpEarthElementReductionFunc(param1:ICustomDataInput) : void
      {
         this.pvpEarthElementReduction = param1.readVarShort();
      }
      
      private function _pvpWaterElementReductionFunc(param1:ICustomDataInput) : void
      {
         this.pvpWaterElementReduction = param1.readVarShort();
      }
      
      private function _pvpAirElementReductionFunc(param1:ICustomDataInput) : void
      {
         this.pvpAirElementReduction = param1.readVarShort();
      }
      
      private function _pvpFireElementReductionFunc(param1:ICustomDataInput) : void
      {
         this.pvpFireElementReduction = param1.readVarShort();
      }
      
      private function _dodgePALostProbabilityFunc(param1:ICustomDataInput) : void
      {
         this.dodgePALostProbability = param1.readVarUhShort();
         if(this.dodgePALostProbability < 0)
         {
            throw new Error("Forbidden value (" + this.dodgePALostProbability + ") on element of GameFightMinimalStats.dodgePALostProbability.");
         }
      }
      
      private function _dodgePMLostProbabilityFunc(param1:ICustomDataInput) : void
      {
         this.dodgePMLostProbability = param1.readVarUhShort();
         if(this.dodgePMLostProbability < 0)
         {
            throw new Error("Forbidden value (" + this.dodgePMLostProbability + ") on element of GameFightMinimalStats.dodgePMLostProbability.");
         }
      }
      
      private function _tackleBlockFunc(param1:ICustomDataInput) : void
      {
         this.tackleBlock = param1.readVarShort();
      }
      
      private function _tackleEvadeFunc(param1:ICustomDataInput) : void
      {
         this.tackleEvade = param1.readVarShort();
      }
      
      private function _fixedDamageReflectionFunc(param1:ICustomDataInput) : void
      {
         this.fixedDamageReflection = param1.readVarShort();
      }
      
      private function _invisibilityStateFunc(param1:ICustomDataInput) : void
      {
         this.invisibilityState = param1.readByte();
         if(this.invisibilityState < 0)
         {
            throw new Error("Forbidden value (" + this.invisibilityState + ") on element of GameFightMinimalStats.invisibilityState.");
         }
      }
      
      private function _meleeDamageReceivedPercentFunc(param1:ICustomDataInput) : void
      {
         this.meleeDamageReceivedPercent = param1.readVarUhShort();
         if(this.meleeDamageReceivedPercent < 0)
         {
            throw new Error("Forbidden value (" + this.meleeDamageReceivedPercent + ") on element of GameFightMinimalStats.meleeDamageReceivedPercent.");
         }
      }
      
      private function _rangedDamageReceivedPercentFunc(param1:ICustomDataInput) : void
      {
         this.rangedDamageReceivedPercent = param1.readVarUhShort();
         if(this.rangedDamageReceivedPercent < 0)
         {
            throw new Error("Forbidden value (" + this.rangedDamageReceivedPercent + ") on element of GameFightMinimalStats.rangedDamageReceivedPercent.");
         }
      }
      
      private function _weaponDamageReceivedPercentFunc(param1:ICustomDataInput) : void
      {
         this.weaponDamageReceivedPercent = param1.readVarUhShort();
         if(this.weaponDamageReceivedPercent < 0)
         {
            throw new Error("Forbidden value (" + this.weaponDamageReceivedPercent + ") on element of GameFightMinimalStats.weaponDamageReceivedPercent.");
         }
      }
      
      private function _spellDamageReceivedPercentFunc(param1:ICustomDataInput) : void
      {
         this.spellDamageReceivedPercent = param1.readVarUhShort();
         if(this.spellDamageReceivedPercent < 0)
         {
            throw new Error("Forbidden value (" + this.spellDamageReceivedPercent + ") on element of GameFightMinimalStats.spellDamageReceivedPercent.");
         }
      }
   }
}
