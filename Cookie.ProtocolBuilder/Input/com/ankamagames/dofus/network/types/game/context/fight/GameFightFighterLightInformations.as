package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameFightFighterLightInformations implements INetworkType
   {
      
      public static const protocolId:uint = 413;
       
      
      public var id:Number = 0;
      
      public var wave:uint = 0;
      
      public var level:uint = 0;
      
      public var breed:int = 0;
      
      public var sex:Boolean = false;
      
      public var alive:Boolean = false;
      
      public function GameFightFighterLightInformations()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 413;
      }
      
      public function initGameFightFighterLightInformations(param1:Number = 0, param2:uint = 0, param3:uint = 0, param4:int = 0, param5:Boolean = false, param6:Boolean = false) : GameFightFighterLightInformations
      {
         this.id = param1;
         this.wave = param2;
         this.level = param3;
         this.breed = param4;
         this.sex = param5;
         this.alive = param6;
         return this;
      }
      
      public function reset() : void
      {
         this.id = 0;
         this.wave = 0;
         this.level = 0;
         this.breed = 0;
         this.sex = false;
         this.alive = false;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameFightFighterLightInformations(param1);
      }
      
      public function serializeAs_GameFightFighterLightInformations(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.sex);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.alive);
         param1.writeByte(_loc2_);
         if(this.id < -9007199254740990 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeDouble(this.id);
         if(this.wave < 0)
         {
            throw new Error("Forbidden value (" + this.wave + ") on element wave.");
         }
         param1.writeByte(this.wave);
         if(this.level < 0)
         {
            throw new Error("Forbidden value (" + this.level + ") on element level.");
         }
         param1.writeVarShort(this.level);
         param1.writeByte(this.breed);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightFighterLightInformations(param1);
      }
      
      public function deserializeAs_GameFightFighterLightInformations(param1:ICustomDataInput) : void
      {
         this.deserializeByteBoxes(param1);
         this._idFunc(param1);
         this._waveFunc(param1);
         this._levelFunc(param1);
         this._breedFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightFighterLightInformations(param1);
      }
      
      public function deserializeAsyncAs_GameFightFighterLightInformations(param1:FuncTree) : void
      {
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._idFunc);
         param1.addChild(this._waveFunc);
         param1.addChild(this._levelFunc);
         param1.addChild(this._breedFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.sex = BooleanByteWrapper.getFlag(_loc2_,0);
         this.alive = BooleanByteWrapper.getFlag(_loc2_,1);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readDouble();
         if(this.id < -9007199254740990 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of GameFightFighterLightInformations.id.");
         }
      }
      
      private function _waveFunc(param1:ICustomDataInput) : void
      {
         this.wave = param1.readByte();
         if(this.wave < 0)
         {
            throw new Error("Forbidden value (" + this.wave + ") on element of GameFightFighterLightInformations.wave.");
         }
      }
      
      private function _levelFunc(param1:ICustomDataInput) : void
      {
         this.level = param1.readVarUhShort();
         if(this.level < 0)
         {
            throw new Error("Forbidden value (" + this.level + ") on element of GameFightFighterLightInformations.level.");
         }
      }
      
      private function _breedFunc(param1:ICustomDataInput) : void
      {
         this.breed = param1.readByte();
      }
   }
}
