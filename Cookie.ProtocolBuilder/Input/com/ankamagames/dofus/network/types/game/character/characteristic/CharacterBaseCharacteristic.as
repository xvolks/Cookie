package com.ankamagames.dofus.network.types.game.character.characteristic
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class CharacterBaseCharacteristic implements INetworkType
   {
      
      public static const protocolId:uint = 4;
       
      
      public var base:int = 0;
      
      public var additionnal:int = 0;
      
      public var objectsAndMountBonus:int = 0;
      
      public var alignGiftBonus:int = 0;
      
      public var contextModif:int = 0;
      
      public function CharacterBaseCharacteristic()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 4;
      }
      
      public function initCharacterBaseCharacteristic(param1:int = 0, param2:int = 0, param3:int = 0, param4:int = 0, param5:int = 0) : CharacterBaseCharacteristic
      {
         this.base = param1;
         this.additionnal = param2;
         this.objectsAndMountBonus = param3;
         this.alignGiftBonus = param4;
         this.contextModif = param5;
         return this;
      }
      
      public function reset() : void
      {
         this.base = 0;
         this.additionnal = 0;
         this.objectsAndMountBonus = 0;
         this.alignGiftBonus = 0;
         this.contextModif = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_CharacterBaseCharacteristic(param1);
      }
      
      public function serializeAs_CharacterBaseCharacteristic(param1:ICustomDataOutput) : void
      {
         param1.writeVarShort(this.base);
         param1.writeVarShort(this.additionnal);
         param1.writeVarShort(this.objectsAndMountBonus);
         param1.writeVarShort(this.alignGiftBonus);
         param1.writeVarShort(this.contextModif);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterBaseCharacteristic(param1);
      }
      
      public function deserializeAs_CharacterBaseCharacteristic(param1:ICustomDataInput) : void
      {
         this._baseFunc(param1);
         this._additionnalFunc(param1);
         this._objectsAndMountBonusFunc(param1);
         this._alignGiftBonusFunc(param1);
         this._contextModifFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterBaseCharacteristic(param1);
      }
      
      public function deserializeAsyncAs_CharacterBaseCharacteristic(param1:FuncTree) : void
      {
         param1.addChild(this._baseFunc);
         param1.addChild(this._additionnalFunc);
         param1.addChild(this._objectsAndMountBonusFunc);
         param1.addChild(this._alignGiftBonusFunc);
         param1.addChild(this._contextModifFunc);
      }
      
      private function _baseFunc(param1:ICustomDataInput) : void
      {
         this.base = param1.readVarShort();
      }
      
      private function _additionnalFunc(param1:ICustomDataInput) : void
      {
         this.additionnal = param1.readVarShort();
      }
      
      private function _objectsAndMountBonusFunc(param1:ICustomDataInput) : void
      {
         this.objectsAndMountBonus = param1.readVarShort();
      }
      
      private function _alignGiftBonusFunc(param1:ICustomDataInput) : void
      {
         this.alignGiftBonus = param1.readVarShort();
      }
      
      private function _contextModifFunc(param1:ICustomDataInput) : void
      {
         this.contextModif = param1.readVarShort();
      }
   }
}
