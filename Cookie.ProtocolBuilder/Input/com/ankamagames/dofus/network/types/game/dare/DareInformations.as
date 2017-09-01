package com.ankamagames.dofus.network.types.game.dare
{
   import com.ankamagames.dofus.network.types.game.character.CharacterBasicMinimalInformations;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class DareInformations implements INetworkType
   {
      
      public static const protocolId:uint = 502;
       
      
      public var dareId:Number = 0;
      
      public var creator:CharacterBasicMinimalInformations;
      
      public var subscriptionFee:Number = 0;
      
      public var jackpot:Number = 0;
      
      public var maxCountWinners:uint = 0;
      
      public var endDate:Number = 0;
      
      public var isPrivate:Boolean = false;
      
      public var guildId:uint = 0;
      
      public var allianceId:uint = 0;
      
      public var criterions:Vector.<DareCriteria>;
      
      public var startDate:Number = 0;
      
      private var _creatortree:FuncTree;
      
      private var _criterionstree:FuncTree;
      
      public function DareInformations()
      {
         this.creator = new CharacterBasicMinimalInformations();
         this.criterions = new Vector.<DareCriteria>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 502;
      }
      
      public function initDareInformations(param1:Number = 0, param2:CharacterBasicMinimalInformations = null, param3:Number = 0, param4:Number = 0, param5:uint = 0, param6:Number = 0, param7:Boolean = false, param8:uint = 0, param9:uint = 0, param10:Vector.<DareCriteria> = null, param11:Number = 0) : DareInformations
      {
         this.dareId = param1;
         this.creator = param2;
         this.subscriptionFee = param3;
         this.jackpot = param4;
         this.maxCountWinners = param5;
         this.endDate = param6;
         this.isPrivate = param7;
         this.guildId = param8;
         this.allianceId = param9;
         this.criterions = param10;
         this.startDate = param11;
         return this;
      }
      
      public function reset() : void
      {
         this.dareId = 0;
         this.creator = new CharacterBasicMinimalInformations();
         this.jackpot = 0;
         this.maxCountWinners = 0;
         this.endDate = 0;
         this.isPrivate = false;
         this.guildId = 0;
         this.allianceId = 0;
         this.criterions = new Vector.<DareCriteria>();
         this.startDate = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_DareInformations(param1);
      }
      
      public function serializeAs_DareInformations(param1:ICustomDataOutput) : void
      {
         if(this.dareId < 0 || this.dareId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.dareId + ") on element dareId.");
         }
         param1.writeDouble(this.dareId);
         this.creator.serializeAs_CharacterBasicMinimalInformations(param1);
         if(this.subscriptionFee < 0 || this.subscriptionFee > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.subscriptionFee + ") on element subscriptionFee.");
         }
         param1.writeVarLong(this.subscriptionFee);
         if(this.jackpot < 0 || this.jackpot > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.jackpot + ") on element jackpot.");
         }
         param1.writeVarLong(this.jackpot);
         if(this.maxCountWinners < 0 || this.maxCountWinners > 65535)
         {
            throw new Error("Forbidden value (" + this.maxCountWinners + ") on element maxCountWinners.");
         }
         param1.writeShort(this.maxCountWinners);
         if(this.endDate < 0 || this.endDate > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.endDate + ") on element endDate.");
         }
         param1.writeDouble(this.endDate);
         param1.writeBoolean(this.isPrivate);
         if(this.guildId < 0)
         {
            throw new Error("Forbidden value (" + this.guildId + ") on element guildId.");
         }
         param1.writeVarInt(this.guildId);
         if(this.allianceId < 0)
         {
            throw new Error("Forbidden value (" + this.allianceId + ") on element allianceId.");
         }
         param1.writeVarInt(this.allianceId);
         param1.writeShort(this.criterions.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.criterions.length)
         {
            (this.criterions[_loc2_] as DareCriteria).serializeAs_DareCriteria(param1);
            _loc2_++;
         }
         if(this.startDate < 0 || this.startDate > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.startDate + ") on element startDate.");
         }
         param1.writeDouble(this.startDate);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DareInformations(param1);
      }
      
      public function deserializeAs_DareInformations(param1:ICustomDataInput) : void
      {
         var _loc4_:DareCriteria = null;
         this._dareIdFunc(param1);
         this.creator = new CharacterBasicMinimalInformations();
         this.creator.deserialize(param1);
         this._subscriptionFeeFunc(param1);
         this._jackpotFunc(param1);
         this._maxCountWinnersFunc(param1);
         this._endDateFunc(param1);
         this._isPrivateFunc(param1);
         this._guildIdFunc(param1);
         this._allianceIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new DareCriteria();
            _loc4_.deserialize(param1);
            this.criterions.push(_loc4_);
            _loc3_++;
         }
         this._startDateFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DareInformations(param1);
      }
      
      public function deserializeAsyncAs_DareInformations(param1:FuncTree) : void
      {
         param1.addChild(this._dareIdFunc);
         this._creatortree = param1.addChild(this._creatortreeFunc);
         param1.addChild(this._subscriptionFeeFunc);
         param1.addChild(this._jackpotFunc);
         param1.addChild(this._maxCountWinnersFunc);
         param1.addChild(this._endDateFunc);
         param1.addChild(this._isPrivateFunc);
         param1.addChild(this._guildIdFunc);
         param1.addChild(this._allianceIdFunc);
         this._criterionstree = param1.addChild(this._criterionstreeFunc);
         param1.addChild(this._startDateFunc);
      }
      
      private function _dareIdFunc(param1:ICustomDataInput) : void
      {
         this.dareId = param1.readDouble();
         if(this.dareId < 0 || this.dareId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.dareId + ") on element of DareInformations.dareId.");
         }
      }
      
      private function _creatortreeFunc(param1:ICustomDataInput) : void
      {
         this.creator = new CharacterBasicMinimalInformations();
         this.creator.deserializeAsync(this._creatortree);
      }
      
      private function _subscriptionFeeFunc(param1:ICustomDataInput) : void
      {
         this.subscriptionFee = param1.readVarUhLong();
         if(this.subscriptionFee < 0 || this.subscriptionFee > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.subscriptionFee + ") on element of DareInformations.subscriptionFee.");
         }
      }
      
      private function _jackpotFunc(param1:ICustomDataInput) : void
      {
         this.jackpot = param1.readVarUhLong();
         if(this.jackpot < 0 || this.jackpot > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.jackpot + ") on element of DareInformations.jackpot.");
         }
      }
      
      private function _maxCountWinnersFunc(param1:ICustomDataInput) : void
      {
         this.maxCountWinners = param1.readUnsignedShort();
         if(this.maxCountWinners < 0 || this.maxCountWinners > 65535)
         {
            throw new Error("Forbidden value (" + this.maxCountWinners + ") on element of DareInformations.maxCountWinners.");
         }
      }
      
      private function _endDateFunc(param1:ICustomDataInput) : void
      {
         this.endDate = param1.readDouble();
         if(this.endDate < 0 || this.endDate > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.endDate + ") on element of DareInformations.endDate.");
         }
      }
      
      private function _isPrivateFunc(param1:ICustomDataInput) : void
      {
         this.isPrivate = param1.readBoolean();
      }
      
      private function _guildIdFunc(param1:ICustomDataInput) : void
      {
         this.guildId = param1.readVarUhInt();
         if(this.guildId < 0)
         {
            throw new Error("Forbidden value (" + this.guildId + ") on element of DareInformations.guildId.");
         }
      }
      
      private function _allianceIdFunc(param1:ICustomDataInput) : void
      {
         this.allianceId = param1.readVarUhInt();
         if(this.allianceId < 0)
         {
            throw new Error("Forbidden value (" + this.allianceId + ") on element of DareInformations.allianceId.");
         }
      }
      
      private function _criterionstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._criterionstree.addChild(this._criterionsFunc);
            _loc3_++;
         }
      }
      
      private function _criterionsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:DareCriteria = new DareCriteria();
         _loc2_.deserialize(param1);
         this.criterions.push(_loc2_);
      }
      
      private function _startDateFunc(param1:ICustomDataInput) : void
      {
         this.startDate = param1.readDouble();
         if(this.startDate < 0 || this.startDate > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.startDate + ") on element of DareInformations.startDate.");
         }
      }
   }
}
