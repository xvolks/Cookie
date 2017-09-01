package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FightCommonInformations implements INetworkType
   {
      
      public static const protocolId:uint = 43;
       
      
      public var fightId:int = 0;
      
      public var fightType:uint = 0;
      
      public var fightTeams:Vector.<FightTeamInformations>;
      
      public var fightTeamsPositions:Vector.<uint>;
      
      public var fightTeamsOptions:Vector.<FightOptionsInformations>;
      
      private var _fightTeamstree:FuncTree;
      
      private var _fightTeamsPositionstree:FuncTree;
      
      private var _fightTeamsOptionstree:FuncTree;
      
      public function FightCommonInformations()
      {
         this.fightTeams = new Vector.<FightTeamInformations>();
         this.fightTeamsPositions = new Vector.<uint>();
         this.fightTeamsOptions = new Vector.<FightOptionsInformations>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 43;
      }
      
      public function initFightCommonInformations(param1:int = 0, param2:uint = 0, param3:Vector.<FightTeamInformations> = null, param4:Vector.<uint> = null, param5:Vector.<FightOptionsInformations> = null) : FightCommonInformations
      {
         this.fightId = param1;
         this.fightType = param2;
         this.fightTeams = param3;
         this.fightTeamsPositions = param4;
         this.fightTeamsOptions = param5;
         return this;
      }
      
      public function reset() : void
      {
         this.fightId = 0;
         this.fightType = 0;
         this.fightTeams = new Vector.<FightTeamInformations>();
         this.fightTeamsPositions = new Vector.<uint>();
         this.fightTeamsOptions = new Vector.<FightOptionsInformations>();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightCommonInformations(param1);
      }
      
      public function serializeAs_FightCommonInformations(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.fightId);
         param1.writeByte(this.fightType);
         param1.writeShort(this.fightTeams.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.fightTeams.length)
         {
            param1.writeShort((this.fightTeams[_loc2_] as FightTeamInformations).getTypeId());
            (this.fightTeams[_loc2_] as FightTeamInformations).serialize(param1);
            _loc2_++;
         }
         param1.writeShort(this.fightTeamsPositions.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.fightTeamsPositions.length)
         {
            if(this.fightTeamsPositions[_loc3_] < 0 || this.fightTeamsPositions[_loc3_] > 559)
            {
               throw new Error("Forbidden value (" + this.fightTeamsPositions[_loc3_] + ") on element 4 (starting at 1) of fightTeamsPositions.");
            }
            param1.writeVarShort(this.fightTeamsPositions[_loc3_]);
            _loc3_++;
         }
         param1.writeShort(this.fightTeamsOptions.length);
         var _loc4_:uint = 0;
         while(_loc4_ < this.fightTeamsOptions.length)
         {
            (this.fightTeamsOptions[_loc4_] as FightOptionsInformations).serializeAs_FightOptionsInformations(param1);
            _loc4_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightCommonInformations(param1);
      }
      
      public function deserializeAs_FightCommonInformations(param1:ICustomDataInput) : void
      {
         var _loc8_:uint = 0;
         var _loc9_:FightTeamInformations = null;
         var _loc10_:uint = 0;
         var _loc11_:FightOptionsInformations = null;
         this._fightIdFunc(param1);
         this._fightTypeFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc8_ = param1.readUnsignedShort();
            _loc9_ = ProtocolTypeManager.getInstance(FightTeamInformations,_loc8_);
            _loc9_.deserialize(param1);
            this.fightTeams.push(_loc9_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc10_ = param1.readVarUhShort();
            if(_loc10_ < 0 || _loc10_ > 559)
            {
               throw new Error("Forbidden value (" + _loc10_ + ") on elements of fightTeamsPositions.");
            }
            this.fightTeamsPositions.push(_loc10_);
            _loc5_++;
         }
         var _loc6_:uint = param1.readUnsignedShort();
         var _loc7_:uint = 0;
         while(_loc7_ < _loc6_)
         {
            _loc11_ = new FightOptionsInformations();
            _loc11_.deserialize(param1);
            this.fightTeamsOptions.push(_loc11_);
            _loc7_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightCommonInformations(param1);
      }
      
      public function deserializeAsyncAs_FightCommonInformations(param1:FuncTree) : void
      {
         param1.addChild(this._fightIdFunc);
         param1.addChild(this._fightTypeFunc);
         this._fightTeamstree = param1.addChild(this._fightTeamstreeFunc);
         this._fightTeamsPositionstree = param1.addChild(this._fightTeamsPositionstreeFunc);
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
            throw new Error("Forbidden value (" + this.fightType + ") on element of FightCommonInformations.fightType.");
         }
      }
      
      private function _fightTeamstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._fightTeamstree.addChild(this._fightTeamsFunc);
            _loc3_++;
         }
      }
      
      private function _fightTeamsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:FightTeamInformations = ProtocolTypeManager.getInstance(FightTeamInformations,_loc2_);
         _loc3_.deserialize(param1);
         this.fightTeams.push(_loc3_);
      }
      
      private function _fightTeamsPositionstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._fightTeamsPositionstree.addChild(this._fightTeamsPositionsFunc);
            _loc3_++;
         }
      }
      
      private function _fightTeamsPositionsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0 || _loc2_ > 559)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of fightTeamsPositions.");
         }
         this.fightTeamsPositions.push(_loc2_);
      }
      
      private function _fightTeamsOptionstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._fightTeamsOptionstree.addChild(this._fightTeamsOptionsFunc);
            _loc3_++;
         }
      }
      
      private function _fightTeamsOptionsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:FightOptionsInformations = new FightOptionsInformations();
         _loc2_.deserialize(param1);
         this.fightTeamsOptions.push(_loc2_);
      }
   }
}
