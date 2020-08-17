package com.ankamagames.dofus.network.types.game.actions.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class FightTemporarySpellImmunityEffect extends AbstractFightDispellableEffect implements INetworkType
   {
      
      public static const protocolId:uint = 366;
       
      
      public var immuneSpellId:int = 0;
      
      public function FightTemporarySpellImmunityEffect()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 366;
      }
      
      public function initFightTemporarySpellImmunityEffect(param1:uint = 0, param2:Number = 0, param3:int = 0, param4:uint = 1, param5:uint = 0, param6:uint = 0, param7:uint = 0, param8:int = 0) : FightTemporarySpellImmunityEffect
      {
         super.initAbstractFightDispellableEffect(param1,param2,param3,param4,param5,param6,param7);
         this.immuneSpellId = param8;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.immuneSpellId = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightTemporarySpellImmunityEffect(param1);
      }
      
      public function serializeAs_FightTemporarySpellImmunityEffect(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractFightDispellableEffect(param1);
         param1.writeInt(this.immuneSpellId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightTemporarySpellImmunityEffect(param1);
      }
      
      public function deserializeAs_FightTemporarySpellImmunityEffect(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._immuneSpellIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightTemporarySpellImmunityEffect(param1);
      }
      
      public function deserializeAsyncAs_FightTemporarySpellImmunityEffect(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._immuneSpellIdFunc);
      }
      
      private function _immuneSpellIdFunc(param1:ICustomDataInput) : void
      {
         this.immuneSpellId = param1.readInt();
      }
   }
}
