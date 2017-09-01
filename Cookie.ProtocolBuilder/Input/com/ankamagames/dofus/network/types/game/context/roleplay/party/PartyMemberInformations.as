package com.ankamagames.dofus.network.types.game.context.roleplay.party
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.character.choice.CharacterBaseInformations;
   import com.ankamagames.dofus.network.types.game.character.status.PlayerStatus;
   import com.ankamagames.dofus.network.types.game.context.roleplay.party.companion.PartyCompanionMemberInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class PartyMemberInformations extends CharacterBaseInformations implements INetworkType
   {
      
      public static const protocolId:uint = 90;
       
      
      public var lifePoints:uint = 0;
      
      public var maxLifePoints:uint = 0;
      
      public var prospecting:uint = 0;
      
      public var regenRate:uint = 0;
      
      public var initiative:uint = 0;
      
      public var alignmentSide:int = 0;
      
      public var worldX:int = 0;
      
      public var worldY:int = 0;
      
      public var mapId:int = 0;
      
      public var subAreaId:uint = 0;
      
      public var status:PlayerStatus;
      
      public var companions:Vector.<PartyCompanionMemberInformations>;
      
      private var _statustree:FuncTree;
      
      private var _companionstree:FuncTree;
      
      public function PartyMemberInformations()
      {
         this.status = new PlayerStatus();
         this.companions = new Vector.<PartyCompanionMemberInformations>();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 90;
      }
      
      public function initPartyMemberInformations(param1:Number = 0, param2:String = "", param3:uint = 0, param4:EntityLook = null, param5:int = 0, param6:Boolean = false, param7:uint = 0, param8:uint = 0, param9:uint = 0, param10:uint = 0, param11:uint = 0, param12:int = 0, param13:int = 0, param14:int = 0, param15:int = 0, param16:uint = 0, param17:PlayerStatus = null, param18:Vector.<PartyCompanionMemberInformations> = null) : PartyMemberInformations
      {
         super.initCharacterBaseInformations(param1,param2,param3,param4,param5,param6);
         this.lifePoints = param7;
         this.maxLifePoints = param8;
         this.prospecting = param9;
         this.regenRate = param10;
         this.initiative = param11;
         this.alignmentSide = param12;
         this.worldX = param13;
         this.worldY = param14;
         this.mapId = param15;
         this.subAreaId = param16;
         this.status = param17;
         this.companions = param18;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.lifePoints = 0;
         this.maxLifePoints = 0;
         this.prospecting = 0;
         this.regenRate = 0;
         this.initiative = 0;
         this.alignmentSide = 0;
         this.worldX = 0;
         this.worldY = 0;
         this.mapId = 0;
         this.subAreaId = 0;
         this.status = new PlayerStatus();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PartyMemberInformations(param1);
      }
      
      public function serializeAs_PartyMemberInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_CharacterBaseInformations(param1);
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
         if(this.initiative < 0)
         {
            throw new Error("Forbidden value (" + this.initiative + ") on element initiative.");
         }
         param1.writeVarShort(this.initiative);
         param1.writeByte(this.alignmentSide);
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element worldX.");
         }
         param1.writeShort(this.worldX);
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element worldY.");
         }
         param1.writeShort(this.worldY);
         param1.writeInt(this.mapId);
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element subAreaId.");
         }
         param1.writeVarShort(this.subAreaId);
         param1.writeShort(this.status.getTypeId());
         this.status.serialize(param1);
         param1.writeShort(this.companions.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.companions.length)
         {
            (this.companions[_loc2_] as PartyCompanionMemberInformations).serializeAs_PartyCompanionMemberInformations(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyMemberInformations(param1);
      }
      
      public function deserializeAs_PartyMemberInformations(param1:ICustomDataInput) : void
      {
         var _loc5_:PartyCompanionMemberInformations = null;
         super.deserialize(param1);
         this._lifePointsFunc(param1);
         this._maxLifePointsFunc(param1);
         this._prospectingFunc(param1);
         this._regenRateFunc(param1);
         this._initiativeFunc(param1);
         this._alignmentSideFunc(param1);
         this._worldXFunc(param1);
         this._worldYFunc(param1);
         this._mapIdFunc(param1);
         this._subAreaIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         this.status = ProtocolTypeManager.getInstance(PlayerStatus,_loc2_);
         this.status.deserialize(param1);
         var _loc3_:uint = param1.readUnsignedShort();
         var _loc4_:uint = 0;
         while(_loc4_ < _loc3_)
         {
            _loc5_ = new PartyCompanionMemberInformations();
            _loc5_.deserialize(param1);
            this.companions.push(_loc5_);
            _loc4_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyMemberInformations(param1);
      }
      
      public function deserializeAsyncAs_PartyMemberInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._lifePointsFunc);
         param1.addChild(this._maxLifePointsFunc);
         param1.addChild(this._prospectingFunc);
         param1.addChild(this._regenRateFunc);
         param1.addChild(this._initiativeFunc);
         param1.addChild(this._alignmentSideFunc);
         param1.addChild(this._worldXFunc);
         param1.addChild(this._worldYFunc);
         param1.addChild(this._mapIdFunc);
         param1.addChild(this._subAreaIdFunc);
         this._statustree = param1.addChild(this._statustreeFunc);
         this._companionstree = param1.addChild(this._companionstreeFunc);
      }
      
      private function _lifePointsFunc(param1:ICustomDataInput) : void
      {
         this.lifePoints = param1.readVarUhInt();
         if(this.lifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.lifePoints + ") on element of PartyMemberInformations.lifePoints.");
         }
      }
      
      private function _maxLifePointsFunc(param1:ICustomDataInput) : void
      {
         this.maxLifePoints = param1.readVarUhInt();
         if(this.maxLifePoints < 0)
         {
            throw new Error("Forbidden value (" + this.maxLifePoints + ") on element of PartyMemberInformations.maxLifePoints.");
         }
      }
      
      private function _prospectingFunc(param1:ICustomDataInput) : void
      {
         this.prospecting = param1.readVarUhShort();
         if(this.prospecting < 0)
         {
            throw new Error("Forbidden value (" + this.prospecting + ") on element of PartyMemberInformations.prospecting.");
         }
      }
      
      private function _regenRateFunc(param1:ICustomDataInput) : void
      {
         this.regenRate = param1.readUnsignedByte();
         if(this.regenRate < 0 || this.regenRate > 255)
         {
            throw new Error("Forbidden value (" + this.regenRate + ") on element of PartyMemberInformations.regenRate.");
         }
      }
      
      private function _initiativeFunc(param1:ICustomDataInput) : void
      {
         this.initiative = param1.readVarUhShort();
         if(this.initiative < 0)
         {
            throw new Error("Forbidden value (" + this.initiative + ") on element of PartyMemberInformations.initiative.");
         }
      }
      
      private function _alignmentSideFunc(param1:ICustomDataInput) : void
      {
         this.alignmentSide = param1.readByte();
      }
      
      private function _worldXFunc(param1:ICustomDataInput) : void
      {
         this.worldX = param1.readShort();
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element of PartyMemberInformations.worldX.");
         }
      }
      
      private function _worldYFunc(param1:ICustomDataInput) : void
      {
         this.worldY = param1.readShort();
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element of PartyMemberInformations.worldY.");
         }
      }
      
      private function _mapIdFunc(param1:ICustomDataInput) : void
      {
         this.mapId = param1.readInt();
      }
      
      private function _subAreaIdFunc(param1:ICustomDataInput) : void
      {
         this.subAreaId = param1.readVarUhShort();
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element of PartyMemberInformations.subAreaId.");
         }
      }
      
      private function _statustreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.status = ProtocolTypeManager.getInstance(PlayerStatus,_loc2_);
         this.status.deserializeAsync(this._statustree);
      }
      
      private function _companionstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._companionstree.addChild(this._companionsFunc);
            _loc3_++;
         }
      }
      
      private function _companionsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:PartyCompanionMemberInformations = new PartyCompanionMemberInformations();
         _loc2_.deserialize(param1);
         this.companions.push(_loc2_);
      }
   }
}
