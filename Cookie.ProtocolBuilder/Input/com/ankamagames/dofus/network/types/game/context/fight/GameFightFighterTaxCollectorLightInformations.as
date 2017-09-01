package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameFightFighterTaxCollectorLightInformations extends GameFightFighterLightInformations implements INetworkType
   {
      
      public static const protocolId:uint = 457;
       
      
      public var firstNameId:uint = 0;
      
      public var lastNameId:uint = 0;
      
      public function GameFightFighterTaxCollectorLightInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 457;
      }
      
      public function initGameFightFighterTaxCollectorLightInformations(param1:Number = 0, param2:uint = 0, param3:uint = 0, param4:int = 0, param5:Boolean = false, param6:Boolean = false, param7:uint = 0, param8:uint = 0) : GameFightFighterTaxCollectorLightInformations
      {
         super.initGameFightFighterLightInformations(param1,param2,param3,param4,param5,param6);
         this.firstNameId = param7;
         this.lastNameId = param8;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.firstNameId = 0;
         this.lastNameId = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameFightFighterTaxCollectorLightInformations(param1);
      }
      
      public function serializeAs_GameFightFighterTaxCollectorLightInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameFightFighterLightInformations(param1);
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
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightFighterTaxCollectorLightInformations(param1);
      }
      
      public function deserializeAs_GameFightFighterTaxCollectorLightInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._firstNameIdFunc(param1);
         this._lastNameIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightFighterTaxCollectorLightInformations(param1);
      }
      
      public function deserializeAsyncAs_GameFightFighterTaxCollectorLightInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._firstNameIdFunc);
         param1.addChild(this._lastNameIdFunc);
      }
      
      private function _firstNameIdFunc(param1:ICustomDataInput) : void
      {
         this.firstNameId = param1.readVarUhShort();
         if(this.firstNameId < 0)
         {
            throw new Error("Forbidden value (" + this.firstNameId + ") on element of GameFightFighterTaxCollectorLightInformations.firstNameId.");
         }
      }
      
      private function _lastNameIdFunc(param1:ICustomDataInput) : void
      {
         this.lastNameId = param1.readVarUhShort();
         if(this.lastNameId < 0)
         {
            throw new Error("Forbidden value (" + this.lastNameId + ") on element of GameFightFighterTaxCollectorLightInformations.lastNameId.");
         }
      }
   }
}
