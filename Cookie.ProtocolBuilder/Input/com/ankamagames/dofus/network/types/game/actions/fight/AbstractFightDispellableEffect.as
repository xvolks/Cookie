package com.ankamagames.dofus.network.types.game.actions.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class AbstractFightDispellableEffect implements INetworkType
   {
      
      public static const protocolId:uint = 206;
       
      
      public var uid:uint = 0;
      
      public var targetId:Number = 0;
      
      public var turnDuration:int = 0;
      
      public var dispelable:uint = 1;
      
      public var spellId:uint = 0;
      
      public var effectId:uint = 0;
      
      public var parentBoostUid:uint = 0;
      
      public function AbstractFightDispellableEffect()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 206;
      }
      
      public function initAbstractFightDispellableEffect(param1:uint = 0, param2:Number = 0, param3:int = 0, param4:uint = 1, param5:uint = 0, param6:uint = 0, param7:uint = 0) : AbstractFightDispellableEffect
      {
         this.uid = param1;
         this.targetId = param2;
         this.turnDuration = param3;
         this.dispelable = param4;
         this.spellId = param5;
         this.effectId = param6;
         this.parentBoostUid = param7;
         return this;
      }
      
      public function reset() : void
      {
         this.uid = 0;
         this.targetId = 0;
         this.turnDuration = 0;
         this.dispelable = 1;
         this.spellId = 0;
         this.effectId = 0;
         this.parentBoostUid = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AbstractFightDispellableEffect(param1);
      }
      
      public function serializeAs_AbstractFightDispellableEffect(param1:ICustomDataOutput) : void
      {
         if(this.uid < 0)
         {
            throw new Error("Forbidden value (" + this.uid + ") on element uid.");
         }
         param1.writeVarInt(this.uid);
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element targetId.");
         }
         param1.writeDouble(this.targetId);
         param1.writeShort(this.turnDuration);
         param1.writeByte(this.dispelable);
         if(this.spellId < 0)
         {
            throw new Error("Forbidden value (" + this.spellId + ") on element spellId.");
         }
         param1.writeVarShort(this.spellId);
         if(this.effectId < 0)
         {
            throw new Error("Forbidden value (" + this.effectId + ") on element effectId.");
         }
         param1.writeVarInt(this.effectId);
         if(this.parentBoostUid < 0)
         {
            throw new Error("Forbidden value (" + this.parentBoostUid + ") on element parentBoostUid.");
         }
         param1.writeVarInt(this.parentBoostUid);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AbstractFightDispellableEffect(param1);
      }
      
      public function deserializeAs_AbstractFightDispellableEffect(param1:ICustomDataInput) : void
      {
         this._uidFunc(param1);
         this._targetIdFunc(param1);
         this._turnDurationFunc(param1);
         this._dispelableFunc(param1);
         this._spellIdFunc(param1);
         this._effectIdFunc(param1);
         this._parentBoostUidFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AbstractFightDispellableEffect(param1);
      }
      
      public function deserializeAsyncAs_AbstractFightDispellableEffect(param1:FuncTree) : void
      {
         param1.addChild(this._uidFunc);
         param1.addChild(this._targetIdFunc);
         param1.addChild(this._turnDurationFunc);
         param1.addChild(this._dispelableFunc);
         param1.addChild(this._spellIdFunc);
         param1.addChild(this._effectIdFunc);
         param1.addChild(this._parentBoostUidFunc);
      }
      
      private function _uidFunc(param1:ICustomDataInput) : void
      {
         this.uid = param1.readVarUhInt();
         if(this.uid < 0)
         {
            throw new Error("Forbidden value (" + this.uid + ") on element of AbstractFightDispellableEffect.uid.");
         }
      }
      
      private function _targetIdFunc(param1:ICustomDataInput) : void
      {
         this.targetId = param1.readDouble();
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element of AbstractFightDispellableEffect.targetId.");
         }
      }
      
      private function _turnDurationFunc(param1:ICustomDataInput) : void
      {
         this.turnDuration = param1.readShort();
      }
      
      private function _dispelableFunc(param1:ICustomDataInput) : void
      {
         this.dispelable = param1.readByte();
         if(this.dispelable < 0)
         {
            throw new Error("Forbidden value (" + this.dispelable + ") on element of AbstractFightDispellableEffect.dispelable.");
         }
      }
      
      private function _spellIdFunc(param1:ICustomDataInput) : void
      {
         this.spellId = param1.readVarUhShort();
         if(this.spellId < 0)
         {
            throw new Error("Forbidden value (" + this.spellId + ") on element of AbstractFightDispellableEffect.spellId.");
         }
      }
      
      private function _effectIdFunc(param1:ICustomDataInput) : void
      {
         this.effectId = param1.readVarUhInt();
         if(this.effectId < 0)
         {
            throw new Error("Forbidden value (" + this.effectId + ") on element of AbstractFightDispellableEffect.effectId.");
         }
      }
      
      private function _parentBoostUidFunc(param1:ICustomDataInput) : void
      {
         this.parentBoostUid = param1.readVarUhInt();
         if(this.parentBoostUid < 0)
         {
            throw new Error("Forbidden value (" + this.parentBoostUid + ") on element of AbstractFightDispellableEffect.parentBoostUid.");
         }
      }
   }
}
