package com.ankamagames.dofus.network.types.game.action.fight
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.actions.fight.AbstractFightDispellableEffect;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class FightDispellableEffectExtendedInformations implements INetworkType
   {
      
      public static const protocolId:uint = 208;
       
      
      public var actionId:uint = 0;
      
      public var sourceId:Number = 0;
      
      public var effect:AbstractFightDispellableEffect;
      
      private var _effecttree:FuncTree;
      
      public function FightDispellableEffectExtendedInformations()
      {
         this.effect = new AbstractFightDispellableEffect();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 208;
      }
      
      public function initFightDispellableEffectExtendedInformations(param1:uint = 0, param2:Number = 0, param3:AbstractFightDispellableEffect = null) : FightDispellableEffectExtendedInformations
      {
         this.actionId = param1;
         this.sourceId = param2;
         this.effect = param3;
         return this;
      }
      
      public function reset() : void
      {
         this.actionId = 0;
         this.sourceId = 0;
         this.effect = new AbstractFightDispellableEffect();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightDispellableEffectExtendedInformations(param1);
      }
      
      public function serializeAs_FightDispellableEffectExtendedInformations(param1:ICustomDataOutput) : void
      {
         if(this.actionId < 0)
         {
            throw new Error("Forbidden value (" + this.actionId + ") on element actionId.");
         }
         param1.writeVarShort(this.actionId);
         if(this.sourceId < -9007199254740990 || this.sourceId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.sourceId + ") on element sourceId.");
         }
         param1.writeDouble(this.sourceId);
         param1.writeShort(this.effect.getTypeId());
         this.effect.serialize(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightDispellableEffectExtendedInformations(param1);
      }
      
      public function deserializeAs_FightDispellableEffectExtendedInformations(param1:ICustomDataInput) : void
      {
         this._actionIdFunc(param1);
         this._sourceIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         this.effect = ProtocolTypeManager.getInstance(AbstractFightDispellableEffect,_loc2_);
         this.effect.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightDispellableEffectExtendedInformations(param1);
      }
      
      public function deserializeAsyncAs_FightDispellableEffectExtendedInformations(param1:FuncTree) : void
      {
         param1.addChild(this._actionIdFunc);
         param1.addChild(this._sourceIdFunc);
         this._effecttree = param1.addChild(this._effecttreeFunc);
      }
      
      private function _actionIdFunc(param1:ICustomDataInput) : void
      {
         this.actionId = param1.readVarUhShort();
         if(this.actionId < 0)
         {
            throw new Error("Forbidden value (" + this.actionId + ") on element of FightDispellableEffectExtendedInformations.actionId.");
         }
      }
      
      private function _sourceIdFunc(param1:ICustomDataInput) : void
      {
         this.sourceId = param1.readDouble();
         if(this.sourceId < -9007199254740990 || this.sourceId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.sourceId + ") on element of FightDispellableEffectExtendedInformations.sourceId.");
         }
      }
      
      private function _effecttreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.effect = ProtocolTypeManager.getInstance(AbstractFightDispellableEffect,_loc2_);
         this.effect.deserializeAsync(this._effecttree);
      }
   }
}
